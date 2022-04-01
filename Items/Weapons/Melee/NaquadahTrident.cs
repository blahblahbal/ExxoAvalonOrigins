using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class NaquadahTrident : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Trident");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 35;
            Item.noUseGraphic = true;
            Item.scale = 1.1f;
            Item.shootSpeed = 5f;
            Item.rare = ItemRarityID.LightRed;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 26;
            Item.knockBack = 5.5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.NaquadahTrident>();
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 86000;
            Item.useAnimation = 26;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
    }
}
