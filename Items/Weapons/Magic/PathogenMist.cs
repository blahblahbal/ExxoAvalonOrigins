using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class PathogenMist : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pathogen Mist");
            Tooltip.SetDefault("Fires a blast of infected mist");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.magic = true;
            item.damage = 24;
            item.autoReuse = true;
            item.scale = 0.9f;
            item.shootSpeed = 14f;
            item.mana = 5;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 11;
            item.knockBack = 5f;
            item.shoot = ModContent.ProjectileType<Projectiles.InfectedMist>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 500000;
            item.useAnimation = 11;
            item.height = dims.Height;
        }
    }
}
