using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items.Placeable{	class AncientMythrilBrickWall : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Ancient Mythril Brick Wall");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Placeable/AncientMythrilBrickWall");			item.autoReuse = true;			item.consumable = true;			item.width = dims.Width;			item.useTurn = true;			item.useTime = 10;			item.createWall = ModContent.WallType<Walls.AncientMythrilBrickWall>();			item.useStyle = 1;			item.maxStack = 999;			item.useAnimation = 15;			item.height = dims.Height;		}        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<AncientMythrilBrick>());
            r.AddTile(ModContent.TileType<Tiles.AncientWorkbench>());
            r.SetResult(this, 4);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(this, 4);
            r.AddTile(ModContent.TileType<Tiles.AncientWorkbench>());
            r.SetResult(ModContent.ItemType<AncientMythrilBrick>());
            r.AddRecipe();
        }
    }}