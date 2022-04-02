using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.NPCs;

[AutoloadBossHead]
public class DragonLordBody3 : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dragon Lord");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults()
    {
        NPC.damage = 100;
        NPC.boss = true;
        NPC.netAlways = true;
        NPC.scale = 1.3f;
        NPC.noTileCollide = true;
        NPC.lifeMax = 35000;
        NPC.defense = 50;
        NPC.noGravity = true;
        NPC.gfxOffY = 25f;
        NPC.width = 32;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = 100000f;
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
    }
    public override Color? GetAlpha(Color drawColor)
    {
        return Color.White;
    }
    public override void BossHeadRotation(ref float rotation)
    {
        rotation = NPC.rotation;
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
        var flag18 = true;
        if (!flag18)
        {
            for (var num197 = num193; num197 < num194; num197++)
            {
                for (var num198 = num195; num198 < num196; num198++)
                {
                    if (Main.tile[num197, num198] != null && ((Main.tile[num197, num198].HasUnactuatedTile && (Main.tileSolid[Main.tile[num197, num198].TileType] || (Main.tileSolidTop[Main.tile[num197, num198].TileType] && Main.tile[num197, num198].TileFrameY == 0))) || Main.tile[num197, num198].liquid > 64))
                    {
                        Vector2 vector20;
                        vector20.X = num197 * 16;
                        vector20.Y = num198 * 16;
                        if (NPC.position.X + NPC.width > vector20.X && NPC.position.X < vector20.X + 16f && NPC.position.Y + NPC.height > vector20.Y && NPC.position.Y < vector20.Y + 16f)
                        {
                            flag18 = true;
                            if (Main.rand.Next(100) == 0 && NPC.type != NPCID.LeechHead && Main.tile[num197, num198].HasUnactuatedTile)
                            {
                                WorldGen.KillTile(num197, num198, true, true, false);
                            }
                            if (Main.netMode != NetmodeID.MultiplayerClient && Main.tile[num197, num198].TileType == TileID.Grass)
                            {
                                var arg_CCAE_0 = Main.tile[num197, num198 - 1].TileType;
                            }
                        }
                    }
                }
            }
        }
        if (NPC.velocity.X < 0f)
        {
            NPC.spriteDirection = 1;
        }
        else if (NPC.velocity.X > 0f)
        {
            NPC.spriteDirection = -1;
        }
        var num201 = 8f;
        var num202 = 0.07f;
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
            if (!flag18)
            {
                NPC.TargetClosest(true);
                NPC.velocity.Y = NPC.velocity.Y + 0.11f;
                if (NPC.velocity.Y > num201)
                {
                    NPC.velocity.Y = num201;
                }
                if (Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) < num201 * 0.4)
                {
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X - num202 * 1.1f;
                    }
                    else
                    {
                        NPC.velocity.X = NPC.velocity.X + num202 * 1.1f;
                    }
                }
                else if (NPC.velocity.Y == num201)
                {
                    if (NPC.velocity.X < num204)
                    {
                        NPC.velocity.X = NPC.velocity.X + num202;
                    }
                    else if (NPC.velocity.X > num204)
                    {
                        NPC.velocity.X = NPC.velocity.X - num202;
                    }
                }
                else if (NPC.velocity.Y > 4f)
                {
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X + num202 * 0.9f;
                    }
                    else
                    {
                        NPC.velocity.X = NPC.velocity.X - num202 * 0.9f;
                    }
                }
            }
            else
            {
                if (NPC.soundDelay == 0)
                {
                    var num208 = num206 / 40f;
                    if (num208 < 10f)
                    {
                        num208 = 10f;
                    }
                    if (num208 > 20f)
                    {
                        num208 = 20f;
                    }
                    NPC.soundDelay = (int)num208;
                    SoundEngine.PlaySound(SoundID.Roar, (int)NPC.position.X, (int)NPC.position.Y, 1);
                }
                num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
                var num209 = Math.Abs(num204);
                var num210 = Math.Abs(num205);
                var num211 = num201 / num206;
                num204 *= num211;
                num205 *= num211;
                var flag21 = false;
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
            }
            NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) + 1.57f;
        }
    }
}