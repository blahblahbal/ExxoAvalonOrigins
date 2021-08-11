using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class AmuletofPower : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Amulet of Power");            Tooltip.SetDefault("Increases all stats");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AmuletofPower");			item.rare = 4;			item.width = dims.Width;			item.accessory = true;			item.value = Item.sellPrice(0, 0, 90);			item.height = dims.Height;            item.defense = 3;		}		public override void UpdateAccessory(Player player, bool hideVisual)		{
            player.magicDamage += 0.03f;
            player.meleeDamage += 0.03f;
            player.rangedDamage += 0.03f;
            player.minionDamage += 0.03f;
            player.thrownDamage += 0.03f;
            player.magicCrit += 3;
            player.meleeCrit += 3;
            player.rangedCrit += 3;
            player.thrownCrit += 3;
            player.statManaMax2 += 40;
            player.statLifeMax2 += 40;
        }        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AmethystAmulet>());
            recipe.AddIngredient(ModContent.ItemType<TopazAmulet>());
            recipe.AddIngredient(ModContent.ItemType<SapphireAmulet>());
            recipe.AddIngredient(ModContent.ItemType<EmeraldAmulet>());
            recipe.AddIngredient(ModContent.ItemType<RubyAmulet>());
            recipe.AddIngredient(ModContent.ItemType<DiamondAmulet>());
            recipe.AddIngredient(ModContent.ItemType<TourmalineAmulet>());
            recipe.AddIngredient(ModContent.ItemType<PeridotAmulet>());
            recipe.AddIngredient(ModContent.ItemType<ZirconAmulet>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }}