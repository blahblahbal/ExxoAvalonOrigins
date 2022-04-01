using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class PrimeArms : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Arms");
            Description.SetDefault("The arms will fight for you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int k)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.PriminiCannon>()] > 0 || player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.PriminiLaser>()] > 0 || player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.PriminiSaw>()] > 0 || player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.PriminiVice>()] > 0)
            {
                player.Avalon().primeMinion = true;
            }
            if (!player.Avalon().primeMinion)
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
