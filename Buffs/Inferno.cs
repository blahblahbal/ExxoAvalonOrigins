using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Inferno : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inferno");
            Description.SetDefault("Losing life");
            Main.debuff[Type] = true;
            canBeCleared = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen = -60;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC N2 = Main.npc[i];
                if (N2.townNPC || N2.friendly) continue;

                if (N2.getRect().Intersects(npc.getRect())) N2.AddBuff(ModContent.BuffType<Inferno>(), 540);
            }
            if (Main.rand.Next(5) == 0)
            {
                int num10 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Torch, 0f, 0f, 0, default(Color), 1.8f);
                Main.dust[num10].noGravity = true;
            }
        }
    }
}