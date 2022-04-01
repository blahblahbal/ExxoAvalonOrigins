using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class VorazylcumThorned : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vorazylcum Thorns");
            Description.SetDefault("Losing life");
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            player.lifeRegen -= 16;
        }
    }
}
