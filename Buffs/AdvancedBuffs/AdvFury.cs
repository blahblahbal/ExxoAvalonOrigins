using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvFury : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Fury");
            Description.SetDefault("30% increased critical damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.Avalon().critDamageMult += 0.3f;
        }
    }
}
