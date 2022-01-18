using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class MissileBolt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Missile Bolt");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.shootSpeed = -1f;
            item.damage = 50;
            item.ammo = AmmoID.StyngerBolt;
            item.ranged = true;
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.knockBack = 3f;
            item.shoot = ModContent.ProjectileType<Projectiles.MissileBolt>();
            item.maxStack = 2000;
            item.value = 150;
            item.height = dims.Height;
        }
    }
}
