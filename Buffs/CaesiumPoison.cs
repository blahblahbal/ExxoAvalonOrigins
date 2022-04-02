using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class CaesiumPoison : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Caesium Poisoning");
        Description.SetDefault("You are poisoned by the Caesium");
        Main.debuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.Avalon().caesiumPoison = true;
        player.blind = true;
    }
}