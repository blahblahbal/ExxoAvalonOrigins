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
            player.allDamage += 0.1f;
            player.AllCrit(1);
            player.statDefense += 5;
            player.lifeRegen++;
            player.Avalon().critDamageMult += 0.05f;
        }
    }
}
