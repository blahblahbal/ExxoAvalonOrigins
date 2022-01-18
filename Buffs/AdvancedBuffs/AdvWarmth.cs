using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvWarmth : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Warmth");
            Description.SetDefault("Reduces damage from cold sources");
        }

        public override void Update(Player player, ref int k)
        {
            player.resistCold = true;
        }
    }
}