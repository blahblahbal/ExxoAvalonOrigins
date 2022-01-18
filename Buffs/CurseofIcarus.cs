using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class CurseofIcarus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Curse of Icarus");
            Description.SetDefault("'Your wings are broken'");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int k)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().curseOfIcarus = true;
        }
    }
}