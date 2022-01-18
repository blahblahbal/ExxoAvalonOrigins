using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvGPS : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced GPS");
            Description.SetDefault("GPS Effect");
        }

        public override void Update(Player player, ref int k)
        {
            player.accWatch = 3;
            player.accDepthMeter = 1;
            player.accCompass = 1;
        }
    }
}