using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TourmalineAmulet : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Tourmaline Amulet");            Tooltip.SetDefault("5% increased critical strike chance");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TourmalineAmulet");			item.rare = 3;			item.width = dims.Width;			item.accessory = true;			item.value = Item.sellPrice(0, 0, 70);			item.height = dims.Height;		}		public override void UpdateAccessory(Player player, bool hideVisual)		{
            player.meleeCrit += 5;            player.magicCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
        }        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Tourmaline>(), 12);
            recipe.AddIngredient(ItemID.Chain);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }}