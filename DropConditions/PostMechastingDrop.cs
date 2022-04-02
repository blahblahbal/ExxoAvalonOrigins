using ExxoAvalonOrigins.Systems;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.DropConditions;
public class PostMechastingDrop : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && DownedBossSystem.downedMechasting;
    }
    public bool CanShowItemDropInUI()
    {
        return true;
    }
    public string GetConditionDescription()
    {
        return "Drops after Mechasting is defeated";
    }
}

