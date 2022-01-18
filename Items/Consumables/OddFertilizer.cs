using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
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
            item.consumable = true;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.maxStack = 20;
            item.useAnimation = 45;
            item.height = dims.Height;
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

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
            return true;
        }
    }
}
