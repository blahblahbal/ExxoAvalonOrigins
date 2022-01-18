using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvWisdom : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Wisdom");
            Description.SetDefault("-4% magic damage, +120 mana");
        }

        public override void Update(Player player, ref int k)
        {
            player.magicDamage -= 0.04f;
            player.statManaMax2 += 120;
        }
    }
}