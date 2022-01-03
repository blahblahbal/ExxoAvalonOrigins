﻿using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExxoAvalonOrigins.Items.Consumables;

namespace ExxoAvalonOrigins.Items.BossBags
{
    public class BacteriumPrimeBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 36;
            item.height = 34;
            item.rare = ItemRarityID.Purple;
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            //player.TryGettingDevArmor();

            player.QuickSpawnItem(ModContent.ItemType<BacciliteOre>(), Main.rand.Next(15, 41) + Main.rand.Next(15, 41));
            player.QuickSpawnItem(ModContent.ItemType<Booger>(), Main.rand.Next(10, 20));
			player.QuickSpawnItem(ModContent.ItemType<BadgeOfBacteria>());
            if (Main.rand.Next(4) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<StaminaCrystal>());
            }
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.BacteriumPrime>();
    }
}
