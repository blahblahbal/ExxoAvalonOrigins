using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class PlanterasFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantera's Fury");
            Tooltip.SetDefault("60% chance to not consume ammo");
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15f, 0f);
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 35;
            Item.autoReuse = true;
            Item.useTurn = false;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 14f;
            Item.crit += 2;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Yellow;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.knockBack = 3f;
            Item.useTime = 4;
            Item.shoot = ProjectileID.Bullet;
            Item.value = Item.sellPrice(0, 30, 0, 0);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 4;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item41;
        }
    }
}
