using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	public class Canister : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 9;
			item.ranged = true;
			item.width = 14;
			item.height = 18;
			item.maxStack = 999;
			item.consumable = true;
			item.value = 10;
			item.rare = ItemRarityID.Red;
			item.shoot = ModContent.ProjectileType<Projectiles.FleshFire>();
			item.ammo = item.type;
		}
	}
}
