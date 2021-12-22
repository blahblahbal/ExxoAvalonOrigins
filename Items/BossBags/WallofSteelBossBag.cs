using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.BossBags
{
    public class WallofSteelBossBag : ModItem
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

            int drop = Main.rand.Next(5);
            if (drop == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<FleshBoiler>(), 1);
            }
            if (drop == 1)
            {
                player.QuickSpawnItem(ModContent.ItemType<MagicCleaver>(), 1);
            }
            if (drop == 2)
            {
                player.QuickSpawnItem(ModContent.ItemType<Accessories.BubbleBoost>(), 1);
            }
            player.QuickSpawnItem(ModContent.ItemType<SoulofBlight>(), Main.rand.Next(40, 56));
            player.QuickSpawnItem(ModContent.ItemType<HellsteelPlate>(), Main.rand.Next(20, 26));
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.WallofSteel>();
    }
}
