using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class BloodCast : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blood Casting");
            Description.SetDefault("Maximum life is added to maximum mana");
        }

        public override void Update(Player player, ref int k)
        {
            player.Avalon().bloodCast = true;
        }
    }
}