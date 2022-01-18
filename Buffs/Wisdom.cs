using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Wisdom : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wisdom");
            Description.SetDefault("-8% magic damage, +60 mana");
        }

        public override void Update(Player player, ref int k)
        {
            player.statManaMax2 += 60;
            player.magicDamage -= 0.08f;
        }
    }
}