﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
    class MechanicalWasp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Wasp");
            Tooltip.SetDefault("Summons Mechasting");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/MechanicalWasp");
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.value = 0;
            item.maxStack = 20;
            item.useAnimation = 45;
            item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<NPCs.Mechasting>())) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position, 0);
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Mechasting>());
            return true;
        }
    }
}
