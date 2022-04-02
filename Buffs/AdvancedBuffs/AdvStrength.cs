using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvStrength : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Strength");
        Description.SetDefault("Increases stats");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage(DamageClass.Generic) += 0.13f;
        player.AllCrit(2);
        player.statDefense += 7;
        player.lifeRegen++;
        player.Avalon().critDamageMult += 0.1f;
    }
}
