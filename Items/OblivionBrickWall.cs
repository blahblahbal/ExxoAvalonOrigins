using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class OblivionBrickWall : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Oblivion Brick Wall");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/OblivionBrickWall");			item.autoReuse = true;			item.consumable = true;			item.width = dims.Width;			item.useTurn = true;			item.useTime = 7;			item.createWall = ModContent.WallType<Walls.OblivionBrickWall>();			item.useStyle = 1;			item.maxStack = 999;			item.useAnimation = 15;			item.height = dims.Height;		}        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<OblivionBrick>());
            recipe.AddRecipe();
        }
    }}