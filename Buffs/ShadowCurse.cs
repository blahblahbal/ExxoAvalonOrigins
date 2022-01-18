using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class ShadowCurse : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shadow Curse");
            Description.SetDefault("You take double damage");
            Main.debuff[Type] = true;
            canBeCleared = false;
        }
    }
}