using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvTitan : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Titan");
            Description.SetDefault("Increases knockback");
        }

        public override void Update(Player player, ref int k)
        {
            player.kbBuff = true;
        }
    }
}