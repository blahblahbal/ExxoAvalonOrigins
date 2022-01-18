using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed
{
    class HellstoneSeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellstone Dart");
            Tooltip.SetDefault("For use with Blowpipes");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 9;
            item.consumable = true;
            item.ammo = AmmoID.Dart;
            item.ranged = true;
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.shoot = ModContent.ProjectileType<Projectiles.HellstoneSeed>();
            item.maxStack = 999;
            item.height = dims.Height;
        }
    }
}
