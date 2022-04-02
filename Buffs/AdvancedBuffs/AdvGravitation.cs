using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvGravitation : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Gravitation");
        Description.SetDefault("Press UP to reverse gravity");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.gravControl = true;
    }
}
