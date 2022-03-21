using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class VorazylcumPicksaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vorazylcum Picksaw");
            Tooltip.SetDefault("Can mine Oblivion Ore");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 30;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.15f;
            item.axe = 25;
            item.pick = 310;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.useTime = 13;
            item.knockBack = 5.5f;
            item.melee = true;
            item.tileBoost += 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 516000;
            item.useAnimation = 15;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == item.type)
            {
                player.pickSpeed -= 0.35f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.VorazylcumBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
