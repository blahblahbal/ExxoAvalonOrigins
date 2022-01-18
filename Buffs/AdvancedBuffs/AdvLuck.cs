using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvLuck : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Luck");
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