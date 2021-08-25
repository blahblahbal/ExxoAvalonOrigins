using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TomorrowsPhoenix : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Tomorrow's Phoenix");			Tooltip.SetDefault("Tome\n8% increased minion damage\n5% increased minion knockback");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TomorrowsPhoenix");			item.rare = ItemRarityID.Orange;			item.width = dims.Width;			item.value = Item.sellPrice(0, 0, 10);
            item.height = dims.Height;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;		}        public override void UpdateAccessory(Player player, bool hideVisual)        {            player.minionDamage += 0.08f;            player.minionKB += 0.05f;        }

        public override void AddRecipes()        {            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 100);
            recipe.AddIngredient(ModContent.ItemType<StrongVenom>(), 5);
            recipe.AddIngredient(ItemID.FallenStar, 20);
            recipe.AddIngredient(ModContent.ItemType<MysticalClaw>(), 4);
            recipe.AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();        }    }}