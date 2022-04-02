using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvCalming : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Calm");
        Description.SetDefault("Reduced enemy aggression");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.Avalon().advCalmingBuff = true;
    }
}
