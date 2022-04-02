using ExxoAvalonOrigins.Systems;
using Terraria.GameContent.ItemDropRules;
using Terraria;

namespace ExxoAvalonOrigins.DropConditions;
public class IceBiomeDrop : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return info.player.ZoneRockLayerHeight && info.player.ZoneSnow && Main.hardMode;
    }
    public bool CanShowItemDropInUI()
    {
        return true;
    }
    public string GetConditionDescription()
    {
        return "Drops in the Underground Ice";
    }
}

