using ExxoAvalonOrigins.Items.Placeable.Tile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.BossBags
{
    public class DragonLordBossBag : ModItem
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
            //if (Main.rand.Next(7) == 0) player.QuickSpawnItem(ModContent.ItemType<Placeable.Trophy.DragonLordTrophy>());
            player.QuickSpawnItem(ModContent.ItemType<DragonScale>(), Main.rand.Next(10, 21));
            player.QuickSpawnItem(ModContent.ItemType<Accessories.DragonsBondage>());
            int rand = Main.rand.Next(5);
            if (rand == 0) player.QuickSpawnItem(ModContent.ItemType<Accessories.DragonStone>());
            else if (rand == 1) player.QuickSpawnItem(ModContent.ItemType<Weapons.Melee.Infernasword>());
            else if (rand == 2) player.QuickSpawnItem(ModContent.ItemType<Weapons.Ranged.QuadroCannon>());
            else if (rand == 3) player.QuickSpawnItem(ModContent.ItemType<Weapons.Magic.MagmafrostBolt>());
            else if (rand == 4) player.QuickSpawnItem(ModContent.ItemType<Weapons.Summon.ReflectorStaff>());
            if (Main.rand.Next(4) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Consumables.StaminaCrystal>());
            }
        }

        public override int BossBagNPC => ModContent.NPCType<NPCs.DragonLordHead>();
    }
}
