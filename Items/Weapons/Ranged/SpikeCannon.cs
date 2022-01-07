using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class SpikeCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spike Cannon");
			Tooltip.SetDefault("Uses spikes for ammo\n'You should be careful with this'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 65;
			item.autoReuse = true;
			item.useTurn = false;
			item.useAmmo = ItemID.Spike;
			item.shootSpeed = 14f;
			item.crit += 2;
			item.ranged = true;
			item.rare = ItemRarityID.LightRed;
			item.noMelee = true;
			item.width = dims.Width;
			item.knockBack = 8f;
			item.useTime = 25;
			item.shoot = ModContent.ProjectileType<Projectiles.SpikeCannon>();
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 25;
			item.height = dims.Height;
            item.UseSound = SoundID.Item11;
        }
    }
}
