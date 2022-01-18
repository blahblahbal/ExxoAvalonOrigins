using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Strong : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Strength");
            Description.SetDefault("Increased stats");
        }

        public override void Update(Player player, ref int k)
        {
            player.meleeDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.minionDamage += 0.1f;
            player.meleeCrit++;
            player.magicCrit++;
            player.rangedCrit++;
            player.statDefense += 5;
            player.lifeRegen++;
        }
    }
}