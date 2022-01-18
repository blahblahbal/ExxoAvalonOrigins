using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class RiftGoggles : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rift Goggles");
            Tooltip.SetDefault("Allows you to see rifts into another world");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Accessories/RiftGoggles");
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.accessory = true;
            item.value = 50000;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().riftGoggles = true;
        }

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Goggles);
            r.AddIngredient(ModContent.ItemType<BloodshotLens>(), 2);
            r.AddIngredient(ItemID.JungleSpores, 10);
            r.AddIngredient(ItemID.CursedFlame, 15);
            r.AddIngredient(ItemID.SoulofNight, 10);
            r.AddIngredient(ModContent.ItemType<Sulphur>(), 20);
            r.AddTile(TileID.DemonAltar);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Goggles);
            r.AddIngredient(ModContent.ItemType<BloodshotLens>(), 2);
            r.AddIngredient(ItemID.JungleSpores, 10);
            r.AddIngredient(ItemID.Ichor, 15);
            r.AddIngredient(ItemID.SoulofNight, 10);
            r.AddIngredient(ModContent.ItemType<Sulphur>(), 20);
            r.AddTile(TileID.DemonAltar);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Goggles);
            r.AddIngredient(ModContent.ItemType<BloodshotLens>(), 2);
            r.AddIngredient(ItemID.JungleSpores, 10);
            r.AddIngredient(ModContent.ItemType<Pathogen>(), 15);
            r.AddIngredient(ItemID.SoulofNight, 10);
            r.AddIngredient(ModContent.ItemType<Sulphur>(), 20);
            r.AddTile(TileID.DemonAltar);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Goggles);
            r.AddIngredient(ModContent.ItemType<BloodshotLens>(), 2);
            r.AddIngredient(ModContent.ItemType<TropicalShroomCap>(), 10);
            r.AddIngredient(ItemID.CursedFlame, 15);
            r.AddIngredient(ItemID.SoulofNight, 10);
            r.AddIngredient(ModContent.ItemType<Sulphur>(), 20);
            r.AddTile(TileID.DemonAltar);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Goggles);
            r.AddIngredient(ModContent.ItemType<BloodshotLens>(), 2);
            r.AddIngredient(ModContent.ItemType<TropicalShroomCap>(), 10);
            r.AddIngredient(ItemID.Ichor, 15);
            r.AddIngredient(ItemID.SoulofNight, 10);
            r.AddIngredient(ModContent.ItemType<Sulphur>(), 20);
            r.AddTile(TileID.DemonAltar);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Goggles);
            r.AddIngredient(ModContent.ItemType<BloodshotLens>(), 2);
            r.AddIngredient(ModContent.ItemType<TropicalShroomCap>(), 10);
            r.AddIngredient(ModContent.ItemType<Pathogen>(), 15);
            r.AddIngredient(ItemID.SoulofNight, 10);
            r.AddIngredient(ModContent.ItemType<Sulphur>(), 20);
            r.AddTile(TileID.DemonAltar);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
