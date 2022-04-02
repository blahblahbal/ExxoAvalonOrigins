using ExxoAvalonOrigins.Systems;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.DropConditions;
public class TropicsDrop : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return info.player.Avalon().ZoneTropics;
    }
    public bool CanShowItemDropInUI()
    {
        return true;
    }
    public string GetConditionDescription()
    {
        return "Drops in the Tropics";
    }
}

