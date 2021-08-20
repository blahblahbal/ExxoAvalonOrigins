using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.BossBags
{
    public class DesertBeakBossBag : ModItem
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

            player.QuickSpawnItem(ItemID.SandBlock, Main.rand.Next(22, 55));
            player.QuickSpawnItem(ModContent.ItemType<DesertFeather>(), Main.rand.Next(2, 4));
            if (Main.rand.Next(10) <= 5)
            {
                player.QuickSpawnItem(ExxoAvalonOriginsWorld.osmiumOre.GetItemOre(), Main.rand.Next(15, 26));   
            }
            if (Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<TomeoftheDistantPast>(), 1);
            }
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.DesertBeak>();
    }
}