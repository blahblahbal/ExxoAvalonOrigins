using System;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class CaesiumStalker : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Caesium Stalker");
        Main.npcFrameCount[NPC.type] = 4;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            ImmuneToAllBuffsThatAreNotWhips = true
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }
    public override void SetDefaults()
    {
        NPC.damage = 73;
        NPC.scale = 1.2f;
        NPC.noTileCollide = false;
        NPC.lifeMax = 575;
        NPC.lavaImmune = true;
        NPC.defense = 44;
        NPC.noGravity = true;
        NPC.aiStyle = -1;
        NPC.width = 24;
        NPC.value = Item.buyPrice(0, 0, 45, 0);
        NPC.timeLeft = 750;
        NPC.knockBackResist = 0f;
        NPC.height = 32;
        for (int i = 0; i < NPC.buffImmune.Length; i++)
        {
            NPC.buffImmune[i] = true;
        }
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.CaesiumStalkerBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void OnKill()
    {
        if (Main.rand.Next(20) == 0)
        {
            Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.position, NPC.velocity, ModContent.ProjectileType<Projectiles.CaesiumGas>(), 0, 0);
        }
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.DownedAllMechBosses(), ModContent.ItemType<CaesiumOre>(), 10, 2, 5));
    }
    public override void AI()
    {
        NPC.netUpdate = true;
        NPC.ai[1] += 1f;
        NPC.TargetClosest(true);
        var player7 = Main.player[NPC.target];
        var num1221 = 0.022f;
        var num1222 = player7.position.X + player7.width / 2;
        var num1223 = player7.position.Y + player7.height / 2;
        var vector164 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
        num1222 = (int)(num1222 / 8f) * 8;
        num1223 = (int)(num1223 / 8f) * 8;
        vector164.X = (int)(vector164.X / 8f) * 8;
        vector164.Y = (int)(vector164.Y / 8f) * 8;
        num1222 -= vector164.X;
        num1223 -= vector164.Y;
        if (player7.position.X + 300f < NPC.position.X || player7.position.X - 300f > NPC.position.X || player7.position.Y + 300f < NPC.position.Y || player7.position.Y - 300f > NPC.position.Y)
        {
            if (player7.position.X + 300f < NPC.position.X)
            {
                if (NPC.velocity.X > -6f)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.2f;
                }
            }
            else if (player7.position.X - 300f > NPC.position.X && NPC.velocity.X < 6f)
            {
                NPC.velocity.X = NPC.velocity.X + 0.2f;
            }
            if (player7.position.Y + 300f < NPC.position.Y)
            {
                if (NPC.velocity.Y > -6f)
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.2f;
                }
            }
            else if (player7.position.Y - 300f > NPC.position.Y && NPC.velocity.Y < 6f)
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.2f;
            }
        }
        else
        {
            NPC.velocity.X = NPC.velocity.X * 0.95f;
            NPC.velocity.Y = NPC.velocity.Y * 0.95f;
            NPC.ai[2] += 1f;
            if (NPC.ai[2] == 60f)
            {
                NPC.ai[0] = Main.rand.Next(-7, 7);
                NPC.velocity.X = NPC.velocity.X + NPC.ai[0];
                NPC.velocity.Y = NPC.velocity.Y + NPC.ai[0];
                NPC.ai[2] = 0f;
            }
        }
        var vector165 = NPC.velocity;
        NPC.velocity = Collision.TileCollision(NPC.position, NPC.velocity, NPC.width, NPC.height, false, false, 1);
        if (NPC.velocity.X != vector165.X)
        {
            NPC.velocity.X = -vector165.X;
        }
        if (NPC.velocity.Y != vector165.Y)
        {
            NPC.velocity.Y = -vector165.Y;
        }
        NPC.rotation = (float)Math.Atan2(num1223, num1222) - 1.57f;
        var num1224 = 0.7f;
        if (NPC.collideX)
        {
            NPC.netUpdate = true;
            NPC.velocity.X = NPC.oldVelocity.X * -num1224;
            if (NPC.direction == -1 && NPC.velocity.X > 0f && NPC.velocity.X < 2f)
            {
                NPC.velocity.X = 2f;
            }
            if (NPC.direction == 1 && NPC.velocity.X < 0f && NPC.velocity.X > -2f)
            {
                NPC.velocity.X = -2f;
            }
        }
        if (NPC.collideY)
        {
            NPC.netUpdate = true;
            NPC.velocity.Y = NPC.oldVelocity.Y * -num1224;
            if (NPC.velocity.Y > 0f && NPC.velocity.Y < 1.5)
            {
                NPC.velocity.Y = 2f;
            }
            if (NPC.velocity.Y < 0f && NPC.velocity.Y > -1.5)
            {
                NPC.velocity.Y = -2f;
            }
        }
        if (Main.rand.Next(40) == 0)
        {
            var num1225 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + NPC.height * 0.25f), NPC.width, (int)(NPC.height * 0.5f), 110, NPC.velocity.X, 2f, 75, NPC.color, NPC.scale);
            var dust56 = Main.dust[num1225];
            dust56.noGravity = true;
            dust56.velocity.X = dust56.velocity.X * 0.5f;
            var dust57 = Main.dust[num1225];
            dust57.velocity.Y = dust57.velocity.Y * 0.1f;
        }
        if (NPC.wet && !NPC.lavaWet)
        {
            NPC.StrikeNPC(50, 0f, 0, false, false);
        }
        if (Main.netMode != NetmodeID.MultiplayerClient && !Main.player[NPC.target].dead)
        {
            if (NPC.justHit)
            {
                NPC.localAI[0] = 0f;
            }
            NPC.localAI[0] += 1f;
            if (NPC.localAI[0] == 180f)
            {
                if (Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                {
                    var mainproj = (float)Math.Atan2(NPC.Center.Y - (Main.player[NPC.target].Center.Y), NPC.Center.X - (Main.player[NPC.target].Center.X));
                    int p = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center.X, NPC.Center.Y, -(float)Math.Cos(mainproj), -(float)Math.Sin(mainproj), ModContent.ProjectileType<Projectiles.CaesiumSpike>(), 50, 1f, NPC.target, 0f, 0f);
                    Main.projectile[p].velocity *= 13f;
                    SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 8);
                }
                NPC.localAI[0] = 0f;
                NPC.localAI[1] = 0f;
            }
        }
        if (!Main.dayTime || !Main.player[NPC.target].dead)
        {
            return;
        }
        NPC.velocity.Y = NPC.velocity.Y - num1221 * 2f;
        if (NPC.timeLeft > 10)
        {
            NPC.timeLeft = 10;
        }
        if (((NPC.velocity.X > 0f && NPC.oldVelocity.X < 0f) || (NPC.velocity.X < 0f && NPC.oldVelocity.X > 0f) || (NPC.velocity.Y > 0f && NPC.oldVelocity.Y < 0f) || (NPC.velocity.Y < 0f && NPC.oldVelocity.Y > 0f)) && !NPC.justHit)
        {
            NPC.netUpdate = true;
            return;
        }
        return;
    }

    public override void FindFrame(int frameHeight)
    {
        /*if (npc.velocity.X > 0f)
        {
            npc.spriteDirection = 1;
        }
        if (npc.velocity.X < 0f)
        {
            npc.spriteDirection = -1;
        }*/
        NPC.rotation = NPC.velocity.X * 0.1f;
        /*if (npc.type == NPCID.Bee || npc.type == NPCID.BeeSmall) the hell is this lol
        {
            npc.frameCounter += 1.0;
            npc.rotation = npc.velocity.X * 0.2f;
        }*/
        NPC.frameCounter += 1.0;
        if (NPC.frameCounter >= 6.0)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            NPC.frameCounter = 0.0;
        }
        if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
        {
            NPC.frame.Y = 0;
        }
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life > 0)
        {
            SoundEngine.PlaySound(SoundID.NPCHit, (int)NPC.Center.X, (int)NPC.Center.Y, 4, 0.9f, -0.5f);
            SoundEngine.PlaySound(SoundID.Item, (int)NPC.Center.X, (int)NPC.Center.Y, 30, 0.2f, -0.5f);
            var rectangle = new Rectangle((int)NPC.position.X, (int)(NPC.position.Y + (NPC.height - NPC.width) / 2), NPC.width, NPC.width);
            for (var j = 1; j <= 25; j++)
            {
                var num11 = Dust.NewDust(NPC.position, rectangle.Width, rectangle.Height, 110, 0f, 0f, 100, default, 0.6f);
                Main.dust[num11].noGravity = true;
                Main.dust[num11].velocity *= 2.5f;
                Main.dust[num11].fadeIn = 1.1f;
            }
        }
        if (NPC.life <= 0)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)NPC.Center.X, (int)NPC.Center.Y, 27, 1.2f, -0.5f);
            SoundEngine.PlaySound(SoundID.NPCHit, (int)NPC.Center.X, (int)NPC.Center.Y, 5, 1f, -0.5f);
            Gore.NewGore(NPC.position, NPC.velocity * 0f, Mod.Find<ModGore>("Gores/StalkerGore1").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity * 0f, Mod.Find<ModGore>("Gores/StalkerGore2").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity * 0f, Mod.Find<ModGore>("Gores/StalkerGore3").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity * 0f, Mod.Find<ModGore>("Gores/StalkerGore4").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity * 0f, Mod.Find<ModGore>("Gores/StalkerGore5").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity * 0f, Mod.Find<ModGore>("Gores/StalkerGore5").Type, 1.2f);
            Gore.NewGore(NPC.position, NPC.velocity * 0f, Mod.Find<ModGore>("Gores/StalkerGore6").Type, 1.2f);
            /*for (int k = 0; k < 7; k++)
            {
                Vector2 value14 = new Vector2(Main.rand.Next(-10, 10), Main.rand.Next(-10, 10));
                value14.Normalize();
                value14 *= 13;
                int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, value14.X, value14.Y, ModContent.ProjectileType<Projectiles.CaesiumSpike>(), 50, 1f, npc.target, 0f);
                Main.projectile[p].timeLeft = 30;
            }*/
        }
    }
    int counter = 0;
    public override void PostDraw(SpriteBatch spriteBatch, Vector2 v, Color drawColor)
    {
        Texture2D texture = Mod.Assets.Request<Texture2D>("NPCs/CaesiumStalker").Value;
        Vector2 origin = new Vector2(texture.Width * 0.5f, NPC.height * 0.5f);
        Main.spriteBatch.Draw(texture, NPC.Center - v, NPC.frame, Color.White * ((255f - NPC.alpha) / 255f), NPC.rotation, origin, NPC.scale, SpriteEffects.None, 0);
        counter++;
        if (counter > 22)
            counter = 0;
        for (int j = 0; j < 2; j++)
        {
            float bonusAlphaMult = 1 - 1 * (counter / 12f);
            float dir = j * 2 - 1;
            Vector2 offset = new Vector2(counter * 0.8f * dir, 0).RotatedBy(NPC.rotation);
            Main.spriteBatch.Draw(texture, NPC.Center - v + offset, NPC.frame, new Color(100, 100, 100, 0) * bonusAlphaMult * ((255f - NPC.alpha) / 255f), NPC.rotation, origin, 1.00f, SpriteEffects.None, 0.0f);
        }
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneCaesium && spawnInfo.player.ZoneUnderworldHeight && !NPC.AnyNPCs(NPCID.WallofFlesh) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.WallofSteel>()))
            return 1f;
        return 0;
    }
}
