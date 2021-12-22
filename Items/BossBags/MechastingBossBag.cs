﻿using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.BossBags
{
    public class MechastingBossBag : ModItem
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
            player.TryGettingDevArmor();

            player.QuickSpawnItem(ModContent.ItemType<SoulofDelight>(), Main.rand.Next(20, 41));
            player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.Summon.AIController>(), 1);
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.Mechasting>();
    }
}
