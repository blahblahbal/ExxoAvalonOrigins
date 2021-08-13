using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items
{
    public class OblivionBossBag : ModItem
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

            if (Main.rand.Next(4) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.CurseofOblivion>(), 1);
            }
            player.QuickSpawnItem(ModContent.ItemType<Items.AccelerationDrill>(), 1);
            player.QuickSpawnItem(ModContent.ItemType<Items.SoulofTorture>(), Main.rand.Next(60, 121));
            if (Main.rand.Next(5) > 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.VictoryPiece>(), 1);
            }
            else
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.VictoryPiece>(), 2);
            }
            player.QuickSpawnItem(ModContent.ItemType<Items.OblivionOre>(), Main.rand.Next(100, 201));
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.OblivionHead1>();
    }
}