using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class StingerProbe : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stinger Probe");
            Description.SetDefault("'Don't get too close!'");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.StingerProbeMinion>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
