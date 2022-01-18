using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvWrath : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Wrath");
            Description.SetDefault("20% increased damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.magicDamage += 0.2f;
            player.rangedDamage += 0.2f;
            player.meleeDamage += 0.2f;
            player.thrownDamage += 0.2f;
        }
    }
}