using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvRogue : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Rogue");
        Description.SetDefault("-5% ranged damage, 25% chance to not consume ammo");
    }

    public override void Update(Player player, ref int k)
    {
        player.ammoCost75 = true;
        player.GetDamage(DamageClass.Ranged) -= 0.05f;
    }
}