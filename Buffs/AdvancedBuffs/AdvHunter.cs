using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvHunter : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Hunter");
        Description.SetDefault("Shows the location of enemies");
    }

    public override void Update(Player player, ref int k)
    {
        player.detectCreature = true;
    }
}