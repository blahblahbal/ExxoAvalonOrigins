using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvArchery : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Advanced Archery");
            Description.SetDefault("30% increased arrow speed and damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.Avalon().advArcheryBuff = true;
        }
    }
}