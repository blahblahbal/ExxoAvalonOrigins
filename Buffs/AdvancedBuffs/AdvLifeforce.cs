using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvLifeforce : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Lifeforce");
            Description.SetDefault("40% increased max life");
        }

        public override void Update(Player player, ref int k)
        {
            player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 5 / 20 * 40;
        }
    }
}