using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class CreatorsTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Creator's Tome");
            Tooltip.SetDefault("Tome\n+20% damage, +5% critical strike chance, -20% mana cost\n25% chance to not consume ammo, 10 defense, +100 HP, +100 mana");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.value = 150000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.2f;
            player.minionDamage += 0.2f;
            player.meleeDamage += 0.2f;
            player.rangedDamage += 0.2f;
            player.thrownDamage += 0.2f;
            player.meleeCrit += 5;
            player.magicCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
            player.manaCost -= 0.2f;
            player.statDefense += 10;
            player.statLifeMax2 += 100;
            player.statManaMax2 += 100;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<TheVoidlands>());
            recipe.AddIngredient(ModContent.ItemType<ScrollofTome>(), 2);
            recipe.AddIngredient(ModContent.ItemType<FineLumber>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Gravel>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Sandstone>(), 20);
            recipe.AddIngredient(ModContent.ItemType<CarbonSteel>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
