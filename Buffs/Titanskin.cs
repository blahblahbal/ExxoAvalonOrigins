using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class Titanskin : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Titanskin");
        Description.SetDefault("Defense is increased by 15 and damage is reduced by 8%");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 15;
        player.GetDamage(DamageClass.Magic) -= 0.08f;
        player.GetDamage(DamageClass.Ranged) -= 0.08f;
        player.GetDamage(DamageClass.Melee) -= 0.08f;
        player.GetDamage(DamageClass.Summon) -= 0.08f;
    }
}
