using ExxoAvalonOrigins.Players;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class CrystalMines : ModBiome
{
    public override bool IsBiomeActive(Player player)
    {
        return player.GetModPlayer<ExxoBiomePlayer>().ZoneCrystal;
    }
}
