using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvFishing : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Fishing");
        Description.SetDefault("Increased fishing level");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.fishingSkill += 30;
    }
}
