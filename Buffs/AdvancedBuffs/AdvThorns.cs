using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvThorns : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Thorns");
            Description.SetDefault("Attackers also take full damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.turtleArmor = true;
            player.thorns = 1f;
        }
    }
}