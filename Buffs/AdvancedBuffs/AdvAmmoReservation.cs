using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvAmmoReservation : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Ammo Reservation");
        Description.SetDefault("30% chance to not consume ammo");
    }

    public override void Update(Player player, ref int k)
    {
        player.Avalon().advAmmoBuff = true;
    }
}