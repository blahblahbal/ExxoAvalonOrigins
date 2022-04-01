using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Projectiles
{
	public class SpikyBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiky Ball");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/SpikyBall");
			Projectile.width = dims.Width * 8 / 16;
			Projectile.height = dims.Height * 8 / 16 / Main.projFrames[Projectile.type];
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.alpha = 0;
			Projectile.MaxUpdates = 1;
			Projectile.scale = 1f;
			Projectile.timeLeft = 300;
			Projectile.DamageType = DamageClass.Ranged;
            Projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
        }

		public override void AI()
		{
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 240)
            {

                Vector2 offset = new Vector2(Projectile.Center.X + 20, Projectile.Center.Y + 20);
                Vector2 offset2 = new Vector2(Projectile.Center.X - 20, Projectile.Center.Y - 20);
                Vector2 offset3 = new Vector2(Projectile.Center.X + 20, Projectile.Center.Y - 20);
                Vector2 offset4 = new Vector2(Projectile.Center.X - 20, Projectile.Center.Y + 20);
                float rotation = (float)Math.Atan2(Projectile.Center.Y - offset.Y, Projectile.Center.X - offset.X);
                float rotation2 = (float)Math.Atan2(Projectile.Center.Y - offset2.Y, Projectile.Center.X - offset2.X);
                float rotation3 = (float)Math.Atan2(Projectile.Center.Y - offset3.Y, Projectile.Center.X - offset3.X);
                float rotation4 = (float)Math.Atan2(Projectile.Center.Y - offset4.Y, Projectile.Center.X - offset4.X);
                float speed = 8f;
                int p;

                if (Projectile.ai[0] % 10 == 0)
                {
                    if (Projectile.ai[1] <= 7.2f)
                    {
                        p = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, (float)((Math.Cos(rotation - Projectile.ai[1]) * speed) * -1), (float)((Math.Sin(rotation - Projectile.ai[1]) * speed) * -1), ModContent.ProjectileType<Spike>(), 60, 0f);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        Main.projectile[p].owner = Projectile.owner;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, (float)((Math.Cos(rotation2 - Projectile.ai[1]) * speed) * -1), (float)((Math.Sin(rotation2 - Projectile.ai[1]) * speed) * -1), ModContent.ProjectileType<Spike>(), 60, 0f);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        Main.projectile[p].owner = Projectile.owner;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, (float)((Math.Cos(rotation3 - Projectile.ai[1]) * speed) * -1), (float)((Math.Sin(rotation3 - Projectile.ai[1]) * speed) * -1), ModContent.ProjectileType<Spike>(), 60, 0f);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        Main.projectile[p].owner = Projectile.owner;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, (float)((Math.Cos(rotation4 - Projectile.ai[1]) * speed) * -1), (float)((Math.Sin(rotation4 - Projectile.ai[1]) * speed) * -1), ModContent.ProjectileType<Spike>(), 60, 0f);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        Main.projectile[p].owner = Projectile.owner;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        if (Projectile.ai[1] >= 7.2f)
                        {
                            Projectile.ai[0] = 0;
                            Projectile.ai[1] = 0;
                        }
                    }
                    Projectile.ai[1] += .18f;
                }
            }
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
			if (Projectile.velocity.Y > 8f)
			{
				Projectile.velocity.Y = 8f;
			}
		}
	}
}
