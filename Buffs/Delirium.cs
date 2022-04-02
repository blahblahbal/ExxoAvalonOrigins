using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class Delirium : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Curse of Delirium");
        Description.SetDefault("Experiencing random bouts of confusion");
        Main.debuff[Type] = true;
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (Main.rand.Next(600) == 0)
        {
            player.Avalon().deliriumCount = Main.rand.Next(240, 481);
        }

        if (player.Avalon().deliriumCount > 0)
        {
            player.confused = true;
            player.Avalon().deliriumCount--;
        }
    }
}
