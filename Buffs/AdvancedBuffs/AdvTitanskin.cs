using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvTitanskin : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Advanced Titanskin");
            Description.SetDefault("Defense is increased by 20 and damage is reduced by 6%");
        }

        public override void Update(Player player, ref int k)
        {
            player.allDamage -= 0.06f;
            player.statDefense += 20;
        }
    }
}
