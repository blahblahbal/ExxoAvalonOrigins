using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.NPCs
{
    [AutoloadBossHead]
	public class DragonLordHead : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Lord");
			Main.npcFrameCount[npc.type] = 1;
		}
        public bool head;
        public override void SetDefaults()
		{
			npc.damage = 125;
			npc.boss = true;
			npc.scale = 1.3f;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.lifeMax = 50000;
			npc.defense = 40;
			npc.noGravity = true;
			npc.width = 32;
			npc.aiStyle = -1;
			npc.npcSlots = 6f;
			npc.value = 100000f;
			npc.timeLeft = 3000;
			npc.height = 32;
			npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit7;
	        npc.DeathSound = SoundID.NPCDeath8;
            npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
            drawOffsetY = 55;
            bossBag = ModContent.ItemType<Items.BossBags.DragonLordBossBag>();
		}
        public override Color? GetAlpha(Color drawColor)
        {
            return Color.White;
        }
		public override void BossHeadRotation(ref float rotation)
		{
			rotation = npc.rotation;
		}
        /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/DragonLordHead");
            Vector2 vector2 = new Vector2(texture.Width / 2, texture.Height / Main.npcFrameCount[npc.type] / 2);
            Color color46 = Lighting.GetColor((int)((double)npc.position.X + (double)npc.width * 0.5) / 16, (int)(((double)npc.position.Y + (double)npc.height * 0.5) / 16.0));
            for (int num99 = 1; num99 < npc.oldPos.Length; num99++)
            {
                _ = ref npc.oldPos[num99];
                Color color24 = color46;
                color24.R = (byte)(0.5 * (double)(int)color24.R * (double)(10 - num99) / 20.0);
                color24.G = (byte)(0.5 * (double)(int)color24.G * (double)(10 - num99) / 20.0);
                color24.B = (byte)(0.5 * (double)(int)color24.B * (double)(10 - num99) / 20.0);
                color24.A = (byte)(0.5 * (double)(int)color24.A * (double)(10 - num99) / 20.0);
                spriteBatch.Draw(texture, new Vector2(npc.oldPos[num99].X - Main.screenPosition.X + (float)(npc.width / 2) - (float)texture.Width * npc.scale / 2f + vector2.X * npc.scale, npc.oldPos[num99].Y - Main.screenPosition.Y + (float)npc.height - (float)texture.Height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + vector2.Y * npc.scale), npc.frame, color24, npc.rotation, vector2, npc.scale, SpriteEffects.None, 0f);
            }
        }*/
        public override void NPCLoot()
		{
			if (Main.rand.Next(7) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DragonLordTrophy>(), 1, false, 0, false);
			}
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                int rand = Main.rand.Next(5);
                if (rand == 0) Item.NewItem(npc.position, ModContent.ItemType<Items.Accessories.DragonStone>());
                else if (rand == 1) Item.NewItem(npc.position, ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
                else if (rand == 2) Item.NewItem(npc.position, ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
                else if (rand == 3) Item.NewItem(npc.position, ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
                else if (rand == 4) Item.NewItem(npc.position, ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DragonScale>(), Main.rand.Next(8, 16), false, 0, false);
            }

            if (!ExxoAvalonOriginsWorld.downedDragonLord)
                ExxoAvalonOriginsWorld.downedDragonLord = true;
        }

        public override void AI()
        {
            if (npc.ai[3] > 0f)
            {
                npc.realLife = (int)npc.ai[3];
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
            {
                npc.timeLeft = 300;
            }
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (npc.ai[0] == 0f)
                {
                    npc.ai[3] = npc.whoAmI;
                    npc.realLife = npc.whoAmI;
                    var num182 = npc.whoAmI;
                    for (var num183 = 0; num183 < 13; num183++)
                    {
                        var num184 = ModContent.NPCType<DragonLordBody>();
                        if (num183 == 1 || num183 == 8)
                        {
                            num184 = ModContent.NPCType<DragonLordLegs>();
                        }
                        else if (num183 == 10)
                        {
                            num184 = ModContent.NPCType<DragonLordBody2>();
                        }
                        else if (num183 == 11)
                        {
                            num184 = ModContent.NPCType<DragonLordBody3>();
                        }
                        else if (num183 == 12)
                        {
                            num184 = ModContent.NPCType<DragonLordTail>();
                        }
                        var num185 = NPC.NewNPC((int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height), num184, npc.whoAmI);
                        Main.npc[num185].ai[3] = npc.whoAmI;
                        Main.npc[num185].realLife = npc.whoAmI;
                        Main.npc[num185].ai[1] = num182;
                        Main.npc[num182].ai[0] = num185;
                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, NetworkText.FromLiteral(""), num185, 0f, 0f, 0f, 0);
                        num182 = num185;
                    }
                }
                if (!Main.npc[(int)npc.ai[0]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
                if (!Main.npc[(int)npc.ai[1]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
                if (!npc.active && Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.StrikeNPC, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, -1f, 0f, 0f, 0);
                }
            }
            var num193 = (int)(npc.position.X / 16f) - 1;
            var num194 = (int)((npc.position.X + npc.width) / 16f) + 2;
            var num195 = (int)(npc.position.Y / 16f) - 1;
            var num196 = (int)((npc.position.Y + npc.height) / 16f) + 2;
            if (num193 < 0)
            {
                num193 = 0;
            }
            if (num194 > Main.maxTilesX)
            {
                num194 = Main.maxTilesX;
            }
            if (num195 < 0)
            {
                num195 = 0;
            }
            if (num196 > Main.maxTilesY)
            {
                num196 = Main.maxTilesY;
            }
            if (Main.rand.Next(275) == 0)
            {
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().dlBreath = true;
                Main.PlaySound(SoundID.Roar, -1, -1, 0);
            }
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().dlBreath)
            {
                int p = Projectile.NewProjectile(npc.position.X + npc.width / 2f, npc.position.Y + npc.height / 2f, npc.velocity.X * 3f + Main.rand.Next(-2, 3), npc.velocity.Y * 3f + Main.rand.Next(-2, 3), ProjectileID.FlamethrowerTrap, 75, 1.2f, 255, 0f, 0f);
                Main.projectile[p].hostile = true;
                Main.projectile[p].friendly = false;
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().breathCD--;
            }
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().breathCD <= 0)
            {
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().dlBreath = false;
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().breathCD = 90;
                Main.PlaySound(SoundID.Item, -1, -1, 20);
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = 1;
            }
            else if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = -1;
            }
            var num201 = 10f;
            var num202 = 0.25f;
            var vector21 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num204 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            var num205 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
            num204 = (int)(num204 / 16f) * 16;
            num205 = (int)(num205 / 16f) * 16;
            vector21.X = (int)(vector21.X / 16f) * 16;
            vector21.Y = (int)(vector21.Y / 16f) * 16;
            num204 -= vector21.X;
            num205 -= vector21.Y;
            var num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
            if (npc.ai[1] > 0f && npc.ai[1] < Main.npc.Length)
            {
                try
                {
                    vector21 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num204 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector21.X;
                    num205 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector21.Y;
                }
                catch
                {
                }
                npc.rotation = (float)Math.Atan2(num205, num204) + 1.57f;
                num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
                var num207 = 42;
                num206 = (num206 - num207) / num206;
                num204 *= num206;
                num205 *= num206;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num204;
                npc.position.Y = npc.position.Y + num205;
                if (num204 < 0f)
                {
                    npc.spriteDirection = 1;
                    return;
                }
                if (num204 > 0f)
                {
                    npc.spriteDirection = -1;
                    return;
                }
            }
            else
            {
                num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
                var num209 = Math.Abs(num204);
                var num210 = Math.Abs(num205);
                var num211 = num201 / num206;
                num204 *= num211;
                num205 *= num211;
                var flag21 = false;
                if (((npc.velocity.X > 0f && num204 < 0f) || (npc.velocity.X < 0f && num204 > 0f) || (npc.velocity.Y > 0f && num205 < 0f) || (npc.velocity.Y < 0f && num205 > 0f)) && Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) > num202 / 2f && num206 < 300f)
                {
                    flag21 = true;
                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num201)
                    {
                        npc.velocity *= 1.1f;
                    }
                }
                if (npc.position.Y > Main.player[npc.target].position.Y || Main.player[npc.target].position.Y / 16f > Main.worldSurface || Main.player[npc.target].dead)
                {
                    flag21 = true;
                    if (Math.Abs(npc.velocity.X) < num201 / 2f)
                    {
                        if (npc.velocity.X == 0f)
                        {
                            npc.velocity.X = npc.velocity.X - npc.direction;
                        }
                        npc.velocity.X = npc.velocity.X * 1.1f;
                    }
                    else if (npc.velocity.Y > -num201)
                    {
                        npc.velocity.Y = npc.velocity.Y - num202;
                    }
                }
                if (!flag21)
                {
                    if ((npc.velocity.X > 0f && num204 > 0f) || (npc.velocity.X < 0f && num204 < 0f) || (npc.velocity.Y > 0f && num205 > 0f) || (npc.velocity.Y < 0f && num205 < 0f))
                    {
                        if (npc.velocity.X < num204)
                        {
                            npc.velocity.X = npc.velocity.X + num202;
                        }
                        else if (npc.velocity.X > num204)
                        {
                            npc.velocity.X = npc.velocity.X - num202;
                        }
                        if (npc.velocity.Y < num205)
                        {
                            npc.velocity.Y = npc.velocity.Y + num202;
                        }
                        else if (npc.velocity.Y > num205)
                        {
                            npc.velocity.Y = npc.velocity.Y - num202;
                        }
                        if (Math.Abs(num205) < num201 * 0.2 && ((npc.velocity.X > 0f && num204 < 0f) || (npc.velocity.X < 0f && num204 > 0f)))
                        {
                            if (npc.velocity.Y > 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y + num202 * 2f;
                            }
                            else
                            {
                                npc.velocity.Y = npc.velocity.Y - num202 * 2f;
                            }
                        }
                        if (Math.Abs(num204) < num201 * 0.2 && ((npc.velocity.Y > 0f && num205 < 0f) || (npc.velocity.Y < 0f && num205 > 0f)))
                        {
                            if (npc.velocity.X > 0f)
                            {
                                npc.velocity.X = npc.velocity.X + num202 * 2f;
                            }
                            else
                            {
                                npc.velocity.X = npc.velocity.X - num202 * 2f;
                            }
                        }
                    }
                    else if (num209 > num210)
                    {
                        if (npc.velocity.X < num204)
                        {
                            npc.velocity.X = npc.velocity.X + num202 * 1.1f;
                        }
                        else if (npc.velocity.X > num204)
                        {
                            npc.velocity.X = npc.velocity.X - num202 * 1.1f;
                        }
                        if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num201 * 0.5)
                        {
                            if (npc.velocity.Y > 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y + num202;
                            }
                            else
                            {
                                npc.velocity.Y = npc.velocity.Y - num202;
                            }
                        }
                    }
                    else
                    {
                        if (npc.velocity.Y < num205)
                        {
                            npc.velocity.Y = npc.velocity.Y + num202 * 1.1f;
                        }
                        else if (npc.velocity.Y > num205)
                        {
                            npc.velocity.Y = npc.velocity.Y - num202 * 1.1f;
                        }
                        if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num201 * 0.5)
                        {
                            if (npc.velocity.X > 0f)
                            {
                                npc.velocity.X = npc.velocity.X + num202;
                            }
                            else
                            {
                                npc.velocity.X = npc.velocity.X - num202;
                            }
                        }
                    }
                }
                npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
            }
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return head ? (bool?)null : false;
        }
    }
}
