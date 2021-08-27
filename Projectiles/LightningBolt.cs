using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.Localization;

namespace ExxoAvalonOrigins.Projectiles{	public class LightningBolt : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Lightning");		}		public override void SetDefaults()		{			projectile.width = 8;			projectile.height = 8;			projectile.scale = 1f;			projectile.alpha = 100;			projectile.aiStyle = -1;			projectile.timeLeft = 50;			projectile.friendly = true;			projectile.penetrate = 1;			projectile.light = 1f;			projectile.ignoreWater = true;			projectile.tileCollide = false;		}        public override void AI()        {            // Disgusting spaghetticode, my apologies. The checks I implemented for the lighning to make it always move down do not work always so if you want to give this a try, be my guest            if (projectile.scale == 1.0)
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
                if (Main.time % 6 <= 1 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int num54 = Projectile.NewProjectile(projectile.position, Vector2.Zero, ModContent.ProjectileType<LightningTrail>(), 60, 0f, projectile.owner);
                    Main.projectile[num54].rotation = projectile.rotation;
                    Main.projectile[num54].timeLeft = projectile.timeLeft;
                    projectile.rotation += (Main.rand.Next(200) - 100) / 100f;
                    projectile.velocity.Y = (float)Math.Sin(projectile.rotation) * 10;
                    projectile.velocity.X = (float)Math.Cos(projectile.rotation) * 10;

                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num54);
                    }
                }
            }
            if (((Main.rand.Next(15) == 0 && projectile.ai[0] > 0) || projectile.scale == 1.0) && projectile.scale > 0.4f)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    float randRot = projectile.rotation + Main.rand.Next(-100, 100) / 100f;
                    int lightning = Projectile.NewProjectile(projectile.position, Vector2.Zero, ModContent.ProjectileType<LightningBolt>(), 80, 0f, projectile.owner);
                    Projectile newLightning = Main.projectile[lightning];
                    newLightning.scale = projectile.scale * (Main.rand.Next(100) / 100f);
                    if (randRot < 2.5f)
                        newLightning.rotation = randRot - projectile.ai[1];
                    else if (randRot > -2.5f)
                        newLightning.rotation = randRot + projectile.ai[1];
                    Vector2 fakePos = projectile.position;
                    fakePos.X += (float)Math.Cos(projectile.rotation) * newLightning.scale * 48;
                    fakePos.Y += (float)Math.Sin(projectile.rotation) * newLightning.scale * 48;
                    fakePos.X += (float)Math.Cos(newLightning.rotation) * newLightning.scale * 48;
                    fakePos.Y += (float)Math.Sin(newLightning.rotation) * newLightning.scale * 48;
                    if (fakePos.Y >= projectile.localAI[1])
                    {
                        if (newLightning.rotation < 2.5f)
                        {
                            newLightning.rotation += 0.01f;
                        }
                        else if (newLightning.rotation > -2.5f)
                        {
                            newLightning.rotation -= 0.01f;
                        }
                        Main.NewText(newLightning.rotation);
                    }
                    else
                    {
                        newLightning.timeLeft = projectile.timeLeft;
                        newLightning.position.X += (float)Math.Cos(projectile.rotation) * newLightning.scale * 48;
                        newLightning.position.Y += (float)Math.Sin(projectile.rotation) * newLightning.scale * 48;
                        newLightning.position.X += (float)Math.Cos(newLightning.rotation) * newLightning.scale * 48;
                        newLightning.position.Y += (float)Math.Sin(newLightning.rotation) * newLightning.scale * 48;
                        newLightning.ai[0] = 10;
                        newLightning.ai[1] = randRot * 2;
                        newLightning.localAI[0] = projectile.position.X;
                        newLightning.localAI[1] = projectile.position.Y;
                    }

                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, lightning);
                    }
                }
            }
            projectile.ai[0]--;
            projectile.alpha = 255 - (projectile.timeLeft * 2) - (int)(25 * projectile.scale);
            if (projectile.alpha < 100) projectile.alpha = 0;
            //if (Main.tileSolid[Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].type] && Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].active)
            if (!Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].active())
            {
                projectile.tileCollide = true;
            }        }    }}