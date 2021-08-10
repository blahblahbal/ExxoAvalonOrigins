using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class PeridotAmulet : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Peridot Amulet");            Tooltip.SetDefault("5% increased summon damage");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/PeridotAmulet");			item.rare = 3;			item.width = dims.Width;			item.accessory = true;			item.value = Item.sellPrice(0, 0, 70);			item.height = dims.Height;		}		public override void UpdateAccessory(Player player, bool hideVisual)		{
            player.minionDamage += 0.05f;
        }        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Peridot>(), 12);
            recipe.AddIngredient(ItemID.Chain);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }}