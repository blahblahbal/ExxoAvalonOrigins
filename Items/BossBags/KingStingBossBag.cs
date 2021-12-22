using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.BossBags
{
    public class KingStingBossBag : ModItem
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

            player.QuickSpawnItem(ModContent.ItemType<ToxinShard>(), Main.rand.Next(50, 81));
            if (Main.rand.Next(0, 10) < 3)
                player.QuickSpawnItem(ItemID.BottledHoney, Main.rand.Next(5, 9));
            if (Main.rand.Next(0, 25) < 23)
                player.QuickSpawnItem(ItemID.JestersArrow, Main.rand.Next(20, 31));
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.Bosses.KingSting>();
    }
}
