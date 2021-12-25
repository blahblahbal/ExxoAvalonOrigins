using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
	public class PrimeArms : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Prime Arms");
			Description.SetDefault("The arms will fight for you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int k)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.PriminiCannon>()] > 0 || player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.PriminiLaser>()] > 0 || player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.PriminiSaw>()] > 0 || player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.PriminiVice>()] > 0)
			{
				player.GetModPlayer<ExxoAvalonOriginsModPlayer>().primeMinion = true;
			}
			if (!player.GetModPlayer<ExxoAvalonOriginsModPlayer>().primeMinion)
			{
				player.DelBuff(k);
				k--;
			}
			else
			{
				player.buffTime[k] = 18000;
			}
		}
	}
}
