using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvIronskin : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Ironskin");
            Description.SetDefault("Increases defense by 12");
        }

        public override void Update(Player player, ref int k)
        {
            player.statDefense += 12;
        }
    }
}
