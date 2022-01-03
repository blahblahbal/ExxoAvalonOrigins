using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class UnvolanditeMite : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unvolandite Mite");
		}
		public override void SetDefaults()
		{
			npc.damage = 77;
			npc.lifeMax = 1300;
			npc.defense = 6;
			npc.width = 18;
			npc.aiStyle = -1;
			npc.value = 10000f;
			npc.height = 40;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[BuffID.Confused] = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void NPCLoot()
        {
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/UnvolanditeMiteGore1"), npc.scale);
            Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/UnvolanditeMiteGore2"), npc.scale);
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
            npc.TargetClosest(true);
            npc.ai[2]++;
            if (npc.ai[2] >= 360 && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
            {
                int proj = Projectile.NewProjectile(npc.position, Vector2.Normalize(Main.player[npc.target].position - npc.position) * 7f, ProjectileID.Stinger, 65, 4f);
                npc.ai[2] = 0;
            }
            if (npc.ai[1] < 1200f)
            {
                npc.ai[1]++;
            }
            if (npc.ai[1] == 1200f && Main.netMode != 1)
            {
                npc.position.Y = npc.position.Y + 16f;
                npc.Transform(ModContent.NPCType<UnvolanditeMiteDigger>());
                npc.netUpdate = true;
                return;
            }
            if (npc.velocity.Y == 0f)
            {
                if (npc.ai[0] == 1f)
                {
                    if (npc.direction == 0)
                    {
                        npc.TargetClosest(true);
                    }
                    if (npc.collideX)
                    {
                        npc.direction *= -1;
                    }
                    npc.velocity.X = 0.2f * (float)npc.direction;
                    if (npc.type == ModContent.NPCType<UnvolanditeMite>())
                    {
                        npc.velocity.X = npc.velocity.X * 3f;
                    }
                }
                else
                {
                    npc.velocity.X = 0f;
                }
                if (Main.netMode != 1)
                {
                    npc.localAI[1] -= 1f;
                    if (npc.localAI[1] <= 0f)
                    {
                        if (npc.ai[0] == 1f)
                        {
                            npc.ai[0] = 0f;
                            npc.localAI[1] = Main.rand.Next(300, 900);
                        }
                        else
                        {
                            npc.ai[0] = 1f;
                            npc.localAI[1] = Main.rand.Next(600, 1800);
                        }
                        npc.netUpdate = true;
                    }
                }
            }
           
        }
    }
}
