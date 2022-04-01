using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class Moonfury : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonfury");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 44;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.scale = 1.1f;
            Item.shootSpeed = 12f;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 42;
            Item.knockBack = 6.75f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Moonfury>();
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 54000;
            Item.useAnimation = 42;
            Item.height = dims.Height;
        }
    }
}
