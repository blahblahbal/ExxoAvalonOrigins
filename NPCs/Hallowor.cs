using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class Hallowor : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hallowor");
        Main.npcFrameCount[NPC.type] = 4;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }
    public override void SetDefaults()
    {
        NPC.npcSlots = 1;
        NPC.width = 40;
        NPC.height = 38;
        NPC.aiStyle = -1;
        NPC.timeLeft = 1750;
        AnimationType = 75;
        NPC.damage = 62;
        NPC.defense = 28;
        NPC.HitSound = SoundID.NPCHit5;
        NPC.DeathSound = SoundID.NPCDeath7;
        NPC.lifeMax = 530;
        NPC.scale = 1.8f;
        NPC.knockBackResist = 0.35f;
        NPC.noGravity = true;
        NPC.noTileCollide = false;
        NPC.value = 900;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.HalloworBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return Main.hardMode && !spawnInfo.player.InPillarZone() && spawnInfo.player.ZoneHallow && spawnInfo.spawnTileY < (Main.maxTilesY - 200) ? 0.13f : 0f;
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.PixieDust, 3));
        npcLoot.Add(ItemDropRule.Common(ItemID.Megaphone, 50));
    }
    public override void AI()
    {
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead)
        {
            NPC.TargetClosest(true);
        }
        float num73 = 4.2f;
        float num74 = 0.022f;
        Vector2 vector11 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
        float num75 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2);
        float num76 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2);
        num75 = (float)((int)(num75 / 8f) * 8);
        num76 = (float)((int)(num76 / 8f) * 8);
        vector11.X = (float)((int)(vector11.X / 8f) * 8);
        vector11.Y = (float)((int)(vector11.Y / 8f) * 8);
        num75 -= vector11.X;
        num76 -= vector11.Y;
        float num77 = (float)Math.Sqrt((double)(num75 * num75 + num76 * num76));
        float num78 = num77;
        if (num77 == 0f)
        {
            num75 = NPC.velocity.X;
            num76 = NPC.velocity.Y;
        }
        else
        {
            num77 = num73 / num77;
            num75 *= num77;
            num76 *= num77;
        }
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
        NPC.velocity.X = NPC.velocity.X + num75 * 0.007f;
        NPC.velocity.Y = NPC.velocity.Y + num76 * 0.007f;
        if (Main.player[NPC.target].dead)
        {
            num75 = (float)NPC.direction * num73 / 2f;
            num76 = -num73 / 2f;
        }
        if (NPC.velocity.X < num75)
        {
            NPC.velocity.X = NPC.velocity.X + num74;
            if (NPC.velocity.X < 0f && num75 > 0f)
            {
                NPC.velocity.X = NPC.velocity.X + num74;
            }
        }
        else
        {
            if (NPC.velocity.X > num75)
            {
                NPC.velocity.X = NPC.velocity.X - num74;
                if (NPC.velocity.X > 0f && num75 < 0f)
                {
                    NPC.velocity.X = NPC.velocity.X - num74;
                }
            }
        }
        if (NPC.velocity.Y < num76)
        {
            NPC.velocity.Y = NPC.velocity.Y + num74;
            if (NPC.velocity.Y < 0f && num76 > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y + num74;
            }
        }
        else
        {
            if (NPC.velocity.Y > num76)
            {
                NPC.velocity.Y = NPC.velocity.Y - num74;
                if (NPC.velocity.Y > 0f && num76 < 0f)
                {
                    NPC.velocity.Y = NPC.velocity.Y - num74;
                }
            }
        }
        NPC.rotation = (float)Math.Atan2((double)num76, (double)num75) - 1.57f;
        float num83 = 0.7f;
        if (NPC.collideX)
        {
            NPC.netUpdate = true;
            NPC.velocity.X = NPC.oldVelocity.X * -num83;
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
            NPC.velocity.Y = NPC.oldVelocity.Y * -num83;
            if (NPC.velocity.Y > 0f && (double)NPC.velocity.Y < 1.5)
            {
                NPC.velocity.Y = 2f;
            }
            if (NPC.velocity.Y < 0f && (double)NPC.velocity.Y > -1.5)
            {
                NPC.velocity.Y = -2f;
            }
        }
        if (Main.rand.Next(20) == 0)
        {
            // Was originally vile dust but I changed it
            int num85 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + (float)NPC.height * 0.25f), NPC.width, (int)((float)NPC.height * 0.5f), DustID.Pixie, NPC.velocity.X, 2f, 75, NPC.color, NPC.scale);
            Dust expr_5B51_cp_0 = Main.dust[num85];
            expr_5B51_cp_0.velocity.X = expr_5B51_cp_0.velocity.X * 0.5f;
            Dust expr_5B6F_cp_0 = Main.dust[num85];
            expr_5B6F_cp_0.velocity.Y = expr_5B6F_cp_0.velocity.Y * 0.1f;
        }
        if (NPC.wet)
        {
            if (NPC.velocity.Y > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y * 0.95f;
            }
            NPC.velocity.Y = NPC.velocity.Y - 0.3f;
            if (NPC.velocity.Y < -2f)
            {
                NPC.velocity.Y = -2f;
            }
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
                    NPC.NewNPC(NPC.GetSpawnSourceForProjectileNPC(), (int)(NPC.position.X + (float)(NPC.width / 2) + NPC.velocity.X), (int)(NPC.position.Y + (float)(NPC.height / 2) + NPC.velocity.Y), ModContent.NPCType<NPCs.HallowSpit>(), 0);
                }
                NPC.localAI[0] = 0f;
            }
        }
        if (((NPC.velocity.X > 0f && NPC.oldVelocity.X < 0f) || (NPC.velocity.X < 0f && NPC.oldVelocity.X > 0f) || (NPC.velocity.Y > 0f && NPC.oldVelocity.Y < 0f) || (NPC.velocity.Y < 0f && NPC.oldVelocity.Y > 0f)) && !NPC.justHit)
        {
            NPC.netUpdate = true;
            return;
        }
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Rectangle R = new Rectangle((int)NPC.position.X, (int)(NPC.position.Y + ((NPC.height - NPC.width) / 2)), NPC.width, NPC.width);
            int C = 50;
            float vR = .4f;
            for (int i = 1; i <= C; i++)
            {
                int D = Dust.NewDust(NPC.position, R.Width, R.Height, DustID.Enchanted_Gold, 0, 0, 100, new Color(), 2f);
                Main.dust[D].noGravity = true;
                Main.dust[D].velocity.X = vR * (Main.dust[D].position.X - (NPC.position.X + (NPC.width / 2)));
                Main.dust[D].velocity.Y = vR * (Main.dust[D].position.Y - (NPC.position.Y + (NPC.height / 2)));
            }
            for (int i2 = 1; i2 <= C; i2++)
            {
                int D2 = Dust.NewDust(NPC.position, R.Width, R.Height, DustID.MagicMirror, 0, 0, 100, new Color(), 2f);
                Main.dust[D2].noGravity = true;
                Main.dust[D2].velocity.X = vR * (Main.dust[D2].position.X - (NPC.position.X + (NPC.width / 2)));
                Main.dust[D2].velocity.Y = vR * (Main.dust[D2].position.Y - (NPC.position.Y + (NPC.height / 2)));
            }
        }
    }
}
