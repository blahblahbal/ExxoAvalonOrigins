using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Luck : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Luck");
            Description.SetDefault("Doubles rare drop chance");
        }

        public override void Update(Player player, ref int k)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().lucky = true;
            player.enemySpawns = true;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().enemySpawns2 = true;
        }
    }
}