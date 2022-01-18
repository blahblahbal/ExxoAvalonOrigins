using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvWaterWalking : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Water Walking");
            Description.SetDefault("Press DOWN to enter water");
        }

        public override void Update(Player player, ref int k)
        {
            player.waterWalk = true;
        }
    }
}