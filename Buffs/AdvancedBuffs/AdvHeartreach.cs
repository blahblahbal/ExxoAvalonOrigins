using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvHeartreach : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Heartreach");
            Description.SetDefault("Increased heart pickup range");
        }

        public override void Update(Player player, ref int k)
        {
            player.lifeMagnet = true;
        }
    }
}