using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Titanskin : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Titanskin");
            Description.SetDefault("Defense is increased by 15 and damage is reduced by 8%");
        }

        public override void Update(Player player, ref int k)
        {
            player.statDefense += 15;
            player.magicDamage -= 0.08f;
            player.rangedDamage -= 0.08f;
            player.meleeDamage -= 0.08f;
            player.minionDamage -= 0.08f;
        }
    }
}