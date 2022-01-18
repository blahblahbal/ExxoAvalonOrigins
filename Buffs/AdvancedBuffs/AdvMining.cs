using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvMining : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Mining");
            Description.SetDefault("50% increased mining speed");
        }

        public override void Update(Player player, ref int k)
        {
            player.pickSpeed -= 0.5f;
        }
    }
}