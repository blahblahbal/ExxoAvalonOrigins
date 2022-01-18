using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PulseLaser : ModProjectile
    {
        Vector2 End = new Vector2(0, 0);
        Vector2 StartReal = new Vector2(0, 0);
        float L = 0f;
        float L2 = 0f;
        bool Following = true;
        bool DrawLazer = true;
        float Lr = 0.5019f, Lg = 0.1922f, Lb = 0.5765f;
        float aLr = 1f, aLg = 1f, aLb = 1f;
        float Ds = 2f;
        int DT = 62;
        float dustSpeed = 4f;
        Color DC = Color.Purple;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pulse Laser");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/PulseLaser");
            projectile.width = dims.Width * 4 / 20;
            projectile.height = dims.Height * 4 / 20 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 7;
            projectile.light = 0.8f;
            projectile.alpha = 255;
            projectile.MaxUpdates = 2;
            projectile.scale = 1.2f;
            projectile.timeLeft = 600;
            projectile.magic = true;
            StartReal = projectile.position;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.penetrate == 7)
            {
                DrawChain(projectile.position, End, "", spriteBatch);
            }
            else if (projectile.penetrate > 1)
            {
                DrawChain(Main.npc[(int)projectile.ai[1]].Center, End, "", spriteBatch);
            }
        }

        public override void AI()
        {
            Projectile p = projectile;
            Player o = Main.player[projectile.owner];
            p.timeLeft = 200;

            if (p.penetrate < 7)
            {
                StartReal = Main.npc[(int)p.ai[1]].Center;
            }
            if (o.channel && Following)
            {
                L += 25f;
                float MaxLineLength = 2500;
                if (L > MaxLineLength) L = MaxLineLength;
            }
            else
            {
                p.tileCollide = true;
                Following = false;
                L2 += 25f;
                p.position = StartReal + new Vector2(L2 * p.velocity.X, L2 * p.velocity.Y);
            }
            p.position -= p.velocity;
            p.rotation = (float)Math.Atan2((p.velocity.Y), (p.velocity.X)) + (float)(Math.PI / 2);


            int npcIndex = -1;

            if (p.penetrate == 7)
            {
                // find closest npc to cursor
                if (ExxoAvalonOriginsGlobalNPC.FindClosest(new Vector2((Main.mouseX + Main.screenPosition.X), (Main.mouseY + Main.screenPosition.Y)), 128) != -1)
                {
                    // find closest npc to cursor
                    npcIndex = ExxoAvalonOriginsGlobalNPC.FindClosest(new Vector2((Main.mouseX + Main.screenPosition.X), (Main.mouseY + Main.screenPosition.Y)), 144);
                    // end is now the center of the closest npc to cursor
                    End = Main.npc[npcIndex].Center;
                    // find the closest npc to the end of the beam, excluding the current npc
                    int thing = ExxoAvalonOriginsGlobalNPC.FindClosestExcludeAnIndex(End, 144, npcIndex);
                    if (thing != -1)
                    {
                        Vector2 newVel = Vector2.Normalize(p.position - Main.npc[thing].position);
                        // spawn new projectile of the same type as current, incrementing ai[0] and setting ai[1]
                        // to the index of the npc we want to exclude
                        if (p.ai[0] == 0)
                        {
                            int proj = Projectile.NewProjectile(Main.npc[npcIndex].Center, newVel, p.type, p.damage, p.knockBack, ai1: thing);
                            Main.projectile[proj].penetrate--;
                            p.ai[0] = 1;
                        }
                        //End = Main.npc[thing].Center;
                    }
                }
                else End = new Vector2((Main.mouseX + Main.screenPosition.X), (Main.mouseY + Main.screenPosition.Y));
            }
            else if (p.penetrate > 1)
            {
                // find closest npc to cursor
                if (ExxoAvalonOriginsGlobalNPC.FindClosestExcludeAnIndex(Main.npc[(int)p.ai[1]].position, 128, (int)p.ai[1]) != -1)
                {
                    // find closest npc to cursor
                    npcIndex = ExxoAvalonOriginsGlobalNPC.FindClosestExcludeAnIndex(Main.npc[(int)p.ai[1]].position, 144, (int)p.ai[1]);
                    // end is now the center of the closest npc to cursor
                    End = Main.npc[npcIndex].Center;
                    // if beams 0-4
                    // find the closest npc to the end of the beam, excluding the current npc
                    int thing = ExxoAvalonOriginsGlobalNPC.FindClosestExcludeAnIndex(End, 144, npcIndex);
                    if (thing != -1)
                    {
                        Vector2 newVel = Vector2.Normalize(p.position - Main.npc[thing].position);
                        // spawn new projectile of the same type as current, incrementing ai[0] and setting ai[1]
                        // to the index of the npc we want to exclude
                        if (p.ai[0] == 0)
                        {
                            int proj = Projectile.NewProjectile(Main.npc[npcIndex].Center, newVel, p.type, p.damage, p.knockBack, ai1: thing);
                            Main.projectile[proj].penetrate--;
                            p.ai[0] = 1;
                        }
                        //End = Main.npc[thing].Center;
                    }
                }
            }
        }
        public void DrawChain(Vector2 start, Vector2 end, string name, SpriteBatch SP)
        {
            start -= Main.screenPosition;
            end -= Main.screenPosition;
            Texture2D TEX = ExxoAvalonOrigins.mod.GetTexture("Sprites/BeamVenoshock");
            int linklength = TEX.Height;
            Vector2 chain = end - start;

            float length = chain.Length();
            int numlinks = (int)Math.Ceiling(length / linklength);
            Vector2[] links = new Vector2[numlinks];
            float rotation = (float)Math.Atan2(chain.Y, chain.X);
            Projectile P = projectile;
            Player Pr = Main.player[P.owner];
            Player MyPr = Main.player[Main.myPlayer];
            for (int i = 0; i < numlinks; i++)
            {
                links[i] = start + chain / numlinks * i;
                Vector2 LR = links[i] + Main.screenPosition;
                Rectangle R = new Rectangle((int)LR.X, (int)LR.Y, P.width, P.height);
                #region Light
                Lighting.AddLight((int)((LR.X + P.width / 2) / 16f), (int)((LR.Y + P.height / 2) / 16f), Lr, Lg, Lb);
                #endregion
                #region Dust
                if (Main.rand.Next(100) == 0)
                {
                    Vector2 DP = LR - (new Vector2(TEX.Width / 2, linklength / 2));
                    Main.dust[Dust.NewDust(DP, 6, 6, DT, P.velocity.X * dustSpeed, P.velocity.Y * dustSpeed, 255, DC, Ds)].noGravity = true;
                    //Main.NewText("1 " + P.velocity.X + " 2 " + P.velocity.Y);
                }
                #endregion
                #region damage time - damage enemies and pvp players
                if (P.owner == Main.myPlayer && P.friendly)
                {
                    if (P.damage > 0)
                    {
                        for (int k = 0; k < Main.npc.Length; k++)
                        {
                            NPC N = Main.npc[k];
                            if (N.active && !N.dontTakeDamage && ((!N.friendly && P.friendly) || (N.friendly && P.hostile)) && (P.owner < 0 || N.immune[P.owner] == 0))
                            {
                                if (((N.noTileCollide || !P.ownerHitCheck || Collision.CanHit(Pr.position, Pr.width, Pr.height, N.position, N.width, N.height))))
                                {
                                    Rectangle NR = new Rectangle((int)N.position.X, (int)N.position.Y, N.width, N.height);
                                    if (R.Intersects(NR))
                                    {
                                        bool Crit = false;
                                        if (P.melee && Main.rand.Next(100) <= Pr.meleeCrit)
                                        {
                                            Crit = true;
                                        }
                                        if (P.ranged && Main.rand.Next(100) <= Pr.rangedCrit)
                                        {
                                            Crit = true;
                                        }
                                        if (P.magic && Main.rand.Next(100) <= Pr.magicCrit)
                                        {
                                            Crit = true;
                                        }
                                        int VEC_L1 = Main.DamageVar((float)P.damage);
                                        P.StatusNPC(k);
                                        N.StrikeNPC(VEC_L1, P.knockBack, P.direction, Crit, false);
                                        if (Main.netMode != 0)
                                        {
                                            if (Crit)
                                            {
                                                NetMessage.SendData(28, -1, -1, null, k, (float)VEC_L1, P.knockBack, (float)P.direction, 1);
                                            }
                                            else
                                            {
                                                NetMessage.SendData(28, -1, -1, null, k, (float)VEC_L1, P.knockBack, (float)P.direction, 0);
                                            }
                                        }
                                        if (P.penetrate != 1)
                                        {
                                            N.immune[P.owner] = 10;
                                        }
                                        if (P.penetrate > 0)
                                        {
                                            P.penetrate--;
                                            if (P.penetrate == 0)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (P.damage > 0 && MyPr.hostile)
                    {
                        for (int l = 0; l < Main.player.Length; l++)
                        {
                            Player PrL = Main.player[l];
                            if (l != P.owner && PrL.active && !PrL.dead && !PrL.immune && PrL.hostile && P.playerImmune[l] <= 0 && (MyPr.team == 0 || MyPr.team != PrL.team) && (!P.ownerHitCheck || Collision.CanHit(Pr.position, Pr.width, Pr.height, PrL.position, PrL.width, PrL.height)))
                            {
                                Rectangle RP = new Rectangle((int)PrL.position.X, (int)PrL.position.Y, PrL.width, PrL.height);
                                if (R.Intersects(RP))
                                {
                                    bool Crit = false;
                                    if (P.melee && Main.rand.Next(100) <= Pr.meleeCrit)
                                    {
                                        Crit = true;
                                    }
                                    if (P.ranged && Main.rand.Next(100) <= Pr.rangedCrit)
                                    {
                                        Crit = true;
                                    }
                                    if (P.magic && Main.rand.Next(100) <= Pr.magicCrit)
                                    {
                                        Crit = true;
                                    }
                                    int DMG = Main.DamageVar((float)P.damage);
                                    if (!PrL.immune)
                                    {
                                        P.StatusPvP(l);
                                    }
                                    PrL.Hurt(PlayerDeathReason.ByProjectile(PrL.whoAmI, P.whoAmI), DMG, P.direction);
                                    if (Main.netMode != 0)
                                    {
                                        if (Crit)
                                        {
                                            NetMessage.SendData(26, -1, -1, NetworkText.FromLiteral(PlayerDeathReason.ByProjectile(PrL.whoAmI, P.whoAmI).ToString()), l, P.direction, DMG, 1f, 1);
                                        }
                                        else
                                        {
                                            NetMessage.SendData(26, -1, -1, NetworkText.FromLiteral(PlayerDeathReason.ByProjectile(PrL.whoAmI, P.whoAmI).ToString()), l, P.direction, DMG, 1f, 0);
                                        }
                                    }
                                    P.playerImmune[l] = 40;
                                    if (P.penetrate > 0)
                                    {
                                        P.penetrate--;
                                        if (P.penetrate == 0)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                //Color color = Lighting.GetColor((int)((LR.X+Main.screenPosition.X)/16), (int)((LR.Y+Main.screenPosition.Y)/16));
                Color color = new Color(aLr, aLg, aLb);
                color.A = 255;
                if (DrawLazer)
                {
                    SP.Draw(TEX, links[i], new Rectangle(0, 0, TEX.Width, linklength), DC, rotation + 1.57f, new Vector2(TEX.Width / 2f, linklength), 1.1f, SpriteEffects.None, 1f);
                }
                int zx = (int)((LR.X + (float)(P.width / 2)) / 16f);
                int zy = (int)((LR.Y + (float)(P.height / 2)) / 16f);
                if (zx < 0) zx = 0;
                if (zy < 0) zy = 0;
                if (zx > Main.maxTilesX) zx = Main.maxTilesX;
                if (zy > Main.maxTilesY) zy = Main.maxTilesY;
                if (Main.tile[zx, zy].active() && Main.tileSolid[Main.tile[zx, zy].type]) return;
            }
        }
        //public override void AI()
        //{
        //    if (projectile.alpha < 170)
        //    {
        //        for (var num26 = 0; num26 < 10; num26++)
        //        {
        //            var x2 = projectile.position.X - projectile.velocity.X / 10f * num26;
        //            var y2 = projectile.position.Y - projectile.velocity.Y / 10f * num26;
        //            int num27;
        //            num27 = Dust.NewDust(new Vector2(x2, y2), 1, 1, DustID.Ice_Pink, 0f, 0f, 0, default(Color), 1f);
        //            Main.dust[num27].alpha = projectile.alpha;
        //            Main.dust[num27].position.X = x2;
        //            Main.dust[num27].position.Y = y2;
        //            Main.dust[num27].velocity *= 0f;
        //            Main.dust[num27].noGravity = true;
        //        }
        //    }
        //    var num28 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
        //    var num29 = projectile.localAI[0];
        //    if (num29 == 0f)
        //    {
        //        projectile.localAI[0] = num28;
        //        num29 = num28;
        //    }
        //    if (projectile.alpha > 0)
        //    {
        //        projectile.alpha -= 25;
        //    }
        //    if (projectile.alpha < 0)
        //    {
        //        projectile.alpha = 0;
        //    }
        //    var projPosStoredX = projectile.position.X;
        //    var projPosStoredY = projectile.position.Y;
        //    var distance = 300f;
        //    var flag = false;
        //    var npcArrayIndexStored = 0;
        //    if (projectile.ai[0] > 0)
        //    {
        //        projectile.ai[0]--;
        //        return;
        //    }
        //    if (projectile.ai[1] == 0f)
        //    {
        //        for (var npcArrayIndex = 0; npcArrayIndex < 200; npcArrayIndex++)
        //        {
        //            if (Main.npc[npcArrayIndex].active && !Main.npc[npcArrayIndex].dontTakeDamage && !Main.npc[npcArrayIndex].friendly && Main.npc[npcArrayIndex].lifeMax > 5 && (projectile.ai[1] == 0f || projectile.ai[1] == npcArrayIndex + 1))
        //            {
        //                var npcCenterX = Main.npc[npcArrayIndex].position.X + Main.npc[npcArrayIndex].width / 2;
        //                var npcCenterY = Main.npc[npcArrayIndex].position.Y + Main.npc[npcArrayIndex].height / 2;
        //                var num37 = Math.Abs(projectile.position.X + projectile.width / 2 - npcCenterX) + Math.Abs(projectile.position.Y + projectile.height / 2 - npcCenterY);
        //                if (num37 < distance && Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), 1, 1, Main.npc[npcArrayIndex].position, Main.npc[npcArrayIndex].width, Main.npc[npcArrayIndex].height))
        //                {
        //                    distance = num37;
        //                    projPosStoredX = npcCenterX;
        //                    projPosStoredY = npcCenterY;
        //                    flag = true;
        //                    npcArrayIndexStored = npcArrayIndex;
        //                }
        //            }
        //        }
        //        if (flag)
        //        {
        //            projectile.ai[1] = npcArrayIndexStored + 1;
        //        }
        //        flag = false;
        //    }
        //    //projectile.ai[0]--;
        //    //if (projectile.ai[0] != -1) return;
        //    if (projectile.ai[1] != 0f)
        //    {
        //        var npcArrayIndexAgain = (int)(projectile.ai[1] - 1f);
        //        if (Main.npc[npcArrayIndexAgain].active)
        //        {
        //            var npcCenterX = Main.npc[npcArrayIndexAgain].position.X + Main.npc[npcArrayIndexAgain].width / 2;
        //            var npcCenterY = Main.npc[npcArrayIndexAgain].position.Y + Main.npc[npcArrayIndexAgain].height / 2;
        //            var num41 = Math.Abs(projectile.position.X + projectile.width / 2 - npcCenterX) + Math.Abs(projectile.position.Y + projectile.height / 2 - npcCenterY);
        //            if (num41 < 1000f)
        //            {
        //                flag = true;
        //                projPosStoredX = Main.npc[npcArrayIndexAgain].position.X + Main.npc[npcArrayIndexAgain].width / 2;
        //                projPosStoredY = Main.npc[npcArrayIndexAgain].position.Y + Main.npc[npcArrayIndexAgain].height / 2;
        //            }
        //        }
        //    }
        //    if (flag)
        //    {
        //        var num42 = num29;
        //        var projCenter = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
        //        var num43 = projPosStoredX - projCenter.X;
        //        var num44 = projPosStoredY - projCenter.Y;
        //        var num45 = (float)Math.Sqrt(num43 * num43 + num44 * num44);
        //        num45 = num42 / num45;
        //        num43 *= num45;
        //        num44 *= num45;
        //        var num46 = 8;
        //        projectile.velocity.X = (projectile.velocity.X * (num46 - 1) + num43) / num46;
        //        projectile.velocity.Y = (projectile.velocity.Y * (num46 - 1) + num44) / num46;
        //    }
        //    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
        //    if (projectile.velocity.Y > 16f)
        //    {
        //        projectile.velocity.Y = 16f;
        //    }
        //}
        //public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        //{
        //    projectile.ai[0] = 20;
        //    projectile.velocity.Y = Main.rand.Next(-3, -2);
        //    int vel = Main.rand.Next(-6, 7);
        //    if (vel > -2 && vel <= 0) vel = -2;
        //    if (vel < 2 && vel > 0) vel = 2;
        //    projectile.velocity.X = vel;
        //}
    }
}
