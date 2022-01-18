using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class FracturingArmor : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fracturing Armor");
            Description.SetDefault("Defense is decreased by 0");
            Main.debuff[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int k)
        {
            player.statDefense -= player.GetModPlayer<ExxoAvalonOriginsModPlayer>().fAlevel;
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().fAlastRecord <= player.buffTime[player.FindBuffIndex(149)])
            {
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().fAlastRecord = player.buffTime[player.FindBuffIndex(149)];
                if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().fAlevel < 30)
                {
                    player.GetModPlayer<ExxoAvalonOriginsModPlayer>().fAlevel++;
                }
            }
            //Main.buffTip[149] = "Decreased defense by " + player.GetModPlayer<ExxoAvalonOriginsGlobalPlayer>(mod).fAlevel;
        }
    }
}