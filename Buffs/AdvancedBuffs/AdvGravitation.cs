using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvGravitation : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Gravitation");
            Description.SetDefault("Press UP to reverse gravity");
        }

        public override void Update(Player player, ref int k)
        {
            player.gravControl = true;
        }
    }
}