using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Rogue : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rogue");
            Description.SetDefault("-5% ranged damage, 20% chance to not consume ammo");
        }

        public override void Update(Player player, ref int k)
        {
            player.rangedDamage -= 0.05f;
            player.ammoCost80 = true;
        }
    }
}