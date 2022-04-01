using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Melting : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Melting");
            Description.SetDefault("I'm melting...!");
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int k)
        {
            player.Avalon().melting = true;
        }
    }
}