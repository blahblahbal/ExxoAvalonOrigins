using ExxoAvalonOrigins.Systems;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria;

namespace ExxoAvalonOrigins.DropConditions;
public class OutpostDrop : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return Main.hardMode && info.player.Avalon().ZoneOutpost;
    }
    public bool CanShowItemDropInUI()
    {
        return true;
    }
    public string GetConditionDescription()
    {
        return "Drops in the Tuhrtl Outpost";
    }
}

