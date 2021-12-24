using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
	public class Reflector : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Reflector");
			Description.SetDefault("The minions will reflect projectiles for you");
		}

		public override void Update(Player player, ref int k)
		{
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Reflector>()] > 0)
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().reflectorMinion = true;
            }
            if (!player.GetModPlayer<ExxoAvalonOriginsModPlayer>().reflectorMinion)
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
