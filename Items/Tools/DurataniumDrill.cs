using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class DurataniumDrill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duratanium Drill");
            Tooltip.SetDefault("Can mine Mythril, Orichalcum, and Naquadah");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item23;
            item.damage = 10;
            item.noUseGraphic = true;
            item.channel = true;
            item.shootSpeed = 32f;
            item.pick = 110;
            item.rare = ItemRarityID.LightRed;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 13;
            item.knockBack = 0f;
            item.shoot = ModContent.ProjectileType<Projectiles.DurataniumDrill>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 54000;
            item.useAnimation = 25;
            item.height = dims.Height;
        }
    }
}
