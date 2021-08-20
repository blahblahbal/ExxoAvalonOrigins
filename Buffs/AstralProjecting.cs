using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class AstralProjecting : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Astral Projecting");
            Description.SetDefault("You are immune to damage, but cannot attack anything - touch mobs to inflict a debuff on them");
        }

        public override void Update(Player player, ref int k)
        {
            player.immune = true;
            player.immuneAlpha = 130;
            player.noItems = true;
            player.thorns = 0f;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().astralCD = 0;

            foreach (NPC n in Main.npc)
            {
                if (n.townNPC || n.dontTakeDamage) continue;
                if (player.getRect().Intersects(n.getRect()))
                {
                    n.AddBuff(ModContent.BuffType<AstralCurse>(), 60 * 30);
                }
            }
        }
    }
}
