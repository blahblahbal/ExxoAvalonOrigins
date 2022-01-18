using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvSwiftness : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Swiftness");
            Description.SetDefault("Increases stats");
        }

        public override void Update(Player player, ref int k)
        {
            player.moveSpeed += 0.5f;
        }
    }
}