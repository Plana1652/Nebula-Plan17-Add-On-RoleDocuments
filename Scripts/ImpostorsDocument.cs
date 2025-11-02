using Virial.Attributes;
using Virial.Compat;
using Virial.Media;
using Virial;
using Virial.Assignable;
using Nebula.Roles;
using Nebula.Player;
using System.Collections.Generic;
using Virial.Text;
using Virial.Helpers;
using Nebula.Modules.GUIWidget;
using System;
using Nebula.Modules;
using Nebula.Utilities;
using System.Linq;
using Nebula.Player;
using Nebula.Configuration;
using Nebula;

namespace Plana.Documents;

[AddonDocument("role.crawlerengineer")]
public class CrawlerengineerDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        return RoleDocumentHelper.GetDocumentLocalizedText(DocumentId + ".tips");
    }

    public override string BuildAbilityText(string original)
    {
        var haswatching = RoleDocumentHelper.ConfigBool("role.crawlerengineer.haswatching", "role.crawlerengineer.ability.haswatching", "role.crawlerengineer.ability.nowatching");
        var nocamouflager = RoleDocumentHelper.ConfigBool("role.crawlerengineer.nocamouflager", "role.crawlerengineer.ability.nocamouflager", "role.crawlerengineer.ability.camouflager");
        return original.Replace("#NOc", nocamouflager).Replace("#HASw", haswatching);

    }
        public override IEnumerable<GUIWidget> GetAbilityWidget()
    {
        yield return RoleDocumentHelper.GetImageLocalizedContent("Map.png", "role.crawlerengineer.ability.MAP");
        yield return RoleDocumentHelper.GetImageLocalizedContent("CrawlerMeetingSkill.png", "role.crawlerengineer.ability.CMK");
    }
    public override RoleType RoleType => RoleType.Role;
}

[AddonDocument("role.crow")]
public class CrowDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        return RoleDocumentHelper.GetDocumentLocalizedText(DocumentId + ".tips");
    }

    public override string BuildAbilityText(string original)
    {   var activeexilemessage = RoleDocumentHelper.ConfigBool("options.role.crow.activeexilemessage" , "role.crow.ability.activeexilemessage", "role.crow.ability.exilemessage");
        var otherimpcanseeexile = RoleDocumentHelper.ConfigBool("options.role.crow.otherimpcanseeexile", "role.crow.ability.otherimpcanseeexile", "role.crow.ability.cannotsee");
        return original.Replace("#AEM", activeexilemessage).Replace("#OICS", otherimpcanseeexile);
    }

    public override IEnumerable<GUIWidget> GetAbilityWidget()
    {
        yield return RoleDocumentHelper.GetImageLocalizedContent("Mark.png", "role.crow.ability.mark");
        yield return RoleDocumentHelper.GetImageLocalizedContent("Teleport.png", "role.crow.ability.teleport");
                var otherimpblock = RoleDocumentHelper.ConfigBool("options.role.crow.otherimpblock", "role.crow.ability.otherimpblock", "role.crow.ability.noblock");
        var useskillotherimpcansee = RoleDocumentHelper.ConfigBool("options.role.crow.useskillotherimpcansee", "role.crow.ability.useskillotherimpcansee", "role.crow.ability.nouse");
        yield return RoleDocumentHelper.GetImageLocalizedContent("Envelop.png", "role.crow.ability.envelop",str=>str.Replace("#OIB", otherimpblock).Replace("#UKI", useskillotherimpcansee));
    }
    public override RoleType RoleType => RoleType.Role;
}

[AddonDocument("role.speechEater")]
public class SpeechEaterDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        return RoleDocumentHelper.GetDocumentLocalizedText(DocumentId + ".tips");
    }

    public override string BuildAbilityText(string original)
    {
        var crewmate = RoleDocumentHelper.ConfigBool("options.role.speecheater.crewmate", "role.SpeechEater.ability.crewmate", "role.SpeechEater.ability.nocrewmate");
        var neutral = RoleDocumentHelper.ConfigBool("options.role.speecheater.neutral", "role.SpeechEater.ability.neutral", "role.SpeechEater.ability.noneutral");
        var impostor = RoleDocumentHelper.ConfigBool("options.role.speecheater.impostor", "role.SpeechEater.ability.impostor", "role.SpeechEater.ability.noimpostor");
        return original.Replace("#C", crewmate).Replace("#N", neutral).Replace("#I", impostor);

    }
    public override IEnumerable<GUIWidget> GetAbilityWidget()
    {
        var Eat = RoleDocumentHelper.Config<int>("options.role.speecheater.numOfEat");
        yield return RoleDocumentHelper.GetImageLocalizedContent("Silent.png", "role.SpeechEater.ability.eaterR", str => str.Replace("#NUM", Eat));

        //var meeting = RoleDocumentHelper.ConfigBool("options.role.SpeechEater.selectiveCollating", "role.SpeechEater.ability.meeting");
        //if(meeting.Length > 0) yield return RoleDocumentHelper.GetImageContent("CollatorIcon.png", meeting);
    }
    public override RoleType RoleType => RoleType.Role;
}
[AddonDocument("role.evilsplicer")]
public class EvilSplicerDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        return RoleDocumentHelper.GetDocumentLocalizedText(DocumentId + ".tips");
    }

    public override string BuildAbilityText(string original)
    {
        var hasnormalkill = RoleDocumentHelper.ConfigBool("options.role.splicer.hasnormalkill", "role.evilsplicer.ability.hasnormalkill", "role.evilsplicer.ability.nonormalkill");
        return original.Replace("#HNK", hasnormalkill);

    }
    public override IEnumerable<GUIWidget> GetAbilityWidget()
    {
        var leftmark = RoleDocumentHelper.ConfigBool("options.role.splicer.usewarpLeftMark", "role.nicesplicer.ability.leftmark", "role.nicesplicer.ability.noleftmark");
        var KillFailWarp = RoleDocumentHelper.ConfigBool("options.role.splicer.usewarpLeftMark", "role.evilsplicer.ability.killfailwarp", "role.evilsplicer.ability.nokillfailwarp");
        yield return RoleDocumentHelper.GetImageLocalizedContent("WarpButtonImpVer.png", "role.evilsplicer.ability.warp", str => str.Replace("#MARK", leftmark).Replace("#KFW", KillFailWarp));
    }
    public override RoleType RoleType => RoleType.Role;
}


/*[AddonDocument("role.cleaner")]
public class CleanerDocument : IDocument
{
    Virial.Media.GUIWidget? IDocument.Build(Artifact<GUIScreen>? target)
    {
        var gui = NebulaAPI.GUI;
        var syncCoolDown = RoleDocumentHelper.ConfigBool("options.role.cleaner.syncKillAndCleanCoolDown", "role.cleaner.ability.main.cooldown");
        return RoleDocumentHelper.GetRoleWidget("cleaner",
            RoleDocumentHelper.GetChapter("role.cleaner.ability", [
                RoleDocumentHelper.GetImageLocalizedContent("Buttons.CleanButton.png", "role.cleaner.ability.main", t => t.Replace("#COOLDOWN", syncCoolDown))
                ]),
            RoleDocumentHelper.GetConfigurationCaption()
            );
    }
}

[AddonDocument("role.destroyer")]
public class DestroyerDocument : IDocument
{
    Virial.Media.GUIWidget? IDocument.Build(Artifact<GUIScreen>? target)
    {
        var gui = NebulaAPI.GUI;
        var leftEvidence = RoleDocumentHelper.ConfigBool("options.role.destroyer.leaveKillEvidence", "role.destroyer.ability.main.leftEvidence");
        return RoleDocumentHelper.GetRoleWidget("destroyer",
            RoleDocumentHelper.GetChapter("role.destroyer.ability", [
                RoleDocumentHelper.GetDocumentLocalizedText("role.destroyer.ability.main", t => t.Replace("#LEFTEVIDENCE", leftEvidence))
                ]),
            RoleDocumentHelper.GetTipsChapter("role.destroyer"),
            RoleDocumentHelper.GetConfigurationCaption()
            );
    }
}

[AddonDocument("role.jailer", false)]
[AddonDocument("role.jailerModifier", true)]
public class JailerDocument : IDocument
{
    bool isModifier;
    public JailerDocument(bool isModifier) { this.isModifier = isModifier; }
    Virial.Media.GUIWidget? IDocument.Build(Artifact<GUIScreen>? target)
    {
        var gui = NebulaAPI.GUI;
        var text = RoleDocumentHelper.ConfigBool("options.role.jailer.canMoveWithMapWatching", "role.jailer.ability.main.canWalk", "role.jailer.ability.main.cannotWalk");
        text = text
        .Replace("#DEADBODY", RoleDocumentHelper.ConfigBool("options.role.jailer.canIdentifyDeadBodies", "role.jailer.ability.main.deadbody"))
        .Replace("#IMPOSTOR", RoleDocumentHelper.ConfigBool("options.role.jailer.canIdentifyImpostors", "role.jailer.ability.main.impostor"));
        if (isModifier) text = text.Replace("#INHERIT", "");
        else text = text.Replace("#INHERIT", RoleDocumentHelper.ConfigBool("options.role.jailer.inheritAbilityOnDying", "role.jailer.ability.main.inherit"));

        DefinedAssignable role = NebulaAPI.GetRole("jailer")!;
        DefinedAssignable assignable = isModifier ? NebulaAPI.GetModifier("jailerModifier")! : role;
        return NebulaAPI.GUI.VerticalHolder(GUIAlignment.Left,[
            RoleDocumentHelper.GetAssignableNameWidget(assignable),
            RoleDocumentHelper.GetConfigurationsChapter(assignable),
            RoleDocumentHelper.GetChapter("role.jailer.ability", [
                RoleDocumentHelper.GetDocumentText(text)
                ]),
            RoleDocumentHelper.GetTipsChapter("role.jailer"),
            RoleDocumentHelper.GetConfigurationCaption(),
            RoleDocumentHelper.GetAchievementWidget(role)]
            );
    }
}

[AddonDocument("role.sniper")]
public class SniperDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        var aimAssistDelay = RoleDocumentHelper.Config<float>("options.role.sniper.delayInAimAssistActivation");
        var sound = RoleDocumentHelper.Config<float>("options.role.sniper.shotNoticeRange");
        var aimAssist = RoleDocumentHelper.ConfigBool("options.role.sniper.aimAssist", "role.sniper.tips.aimAssist").Replace("#DELAY", aimAssistDelay);
        return RoleDocumentHelper.GetDocumentLocalizedText("role.sniper.tips", t => t.Replace("#AIMASSIST", aimAssist).Replace("#SOUND", sound));
    }
    public override IEnumerable<GUIWidget> GetAbilityWidget() {
        yield return RoleDocumentHelper.GetImageLocalizedContent("Buttons.SnipeButton.png", "role.sniper.ability.snipe");
    }
    public override RoleType RoleType => RoleType.Role;
}*/