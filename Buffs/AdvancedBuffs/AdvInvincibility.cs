using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvInvincibility : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Invincibility");
        Description.SetDefault("You are invincible. Hurray!");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.immune = true;
    }
}
