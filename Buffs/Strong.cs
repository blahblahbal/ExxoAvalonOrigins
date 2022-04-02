using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class Strong : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Strength");
        Description.SetDefault("Increased stats");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage(DamageClass.Generic) += 0.1f;
        player.AllCrit(1);
        player.statDefense += 5;
        player.lifeRegen++;
        player.Avalon().critDamageMult += 0.05f;
    }
}
