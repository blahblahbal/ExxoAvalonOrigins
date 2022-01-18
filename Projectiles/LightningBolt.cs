using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class LightningBolt : ModProjectile
    {
        float rot = 0f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.scale = 1f;
            projectile.alpha = 100;
            projectile.aiStyle = -1;
            projectile.timeLeft = 50;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.light = 1f;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            // Disgusting spaghetticode, my apologies. The checks I implemented for the lighning to make it always move down do not work always so if you want to give this a try, be my guest
            if (projectile.scale == 1.0)
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
            if (projectile.ai[0] == 10)
            {
                rot = MathHelper.PiOver2;
                projectile.ai[0]--;
                //Main.NewText(rot.ToString(), 255, 255, 0);
            }
            if (((Main.rand.Next(15) == 0 && projectile.ai[0] > 0) || projectile.scale == 1.0) && projectile.scale > 0.4f)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    float randRot = projectile.rotation + Main.rand.NextFloat(-0.05f, 0.05f);
                    int lightning = Projectile.NewProjectile(projectile.position, Vector2.Zero, ModContent.ProjectileType<LightningBolt>(), 80, 0f, projectile.owner);
                    Projectile newLightning = Main.projectile[lightning];
                    newLightning.scale = projectile.scale * (Main.rand.Next(100) / 100f);
                    //float r1 = Main.rand.NextFloat(0.05f, 0.2f);
                    newLightning.rotation = randRot;
                    //if (newLightning.rotation < rot + r1 && newLightning.rotation > 0.5f)
                    //    newLightning.rotation += 0.01f;
                    //else if (newLightning.rotation > -rot - r1 && newLightning.rotation < -0.5f)
                    //    newLightning.rotation -= 0.01f;

                    //Main.NewText(newLightning.rotation.ToString(), 100, 255, 100);
                    //Main.NewText(randRot.ToString(), 255, 255, 0);
                    //Main.NewText(projectile.rotation.ToString());

                    //Vector2 fakePos = projectile.position;
                    //fakePos.X += (float)Math.Cos(projectile.rotation) * newLightning.scale * 48;
                    //fakePos.Y += (float)Math.Sin(projectile.rotation) * newLightning.scale * 48;
                    //fakePos.X += (float)Math.Cos(newLightning.rotation) * newLightning.scale * 48;
                    //fakePos.Y += (float)Math.Sin(newLightning.rotation) * newLightning.scale * 48;

                    //Main.NewText(((int)(projectile.position.Y / 16)).ToString());

                    //Main.NewText(((int)(newLightning.position.Y / 16)).ToString(), 255, 255, 100);
                    //else
                    //{
                    newLightning.timeLeft = projectile.timeLeft;
                    //newLightning.position.X += (float)Math.Cos(projectile.rotation) * newLightning.scale * 48;
                    //newLightning.position.Y += Math.Abs((float)Math.Sin(projectile.rotation) * newLightning.scale * 48);
                    //newLightning.position.X += (float)Math.Cos(newLightning.rotation) * newLightning.scale * 48;
                    //newLightning.position.Y += Math.Abs((float)Math.Sin(newLightning.rotation) * newLightning.scale * 48);

                    //if (newLightning.position.X < projectile.position.X - 16)
                    //{
                    //    newLightning.position.X++;
                    //}
                    //if (newLightning.position.X > projectile.position.X + 16)
                    //{
                    //    newLightning.position.X--;
                    //}
                    while (newLightning.position.Y < projectile.position.Y + 160)
                    {
                        newLightning.position.Y += 10;
                    }
                    //newLightning.ai[0] = 10;
                    //newLightning.ai[1] = randRot * 2;
                    //newLightning.localAI[0] = projectile.position.X;
                    //newLightning.localAI[1] = projectile.position.Y;
                    //}

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
            }
        }
    }
}