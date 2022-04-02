using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvNightOwl : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Night Owl");
        Description.SetDefault("Increased night vision");
    }

    public override void Update(Player player, ref int k)
    {
        player.nightVision = true;
    }
}