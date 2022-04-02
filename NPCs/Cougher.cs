using System;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs;

public class Cougher : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cougher");
        Main.npcFrameCount[NPC.type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.damage = 35;
        NPC.lifeMax = 230;
        NPC.defense = 12;
        NPC.noGravity = true;
        NPC.width = 28;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = 510f;
        NPC.height = 38;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.knockBackResist = 0.3f;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.CougherBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<YuckyBit>(), 2));
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.Avalon().ZoneContagion && Main.hardMode && !spawnInfo.player.InPillarZone())
            return (spawnInfo.player.Avalon().ZoneContagion && Main.hardMode && !spawnInfo.player.InPillarZone()) ? 1f : 0f;
        return 0f;
    }
    public override void AI()
    {
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead)
        {
            NPC.TargetClosest(true);
        }
        var num146 = 4f;
        var num147 = 0.02f;
        var vector17 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
        var num149 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2;
        var num150 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2;
        num149 = (int)(num149 / 8f) * 8;
        num150 = (int)(num150 / 8f) * 8;
        vector17.X = (int)(vector17.X / 8f) * 8;
        vector17.Y = (int)(vector17.Y / 8f) * 8;
        num149 -= vector17.X;
        num150 -= vector17.Y;
        var num151 = (float)Math.Sqrt(num149 * num149 + num150 * num150);
        var num152 = num151;
        if (num151 == 0f)
        {
            num149 = NPC.velocity.X;
            num150 = NPC.velocity.Y;
        }
        else
        {
            num151 = num146 / num151;
            num149 *= num151;
            num150 *= num151;
        }
        if (num152 > 100f)
        {
            NPC.ai[0] += 1f;
            if (NPC.ai[0] > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.023f;
            }
            else
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.023f;
            }
            if (NPC.ai[0] < -100f || NPC.ai[0] > 100f)
            {
                NPC.velocity.X = NPC.velocity.X + 0.023f;
            }
            else
            {
                NPC.velocity.X = NPC.velocity.X - 0.023f;
            }
            if (NPC.ai[0] > 200f)
            {
                NPC.ai[0] = -200f;
            }
        }
        if (num152 < 150f && (NPC.type == NPCID.GoldMouse || NPC.type == NPCID.GoldWorm))
        {
            NPC.velocity.X = NPC.velocity.X + num149 * 0.007f;
            NPC.velocity.Y = NPC.velocity.Y + num150 * 0.007f;
        }
        if (Main.player[NPC.target].dead)
        {
            num149 = NPC.direction * num146 / 2f;
            num150 = -num146 / 2f;
        }
        if (NPC.velocity.X < num149)
        {
            NPC.velocity.X = NPC.velocity.X + num147;
            if (NPC.velocity.X < 0f && num149 > 0f)
            {
                NPC.velocity.X = NPC.velocity.X + num147;
            }
        }
        else if (NPC.velocity.X > num149)
        {
            NPC.velocity.X = NPC.velocity.X - num147;
            if (NPC.velocity.X > 0f && num149 < 0f)
            {
                NPC.velocity.X = NPC.velocity.X - num147;
            }
        }
        if (NPC.velocity.Y < num150)
        {
            NPC.velocity.Y = NPC.velocity.Y + num147;
            if (NPC.velocity.Y < 0f && num150 > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y + num147;
            }
        }
        else if (NPC.velocity.Y > num150)
        {
            NPC.velocity.Y = NPC.velocity.Y - num147;
            if (NPC.velocity.Y > 0f && num150 < 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y - num147;
            }
        }
        if (num149 > 0f)
        {
            NPC.spriteDirection = 1;
            //npc.rotation = (float)Math.Atan2(num150, num149);
        }
        else if (num149 < 0f)
        {
            NPC.spriteDirection = -1;
            //npc.rotation = (float)Math.Atan2(num150, num149) + 3.14f;
        }
        var num157 = 0.7f;
        if (NPC.collideX)
        {
            NPC.netUpdate = true;
            NPC.velocity.X = NPC.oldVelocity.X * -num157;
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
            NPC.velocity.Y = NPC.oldVelocity.Y * -num157;
            if (NPC.velocity.Y > 0f && NPC.velocity.Y < 1.5)
            {
                NPC.velocity.Y = 2f;
            }
            if (NPC.velocity.Y < 0f && NPC.velocity.Y > -1.5)
            {
                NPC.velocity.Y = -2f;
            }
        }
        else if (NPC.type == NPCID.VortexLarva)
        {
            var num159 = Dust.NewDust(new Vector2(NPC.position.X - NPC.velocity.X, NPC.position.Y - NPC.velocity.Y), NPC.width, NPC.height, DustID.MagicMirror, NPC.velocity.X * 0.2f, NPC.velocity.Y * 0.2f, 100, default(Color), 2f);
            Main.dust[num159].noGravity = true;
            var dust11 = Main.dust[num159];
            dust11.velocity.X = dust11.velocity.X * 0.3f;
            var dust12 = Main.dust[num159];
            dust12.velocity.Y = dust12.velocity.Y * 0.3f;
        }
        else if (Main.rand.Next(20) == 0)
        {
            var num160 = 18;
            var num161 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + NPC.height * 0.25f), NPC.width, (int)(NPC.height * 0.5f), num160, NPC.velocity.X, 2f, 75, NPC.color, NPC.scale);
            var dust13 = Main.dust[num161];
            dust13.velocity.X = dust13.velocity.X * 0.5f;
            var dust14 = Main.dust[num161];
            dust14.velocity.Y = dust14.velocity.Y * 0.1f;
        }
        if (Main.dayTime || Main.player[NPC.target].dead)
        {
            NPC.velocity.Y = NPC.velocity.Y - num147 * 2f;
            if (NPC.timeLeft > 10)
            {
                NPC.timeLeft = 10;
            }
        }
        if (((NPC.velocity.X > 0f && NPC.oldVelocity.X < 0f) || (NPC.velocity.X < 0f && NPC.oldVelocity.X > 0f) || (NPC.velocity.Y > 0f && NPC.oldVelocity.Y < 0f) || (NPC.velocity.Y < 0f && NPC.oldVelocity.Y > 0f)) && !NPC.justHit)
        {
            NPC.netUpdate = true;
            return;
        }
    }

    public override void FindFrame(int frameHeight)
    {
        NPC.frameCounter += 1.0;
        if (NPC.frameCounter >= 8.0)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            NPC.frameCounter = 0.0;
        }
        if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
        {
            NPC.frame.Y = 0;
        }
    }
}