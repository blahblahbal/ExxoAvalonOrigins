using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvGauntlet : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Gauntlet");
            Description.SetDefault("-6 defense, +25% melee damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.statDefense -= 6;
            player.meleeDamage += 0.25f;
        }
    }
}