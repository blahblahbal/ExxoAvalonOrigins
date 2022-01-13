using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.BossBags
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
            player.QuickSpawnItem(ModContent.ItemType<Items.Accessories.AstrallineArtifact>());
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
            if (Main.rand.Next(4) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Consumables.StaminaCrystal>());
            }
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.Bosses.Phantasm>();
    }
}
