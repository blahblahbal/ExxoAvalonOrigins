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
		float acceleration;
		float maxVel;
		int movementPhase;
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
		}

		public override void SetDefaults()
		{
			npc.npcSlots = 150;
			animationType = NPCID.Hornet;
			npc.height = 174;
			npc.width = 88;
			npc.knockBackResist = 0f;
			npc.netAlways = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.value = 50000;
			npc.aiStyle = 5;
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
			movementPhase = 0;
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
			#region Old AI
			/*npc.ai[0]++;
			npc.ai[1]++;
			npc.rotation = 0f;
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
			{
				npc.TargetClosest(true);
			}
			if (npc.justHit)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, DustID.Vile, 0.2f, 0.2f, 100, default(Color), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, DustID.Vile, 0.2f, 0.2f, 100, default(Color), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, DustID.Vile, 0.2f, 0.2f, 100, default(Color), 1f);
			}
			if (npc.ai[1] < 300)
			{
				if (Main.player[npc.target].position.X < npc.position.X)
				{
					if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
				}

				if (Main.player[npc.target].position.X > npc.position.X)
				{
					if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
				}

				if (Main.player[npc.target].position.Y < npc.position.Y + 250)
				{
					if (npc.velocity.Y < 0)
					{
						if (npc.velocity.Y > -3) npc.velocity.Y -= 0.6f;
					}
					else npc.velocity.Y -= 0.5f;
				}

				if (Main.player[npc.target].position.Y > npc.position.Y + 250)
				{
					if (npc.velocity.Y > 0)
					{
						if (npc.velocity.Y < 4) npc.velocity.Y += 0.7f;
					}
					else npc.velocity.Y += 0.6f;
				}
			}
			else if (npc.ai[1] >= 300 && npc.ai[1] < 330)
			{
				npc.velocity.X *= 0.98f;
				npc.velocity.Y *= 0.98f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
				if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
				{
					float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					npc.velocity.X = (float)(Math.Cos(rotation) * 25) * -1;
					npc.velocity.Y = (float)(Math.Sin(rotation) * 25) * -1;
				}
			}
			else npc.ai[1] = 0;
			if (npc.ai[0] >= 120)
			{
				float Speed = 12f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
				int damage = 20;
				Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 17);
				float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), 55, damage, 0f, 0);
				npc.ai[0] = 0;
			}
			if (Main.player[npc.target].dead)
			{
				npc.velocity.Y -= 0.04f;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
					return;
				}
			}
			if (npc.life <= 0)
			{
				//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,16,18,"Stinger",209,false,2);
				//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,18,18,"Heart",58,false,10);
				//	Item.NewItem((int)npc.position.X,(int)npc.position.Y,20,26,"Lesser Healing Potion",28,false,7);
				//  Main.NewText("King Sting has been defeated!", 175, 75, 255);
			}*/
			#endregion

			if (phase == 0)
            {
				npc.TargetClosest();
				phase = 1;
            }

			Player player = Main.player[npc.target];

			if (player.dead || Vector2.Distance(npc.Center, player.Center) > 3000f)
			{
				npc.TargetClosest();
				if (player.dead || Vector2.Distance(npc.Center, player.Center) > 3000f)
				{
					if (npc.timeLeft > 10)
						npc.timeLeft = 10;
					npc.velocity.Y -= 0.04f;
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

			float lOrR = (npc.Center.X <= player.Center.X) ? 1 : (-1);
			npc.direction = npc.spriteDirection = (int)lOrR; // direction set to left or right

			switch (facingType)
			{
				case 1: // Face towards the player (capped angle)
					npc.rotation = npc.rotation.AngleLerp((player.Center - npc.Center).ToRotation(), 0.1f) * 0.08f;
					break;
				case 2: // Face towards the player (uncapped)
					npc.rotation = npc.rotation.AngleLerp((player.Center - npc.Center).ToRotation(), 0.1f);
					break;
				case 3: // Face towards velocity (capped angle)
					npc.rotation = npc.velocity.ToRotation() * 0.2f;
					break;
				case 4: // Face Upright
					if (npc.rotation != 0)
						npc.rotation += 0.06f;
					if (Math.Abs(npc.rotation) <= 0.1f)
						npc.rotation = 0;
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
					float speed = 20f;
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
					Projectile.NewProjectile(npc.Center, rotation * speed, ProjectileID.Stinger, 25, 1.5f, Main.myPlayer);
					attackTimer = 0;
                }

				if (masterTimer >= 360)
                {
					pickInit = false;
					attackType = 0;
                }
			}
			else if (attackType == 3)
			{
				attackTimer++;

				trueDestination = new Vector2(player.Center.X, player.Center.Y - 400f);
				destination = trueDestination;
				Vector2 desiredVelocity = npc.DirectionTo(destination) * maxVel;
				FlyTo(desiredVelocity, acceleration);

				if (Vector2.Distance(destination, npc.Center) < 100)
				{
					npc.velocity *= 0.98f;
					StandStillIfSlow(0.1f);
				}

				if (attackTimer >= 60)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Hornet);
					attackTimer = 0;
				}

				if (masterTimer >= 360)
				{
					pickInit = false;
					attackType = 0;
				}
			}
			else if (attackType == 4)
			{
				attackTimer++;

				trueDestination = new Vector2(player.Center.X, player.Center.Y - 400f);
				destination = trueDestination;
				Vector2 desiredVelocity = npc.DirectionTo(destination) * maxVel;
				FlyTo(desiredVelocity, acceleration);

				if (Vector2.Distance(destination, npc.Center) < 100)
				{
					npc.velocity *= 0.98f;
					StandStillIfSlow(0.1f);
				}

				if (attackTimer >= 120)
				{
					for (int i = 0; i < 3; i++)
					{
						Vector2 velocity = new Vector2(0f, Main.rand.NextFloat(-3f, -5f)).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-35, 36)));
						Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.DarkCinder>(), 30, 0.5f, npc.target);
					}
					attackTimer = 0;
				}

				if (masterTimer >= 360)
				{
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
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) // Not working? Not sure why it's not
		{
			if (afterImage)
			{
				Vector2 drawOrigin = Main.npcTexture[npc.type].Size() / new Vector2(2, (Main.npcFrameCount[npc.type] * 2));

				for (int i = 0; i < npc.oldPos.Length; i++)
				{
					Vector2 drawPos = npc.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, npc.gfxOffY);
					Color color = npc.GetAlpha(lightColor) * ((float)(npc.oldPos.Length - i) / (float)npc.oldPos.Length);
					spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, npc.frame, color, npc.rotation, drawOrigin, npc.scale, SpriteEffects.None, 0f);
				}
			}
			return true;
		}
	}
}