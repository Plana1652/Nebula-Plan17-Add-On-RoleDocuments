using Virial;
using Virial.Compat;
using Virial.Media;
using Virial.Text;
using Virial.Attributes;
using System.Collections.Generic;
using Nebula.Player;

namespace Plana.Documents;

[AddonDocument("role.knighted")]
public class KnightedDocument : IDocument
{
    Virial.Media.GUIWidget? IDocument.Build(Artifact<GUIScreen>? target)
    {
        var gui = NebulaAPI.GUI;
        var killNum = RoleDocumentHelper.Config<int>("options.role.knighted.op1");
        return RoleDocumentHelper.GetRoleWidget("knighted",
            RoleDocumentHelper.GetWinCondChapter("role.knighted"),
            RoleDocumentHelper.GetChapter("role.knighted.ability", [
                RoleDocumentHelper.GetDocumentLocalizedText("role.knighted.ability.main", str => str.Replace("#NUM", killNum)),
                RoleDocumentHelper.GetImageLocalizedContent("Select.png", "role.knighted.ability.Select"),
                ]),
            RoleDocumentHelper.GetTipsChapter("role.knighted"),
            RoleDocumentHelper.GetConfigurationCaption()
            );
    }
}

[AddonDocument("role.lawyer")]
public class LawyerDocument : IDocument
{
    Virial.Media.GUIWidget? IDocument.Build(Artifact<GUIScreen>? target)
    {
        var gui = NebulaAPI.GUI;
        var ClientknowMyIsClient = RoleDocumentHelper.ConfigBool("options.role.lawyer.targetknowmyisclient","role.lawyer.ability.targetknowmyisclient","role.lawyer.ability.noTKM");
        var WinAfterMeetings = RoleDocumentHelper.ConfigBool("options.role.lawyer.winaftermeetings","role.lawyer.ability.winaftermeetings","role.lawyer.ability.noWAM");
        var winneededMeetings = RoleDocumentHelper.Config<int>("options.role.lawyer.winneededmeetings");
        var lawyerKnowClientRole = RoleDocumentHelper.ConfigBool("options.role.lawyer.lawyerknowclientrole","role.lawyer.ability.lawyerknowclientrole","role.lawyer.ability.noLKC");
        return RoleDocumentHelper.GetRoleWidget("lawyer",
            RoleDocumentHelper.GetWinCondChapter("role.lawyer", str => str.Replace("#WAM",WinAfterMeetings).Replace("#NUM",winneededMeetings)),
            RoleDocumentHelper.GetChapter("role.lawyer.ability", [
                RoleDocumentHelper.GetDocumentLocalizedText("role.lawyer.ability.main", str => str.Replace("#TKM",ClientknowMyIsClient).Replace("#LKC",lawyerKnowClientRole))
                ]),
            RoleDocumentHelper.GetTipsChapter("role.lawyer"),
            RoleDocumentHelper.GetConfigurationCaption()
            );
    }
}
[AddonDocument("role.pursuer")]
public class PursuerDocument : IDocument
{
    Virial.Media.GUIWidget? IDocument.Build(Artifact<GUIScreen>? target)
    {
        var gui = NebulaAPI.GUI;
        var BlankNum = RoleDocumentHelper.Config<int>("options.role.pursuer.blanknum");
        return RoleDocumentHelper.GetRoleWidget("pursuer",
            RoleDocumentHelper.GetWinCondChapter("role.pursuer"),
            RoleDocumentHelper.GetChapter("role.pursuer.ability", [
                RoleDocumentHelper.GetDocumentLocalizedText("role.pursuer.ability.main", str => str.Replace("#NUM",BlankNum))
                ]),
            RoleDocumentHelper.GetTipsChapter("role.pursuer"),
            RoleDocumentHelper.GetConfigurationCaption()
            );
    }
}
/*[AddonDocument("role.dancer")]
public class DancerDocument : IDocument
{
    Virial.Media.GUIWidget? IDocument.Build(Artifact<GUIScreen>? target)
    {
        var gui = NebulaAPI.GUI;
        var winCondNum = RoleDocumentHelper.Config<int>("options.role.dancer.numOfSuccessfulForecastToWin");
        var lastDance = RoleDocumentHelper.ConfigBool("options.role.dancer.finalDance","role.dancer.winCond.main.lastDance");
        return RoleDocumentHelper.GetRoleWidget("dancer",
            RoleDocumentHelper.GetWinCondChapter("role.dancer", str => str.Replace("#NUM", winCondNum).Replace("#ADD", lastDance)),
            RoleDocumentHelper.GetChapter("role.dancer.ability", [
                RoleDocumentHelper.GetDocumentLocalizedText("role.dancer.ability.main"),
                RoleDocumentHelper.GetImageLocalizedContent("Buttons.DanceButton.png", "role.dancer.ability.dance"),
                RoleDocumentHelper.GetImageLocalizedContent("Buttons.DanceKillButton.png", "role.dancer.ability.danceKill")
                ]),
            RoleDocumentHelper.GetTipsChapter("role.dancer"),
            RoleDocumentHelper.GetConfigurationCaption()
            );
    }
}

[AddonDocument("role.paparazzo")]
public class PaparazzoDocument : AbstractAssignableDocument
{
    public override IEnumerable<GUIWidget> GetAbilityWidget()
    { 
        yield return RoleDocumentHelper.GetImageLocalizedContent("Buttons.CameraButton.png", "role.paparazzo.ability.camera");
    }

    public override bool WithWinCond => true;
    public override GUIWidget GetCustomWinCondWidget() {
        var subject = RoleDocumentHelper.Config<int>("options.role.paparazzo.requiredSubjects");
        var enclosed = RoleDocumentHelper.Config<int>("options.role.paparazzo.requiredDisclosed");
        return RoleDocumentHelper.GetWinCondChapter(DocumentId, str => str.Replace("#SUBJECT", subject).Replace("#ENCLOSED", enclosed));
    }
    public override RoleType RoleType => RoleType.Role;
}

[AddonDocument("role.spectre")]
public class SpectreDocument : AbstractAssignableDocument
{
    public override IEnumerable<GUIWidget> GetAbilityWidget()
    {
        yield return RoleDocumentHelper.GetImageLocalizedContent("SpectreDish.png", "role.spectre.rule.fries");
        yield return RoleDocumentHelper.GetImageLocalizedContent("Buttons.SpectreButton.png", "role.spectre.ability.vanish");
    }

    public override bool WithWinCond => true;
    public override GUIWidget GetCustomWinCondWidget()
    {
        var satiety = RoleDocumentHelper.Config<float>("options.role.spectre.requiredSatietyForWinning");
        return RoleDocumentHelper.GetWinCondChapter(DocumentId, str => str.Replace("#NUM", satiety));
    }
    public override RoleType RoleType => RoleType.Role;
}*/