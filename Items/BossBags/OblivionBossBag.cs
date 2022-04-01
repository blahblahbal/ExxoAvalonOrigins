using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Painting;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.BossBags
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
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 36;
            Item.height = 34;
            Item.rare = ItemRarityID.Purple;
            Item.expert = true;
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
                player.QuickSpawnItem(ModContent.ItemType<CurseofOblivion>(), 1);
            }
            player.QuickSpawnItem(ModContent.ItemType<Tools.AccelerationDrill>(), 1);
            player.QuickSpawnItem(ModContent.ItemType<SoulofTorture>(), Main.rand.Next(60, 121));
            if (Main.rand.Next(5) > 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<VictoryPiece>(), 1);
            }
            else
            {
                player.QuickSpawnItem(ModContent.ItemType<VictoryPiece>(), 2);
            }
            player.QuickSpawnItem(ModContent.ItemType<OblivionOre>(), Main.rand.Next(100, 201));
            if (Main.rand.Next(4) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Consumables.StaminaCrystal>());
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Accessories.TomeofLuck>());
            }
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.AncientOblivionHead1>();
    }
}
