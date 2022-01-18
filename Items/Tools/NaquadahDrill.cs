using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class NaquadahDrill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Drill");
            Tooltip.SetDefault("Can mine Adamantite, Titanium, and Troxinium");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 12;
            item.noUseGraphic = true;
            item.channel = true;
            item.shootSpeed = 32f;
            item.pick = 150;
            item.rare = ItemRarityID.LightRed;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 13;
            item.knockBack = 0f;
            item.shoot = ModContent.ProjectileType<Projectiles.NaquadahDrill>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 54000;
            item.useAnimation = 25;
            item.height = dims.Height;
            item.UseSound = SoundID.Item23;
        }
    }
}
