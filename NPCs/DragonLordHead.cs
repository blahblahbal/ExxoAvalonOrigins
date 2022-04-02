using System;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.NPCs;

[AutoloadBossHead]
public class DragonLordHead : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dragon Lord");
        Main.npcFrameCount[NPC.type] = 1;
    }
    public bool head;
    public override void SetDefaults()
    {
        NPC.damage = 125;
        NPC.boss = true;
        NPC.scale = 1.3f;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 50000;
        NPC.defense = 40;
        NPC.noGravity = true;
        NPC.width = 32;
        NPC.aiStyle = -1;
        NPC.npcSlots = 6f;
        NPC.value = 100000f;
        NPC.gfxOffY = 25f;
        NPC.timeLeft = 3000;
        NPC.height = 32;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit7;
        NPC.DeathSound = SoundID.NPCDeath8;
        NPC.buffImmune[BuffID.Confused] = true;
        NPC.buffImmune[BuffID.CursedInferno] = true;
        NPC.buffImmune[BuffID.OnFire] = true;
        NPC.buffImmune[BuffID.Poisoned] = true;
        NPC.buffImmune[BuffID.Frostburn] = true;
        drawOffsetY = 55;
        bossBag = ModContent.ItemType<Items.BossBags.DragonLordBossBag>();
    }
    public override void BossLoot(ref string name, ref int potionType)
    {
        potionType = ModContent.ItemType<Items.Potions.ElixirofLife>();
    }
    public override Color? GetAlpha(Color drawColor)
    {
        return Color.White;
    }
    public override void BossHeadRotation(ref float rotation)
    {
        rotation = NPC.rotation;
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
            Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<DragonLordTrophy>(), 1, false, 0, false);
        }
        if (Main.expertMode)
        {
            NPC.DropBossBags();
        }
        else
        {
            int rand = Main.rand.Next(5);
            if (rand == 0) Item.NewItem(NPC.position, ModContent.ItemType<Items.Accessories.DragonStone>());
            else if (rand == 1) Item.NewItem(NPC.position, ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            else if (rand == 2) Item.NewItem(NPC.position, ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            else if (rand == 3) Item.NewItem(NPC.position, ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            else if (rand == 4) Item.NewItem(NPC.position, ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<DragonScale>(), Main.rand.Next(8, 16), false, 0, false);
        }

        if (!ExxoAvalonOriginsWorld.downedDragonLord)
            ExxoAvalonOriginsWorld.downedDragonLord = true;
    }

    public override void AI()
    {
        if (NPC.ai[3] > 0f)
        {
            NPC.realLife = (int)NPC.ai[3];
        }
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead)
        {
            NPC.TargetClosest(true);
        }
        if (Main.player[NPC.target].dead && NPC.timeLeft > 300)
        {
            NPC.timeLeft = 300;
        }
        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            if (NPC.ai[0] == 0f)
            {
                NPC.ai[3] = NPC.whoAmI;
                NPC.realLife = NPC.whoAmI;
                var num182 = NPC.whoAmI;
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
                    var num185 = NPC.NewNPC((int)(NPC.position.X + NPC.width / 2), (int)(NPC.position.Y + NPC.height), num184, NPC.whoAmI);
                    Main.npc[num185].ai[3] = NPC.whoAmI;
                    Main.npc[num185].realLife = NPC.whoAmI;
                    Main.npc[num185].ai[1] = num182;
                    Main.npc[num182].ai[0] = num185;
                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, NetworkText.FromLiteral(""), num185, 0f, 0f, 0f, 0);
                    num182 = num185;
                }
            }
            if (!Main.npc[(int)NPC.ai[0]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (!NPC.active && Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.DamageNPC, -1, -1, NetworkText.FromLiteral(""), NPC.whoAmI, -1f, 0f, 0f, 0);
            }
        }
        var num193 = (int)(NPC.position.X / 16f) - 1;
        var num194 = (int)((NPC.position.X + NPC.width) / 16f) + 2;
        var num195 = (int)(NPC.position.Y / 16f) - 1;
        var num196 = (int)((NPC.position.Y + NPC.height) / 16f) + 2;
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
            NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().dlBreath = true;
            SoundEngine.PlaySound(SoundID.Roar, -1, -1, 0);
        }
        if (NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().dlBreath)
        {
            int p = Projectile.NewProjectile(NPC.position.X + NPC.width / 2f, NPC.position.Y + NPC.height / 2f, NPC.velocity.X * 3f + Main.rand.Next(-2, 3), NPC.velocity.Y * 3f + Main.rand.Next(-2, 3), ProjectileID.FlamethrowerTrap, 75, 1.2f, 255, 0f, 0f);
            Main.projectile[p].hostile = true;
            Main.projectile[p].friendly = false;
            NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().breathCD--;
        }
        if (NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().breathCD <= 0)
        {
            NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().dlBreath = false;
            NPC.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().breathCD = 90;
            SoundEngine.PlaySound(SoundID.Item, -1, -1, 20);
        }
        if (NPC.velocity.X < 0f)
        {
            NPC.spriteDirection = 1;
        }
        else if (NPC.velocity.X > 0f)
        {
            NPC.spriteDirection = -1;
        }
        var num201 = 10f;
        var num202 = 0.25f;
        var vector21 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
        var num204 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2;
        var num205 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2;
        num204 = (int)(num204 / 16f) * 16;
        num205 = (int)(num205 / 16f) * 16;
        vector21.X = (int)(vector21.X / 16f) * 16;
        vector21.Y = (int)(vector21.Y / 16f) * 16;
        num204 -= vector21.X;
        num205 -= vector21.Y;
        var num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
        if (NPC.ai[1] > 0f && NPC.ai[1] < Main.npc.Length)
        {
            try
            {
                vector21 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                num204 = Main.npc[(int)NPC.ai[1]].position.X + Main.npc[(int)NPC.ai[1]].width / 2 - vector21.X;
                num205 = Main.npc[(int)NPC.ai[1]].position.Y + Main.npc[(int)NPC.ai[1]].height / 2 - vector21.Y;
            }
            catch
            {
            }
            NPC.rotation = (float)Math.Atan2(num205, num204) + 1.57f;
            num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
            var num207 = 42;
            num206 = (num206 - num207) / num206;
            num204 *= num206;
            num205 *= num206;
            NPC.velocity = Vector2.Zero;
            NPC.position.X = NPC.position.X + num204;
            NPC.position.Y = NPC.position.Y + num205;
            if (num204 < 0f)
            {
                NPC.spriteDirection = 1;
                return;
            }
            if (num204 > 0f)
            {
                NPC.spriteDirection = -1;
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
            if (((NPC.velocity.X > 0f && num204 < 0f) || (NPC.velocity.X < 0f && num204 > 0f) || (NPC.velocity.Y > 0f && num205 < 0f) || (NPC.velocity.Y < 0f && num205 > 0f)) && Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) > num202 / 2f && num206 < 300f)
            {
                flag21 = true;
                if (Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) < num201)
                {
                    NPC.velocity *= 1.1f;
                }
            }
            if (NPC.position.Y > Main.player[NPC.target].position.Y || Main.player[NPC.target].position.Y / 16f > Main.worldSurface || Main.player[NPC.target].dead)
            {
                flag21 = true;
                if (Math.Abs(NPC.velocity.X) < num201 / 2f)
                {
                    if (NPC.velocity.X == 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X - NPC.direction;
                    }
                    NPC.velocity.X = NPC.velocity.X * 1.1f;
                }
                else if (NPC.velocity.Y > -num201)
                {
                    NPC.velocity.Y = NPC.velocity.Y - num202;
                }
            }
            if (!flag21)
            {
                if ((NPC.velocity.X > 0f && num204 > 0f) || (NPC.velocity.X < 0f && num204 < 0f) || (NPC.velocity.Y > 0f && num205 > 0f) || (NPC.velocity.Y < 0f && num205 < 0f))
                {
                    if (NPC.velocity.X < num204)
                    {
                        NPC.velocity.X = NPC.velocity.X + num202;
                    }
                    else if (NPC.velocity.X > num204)
                    {
                        NPC.velocity.X = NPC.velocity.X - num202;
                    }
                    if (NPC.velocity.Y < num205)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + num202;
                    }
                    else if (NPC.velocity.Y > num205)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - num202;
                    }
                    if (Math.Abs(num205) < num201 * 0.2 && ((NPC.velocity.X > 0f && num204 < 0f) || (NPC.velocity.X < 0f && num204 > 0f)))
                    {
                        if (NPC.velocity.Y > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + num202 * 2f;
                        }
                        else
                        {
                            NPC.velocity.Y = NPC.velocity.Y - num202 * 2f;
                        }
                    }
                    if (Math.Abs(num204) < num201 * 0.2 && ((NPC.velocity.Y > 0f && num205 < 0f) || (NPC.velocity.Y < 0f && num205 > 0f)))
                    {
                        if (NPC.velocity.X > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + num202 * 2f;
                        }
                        else
                        {
                            NPC.velocity.X = NPC.velocity.X - num202 * 2f;
                        }
                    }
                }
                else if (num209 > num210)
                {
                    if (NPC.velocity.X < num204)
                    {
                        NPC.velocity.X = NPC.velocity.X + num202 * 1.1f;
                    }
                    else if (NPC.velocity.X > num204)
                    {
                        NPC.velocity.X = NPC.velocity.X - num202 * 1.1f;
                    }
                    if (Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) < num201 * 0.5)
                    {
                        if (NPC.velocity.Y > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + num202;
                        }
                        else
                        {
                            NPC.velocity.Y = NPC.velocity.Y - num202;
                        }
                    }
                }
                else
                {
                    if (NPC.velocity.Y < num205)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + num202 * 1.1f;
                    }
                    else if (NPC.velocity.Y > num205)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - num202 * 1.1f;
                    }
                    if (Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) < num201 * 0.5)
                    {
                        if (NPC.velocity.X > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + num202;
                        }
                        else
                        {
                            NPC.velocity.X = NPC.velocity.X - num202;
                        }
                    }
                }
            }
            NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) + 1.57f;
        }
    }
    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return head ? (bool?)null : false;
    }
}