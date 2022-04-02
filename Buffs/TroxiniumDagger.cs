using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class TroxiniumDagger : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Troxinium Dagger");
        Description.SetDefault("The dagger will fight for you");
        base.SetStaticDefaults();
    }
}
