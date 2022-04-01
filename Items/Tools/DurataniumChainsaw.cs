using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class DurataniumChainsaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duratanium Chainsaw");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item23;
            Item.damage = 25;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.axe = 15;
            Item.shootSpeed = 40f;
            Item.rare = ItemRarityID.LightRed;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 6;
            Item.knockBack = 3.5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.DurataniumChainsaw>();
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 60000;
            Item.useAnimation = 25;
            Item.height = dims.Height;
        }
    }
}
