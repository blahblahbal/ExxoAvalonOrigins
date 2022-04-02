using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvBuilder : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Builder");
        Description.SetDefault("Increased placement speed and range");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.tileSpeed += 0.3f;
        player.wallSpeed += 0.3f;
        player.blockRange += 2;
    }
}
