using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class DiamondAmulet : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Diamond Amulet");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DiamondAmulet");			item.rare = ItemRarityID.Green;			item.width = dims.Width;			item.accessory = true;			item.value = Item.sellPrice(0, 0, 50);			item.height = dims.Height;            item.defense = 5;		}		public override void UpdateAccessory(Player player, bool hideVisual)		{
            		}        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond, 12);
            recipe.AddIngredient(ItemID.Chain);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }}