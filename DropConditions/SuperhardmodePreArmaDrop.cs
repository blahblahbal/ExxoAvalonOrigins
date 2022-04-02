using ExxoAvalonOrigins.Systems;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.DropConditions;
public class SuperhardmodePreArmaDrop : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && !DownedBossSystem.stoppedArmageddon;
    }
    public bool CanShowItemDropInUI()
    {
        return true;
    }
    public string GetConditionDescription()
    {
        return "Drops in early Superhardmode";
    }
}

