using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class TheGoldenFlames : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Golden Flames");
            Tooltip.SetDefault("'The flames are made of gold!'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.magic = true;
            item.damage = 72;
            item.channel = true;
            item.shootSpeed = 10f;
            item.crit += 11;
            item.mana = 14;
            item.noMelee = true;
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.knockBack = 7f;
            item.useTime = 50;
            item.shoot = ModContent.ProjectileType<Projectiles.GoldenFire>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 250000;
            item.useAnimation = 50;
            item.height = dims.Height;
        }
    }
}
