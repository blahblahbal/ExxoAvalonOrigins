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
            item.UseSound = SoundID.Item1;
            item.damage = 44;
            item.noUseGraphic = true;
            item.channel = true;
            item.scale = 1.1f;
            item.shootSpeed = 12f;
            item.noMelee = true;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.useTime = 42;
            item.knockBack = 6.75f;
            item.shoot = ModContent.ProjectileType<Projectiles.Moonfury>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 54000;
            item.useAnimation = 42;
            item.height = dims.Height;
        }
    }
}
