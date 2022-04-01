using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Throw
{
    class EnchantedShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Shuriken");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 13;
            Item.noUseGraphic = true;
            Item.maxStack = 999;
            Item.shootSpeed = 9f;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.shoot = ModContent.ProjectileType<Projectiles.EnchantedShuriken>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 30;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
