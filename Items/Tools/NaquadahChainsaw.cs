using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class NaquadahChainsaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Chainsaw");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 29;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.axe = 18;
            Item.shootSpeed = 40f;
            Item.rare = ItemRarityID.LightRed;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 6;
            Item.knockBack = 4.5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.NaquadahChainsaw>();
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 102500;
            Item.useAnimation = 25;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item23;
        }
    }
}
