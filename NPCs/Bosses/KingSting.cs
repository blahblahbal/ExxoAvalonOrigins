using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.NPCs.Bosses
{
	public class KingSting : ModNPC
	{
		// Misc vars
		int phase;
		int masterTimer;

		// Movement vars
		bool dontContinue;
		bool dontFlip;
		float acceleration;
		float maxVel;
		int facingType;
		Vector2 trueDestination;
		Vector2 destination;

		// Attack vars
		bool pickInit;
		int attackType;
		int lastAttack;
		int attackList;
		int attackTimer;
		int attackCounter;
		int goSide;

		// VFX
		bool afterImage;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King Sting");
			Main.npcFrameCount[npc.type] = 3;

			NPCID.Sets.TrailCacheLength[npc.type] = 4;
			NPCID.Sets.TrailingMode[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.npcSlots = 150f;
			animationType = NPCID.Hornet;
			npc.height = 174;
			npc.width = 88;
			npc.knockBackResist = 0f;
			npc.netAlways = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.timeLeft = 1000;
			npc.value = 50000;
			npc.aiStyle = -1;
			npc.damage = 40;
			npc.defense = 15;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.boss = true;
			npc.lifeMax = 3400;
			npc.scale = 1;
			bossBag = ModContent.ItemType<Items.KingStingBossBag>();

			// Misc vars
			phase = 0;
			masterTimer = 0;

			// Movement vars
			dontContinue = false;
			dontFlip = false;
			facingType = 0;
			trueDestination = Vector2.Zero;
			destination = Vector2.Zero;

			// Projectile vars
			pickInit = false;
			acceleration = 0f;
			maxVel = 0f;
			attackType = 0;
			lastAttack = 0;
			attackList = 0;
			attackTimer = 0;
			attackCounter = 0;
			goSide = 0;

			//VFX
			afterImage = false;
		}
		public override void AI()
		{
			if (phase == 0)
            {
				npc.TargetClosest();
				phase = 1;
            }

			Player player = Main.player[npc.target];
			if (player.dead || !player.active)
			{
				npc.TargetClosest();
				if (player.dead || !player.active)
				{
					npc.velocity.Y = npc.velocity.Y - 0.04f;
					if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
						return;
					}
				}
			}

			if (npc.life <= npc.lifeMax / 2)
				phase = 2;

			if (Main.expertMode)
			{
				if (phase == 2)
				{
					acceleration = 1.5f;
					maxVel = 8f;
				}
				else
				{
					acceleration = 0.9f;
					maxVel = 6f;
				}
			}
			else
			{
				if (phase == 2)
				{
					acceleration = 0.9f;
					maxVel = 6f;
				}
				else
				{
					acceleration = 0.6f;
					maxVel = 5f;
				}
			}

			float lOrR = (npc.Center.X <= player.Center.X) ? 1 : (-1); // Based on pos
			float lOrR2 = (npc.velocity.X <= 0f) ? 1 : (-1); // Based on vel
			// 1 is left -1 is right

			if (!dontFlip)
			{
				if (facingType != 3)
					npc.direction = npc.spriteDirection = (int)lOrR;
				else
					npc.direction = npc.spriteDirection = (int)-lOrR2;
			}

			switch (facingType)
			{
				case 1: // Face towards the player (capped angle)
					npc.rotation = npc.rotation.AngleLerp((player.Center - npc.Center).ToRotation(), 0.1f) * -0.08f;
					break;
				case 2: // Face towards the player (uncapped)
					npc.rotation = npc.rotation.AngleLerp((player.Center - npc.Center).ToRotation(), 0.1f);
					break;
				case 3: // Face towards velocity (capped angle)
					npc.rotation = npc.velocity.X * 0.02f;
					break;
			}

			if (!dontContinue && attackType != 0)
				masterTimer++;

			if (attackType == 0)
            {
				SelectAttack(player);
				npc.velocity *= 0.98f;
				StandStillIfSlow(0.1f);
			}
			else if (attackType == 1)
            {
				attackTimer++;

				trueDestination = player.Center;
				if (npc.velocity == Vector2.Zero)
					facingType = 1;
				else
					facingType = 3;

				if (Math.Abs(npc.velocity.X) >= 6f || Math.Abs(npc.velocity.Y) >= 6f)
					afterImage = true;
				else
					afterImage = false;

				if (attackTimer >= 90)
                {
					float rotation = (float)Math.Atan2(npc.Center.Y - trueDestination.Y, npc.Center.X - trueDestination.X);
					float speed = 15f + maxVel;
					npc.velocity = new Vector2((float)Math.Cos(rotation) * speed, (float)Math.Sin(rotation) * speed) * -1f;
					attackCounter += 1;
					attackTimer = 0;
                }
				else
                {
					npc.velocity *= 0.98f;
					StandStillIfSlow(0.1f);
                }

				if (attackCounter >= 3 && attackTimer >= 45)
                {
					pickInit = false;
					afterImage = false;
					attackType = 0;
				}
            }
			else if (attackType == 2)
			{
				attackTimer++;

				facingType = 1;
				trueDestination = new Vector2(player.Center.X, player.Center.Y - 300f);
				Vector2[] points = 
				{
					new Vector2(trueDestination.X - 200, trueDestination.Y), 
					new Vector2(trueDestination.X + 200, trueDestination.Y)
				};

				if (goSide == 0)
				{
					destination = points[0];

					if (Vector2.Distance(destination, npc.Center) < 30)
						goSide = 1;
				}
				else
                {
					destination = points[1];

					if (Vector2.Distance(destination, npc.Center) < 30)
						goSide = 0;
				}

				Vector2 desiredVelocity = npc.DirectionTo(destination) * maxVel;
				FlyTo(desiredVelocity, acceleration);

				if (attackTimer >= 90)
                {
					Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 17);
					Vector2 rotation = (player.Center - npc.Center).SafeNormalize(-Vector2.UnitY);
					float speed = 8f;
					Projectile.NewProjectile(npc.Center, rotation * speed, ProjectileID.Stinger, 20, 1.5f, Main.myPlayer);
					attackTimer = 0;
                }

				if (masterTimer >= 360)
                {
					pickInit = false;
					attackType = 0;
                }
			}
			else if (attackType == 3 || attackType == 4)
			{
				attackTimer++;

				trueDestination = new Vector2(player.Center.X, player.Center.Y - 400f);
				destination = trueDestination;
				Vector2 desiredVelocity = npc.DirectionTo(destination) * maxVel;

				if (Vector2.Distance(destination, npc.Center) < 100)
				{
					dontFlip = true;
					npc.velocity *= 0.98f;
					StandStillIfSlow(0.2f);
				}
				else
                {
					FlyTo(desiredVelocity, acceleration);
					dontFlip = false;
				}

				if (attackType == 3)
				{
					if (attackTimer >= 60)
					{
						Vector2 velocity = new Vector2(Main.rand.Next(-100, 101) * 0.03f, Main.rand.Next(-100, 101) * 0.03f);
						int larvae = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NPCs.Larvae>(), default, default, default, default, default, npc.target);
						Main.npc[larvae].velocity = velocity;
						attackTimer = 0;
					}
				}
				else if (attackType == 4)
                {
					if (attackTimer >= 120)
					{
						for (int i = 0; i < 3; i++)
						{
							Vector2 velocity = new Vector2(0f, Main.rand.NextFloat(-3f, -5f)).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-35, 36)));
							Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.ToxinBall>(), 25, 0.5f, npc.target);
						}
						attackTimer = 0;
					}
				}

				if (masterTimer >= 360)
				{
					dontFlip = false;
					pickInit = false;
					attackType = 0;
				}
			}
		}
		public void FlyTo(Vector2 endpoint, float accel)
        {
			if (npc.velocity.X < endpoint.X)
			{
				npc.velocity.X += accel;
				if (npc.velocity.X < 0f && endpoint.X > 0f)
				{
					npc.velocity.X += accel;
				}
			}
			else if (npc.velocity.X > endpoint.X)
			{
				npc.velocity.X -= accel;
				if (npc.velocity.X > 0f && endpoint.X < 0f)
				{
					npc.velocity.X -= accel;
				}
			}
			if (npc.velocity.Y < endpoint.Y)
			{
				npc.velocity.Y += accel;
				if (npc.velocity.Y < 0f && endpoint.Y > 0f)
				{
					npc.velocity.Y += accel;
				}
			}
			else if (npc.velocity.Y > endpoint.Y)
			{
				npc.velocity.Y -= accel;
				if (npc.velocity.Y > 0f && endpoint.Y < 0f)
				{
					npc.velocity.Y -= accel;
				}
			}
		}
		public void StandStillIfSlow(float threshold)
		{
			if (Math.Abs(npc.velocity.X) <= threshold)
				npc.velocity.X = 0f;
			if (Math.Abs(npc.velocity.Y) <= threshold)
				npc.velocity.Y = 0f;
		}
		public void SelectAttack(Player player)
        {
			if (!pickInit)
            {
				int extraAttacks;
				if (Main.expertMode && phase == 2)
					extraAttacks = 2;
				else if (phase == 2)
					extraAttacks = 1;
				else
					extraAttacks = 0;

				attackList = Main.rand.Next(1, 3 + extraAttacks); // 1-2 in phase 1, 1-3 in phase 2 (1-4 in expert)

				pickInit = true;
			}

			if (attackList != lastAttack)
			{
				switch (attackList)
                {
					case 1: // Dashes at player
						trueDestination = player.Center;
						break;
					case 2: // Fire stingers
						goSide = 0;
						trueDestination = new Vector2(player.Center.X, player.Center.Y - 300f);
						break;
					case 3: // Spawn Larvae
						trueDestination = new Vector2(player.Center.X, player.Center.Y - 400f);
						break;
					case 4: // Splash Venom
						trueDestination = new Vector2(player.Center.X, player.Center.Y - 400f);
						break;
				}

				//npc.TargetClosest();
				attackCounter = 0;
				masterTimer = 0;
				attackTimer = 0;
				lastAttack = attackList;
				attackType = attackList;
			}
			else
			{
				pickInit = false;
			}
		}
        public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem(npc.position, ModContent.ItemType<Items.ToxinShard>(), Main.rand.Next(50, 81));
				if (Main.rand.Next(0, 10) < 3)
					Item.NewItem(npc.position, ItemID.BottledHoney, Main.rand.Next(5, 9));
				if (Main.rand.Next(0, 25) < 23)
					Item.NewItem(npc.position, ItemID.JestersArrow, Main.rand.Next(20, 31));
			}

			Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/KingStingHead"), 1f);
			Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/KingStingWing"), 1f);
			Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/KingStingBody"), 1f);
			Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/KingStingStinger"), 1f);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) // Not flipping? Not sure why it's not
		{
			if (afterImage)
			{
				Vector2 drawOrigin = Main.npcTexture[npc.type].Size() / new Vector2(2, (Main.npcFrameCount[npc.type] * 2));

				SpriteEffects spriteEffect;
				if (npc.spriteDirection == 1)
					spriteEffect = SpriteEffects.FlipHorizontally;
				else
					spriteEffect = SpriteEffects.None;

				for (int i = 0; i < npc.oldPos.Length; i++)
				{
					Vector2 drawPos = npc.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, npc.gfxOffY);
					Color color = npc.GetAlpha(lightColor) * ((float)(npc.oldPos.Length - i) / (float)npc.oldPos.Length);
					spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, npc.frame, color, npc.rotation, drawOrigin, npc.scale, spriteEffect, 0f);
				}
			}
			return true;
		}
	}
}