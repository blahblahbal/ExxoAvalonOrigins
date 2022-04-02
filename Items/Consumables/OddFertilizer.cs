using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables;

class OddFertilizer : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Odd Fertilizer");
        Tooltip.SetDefault("Summons Plantera");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 45;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.maxStack = 20;
        Item.useAnimation = 45;
        Item.height = dims.Height;
    }

    public override bool CanUseItem(Player player)
    {
        if (!Main.hardMode) return false;
        if (!NPC.downedMechBoss1) return false;
        if (!NPC.downedMechBoss2) return false;
        if (!NPC.downedMechBoss3) return false;
        if (NPC.AnyNPCs(NPCID.Plantera)) return false;
        return true;
    }

    public override bool? UseItem(Player player)
    {
        NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
        return true;
    }
}