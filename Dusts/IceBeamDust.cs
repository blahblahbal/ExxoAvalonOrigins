using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Dusts
{
    public class IceBeamDust : ModDust
    {
        public override bool Update(Dust dust)
        {
            foreach (NPC n in Main.npc)
            {
                if (n.getRect().Intersects(new Rectangle((int)dust.position.X, (int)dust.position.Y, 8, 8)))
                {
                    n.AddBuff(ModContent.BuffType<Buffs.IcySlowdown>(), 60 * 10);
                }
            }
            var lightFade = (dust.scale > 1 ? 1 : dust.scale);
            Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), (0.1f * lightFade), (0.1f * lightFade), (0.1f * lightFade));
            return true;
        }
        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color(255, 255, 255, 100);
        }
    }
}
