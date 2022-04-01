using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvStrength : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Advanced Strength");
            Description.SetDefault("Increases stats");
        }

        public override void Update(Player player, ref int k)
        {
            player.allDamage += 0.13f;
            player.AllCrit(2);
            player.statDefense += 7;
            player.lifeRegen++;
            player.Avalon().critDamageMult += 0.1f;
        }
    }
}
