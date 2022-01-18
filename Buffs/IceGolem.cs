using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class IceGolem : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ice Golem");
            Description.SetDefault("The ice golem will fight for you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int k)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.IceGolemSummon>()] > 0)
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().iceGolem = true;
            }
            if (!player.GetModPlayer<ExxoAvalonOriginsModPlayer>().iceGolem)
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
