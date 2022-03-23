using ExxoAvalonOrigins.Items.Accessories;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Electrified : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Electrified");
            Description.SetDefault("Losing more life when moving");
            Main.debuff[Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            int minus = ((player.Avalon().duraShield && player.HasItemInArmor(ModContent.ItemType<DurataniumShield>())) ? 4 : (player.Avalon().duraShield ? 6 : 8));
            int minus2 = ((player.Avalon().duraShield && player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>())) ? 16 : (player.Avalon().duraShield ? 24 : 32));
            player.lifeRegen -= minus;
            if (player.velocity.X != 0)
            {
                player.lifeRegen -= minus2;
            }
        }
    }
}
