using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.DropConditions;

public class DropIfNoArmaAlive : IItemDropRuleCondition
{
    public bool CanDrop(DropAttemptInfo info)
    {
        if (!info.IsInSimulation)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>());
        }
        return false;
    }

    public bool CanShowItemDropInUI()
    {
        return true;
    }

    public string GetConditionDescription()
    {
        return "Drops if the Armageddon Slime is not in the world.";
    }
}