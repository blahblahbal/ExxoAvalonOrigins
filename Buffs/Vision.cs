using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Vision : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Vision");
            Description.SetDefault("Open caves light up");
        }

        public override void Update(Player player, ref int k)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().vision = true;
        }
    }
}