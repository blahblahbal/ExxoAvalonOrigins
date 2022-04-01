using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class HeavensTear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven's Tear");
            Tooltip.SetDefault("'Heaven splits with each swing'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 54;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.scale = 1.1f;
            Item.shootSpeed = 12f;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.useTime = 45;
            Item.knockBack = 8f;
            Item.shoot = ModContent.ProjectileType<Projectiles.HeavensTear>();
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 54000;
            Item.useAnimation = 45;
            Item.height = dims.Height;
        }
    }
}
