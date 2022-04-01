using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Hungry : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hungry");
            Description.SetDefault("The hungry will fight for you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = false;
        }

        public override void Update(Player player, ref int k)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.HungrySummon>()] > 0)
            {
                player.Avalon().hungryMinion = true;
            }
            if (!player.Avalon().hungryMinion)
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
