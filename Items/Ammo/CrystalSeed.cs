using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class CrystalSeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Seed");
            Tooltip.SetDefault("For use with Blowpipes");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 5;
            Item.ammo = AmmoID.Dart;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.shoot = ModContent.ProjectileType<Projectiles.CrystalSeed>();
            Item.maxStack = 999;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(50).AddIngredient(ItemID.Seed, 50).AddIngredient(ItemID.CrystalShard).AddTile(TileID.MythrilAnvil).Register();
        }
    }
}
