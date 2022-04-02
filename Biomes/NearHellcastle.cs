using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Biomes;

public class NearHellcastle : ModBiome
{
    public override bool IsBiomeActive(Player player)
    {
        player.Avalon().ZoneNearHellcastle = ExxoAvalonOriginsWorld.hellcastleTiles >= 350;
        return player.Avalon().ZoneNearHellcastle;
    }
}

