using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvManaRegeneration : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Mana Regeneration");
            Description.SetDefault("Increased mana regeneration");
        }

        public override void Update(Player player, ref int k)
        {
            player.manaRegenBuff = true;
        }
    }
}