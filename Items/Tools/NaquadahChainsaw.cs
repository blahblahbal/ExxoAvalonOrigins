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
            item.damage = 29;
            item.noUseGraphic = true;
            item.channel = true;
            item.axe = 18;
            item.shootSpeed = 40f;
            item.rare = ItemRarityID.LightRed;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 6;
            item.knockBack = 4.5f;
            item.shoot = ModContent.ProjectileType<Projectiles.NaquadahChainsaw>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 102500;
            item.useAnimation = 25;
            item.height = dims.Height;
            item.UseSound = SoundID.Item23;
        }
    }
}
