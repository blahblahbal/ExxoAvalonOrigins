using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvGauntlet : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Gauntlet");
        Description.SetDefault("-10 defense, +18% melee damage");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense -= 10;
        player.GetDamage(DamageClass.Melee) += 0.18f;
    }
}
