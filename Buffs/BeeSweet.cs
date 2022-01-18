using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class BeeSweet : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bee Sweet");
            Description.SetDefault("You are immune to Hornets");
        }

        public override void Update(Player player, ref int k)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().beeRepel = true;
        }
    }
}