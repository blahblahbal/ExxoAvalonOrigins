using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvCrate : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Crate");
        Description.SetDefault("Greater chance of fishing up a crate");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.Avalon().advCrateBuff = true;
    }
}
