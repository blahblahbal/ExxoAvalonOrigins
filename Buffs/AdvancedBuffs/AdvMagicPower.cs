using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvMagicPower : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Magic Power");
            Description.SetDefault("30% increased magic damage");
        }

        public override void Update(Player player, ref int k)
        {
            player.magicDamage += 0.3f;
        }
    }
}
