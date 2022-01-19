using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class CrystalSpectre : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Spectre");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.damage = 105;
            npc.netAlways = true;
            npc.scale = 1f;
            npc.noTileCollide = true;
            npc.lifeMax = 3800;
            npc.defense = 50;
            npc.noGravity = true;
            npc.alpha = 50;
            npc.width = 24;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.timeLeft = 750;
            npc.height = 44;
            npc.HitSound = SoundID.NPCHit54;
            npc.DeathSound = SoundID.NPCDeath52;
            npc.knockBackResist = 0.05f;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            //banner = npc.type;
            //bannerItem = ModContent.ItemType<Items.Banners.CrystalSpectreBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.35f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
            npc.ai[3]++;
            if (npc.ai[3] >= 180)
            {

                if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].head))
                {
                    if (npc.ai[3] == 180 || npc.ai[3] == 300 || npc.ai[3] == 420 || npc.ai[3] == 540)
                    {
                        npc.velocity.X = 0f;
                        float speedX = npc.velocity.X + Main.rand.Next(-51, 51) * 0.1f;
                        float speedY = npc.velocity.Y + Main.rand.Next(-51, 51) * 0.1f;
                        Projectile.NewProjectile(npc.position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.CrystalBit>(), 0, 0, Main.myPlayer);
                    }
                }
                if (npc.ai[3] == 540) npc.ai[3] = 0;
            }
            if (npc.justHit)
            {
                npc.ai[2] = 0f;
            }
            if (npc.ai[2] >= 0f)
            {
                int num391 = 16;
                bool flag35 = false;
                bool flag36 = false;
                if (npc.position.X > npc.ai[0] - num391 && npc.position.X < npc.ai[0] + num391)
                {
                    flag35 = true;
                }
                else if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
                {
                    flag35 = true;
                }
                num391 += 24;
                if (npc.position.Y > npc.ai[1] - num391 && npc.position.Y < npc.ai[1] + num391)
                {
                    flag36 = true;
                }
                if (flag35 && flag36)
                {
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 60f)
                    {
                        npc.ai[2] = -200f;
                        npc.direction *= -1;
                        npc.velocity.X = npc.velocity.X * -1f;
                        npc.collideX = false;
                    }
                }
                else
                {
                    npc.ai[0] = npc.position.X;
                    npc.ai[1] = npc.position.Y;
                    npc.ai[2] = 0f;
                }
                npc.TargetClosest(true);
            }
            npc.ai[2]++;
            if (Main.player[npc.target].position.X + Main.player[npc.target].width / 2 > npc.position.X + npc.width / 2)
            {
                npc.direction = 1;
            }
            else
            {
                npc.direction = -1;
            }

            int num392 = (int)((npc.position.X + npc.width / 2) / 16f) + npc.direction * 2;
            int num393 = (int)((npc.position.Y + npc.height) / 16f);
            if (npc.collideX)
            {
                npc.velocity.X = npc.oldVelocity.X * -0.4f;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
                {
                    npc.velocity.X = 1f;
                }
                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
                {
                    npc.velocity.X = -1f;
                }
            }
            if (npc.collideY)
            {
                npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
                {
                    npc.velocity.Y = 1f;
                }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
                {
                    npc.velocity.Y = -1f;
                }
            }
            float num418 = 2f;
            if (npc.direction == -1 && npc.velocity.X > -num418)
            {
                npc.velocity.X = npc.velocity.X - 0.1f;
                if (npc.velocity.X > num418)
                {
                    npc.velocity.X = npc.velocity.X - 0.1f;
                }
                else if (npc.velocity.X > 0f)
                {
                    npc.velocity.X = npc.velocity.X + 0.05f;
                }
                if (npc.velocity.X < -num418)
                {
                    npc.velocity.X = -num418;
                }
            }
            else if (npc.direction == 1 && npc.velocity.X < num418)
            {
                npc.velocity.X = npc.velocity.X + 0.1f;
                if (npc.velocity.X < -num418)
                {
                    npc.velocity.X = npc.velocity.X + 0.1f;
                }
                else if (npc.velocity.X < 0f)
                {
                    npc.velocity.X = npc.velocity.X - 0.05f;
                }
                if (npc.velocity.X > num418)
                {
                    npc.velocity.X = num418;
                }
            }
            if (npc.directionY == -1 && npc.velocity.Y > -1.5)
            {
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if (npc.velocity.Y > 1.5)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.05f;
                }
                else if (npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.03f;
                }
                if (npc.velocity.Y < -1.5)
                {
                    npc.velocity.Y = -1.5f;
                }
            }
            else if (npc.directionY == 1 && npc.velocity.Y < 1.5)
            {
                npc.velocity.Y = npc.velocity.Y + 0.04f;
                if (npc.velocity.Y < -1.5)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.05f;
                }
                else if (npc.velocity.Y < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.03f;
                }
                if (npc.velocity.Y > 1.5)
                {
                    npc.velocity.Y = 1.5f;
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return !Main.dayTime && Main.hardMode && spawnInfo.player.Avalon().ZoneCrystal ? 0.5f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Placeable.Tile.CrystalStoneBlock>(), Main.rand.Next(10, 15));
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int num333 = 0; num333 < 20; num333++)
                {
                    int num334 = Dust.NewDust(npc.position, npc.width, npc.height, 54, 0f, 0f, 50, default, 1.5f);
                    Main.dust[num334].velocity *= 2f;
                    Main.dust[num334].noGravity = true;
                }
                int num335 = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y - 10f), new Vector2(hitDirection, 0f), 99, npc.scale);
                Main.gore[num335].velocity *= 0.3f;
                num335 = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y + npc.height / 2 - 15f), new Vector2(hitDirection, 0f), 99, npc.scale);
                Main.gore[num335].velocity *= 0.3f;
                num335 = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y + npc.height - 20f), new Vector2(hitDirection, 0f), 99, npc.scale);
                Main.gore[num335].velocity *= 0.3f;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = 1;
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;
            }
            npc.rotation = npc.velocity.X * 0.1f;
            if (npc.ai[3] < 180)
            {
                npc.frameCounter++;
                if (npc.frameCounter >= 6)
                {
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    npc.frameCounter = 0;
                }
                if (npc.frame.Y >= frameHeight * 4)
                {
                    npc.frame.Y = 0;
                }
            }
            else
            {
                npc.frameCounter++;
                if (npc.frameCounter <= 6)
                {
                    npc.frame.Y = 4 * frameHeight;
                }
                else if (npc.frameCounter <= 12)
                {
                    npc.frame.Y = 5 * frameHeight;
                }
                else if (npc.frameCounter <= 18)
                {
                    npc.frame.Y = 6 * frameHeight;
                }
                else if (npc.frameCounter <= 24)
                {
                    npc.frame.Y = 7 * frameHeight;
                    npc.frameCounter = 0;
                }
                if (npc.frame.Y >= frameHeight * 8)
                {
                    npc.frame.Y = frameHeight * 4;
                }
            }
        }
    }
}
