using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items
{
    public class PhantasmBossBag : ModItem
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
            item.width = 24;
            item.height = 24;
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
            int drop = Main.rand.Next(3);
            if (drop == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<VampireTeeth>());
            }
            else if (drop == 1)
            {
                player.QuickSpawnItem(ModContent.ItemType<PhantomKnives>());
            }
            else if (drop == 2)
            {
                player.QuickSpawnItem(ModContent.ItemType<EtherealHeart>());
            }
            player.QuickSpawnItem(ModContent.ItemType<GhostintheMachine>(), Main.rand.Next(3, 6));
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.Phantasm>();
    }
}