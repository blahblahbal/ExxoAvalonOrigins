using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class WeaponImbuePathogen : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Weapon Imbue: Infection");
        Description.SetDefault("Melee attacks inflict Infected on your targets");
    }

    public override void Update(Player player, ref int k)
    {
        player.meleeEnchant = 9;
    }
}