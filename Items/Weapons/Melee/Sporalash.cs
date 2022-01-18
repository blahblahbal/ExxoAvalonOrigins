using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class Sporalash : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sporalash");
            Tooltip.SetDefault("Has a chance to poison");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 33;
            item.noUseGraphic = true;
            item.channel = true;
            item.scale = 1.1f;
            item.shootSpeed = 10f;
            item.noMelee = true;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.useTime = 46;
            item.knockBack = 6.75f;
            item.shoot = ModContent.ProjectileType<Projectiles.Sporalash>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 27000;
            item.useAnimation = 46;
            item.height = dims.Height;
        }
    }
}
