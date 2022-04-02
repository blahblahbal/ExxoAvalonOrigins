using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class GPS : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("GPS");
        Description.SetDefault("GPS Effect");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.accCompass = 1;
        player.accDepthMeter = 1;
        player.accWatch = 3;
    }
}
