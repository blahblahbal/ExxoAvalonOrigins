using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items.Placeable{	class XanthophyteBar : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Xanthophyte Bar");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Placeable/XanthophyteBar");			item.autoReuse = true;			item.consumable = true;			item.createTile = ModContent.TileType<Tiles.PlacedBars>();			item.rare = ItemRarityID.Yellow;            item.placeStyle = 23;			item.width = dims.Width;			item.useTime = 10;			item.useTurn = true;			item.useStyle = ItemUseStyleID.SwingThrow;			item.maxStack = 999;			item.value = Item.sellPrice(0, 0, 15, 0);			item.useAnimation = 15;			item.height = dims.Height;		}        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<XanthophyteOre>(), 6);
            r.AddTile(TileID.AdamantiteForge);
            r.SetResult(this);
            r.AddRecipe();
        }
    }}