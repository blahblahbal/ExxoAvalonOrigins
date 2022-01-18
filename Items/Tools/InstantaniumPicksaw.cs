using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class InstantaniumPicksaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instantanium Picksaw");
            Tooltip.SetDefault("'The ultimate tool'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 30;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.15f;
            item.axe = 35;
            item.pick = 350;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.useTime = 5;
            item.knockBack = 5.5f;
            item.melee = true;
            item.tileBoost += 4;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 416000;
            item.useAnimation = 11;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }

        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("InstantaniumPicksaw"))
            {
                player.pickSpeed -= 0.5f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
            recipe.AddIngredient(ItemID.TitaniumBar, 30);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<InstantaniumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.TroxiniumBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<InstantaniumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
            recipe.AddIngredient(ItemID.AdamantiteBar, 30);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<InstantaniumPicksaw>());
            recipe.AddRecipe();
        }
    }
}
