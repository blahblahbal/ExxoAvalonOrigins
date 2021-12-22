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
			item.damage = 35;
			item.autoReuse = true;
			item.useTurn = false;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 14f;
			item.crit += 2;
			item.ranged = true;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.width = dims.Width;
			item.knockBack = 3f;
			item.useTime = 4;
			item.shoot = ProjectileID.Bullet;
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 4;
			item.height = dims.Height;
            item.UseSound = SoundID.Item41;
		}
	}
}
