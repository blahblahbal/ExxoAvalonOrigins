using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class ObsidianRoseShield : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Obsidian Rose Shield");			Tooltip.SetDefault("Reduces damage from touching lava\nGrants immunity to fire blocks and knockback");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ObsidianRoseShield");			item.rare = 6;			item.width = dims.Width;			item.accessory = true;			item.value = Item.sellPrice(0, 3);			item.height = dims.Height;		}		public override void UpdateAccessory(Player player, bool hideVisual)		{
            player.lavaRose = player.fireWalk = player.noKnockback = true;		}        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianShield);
            recipe.AddIngredient(ItemID.ObsidianRose);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }}