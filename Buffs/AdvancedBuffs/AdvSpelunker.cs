using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvSpelunker : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Spelunker");
        Description.SetDefault("Shows the location of treasure and ore");
    }

    public override void Update(Player player, ref int k)
    {
        player.findTreasure = true;
    }
}