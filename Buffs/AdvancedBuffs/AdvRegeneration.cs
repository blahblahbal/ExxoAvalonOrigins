using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvRegeneration : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Regeneration");
        Description.SetDefault("Provides life regeneration");
    }

    public override void Update(Player player, ref int k)
    {
        player.lifeRegen += 3;
    }
}