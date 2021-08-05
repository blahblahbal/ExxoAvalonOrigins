using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    internal class DragonLordHead : DragonLordWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/DragonLordHead";

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonLordHead"), 1f);
            }
        }

        public override void SetDefaults()
        {
            npc.damage = 110;
            npc.boss = true;
            npc.scale = 1.3f;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 35000;
            npc.defense = 50;
            npc.noGravity = true;
            npc.width = 32;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
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
        }

        public override void Init()
        {
            base.Init();
            head = true;
        }

        public override void CustomBehavior()
        {
            if (Main.rand.Next(275) == 0)
            {
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().dlBreath = true;
                Main.PlaySound(15, -1, -1, 0);
            }
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().dlBreath)
            {
                Projectile.NewProjectile(npc.position.X + npc.width / 2f, npc.position.Y + npc.height / 2f, npc.velocity.X * 3f + Main.rand.Next(-2, 3), npc.velocity.Y * 3f + Main.rand.Next(-2, 3), ProjectileID.FlamethrowerTrap, 75, 1.2f, 255, 0f, 0f);
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().breathCD--;
            }
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().breathCD <= 0)
            {
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().dlBreath = false;
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().breathCD = 90;
                Main.PlaySound(2, -1, -1, 20);
            }
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.DragonLordTrophy>(), 1, false, 0, false);
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.DragonScale>(), Main.rand.Next(5, 11), false, 0, false);
        }
    }

    internal class DragonLordBody : DragonLordWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/DragonLordBody";

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonLordBody"), 1f);
            }
        }

        public override void SetDefaults()
        {
            npc.damage = 100;
            npc.boss = true;
            npc.scale = 1.3f;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 35000;
            npc.defense = 50;
            npc.noGravity = true;
            npc.width = 32;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
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
        }
    }

    internal class DragonLordBody2 : DragonLordWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/DragonLordBody2";

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonLordBody2"), 1f);
            }
        }

        public override void SetDefaults()
        {
            npc.damage = 100;
            npc.boss = true;
            npc.scale = 1.3f;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 35000;
            npc.defense = 50;
            npc.noGravity = true;
            npc.width = 32;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
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
        }
        public override void Init()
        {
            base.Init();
            //body2 = true;
        }
    }

    internal class DragonLordBody3 : DragonLordWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/DragonLordBody3";

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonLordBody3"), 1f);
            }
        }

        public override void SetDefaults()
        {
            npc.damage = 100;
            npc.boss = true;
            npc.netAlways = true;
            npc.scale = 1.3f;
            npc.noTileCollide = true;
            npc.lifeMax = 35000;
            npc.defense = 50;
            npc.noGravity = true;
            npc.width = 32;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
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
        }
        public override void Init()
        {
            base.Init();
            //body3 = true;
        }
    }

    internal class DragonLordLegs : DragonLordWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/DragonLordLegs";

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonLordLegs"), 1f);
            }
        }

        public override void SetDefaults()
        {
            npc.damage = 100;
            npc.boss = true;
            npc.scale = 1.3f;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 35000;
            npc.defense = 45;
            npc.noGravity = true;
            npc.width = 32;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
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
        }
        public override void Init()
        {
            base.Init();
            //legs = true;
        }
    }

    internal class DragonLordTail : DragonLordWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/DragonLordTail";

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonLordTail"), 1f);
            }
        }

        public override void SetDefaults()
        {
            npc.damage = 160;
            npc.boss = true;
            npc.netAlways = true;
            npc.scale = 1.3f;
            npc.noTileCollide = true;
            npc.lifeMax = 35000;
            npc.defense = 10;
            npc.noGravity = true;
            npc.width = 32;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
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
        }

        public override void Init()
        {
            base.Init();
            tail = true;
        }
    }

    // I made this 2nd base class to limit code repetition.
    public abstract class DragonLordWorm : Worm
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Lord");
        }

        public override void Init()
        {
            minLength = 12;
            maxLength = 12;
            tailType = ModContent.NPCType<DragonLordTail>();
            bodyType = ModContent.NPCType<DragonLordBody>();
            headType = ModContent.NPCType<DragonLordHead>();
            speed = 7.5f;
            turnSpeed = 0.075f;
        }
    }

    //ported from my tAPI mod because I'm lazy
    // This abstract class can be used for non splitting worm type NPC.
    public abstract class DLWorm : ModNPC
    {
        /* ai[0] = follower
		 * ai[1] = following
		 * ai[2] = distanceFromTail
		 * ai[3] = head
		 */
        public bool head;
        public bool tail;
        public bool body2;
        public bool body3;
        public bool legs;
        private bool tailSpawned = false;
        public int minLength;
        public int maxLength;
        public int headType;
        public int bodyType;
        public int body2Type;
        public int body3Type;
        public int legsType;
        public int tailType;
        public bool flies = true;
        public bool directional = true;
        public float speed;
        public float turnSpeed;

        //public override void AI()
        //{
        //    if (Main.netMode != 1)
        //    {
        //        if (npc.type == headType && npc.ai[0] == 0f)
        //        {
        //            npc.ai[3] = npc.whoAmI;
        //            npc.realLife = npc.whoAmI;
        //            int num44 = 0;
        //            int num55 = npc.whoAmI;
        //            for (int k = 0; k < 13; k++)
        //            {
        //                int num58 = bodyType;
        //                switch (k)
        //                {
        //                    case 1:
        //                    case 8:
        //                        num58 = legsType;
        //                        break;
        //                    case 10:
        //                        num58 = body2Type;
        //                        break;
        //                    case 11:
        //                        num58 = body3Type;
        //                        break;
        //                    case 12:
        //                        num58 = tailType;
        //                        break;
        //                }
        //                num44 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), num58, npc.whoAmI);
        //                Main.npc[num44].ai[3] = npc.whoAmI;
        //                Main.npc[num44].realLife = npc.whoAmI;
        //                Main.npc[num44].ai[1] = num55;
        //                Main.npc[num55].ai[0] = num44;
        //                NetMessage.SendData(23, -1, -1, null, num44);
        //                num55 = num44;
        //            }
        //        }
        //        if (npc.type == bodyType || npc.type == body2Type || npc.type == body3Type || npc.type == legsType || npc.type == tailType)
        //        {
        //            if (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].aiStyle != npc.aiStyle)
        //            {
        //                npc.life = 0;
        //                npc.HitEffect();
        //                npc.active = false;
        //                NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f);
        //            }
        //        }
        //        if (npc.type == bodyType || npc.type == body2Type || npc.type == body3Type || npc.type == legsType || npc.type == headType)
        //        {
        //            if (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].aiStyle != npc.aiStyle)
        //            {
        //                npc.life = 0;
        //                npc.HitEffect();
        //                npc.active = false;
        //                NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f);
        //            }
        //        }
        //    }
            
        //    int num21 = (int)(npc.position.X / 16f) - 1;
        //    int num22 = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
        //    int num24 = (int)(npc.position.Y / 16f) - 1;
        //    int num25 = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
        //    if (num21 < 0)
        //    {
        //        num21 = 0;
        //    }
        //    if (num22 > Main.maxTilesX)
        //    {
        //        num22 = Main.maxTilesX;
        //    }
        //    if (num24 < 0)
        //    {
        //        num24 = 0;
        //    }
        //    if (num25 > Main.maxTilesY)
        //    {
        //        num25 = Main.maxTilesY;
        //    }
        //    //bool flag2 = true;
        //    if (npc.velocity.X < 0f)
        //    {
        //        npc.spriteDirection = 1;
        //    }
        //    else if (npc.velocity.X > 0f)
        //    {
        //        npc.spriteDirection = -1;
        //    }
        //    float num30 = 8f;
        //    float num31 = 0.07f;
        //    if (npc.type == headType)
        //    {
        //        num30 = 11f;
        //        num31 = 0.25f;
        //    }
        //    Vector2 vector2 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
        //    float num32 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
        //    float num34 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
        //    num32 = (int)(num32 / 16f) * 16;
        //    num34 = (int)(num34 / 16f) * 16;
        //    vector2.X = (int)(vector2.X / 16f) * 16;
        //    vector2.Y = (int)(vector2.Y / 16f) * 16;
        //    num32 -= vector2.X;
        //    num34 -= vector2.Y;
        //    float num47 = (float)Math.Sqrt(num32 * num32 + num34 * num34);
        //    if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
        //    {
        //        try
        //        {
        //            vector2 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
        //            num32 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector2.X;
        //            num34 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector2.Y;
        //        }
        //        catch
        //        {
        //        }
        //        npc.rotation = (float)Math.Atan2(num34, num32) + 1.57f;
        //        num47 = (float)Math.Sqrt(num32 * num32 + num34 * num34);
        //        int num48 = 42;
        //        num47 = (num47 - (float)num48) / num47;
        //        num32 *= num47;
        //        num34 *= num47;
        //        npc.velocity = Vector2.Zero;
        //        npc.position.X += num32;
        //        npc.position.Y += num34;
        //        if (num32 < 0f)
        //        {
        //            npc.spriteDirection = 1;
        //        }
        //        else if (num32 > 0f)
        //        {
        //            npc.spriteDirection = -1;
        //        }
        //        return;
        //    }
        //    num47 = (float)Math.Sqrt(num32 * num32 + num34 * num34);
        //    float num50 = Math.Abs(num32);
        //    float num51 = Math.Abs(num34);
        //    float num52 = num30 / num47;
        //    num32 *= num52;
        //    num34 *= num52;
        //    bool flag6 = false;
        //    if (npc.type == headType)
        //    {
        //        if (((npc.velocity.X > 0f && num32 < 0f) || (npc.velocity.X < 0f && num32 > 0f) || (npc.velocity.Y > 0f && num34 < 0f) || (npc.velocity.Y < 0f && num34 > 0f)) && Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) > num31 / 2f && num47 < 300f)
        //        {
        //            flag6 = true;
        //            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num30)
        //            {
        //                npc.velocity *= 1.1f;
        //            }
        //        }
        //        if (npc.position.Y > Main.player[npc.target].position.Y || Main.player[npc.target].dead)
        //        {
        //            flag6 = true;
        //            if (Math.Abs(npc.velocity.X) < num30 / 2f)
        //            {
        //                if (npc.velocity.X == 0f)
        //                {
        //                    npc.velocity.X -= npc.direction;
        //                }
        //                npc.velocity.X *= 1.1f;
        //            }
        //            else if (npc.velocity.Y > 0f - num30)
        //            {
        //                npc.velocity.Y -= num31;
        //            }
        //        }
        //    }
        //    if (!flag6)
        //    {
        //        if ((npc.velocity.X > 0f && num32 > 0f) || (npc.velocity.X < 0f && num32 < 0f) || (npc.velocity.Y > 0f && num34 > 0f) || (npc.velocity.Y < 0f && num34 < 0f))
        //        {
        //            if (npc.velocity.X < num32)
        //            {
        //                npc.velocity.X += num31;
        //            }
        //            else if (npc.velocity.X > num32)
        //            {
        //                npc.velocity.X -= num31;
        //            }
        //            if (npc.velocity.Y < num34)
        //            {
        //                npc.velocity.Y += num31;
        //            }
        //            else if (npc.velocity.Y > num34)
        //            {
        //                npc.velocity.Y -= num31;
        //            }
        //            if ((double)Math.Abs(num34) < (double)num30 * 0.2 && ((npc.velocity.X > 0f && num32 < 0f) || (npc.velocity.X < 0f && num32 > 0f)))
        //            {
        //                if (npc.velocity.Y > 0f)
        //                {
        //                    npc.velocity.Y += num31 * 2f;
        //                }
        //                else
        //                {
        //                    npc.velocity.Y -= num31 * 2f;
        //                }
        //            }
        //            if ((double)Math.Abs(num32) < (double)num30 * 0.2 && ((npc.velocity.Y > 0f && num34 < 0f) || (npc.velocity.Y < 0f && num34 > 0f)))
        //            {
        //                if (npc.velocity.X > 0f)
        //                {
        //                    npc.velocity.X += num31 * 2f;
        //                }
        //                else
        //                {
        //                    npc.velocity.X -= num31 * 2f;
        //                }
        //            }
        //        }
        //        else if (num50 > num51)
        //        {
        //            if (npc.velocity.X < num32)
        //            {
        //                npc.velocity.X += num31 * 1.1f;
        //            }
        //            else if (npc.velocity.X > num32)
        //            {
        //                npc.velocity.X -= num31 * 1.1f;
        //            }
        //            if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num30 * 0.5)
        //            {
        //                if (npc.velocity.Y > 0f)
        //                {
        //                    npc.velocity.Y += num31;
        //                }
        //                else
        //                {
        //                    npc.velocity.Y -= num31;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (npc.velocity.Y < num34)
        //            {
        //                npc.velocity.Y += num31 * 1.1f;
        //            }
        //            else if (npc.velocity.Y > num34)
        //            {
        //                npc.velocity.Y -= num31 * 1.1f;
        //            }
        //            if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num30 * 0.5)
        //            {
        //                if (npc.velocity.X > 0f)
        //                {
        //                    npc.velocity.X += num31;
        //                }
        //                else
        //                {
        //                    npc.velocity.X -= num31;
        //                }
        //            }
        //        }
        //    }
        //    npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
        //    CustomBehavior();
        //}

        //public override void AI()
        //{
        //    if (npc.localAI[1] == 0f)
        //    {
        //        npc.localAI[1] = 1f;
        //        Init();
        //    }
        //    if (npc.ai[3] > 0f)
        //    {
        //        npc.realLife = (int)npc.ai[3];
        //    }
        //    if (!head && npc.timeLeft < 300)
        //    {
        //        npc.timeLeft = 300;
        //    }
        //    if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
        //    {
        //        npc.TargetClosest(true);
        //    }
        //    if (Main.player[npc.target].dead && npc.timeLeft > 300)
        //    {
        //        npc.timeLeft = 300;
        //    }
        //    if (Main.netMode != NetmodeID.MultiplayerClient)
        //    {
        //        if (!tailSpawned && npc.ai[0] == 0f)
        //        {
        //            for (int i = 0; i < 13; i++)
        //            {
        //                if (i == 0)
        //                {
        //                    npc.ai[3] = (float)npc.whoAmI;
        //                    npc.realLife = npc.whoAmI;
        //                    npc.ai[2] = (float)Main.rand.Next(minLength, maxLength + 1);
        //                    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), headType, npc.whoAmI);
        //                }
        //                else if (i == 1 || i == 8)
        //                {
        //                    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), legsType, npc.whoAmI);
        //                }
        //                else if (i >= 2 && i <= 7 || i == 9)
        //                {
        //                    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), bodyType, npc.whoAmI);
        //                }
        //                else if (i == 10)
        //                {
        //                    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), body2Type, npc.whoAmI);
        //                }
        //                else if (i == 11)
        //                {
        //                    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), body3Type, npc.whoAmI);
        //                }
        //                else if (i == 12)
        //                {
        //                    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), tailType, npc.whoAmI);
        //                    tailSpawned = true;
        //                    break;
        //                }
        //                Main.npc[(int)npc.ai[0]].ai[3] = npc.ai[3];
        //                Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
        //                Main.npc[(int)npc.ai[0]].ai[1] = (float)npc.whoAmI;
        //                Main.npc[(int)npc.ai[0]].ai[2] = npc.ai[2] - 1f;
        //                npc.netUpdate = true;
        //            }
        //            //if (head)
        //            //{
        //            //    npc.ai[3] = (float)npc.whoAmI;
        //            //    npc.realLife = npc.whoAmI;
        //            //    npc.ai[2] = (float)Main.rand.Next(minLength, maxLength + 1);
        //            //    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), bodyType, npc.whoAmI);
        //            //}
        //            //else if (npc.ai[2] >= 2 && npc.ai[2] <= 7 || npc.ai[2] == 9)
        //            //{
        //            //    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), npc.type, npc.whoAmI);
        //            //}
        //            //else if (npc.ai[2] == 1 || npc.ai[2] == 8)
        //            //{
        //            //    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), legsType, npc.whoAmI);
        //            //}
        //            //else if (npc.ai[2] == 10)
        //            //{
        //            //    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), body2Type, npc.whoAmI);
        //            //}
        //            //else if (npc.ai[2] == 11)
        //            //{
        //            //    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), body3Type, npc.whoAmI);
        //            //}
        //            //else if (npc.ai[2] == 12)
        //            //{
        //            //    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), tailType, npc.whoAmI);
        //            //}
        //            //else
        //            //{
        //            //    npc.ai[0] = (float)NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + (float)npc.height), npc.type, npc.whoAmI);
        //            //}

        //        }
        //        if (!head && (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].type != headType && Main.npc[(int)npc.ai[1]].type != bodyType && Main.npc[(int)npc.ai[1]].type != body2Type && Main.npc[(int)npc.ai[1]].type != body3Type && Main.npc[(int)npc.ai[1]].type != legsType))
        //        {
        //            npc.life = 0;
        //            npc.HitEffect(0, 10.0);
        //            npc.active = false;
        //        }
        //        if (!tail && (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].type != bodyType && Main.npc[(int)npc.ai[0]].type != tailType && Main.npc[(int)npc.ai[0]].type != body2Type && Main.npc[(int)npc.ai[0]].type != body3Type && Main.npc[(int)npc.ai[0]].type != legsType))
        //        {
        //            npc.life = 0;
        //            npc.HitEffect(0, 10.0);
        //            npc.active = false;
        //        }
        //        if (!npc.active && Main.netMode == NetmodeID.Server)
        //        {
        //            NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
        //        }
        //    }
        //    int num180 = (int)(npc.position.X / 16f) - 1;
        //    int num181 = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
        //    int num182 = (int)(npc.position.Y / 16f) - 1;
        //    int num183 = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
        //    if (num180 < 0)
        //    {
        //        num180 = 0;
        //    }
        //    if (num181 > Main.maxTilesX)
        //    {
        //        num181 = Main.maxTilesX;
        //    }
        //    if (num182 < 0)
        //    {
        //        num182 = 0;
        //    }
        //    if (num183 > Main.maxTilesY)
        //    {
        //        num183 = Main.maxTilesY;
        //    }
        //    bool flag18 = flies;
        //    if (!flag18)
        //    {
        //        for (int num184 = num180; num184 < num181; num184++)
        //        {
        //            for (int num185 = num182; num185 < num183; num185++)
        //            {
        //                if (Main.tile[num184, num185] != null && (Main.tile[num184, num185].nactive() && (Main.tileSolid[(int)Main.tile[num184, num185].type] || Main.tileSolidTop[(int)Main.tile[num184, num185].type] && Main.tile[num184, num185].frameY == 0) || Main.tile[num184, num185].liquid > 64))
        //                {
        //                    Vector2 vector17;
        //                    vector17.X = (float)(num184 * 16);
        //                    vector17.Y = (float)(num185 * 16);
        //                    if (npc.position.X + (float)npc.width > vector17.X && npc.position.X < vector17.X + 16f && npc.position.Y + (float)npc.height > vector17.Y && npc.position.Y < vector17.Y + 16f)
        //                    {
        //                        flag18 = true;
        //                        if (Main.rand.NextBool(100) && npc.behindTiles && Main.tile[num184, num185].nactive())
        //                        {
        //                            WorldGen.KillTile(num184, num185, true, true, false);
        //                        }
        //                        if (Main.netMode != NetmodeID.MultiplayerClient && Main.tile[num184, num185].type == 2)
        //                        {
        //                            ushort arg_BFCA_0 = Main.tile[num184, num185 - 1].type;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (!flag18 && head)
        //    {
        //        Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
        //        int num186 = 1000;
        //        bool flag19 = true;
        //        for (int num187 = 0; num187 < 255; num187++)
        //        {
        //            if (Main.player[num187].active)
        //            {
        //                Rectangle rectangle2 = new Rectangle((int)Main.player[num187].position.X - num186, (int)Main.player[num187].position.Y - num186, num186 * 2, num186 * 2);
        //                if (rectangle.Intersects(rectangle2))
        //                {
        //                    flag19 = false;
        //                    break;
        //                }
        //            }
        //        }
        //        if (flag19)
        //        {
        //            flag18 = true;
        //        }
        //    }
        //    if (directional)
        //    {
        //        if (npc.velocity.X < 0f)
        //        {
        //            npc.spriteDirection = 1;
        //        }
        //        else if (npc.velocity.X > 0f)
        //        {
        //            npc.spriteDirection = -1;
        //        }
        //    }
        //    float num188 = speed;
        //    float num189 = turnSpeed;
        //    Vector2 vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
        //    float num191 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
        //    float num192 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
        //    num191 = (float)((int)(num191 / 16f) * 16);
        //    num192 = (float)((int)(num192 / 16f) * 16);
        //    vector18.X = (float)((int)(vector18.X / 16f) * 16);
        //    vector18.Y = (float)((int)(vector18.Y / 16f) * 16);
        //    num191 -= vector18.X;
        //    num192 -= vector18.Y;
        //    float num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
        //    if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
        //    {
        //        try
        //        {
        //            vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
        //            num191 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector18.X;
        //            num192 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector18.Y;
        //        }
        //        catch
        //        {
        //        }
        //        npc.rotation = (float)Math.Atan2((double)num192, (double)num191) + 1.57f;
        //        num193 = (float)Math.Sqrt((double)(num191 * num191 + num192 * num192));
        //        int num194 = npc.width;
        //        num193 = (num193 - (float)num194) / num193;
        //        num191 *= num193;
        //        num192 *= num193;
        //        npc.velocity = Vector2.Zero;
        //        npc.position.X = npc.position.X + num191;
        //        npc.position.Y = npc.position.Y + num192;
        //        if (directional)
        //        {
        //            if (num191 < 0f)
        //            {
        //                npc.spriteDirection = 1;
        //            }
        //            if (num191 > 0f)
        //            {
        //                npc.spriteDirection = -1;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (!flag18)
        //        {
        //            npc.TargetClosest(true);
        //            npc.velocity.Y = npc.velocity.Y + 0.11f;
        //            if (npc.velocity.Y > num188)
        //            {
        //                npc.velocity.Y = num188;
        //            }
        //            if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.4)
        //            {
        //                if (npc.velocity.X < 0f)
        //                {
        //                    npc.velocity.X = npc.velocity.X - num189 * 1.1f;
        //                }
        //                else
        //                {
        //                    npc.velocity.X = npc.velocity.X + num189 * 1.1f;
        //                }
        //            }
        //            else if (npc.velocity.Y == num188)
        //            {
        //                if (npc.velocity.X < num191)
        //                {
        //                    npc.velocity.X = npc.velocity.X + num189;
        //                }
        //                else if (npc.velocity.X > num191)
        //                {
        //                    npc.velocity.X = npc.velocity.X - num189;
        //                }
        //            }
        //            else if (npc.velocity.Y > 4f)
        //            {
        //                if (npc.velocity.X < 0f)
        //                {
        //                    npc.velocity.X = npc.velocity.X + num189 * 0.9f;
        //                }
        //                else
        //                {
        //                    npc.velocity.X = npc.velocity.X - num189 * 0.9f;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (!flies && npc.behindTiles && npc.soundDelay == 0)
        //            {
        //                float num195 = num193 / 40f;
        //                if (num195 < 10f)
        //                {
        //                    num195 = 10f;
        //                }
        //                if (num195 > 20f)
        //                {
        //                    num195 = 20f;
        //                }
        //                npc.soundDelay = (int)num195;
        //                Main.PlaySound(SoundID.Roar, npc.position, 1);
        //            }
        //            num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
        //            float num196 = System.Math.Abs(num191);
        //            float num197 = System.Math.Abs(num192);
        //            float num198 = num188 / num193;
        //            num191 *= num198;
        //            num192 *= num198;
        //            if (ShouldRun())
        //            {
        //                bool flag20 = true;
        //                for (int num199 = 0; num199 < 255; num199++)
        //                {
        //                    if (Main.player[num199].active && !Main.player[num199].dead && Main.player[num199].ZoneCorrupt)
        //                    {
        //                        flag20 = false;
        //                    }
        //                }
        //                if (flag20)
        //                {
        //                    if (Main.netMode != NetmodeID.MultiplayerClient && (double)(npc.position.Y / 16f) > (Main.rockLayer + (double)Main.maxTilesY) / 2.0)
        //                    {
        //                        npc.active = false;
        //                        int num200 = (int)npc.ai[0];
        //                        while (num200 > 0 && num200 < 200 && Main.npc[num200].active && Main.npc[num200].aiStyle == npc.aiStyle)
        //                        {
        //                            int num201 = (int)Main.npc[num200].ai[0];
        //                            Main.npc[num200].active = false;
        //                            npc.life = 0;
        //                            if (Main.netMode == NetmodeID.Server)
        //                            {
        //                                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num200, 0f, 0f, 0f, 0, 0, 0);
        //                            }
        //                            num200 = num201;
        //                        }
        //                        if (Main.netMode == NetmodeID.Server)
        //                        {
        //                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc.whoAmI, 0f, 0f, 0f, 0, 0, 0);
        //                        }
        //                    }
        //                    num191 = 0f;
        //                    num192 = num188;
        //                }
        //            }
        //            bool flag21 = false;
        //            if (npc.type == NPCID.WyvernHead)
        //            {
        //                if ((npc.velocity.X > 0f && num191 < 0f || npc.velocity.X < 0f && num191 > 0f || npc.velocity.Y > 0f && num192 < 0f || npc.velocity.Y < 0f && num192 > 0f) && System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y) > num189 / 2f && num193 < 300f)
        //                {
        //                    flag21 = true;
        //                    if (System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y) < num188)
        //                    {
        //                        npc.velocity *= 1.1f;
        //                    }
        //                }
        //                if (npc.position.Y > Main.player[npc.target].position.Y || (double)(Main.player[npc.target].position.Y / 16f) > Main.worldSurface || Main.player[npc.target].dead)
        //                {
        //                    flag21 = true;
        //                    if (System.Math.Abs(npc.velocity.X) < num188 / 2f)
        //                    {
        //                        if (npc.velocity.X == 0f)
        //                        {
        //                            npc.velocity.X = npc.velocity.X - (float)npc.direction;
        //                        }
        //                        npc.velocity.X = npc.velocity.X * 1.1f;
        //                    }
        //                    else
        //                    {
        //                        if (npc.velocity.Y > -num188)
        //                        {
        //                            npc.velocity.Y = npc.velocity.Y - num189;
        //                        }
        //                    }
        //                }
        //            }
        //            if (!flag21)
        //            {
        //                if (npc.velocity.X > 0f && num191 > 0f || npc.velocity.X < 0f && num191 < 0f || npc.velocity.Y > 0f && num192 > 0f || npc.velocity.Y < 0f && num192 < 0f)
        //                {
        //                    if (npc.velocity.X < num191)
        //                    {
        //                        npc.velocity.X = npc.velocity.X + num189;
        //                    }
        //                    else
        //                    {
        //                        if (npc.velocity.X > num191)
        //                        {
        //                            npc.velocity.X = npc.velocity.X - num189;
        //                        }
        //                    }
        //                    if (npc.velocity.Y < num192)
        //                    {
        //                        npc.velocity.Y = npc.velocity.Y + num189;
        //                    }
        //                    else
        //                    {
        //                        if (npc.velocity.Y > num192)
        //                        {
        //                            npc.velocity.Y = npc.velocity.Y - num189;
        //                        }
        //                    }
        //                    if ((double)System.Math.Abs(num192) < (double)num188 * 0.2 && (npc.velocity.X > 0f && num191 < 0f || npc.velocity.X < 0f && num191 > 0f))
        //                    {
        //                        if (npc.velocity.Y > 0f)
        //                        {
        //                            npc.velocity.Y = npc.velocity.Y + num189 * 2f;
        //                        }
        //                        else
        //                        {
        //                            npc.velocity.Y = npc.velocity.Y - num189 * 2f;
        //                        }
        //                    }
        //                    if ((double)System.Math.Abs(num191) < (double)num188 * 0.2 && (npc.velocity.Y > 0f && num192 < 0f || npc.velocity.Y < 0f && num192 > 0f))
        //                    {
        //                        if (npc.velocity.X > 0f)
        //                        {
        //                            npc.velocity.X = npc.velocity.X + num189 * 2f;
        //                        }
        //                        else
        //                        {
        //                            npc.velocity.X = npc.velocity.X - num189 * 2f;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (num196 > num197)
        //                    {
        //                        if (npc.velocity.X < num191)
        //                        {
        //                            npc.velocity.X = npc.velocity.X + num189 * 1.1f;
        //                        }
        //                        else if (npc.velocity.X > num191)
        //                        {
        //                            npc.velocity.X = npc.velocity.X - num189 * 1.1f;
        //                        }
        //                        if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.5)
        //                        {
        //                            if (npc.velocity.Y > 0f)
        //                            {
        //                                npc.velocity.Y = npc.velocity.Y + num189;
        //                            }
        //                            else
        //                            {
        //                                npc.velocity.Y = npc.velocity.Y - num189;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (npc.velocity.Y < num192)
        //                        {
        //                            npc.velocity.Y = npc.velocity.Y + num189 * 1.1f;
        //                        }
        //                        else if (npc.velocity.Y > num192)
        //                        {
        //                            npc.velocity.Y = npc.velocity.Y - num189 * 1.1f;
        //                        }
        //                        if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.5)
        //                        {
        //                            if (npc.velocity.X > 0f)
        //                            {
        //                                npc.velocity.X = npc.velocity.X + num189;
        //                            }
        //                            else
        //                            {
        //                                npc.velocity.X = npc.velocity.X - num189;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        npc.rotation = (float)System.Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;
        //        if (head)
        //        {
        //            if (flag18)
        //            {
        //                if (npc.localAI[0] != 1f)
        //                {
        //                    npc.netUpdate = true;
        //                }
        //                npc.localAI[0] = 1f;
        //            }
        //            else
        //            {
        //                if (npc.localAI[0] != 0f)
        //                {
        //                    npc.netUpdate = true;
        //                }
        //                npc.localAI[0] = 0f;
        //            }
        //            if ((npc.velocity.X > 0f && npc.oldVelocity.X < 0f || npc.velocity.X < 0f && npc.oldVelocity.X > 0f || npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f || npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f) && !npc.justHit)
        //            {
        //                npc.netUpdate = true;
        //                return;
        //            }
        //        }
        //    }
        //    CustomBehavior();
        //}

        public virtual void Init()
        {
        }

        public virtual bool ShouldRun()
        {
            return false;
        }

        public virtual void CustomBehavior()
        {
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return head ? (bool?)null : false;
        }
    }
}