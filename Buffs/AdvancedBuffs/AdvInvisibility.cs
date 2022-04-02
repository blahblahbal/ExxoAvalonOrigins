using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvInvisibility : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Invisibility");
        Description.SetDefault("Grants invisibility");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.invis = true;
    }
}
