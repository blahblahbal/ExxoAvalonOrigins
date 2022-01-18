using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvEndurance : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Endurance");
            Description.SetDefault("20% reduced damage taken");
        }

        public override void Update(Player player, ref int k)
        {
            player.endurance += 0.2f;
        }
    }
}