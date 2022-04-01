using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class EctoplasmicBeacon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ectoplasmic Beacon");
            Tooltip.SetDefault("Summons Phantasm\nMust be used in the Hellcastle");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.consumable = true;
            Item.width = dims.Width;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = 0;
            Item.maxStack = 20;
            Item.useAnimation = 45;
            Item.height = dims.Height;
            Item.rare = ItemRarityID.Yellow;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Phantasm>()) && player.Avalon().ZoneHellcastle && NPC.downedMoonlord && Main.hardMode;
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Phantasm>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Ectoplasm, 10).AddIngredient(ItemID.ChlorophyteBar, 10).AddIngredient(ModContent.ItemType<SolariumStar>(), 8).AddTile(ModContent.TileType<Tiles.LibraryAltar>()).Register();
        }
    }
}
