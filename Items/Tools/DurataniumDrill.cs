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
            Item.UseSound = SoundID.Item23;
            Item.damage = 10;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.shootSpeed = 32f;
            Item.pick = 110;
            Item.rare = ItemRarityID.LightRed;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 13;
            Item.knockBack = 0f;
            Item.shoot = ModContent.ProjectileType<Projectiles.DurataniumDrill>();
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 60000;
            Item.useAnimation = 25;
            Item.height = dims.Height;
        }
    }
}
