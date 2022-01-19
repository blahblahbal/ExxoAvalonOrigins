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
            player.statDefense -= player.Avalon().fAlevel;
            if (player.Avalon().fAlastRecord <= player.buffTime[player.FindBuffIndex(149)])
            {
                player.Avalon().fAlastRecord = player.buffTime[player.FindBuffIndex(149)];
                if (player.Avalon().fAlevel < 30)
                {
                    player.Avalon().fAlevel++;
                }
            }
            //Main.buffTip[149] = "Decreased defense by " + player.GetModPlayer<ExxoAvalonOriginsGlobalPlayer>(mod).fAlevel;
        }
    }
}