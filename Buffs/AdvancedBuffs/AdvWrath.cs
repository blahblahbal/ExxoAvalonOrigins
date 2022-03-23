using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvWrath : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Wrath");
            Description.SetDefault("15% increased damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.allDamage += 0.15f;
        }
    }
}
