using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class GoldminePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goldmine Pickaxe");
            Tooltip.SetDefault("Able to mine Hellstone");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 10;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.15f;
            item.pick = 69;
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.useTime = 13;
            item.knockBack = 3f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 36, 0);
            item.useAnimation = 21;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<Material.Booger>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
