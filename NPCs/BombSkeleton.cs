using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class BombSkeleton : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bomb Skeleton");
            Main.npcFrameCount[npc.type] = 15;
        }

        public override void SetDefaults()
        {
            npc.damage = 90;
            npc.lifeMax = 1000;
            npc.defense = 50;
            npc.width = 18;
            npc.aiStyle = 3;
            npc.value = 40000f;
            npc.height = 40;
            npc.knockBackResist = 0.05f;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.BombSkeletonBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.35f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void NPCLoot()
        {
            var num2 = 13f;
            var vector = new Vector2(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2);
            var num3 = 120;
            var num4 = ModContent.ProjectileType<Projectiles.SkeletonHeadbomb>();
            var num5 = (float)Math.Atan2(vector.Y - (Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f), vector.X - (Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f));
            var num6 = Projectile.NewProjectile(vector.X, vector.Y, (float)(Math.Cos(num5) * num2 * -1.0), (float)(Math.Sin(num5) * num2 * -1.0), num4, num3, 0f, 0, 0f, 0f);
            Main.projectile[num6].velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * 8f;
            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NPCs.BombBones>(), npc.whoAmI);
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.Y == 0f)
            {
                if (npc.direction == 1)
                {
                    npc.spriteDirection = 1;
                }
                if (npc.direction == -1)
                {
                    npc.spriteDirection = -1;
                }
                if (npc.velocity.X == 0f)
                {
                    npc.frame.Y = 0;
                    npc.frameCounter = 0.0;
                }
                else
                {
                    npc.frameCounter += Math.Abs(npc.velocity.X) * 2f;
                    npc.frameCounter += 1.0;
                    if (npc.frameCounter > 6.0)
                    {
                        npc.frame.Y = npc.frame.Y + frameHeight;
                        npc.frameCounter = 0.0;
                    }
                    if (npc.frame.Y / frameHeight >= Main.npcFrameCount[npc.type])
                    {
                        npc.frame.Y = frameHeight * 2;
                    }
                }
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && spawnInfo.player.ZoneRockLayerHeight ? 0.1f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
