using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Luck : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luck");
            Description.SetDefault("Doubles rare drop chance");
        }

        public override void Update(Player player, ref int k)
        {
            player.Avalon().lucky = true;
            player.enemySpawns = true;
            player.Avalon().enemySpawns2 = true;
        }
    }
}