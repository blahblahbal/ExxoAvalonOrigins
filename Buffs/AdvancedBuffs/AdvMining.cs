using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvMining : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Mining");
        Description.SetDefault("35% increased mining speed");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.pickSpeed -= 0.35f;
    }
}
