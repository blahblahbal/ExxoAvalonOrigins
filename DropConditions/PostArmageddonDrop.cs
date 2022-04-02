using ExxoAvalonOrigins.Systems;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.DropConditions;
public class PostArmageddonDrop : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && DownedBossSystem.stoppedArmageddon && !DownedBossSystem.downedMechasting;
    }
    public bool CanShowItemDropInUI()
    {
        return true;
    }
    public string GetConditionDescription()
    {
        return "Drops after Armageddon Slime is defeated";
    }
}

