using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Fury : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fury");
            Description.SetDefault("20% increased critical damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.Avalon().critDamageMult += 0.2f;
        }
    }
}