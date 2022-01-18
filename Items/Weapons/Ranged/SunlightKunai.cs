using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class SunlightKunai : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunlight Kunai");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.noUseGraphic = true;
            item.damage = 49;
            item.maxStack = 999;
            item.shootSpeed = 12f;
            item.crit += 6;
            item.ranged = true;
            item.consumable = true;
            item.noMelee = true;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.useTime = 15;
            item.knockBack = 4f;
            item.shoot = ModContent.ProjectileType<Projectiles.SunlightKunai>();
            item.value = 550;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
