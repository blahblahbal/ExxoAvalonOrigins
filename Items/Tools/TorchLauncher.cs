using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class TorchLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Torch Launcher");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 0;
            item.UseSound = SoundID.Item5;
            item.shootSpeed = 8f;
            item.useAmmo = 8;
            item.ranged = true;
            item.noMelee = true;
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTime = 16;
            item.knockBack = 0f;
            item.shoot = ModContent.ProjectileType<Projectiles.Torches.Torch>();
            item.value = 39000;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 16;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 50);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.anyWood = true;
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
