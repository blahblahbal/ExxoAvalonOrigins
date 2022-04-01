using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Piercing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Piercing");
            Description.SetDefault("Projectile penetration is increased");
        }

        public override void Update(Player player, ref int k)
        {

        }
    }
}
