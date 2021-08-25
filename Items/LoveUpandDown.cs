using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class LoveUpandDown : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Love Up and Down");			Tooltip.SetDefault("Tome\n+15% damage, +7% critical strike chance, -25% mana cost\n20% chance to not consume ammo, 7 defense, +80 HP, +80 mana");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/LoveUpandDown");			item.rare = ItemRarityID.Lime;			item.width = dims.Width;			item.value = 150000;			item.height = dims.Height;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;        }        public override void UpdateAccessory(Player player, bool hideVisual)        {            player.rangedDamage += 0.15f;            player.meleeDamage += 0.15f;            player.magicDamage += 0.15f;            player.minionDamage += 0.15f;            player.thrownDamage += 0.15f;            player.meleeCrit += 7;            player.magicCrit += 7;            player.rangedCrit += 7;            player.thrownCrit += 7;            player.manaCost -= 0.25f;            player.statDefense += 7;            player.statLifeMax2 += 80;            player.statManaMax2 += 80;        }        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<AdventuresandMishaps>());
            recipe.AddIngredient(ModContent.ItemType<ScrollofTome>(), 3);
            recipe.AddIngredient(ModContent.ItemType<FineLumber>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Gravel>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Sandstone>(), 20);
            recipe.AddIngredient(ModContent.ItemType<CarbonSteel>(), 20);
            recipe.AddIngredient(ModContent.ItemType<MysteriousPage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }    }}