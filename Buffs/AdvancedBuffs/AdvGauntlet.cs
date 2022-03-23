using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvGauntlet : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Gauntlet");
            Description.SetDefault("-10 defense, +18% melee damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.statDefense -= 10;
            player.meleeDamage += 0.18f;
        }
    }
}
