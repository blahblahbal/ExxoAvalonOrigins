using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class DarkInferno : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dark Inferno");
        Description.SetDefault("Losing life");
        Main.debuff[Type] = true;
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.Avalon().darkInferno = true;
    }
}
