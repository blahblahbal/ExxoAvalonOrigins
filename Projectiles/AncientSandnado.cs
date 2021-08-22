using Microsoft.Xna.Framework;using Terraria;using Terraria.ModLoader;using Terraria.ID;using System;

namespace ExxoAvalonOrigins.Projectiles{	public class AncientSandnado : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Ancient's Sandstorm");		}		public override void SetDefaults()		{
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
			projectile.alpha = 255;
            projectile.timeLeft = 1200;
        }        public override void AI()        {
			float num998 = 900f;
			if (projectile.soundDelay == 0)
			{
				projectile.soundDelay = -1;
				Main.PlaySound(SoundID.Item82, projectile.Center);
			}
            foreach (NPC n in Main.npc)
            {
                float posX = projectile.Center.X;
                float posY = projectile.Center.Y;
                Point c = projectile.Center.ToTileCoordinates();
                while (!Main.tile[c.X, c.Y].active())
                {
                    c.Y++;
                    if (Main.tile[c.X, c.Y].active()) break;
                }
                Vector2 newPos = new Vector2(c.X, c.Y) * 16f;
                if (Math.Abs(Vector2.Distance(n.Center, newPos)) < 500f)
                {
                    if (!n.townNPC && !n.friendly && !n.dontTakeDamage && !n.boss)
                    {
                        n.velocity = Vector2.Normalize(n.position - newPos) * -4.5f;
                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, n.whoAmI);
                    }
                }
            }
            projectile.ai[0]++;
			if (projectile.ai[0] >= num998)
			{
				projectile.Kill();
			}
			if (projectile.localAI[0] >= 30f)
			{
				projectile.damage = 0;
				if (projectile.ai[0] < num998 - 120f)
				{
					float num999 = projectile.ai[0] % 60f;
					projectile.ai[0] = num998 - 120f + num999;
					projectile.netUpdate = true;
				}
			}
			float num1000 = 15f;
			float num1001 = 15f;
			Point point5 = projectile.Center.ToTileCoordinates();
			Collision.ExpandVertically(point5.X, point5.Y, out int topY, out int bottomY, (int)num1000, (int)num1001);
			topY++;
			bottomY--;
			Vector2 value68 = new Vector2(point5.X, topY) * 16f + new Vector2(8f);
			Vector2 value69 = new Vector2(point5.X, bottomY) * 16f + new Vector2(8f);
			Vector2 vector105 = Vector2.Lerp(value68, value69, 0.5f);
			Vector2 value70 = new Vector2(0f, value69.Y - value68.Y);
			value70.X = value70.Y * 0.2f;
			projectile.width = (int)(value70.X * 0.65f);
			projectile.height = (int)value70.Y;
			projectile.Center = vector105;
			if (projectile.owner == Main.myPlayer)
			{
				bool flag60 = false;
				Vector2 center13 = Main.player[projectile.owner].Center;
				Vector2 top = Main.player[projectile.owner].Top;
				for (float num1002 = 0f; num1002 < 1f; num1002 += 0.05f)
				{
					Vector2 position8 = Vector2.Lerp(value68, value69, num1002);
					if (Collision.CanHitLine(position8, 0, 0, center13, 0, 0) || Collision.CanHitLine(position8, 0, 0, top, 0, 0))
					{
						flag60 = true;
						break;
					}
				}
				if (!flag60 && projectile.ai[0] < num998 - 120f)
				{
					float num1003 = projectile.ai[0] % 60f;
					projectile.ai[0] = num998 - 120f + num1003;
					projectile.netUpdate = true;
				}
			}
			if (!(projectile.ai[0] < num998 - 120f))
			{
				return;
			}
			for (int num1004 = 0; num1004 < 1; num1004++)
			{
				float value71 = -0.5f;
				float value72 = 0.9f;
				float amount3 = Main.rand.NextFloat();
				Vector2 value73 = new Vector2(MathHelper.Lerp(0.1f, 1f, Main.rand.NextFloat()), MathHelper.Lerp(value71, value72, amount3));
				value73.X *= MathHelper.Lerp(2.2f, 0.6f, amount3);
				value73.X *= -1f;
				Vector2 value74 = new Vector2(6f, 10f);
				Vector2 position9 = vector105 + value70 * value73 * 0.5f + value74;
				Dust dust48 = Main.dust[Dust.NewDust(position9, 0, 0, 269)];
				dust48.position = position9;
				dust48.customData = vector105 + value74;
				dust48.fadeIn = 1f;
				dust48.scale = 0.3f;
				if (value73.X > -1.2f)
				{
					dust48.velocity.X = 1f + Main.rand.NextFloat();
				}
				dust48.velocity.Y = Main.rand.NextFloat() * -0.5f - 1f;
			}
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (damage > 0)
            {
				int healingAmount = damage / 20;
				Main.player[projectile.owner].statLife += healingAmount;
				Main.player[projectile.owner].HealEffect(healingAmount, true);
			}
        }    }}