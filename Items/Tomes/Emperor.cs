using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes
{
    class Emperor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emperor");
            Tooltip.SetDefault("Tome\n25% increased damage, 12% increased critical strike chance, -20% mana cost\n30% chance to not consume ammo, 14 defense, +200 mana, +100 HP, +90 stamina");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.value = 250000;
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.25f;
            player.minionDamage += 0.25f;
            player.meleeDamage += 0.25f;
            player.rangedDamage += 0.25f;
            player.thrownDamage += 0.25f;
            player.meleeCrit += 12;
            player.magicCrit += 12;
            player.rangedCrit += 12;
            player.thrownCrit += 12;
            player.manaCost -= 0.2f;
            player.statDefense += 14;
            player.statLifeMax2 += 100;
            player.statManaMax2 += 200;
            player.Avalon().statStamMax2 += 90;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Dominance>());
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>(), 3);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
