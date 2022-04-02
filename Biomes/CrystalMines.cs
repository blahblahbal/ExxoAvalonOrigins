using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class CrystalMines : ModBiome
{
    public override bool IsBiomeActive(Player player)
    {
        player.Avalon().ZoneCrystal = ExxoAvalonOriginsWorld.crystalTiles > 100;
        return player.Avalon().ZoneCrystal;
    }
}

