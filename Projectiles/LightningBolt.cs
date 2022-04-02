using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class LightningBolt : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lightning");
    }

    public override void SetDefaults()
    {
        Projectile.width = 8;
        Projectile.height = 8;
        Projectile.scale = 1f;
        Projectile.alpha = 100;
        Projectile.aiStyle = -1;
        Projectile.timeLeft = 50;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.light = 1f;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
    }
    public override void AI()
    {
        // Disgusting spaghetticode, my apologies. The checks I implemented for the lighning to make it always move down do not work always so if you want to give this a try, be my guest
        if (Projectile.scale == 1.0)
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
            if (Main.time % 6 <= 1 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                int num54 = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, Vector2.Zero, ModContent.ProjectileType<LightningTrail>(), 60, 0f, Projectile.owner);
                Main.projectile[num54].rotation = Projectile.rotation;
                Main.projectile[num54].timeLeft = Projectile.timeLeft;
                Projectile.rotation += (Main.rand.Next(200) - 100) / 100f;
                Projectile.velocity.Y = (float)Math.Sin(Projectile.rotation) * 10;
                Projectile.velocity.X = (float)Math.Cos(Projectile.rotation) * 10;

                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, num54);
                }
            }
        }
        if (((Main.rand.Next(15) == 0 && Projectile.ai[0] > 0) || Projectile.scale == 1.0) && Projectile.scale > 0.4f)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                float randRot = Projectile.rotation + Main.rand.NextFloat(-0.05f, 0.05f);
                int lightning = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, Vector2.Zero, ModContent.ProjectileType<LightningBolt>(), 80, 0f, Projectile.owner);
                Projectile newLightning = Main.projectile[lightning];
                newLightning.scale = Projectile.scale * (Main.rand.Next(100) / 100f);
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
                newLightning.timeLeft = Projectile.timeLeft;
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
                while (newLightning.position.Y < Projectile.position.Y + 160)
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
        Projectile.ai[0]--;
        Projectile.alpha = 255 - (Projectile.timeLeft * 2) - (int)(25 * Projectile.scale);
        if (Projectile.alpha < 100) Projectile.alpha = 0;
        //if (Main.tileSolid[Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].type] && Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].active)
        if (!Main.tile[(int)(Projectile.position.X / 16f), (int)(Projectile.position.Y / 16f)].HasTile)
        {
            Projectile.tileCollide = true;
        }
    }
}
