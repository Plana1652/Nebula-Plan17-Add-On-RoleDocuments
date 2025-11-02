using Nebula.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virial.Attributes;
using Virial.Media;

namespace Plana.Documents;

[AddonDocument("role.justicePlus")]
public class justicePlusDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        return RoleDocumentHelper.GetDocumentLocalizedText(DocumentId + ".tips");
    }
    public override string BuildAbilityText(string original)
    {
        var Balance = RoleDocumentHelper.Config<int>("options.role.JusticePlus.JusticePlusMaxPlayer");
        return original.Replace("#NUM", Balance);

    }
    public override IEnumerable<GUIWidget> GetAbilityWidget()
   {
        var Balance = RoleDocumentHelper.Config<int>("options.role.JusticePlus.JusticePlusMaxPlayer");
        yield return RoleDocumentHelper.GetImageLocalizedContent("Balance.png", "role.justicePlus.ability.Balance", str => str.Replace("#NUM", Balance));
    }
    public override RoleType RoleType => RoleType.Role;
}

[AddonDocument("role.lovemesseger")]
public class LoveMessegerDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        return RoleDocumentHelper.GetDocumentLocalizedText(DocumentId + ".tips");
    }

    public override string BuildAbilityText(string original)
    {
        var crewmate = RoleDocumentHelper.ConfigBool("options.role.lovemesseger.crewmate", "role.lovemesseger.ability.crewmate", "role.lovemesseger.ability.nocrewmate");
        var neutral = RoleDocumentHelper.ConfigBool("options.role.lovemesseger.neutral", "role.lovemesseger.ability.neutral", "role.lovemesseger.ability.noneutral");
        var impostor = RoleDocumentHelper.ConfigBool("options.role.lovemesseger.impostor", "role.lovemesseger.ability.impostor", "role.lovemesseger.ability.noimpostor");
        return original.Replace("#C", crewmate).Replace("#N", neutral).Replace("#I", impostor);
        
    }
    public override IEnumerable<GUIWidget> GetAbilityWidget()
    {
        yield return RoleDocumentHelper.GetImageLocalizedContent("LMButton.png", "role.lovemesseger.ability.love");
    }
    public override RoleType RoleType => RoleType.Role;
}

[AddonDocument("role.swapper")]
public class SwapperDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        return RoleDocumentHelper.GetDocumentLocalizedText(DocumentId + ".tips");
    }

    public override string BuildAbilityText(string original)
    {
        var myself = RoleDocumentHelper.ConfigBool("options.role.swapper.op2", "role.swapper.ability.true", "role.swapper.ability.false");
        return original.Replace("#my", myself);
        
    }
    public override IEnumerable<GUIWidget> GetAbilityWidget()
    {
        yield return RoleDocumentHelper.GetImageLocalizedContent("swapper.png", "role.swapper.ability.swapper");
    }
    public override RoleType RoleType => RoleType.Role;
}
[AddonDocument("role.nicesplicer")]
public class NiceSplicerDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        return RoleDocumentHelper.GetDocumentLocalizedText(DocumentId + ".tips");
    }
    public override IEnumerable<GUIWidget> GetAbilityWidget()
    {
        var leftmark = RoleDocumentHelper.ConfigBool("options.role.splicer.usewarpLeftMark", "role.nicesplicer.ability.leftmark", "role.nicesplicer.ability.noleftmark");
        yield return RoleDocumentHelper.GetImageLocalizedContent("WarpButton.png", "role.nicesplicer.ability.warp", str => str.Replace("#MARK", leftmark));
    }
    public override RoleType RoleType => RoleType.Role;
}


/*[AddonDocument("role.justice")]
public class JusticeDocument : AbstractAssignableDocument
{
    public override GUIWidget? GetTipsWidget()
    {
        return RoleDocumentHelper.GetDocumentLocalizedText(DocumentId + ".tips");
    }

    public override string BuildAbilityText(string original)
    {
        var pickUpMe = RoleDocumentHelper.ConfigBool("options.role.justice.putJusticeOnTheBalance", "role.justice.ability.pickJustice");
        var select = RoleDocumentHelper.ConfigBoolRaw("options.role.justice.putJusticeOnTheBalance", "1", "2");
        return original.Replace("#PICKME", pickUpMe).Replace("#NUM", select);

    }
    public override IEnumerable<GUIWidget> GetAbilityWidget()
    {
        yield return RoleDocumentHelper.GetImageLocalizedContent("JusticeIcon.png", "role.justice.ability.meeting");
    }
    public override RoleType RoleType => RoleType.Role;
}*/