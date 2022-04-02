using ExxoAvalonOrigins.Systems;
using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.DropConditions;
public class PostPhantasmHellcastleDrop : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return info.player.Avalon().ZoneHellcastle && NPC.downedMoonlord && DownedBossSystem.downedPhantasm;
    }
    public bool CanShowItemDropInUI()
    {
        return true;
    }
    public string GetConditionDescription()
    {
        return "Drops in the Hellcastle";
    }
}

