using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items.Placeable{	class AncientCobaltBrick : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Ancient Cobalt Brick");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Placeable/AncientCobaltBrick");			item.autoReuse = true;			item.consumable = true;			item.createTile = ModContent.TileType<Tiles.AncientCobaltBrick>();			item.width = dims.Width;			item.useTime = 10;			item.useTurn = true;			item.useStyle = ItemUseStyleID.SwingThrow;			item.maxStack = 999;			item.useAnimation = 15;			item.height = dims.Height;		}        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.CobaltBrick);
            r.AddTile(ModContent.TileType<Tiles.AncientWorkbench>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(this);
            r.AddTile(ModContent.TileType<Tiles.AncientWorkbench>());
            r.SetResult(ItemID.CobaltBrick);
            r.AddRecipe();
        }
    }}