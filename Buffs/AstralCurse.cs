using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class AstralCurse : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Astral Curse");
            Description.SetDefault("You take triple damage");
        }

        //public override void Update(Player player, ref int k)
        //{        //    //player.GetModPlayer<ExxoAvalonOriginsModPlayer>().astralProject = true;
        //    player.immune = true;
        //    player.immuneAlpha = 100;
        //    player.noItems = true;

        //    foreach (NPC n in Main.npc)
        //    {
        //        if (player.getRect().Intersects(n.getRect()))
        //        {
        //            //n.AddBuff()
        //        }
        //    }
        //}
    }
}
