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
            item.UseSound = SoundID.Item1;
            item.damage = 35;
            item.noUseGraphic = true;
            item.scale = 1.1f;
            item.shootSpeed = 5f;
            item.rare = ItemRarityID.LightRed;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 26;
            item.knockBack = 5.5f;
            item.shoot = ModContent.ProjectileType<Projectiles.NaquadahTrident>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 86000;
            item.useAnimation = 26;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
