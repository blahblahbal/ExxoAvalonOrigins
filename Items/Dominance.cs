using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class Dominance : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Dominance");			Tooltip.SetDefault("Tome\n+22% damage, +8% critical strike chance, -10% mana cost\n20% chance to not consume ammo, 11 defense, +140 mana, +80 HP");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Dominance");			item.rare = ItemRarityID.Cyan;			item.width = dims.Width;			item.value = 250000;			item.height = dims.Height;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;        }        public override void UpdateAccessory(Player player, bool hideVisual)        {            player.magicDamage += 0.22f;            player.minionDamage += 0.22f;            player.meleeDamage += 0.22f;            player.rangedDamage += 0.22f;            player.thrownDamage += 0.22f;            player.meleeCrit += 8;            player.magicCrit += 8;            player.rangedCrit += 8;            player.thrownCrit += 8;            player.manaCost -= 0.1f;            player.statDefense += 11;            player.statLifeMax2 += 80;            player.statManaMax2 += 140;        }        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<TheOasisRemembered>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<TheOasisRemembered>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<SceneofCarnage>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<SceneofCarnage>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<ThePlumHarvest>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<ThePlumHarvest>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<ChantoftheWaterDragon>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<ChantoftheWaterDragon>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<TheThreeScholars>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<TheThreeScholars>());
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }    }}