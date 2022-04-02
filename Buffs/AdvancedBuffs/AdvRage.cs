using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvRage : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Rage");
        Description.SetDefault("15% increased critical strike chance");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.AllCrit(15);
    }
}
