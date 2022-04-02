using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvFlipper : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Flipper");
        Description.SetDefault("Move like normal in water");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.accFlipper = true;
    }
}
