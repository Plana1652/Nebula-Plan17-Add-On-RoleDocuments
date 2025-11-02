using Nebula.Modules;
using Nebula.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virial;
using Virial.Attributes;
using Virial.Compat;
using Virial.Media;
using Virial.Runtime;

namespace Plana.Documents;

[AddonDocument("role.knight", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.soulrefiner", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.ninja", RoleType.Role, (string[])[], false, true)]
//[AddonDocument("role.lovemesseger", RoleType.Role, (string[])["LMButton.png;role.lovemesseger.ability.love"], false, true)]
[AddonDocument("role.shifter", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.engineer", RoleType.Role, (string[])[], false, true)]
//[AddonDocument("role.SpeechEater", RoleType.Role, (string[])["Silent.png;role.SpeechEater.ability.eaterR"], false, true)]
[AddonDocument("role.firstdead", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.madmateplus", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.mini", RoleType.Modifier, (string[])[], false, true)]
//[AddonDocument("role.knighted", RoleType.Role, (string[])[";"], true, false)]
[AddonDocument("role.tunny", RoleType.Role, (string[])[], true, true)]
[AddonDocument("role.yandere", RoleType.Role, (string[])[], true, true)]
[AddonDocument("role.evilAce", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.ferryman", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.insomniacs", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.insomniacsM", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.dreamweaver", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.dreamweaverM", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.scrambler", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.seluch", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.vip", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.speedster", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.infected", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.chameleon", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.baitM", RoleType.Modifier, (string[])[], false, true)]
[AddonDocument("role.gamemaster", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.sommelier", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.SchrodingerCat", RoleType.Role, (string[])[], true, true)]
[AddonDocument("role.skinner", RoleType.Role, (string[])[], true, true)]
[AddonDocument("role.skinnerdog", RoleType.Modifier, (string[])[], true, true)]
[AddonDocument("role.celestialdog", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.outlawLeaderShower", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.outlawLeader", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.assistant", RoleType.Role, (string[])[], false, true)]
[AddonDocument("role.dunner", RoleType.Role, (string[])[], false, true)]
public class StandardDocument : IDocumentWithId
{
    string documentId;
    bool withTips;
    bool withWinCond;
    string[][] abilityContents;
    RoleType roleType;
    public StandardDocument(RoleType roleType, string[] abilityContents, bool withWinCond, bool withTips)
    {
        this.roleType = roleType;
        this.withTips = withTips;
        this.withWinCond = withWinCond;
        this.abilityContents = abilityContents.Select(str => str.Split()).ToArray();
    }

    void IDocumentWithId.OnSetId(string documentId) { 
        this.documentId = documentId;
    }

    Virial.Media.GUIWidget? IDocument.Build(Artifact<GUIScreen>? target)
    {
        var gui = NebulaAPI.GUI;
        return
            RoleDocumentHelper.GetAssignableWidget(roleType, documentId.Split('.', 2).Last(),
            withWinCond ? RoleDocumentHelper.GetWinCondChapter(documentId) : null,
            abilityContents.Length > 0 ? RoleDocumentHelper.GetChapter($"{documentId}.ability", [
                RoleDocumentHelper.GetDocumentLocalizedText($"{documentId}.ability.main"),
                ..abilityContents.Select(c => RoleDocumentHelper.GetImageLocalizedContent(c[0], c[1])),
                ]) : null,
            withTips ? RoleDocumentHelper.GetTipsChapter(documentId) : null,
            RoleDocumentHelper.GetConfigurationCaption()
            );
    }
}

public abstract class AbstractAssignableDocument : IDocumentWithId
{
    public string DocumentId { get; private set; }
    void IDocumentWithId.OnSetId(string documentId) => DocumentId = documentId;

    public virtual bool WithWinCond => false;
    public virtual GUIWidget GetCustomWinCondWidget() => RoleDocumentHelper.GetWinCondChapter(DocumentId);
    public virtual GUIWidget? GetTipsWidget() => null;
    public virtual IEnumerable<GUIWidget> GetAbilityWidget() { yield break; }
    public abstract RoleType RoleType { get; }
    public virtual string BuildAbilityText(string original) => original;
    Virial.Media.GUIWidget? IDocument.Build(Artifact<GUIScreen>? target)
    {
        var tipsWidget = GetTipsWidget();
        var abilityWidget = GetAbilityWidget().ToArray();
        var gui = NebulaAPI.GUI;
        return
            RoleDocumentHelper.GetAssignableWidget(RoleType, DocumentId.Split('.', 2).Last(),
            WithWinCond ? GetCustomWinCondWidget() : null,
            abilityWidget.Length > 0 ? RoleDocumentHelper.GetChapter($"{DocumentId}.ability", [
                RoleDocumentHelper.GetDocumentLocalizedText($"{DocumentId}.ability.main", BuildAbilityText),
                ..abilityWidget,
                ]) : null,
            tipsWidget != null ? RoleDocumentHelper.GetChapter("document.tips", [tipsWidget]) : null,
            RoleDocumentHelper.GetConfigurationCaption()
            );
    }
}

[NebulaPreprocess(Virial.Attributes.PreprocessPhase.FixStructure)]
public class DocumentLoader
{
    public static void Preprocess(NebulaPreprocessor preprocess)
    {
        foreach(var r in Nebula.Roles.Roles.AllRoles)
        {
            if (DocumentManager.GetDocument("role." + r.InternalName) == null)
            {
                var doc = new StandardDocument(RoleType.Role, [], false, false);
                (doc as IDocumentWithId).OnSetId("role." + r.InternalName);
                DocumentManager.Register("role." + r.InternalName, doc);
            }
        }
        foreach (var r in Nebula.Roles.Roles.AllModifiers)
        {
            if (DocumentManager.GetDocument("role." + r.InternalName) == null)
            {
                var doc = new StandardDocument(RoleType.Modifier, [], false, false);
                (doc as IDocumentWithId).OnSetId("role." + r.InternalName);
                DocumentManager.Register("role." + r.InternalName, doc);
            }
        }
        foreach (var r in Nebula.Roles.Roles.AllGhostRoles)
        {
            if (DocumentManager.GetDocument("role." + r.InternalName) == null)
            {
                var doc = new StandardDocument(RoleType.GhostRole, [], false, false);
                (doc as IDocumentWithId).OnSetId("role." + r.InternalName);
                DocumentManager.Register("role." + r.InternalName, doc);
            }
        }
    }
}