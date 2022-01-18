using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class EctoHand : ModNPC
    {
        private int timer = 0;
        private bool spawn = false;
        private float PosX = 0f;
        private float PosY = 0f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ecto Hand");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.damage = 66;
            npc.lifeMax = 1600;
            npc.defense = 30;
            npc.width = 30;
            npc.height = 30;
            npc.aiStyle = -1;
            npc.scale = 1.3f;
            npc.value = 1000f;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit36;
            npc.DeathSound = SoundID.NPCDeath39;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.behindTiles = false;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.EctoHandBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override Color? GetAlpha(Color drawColor)
        {
            return Color.White;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Vector2 vector7 = new Vector2(npc.Center.X, npc.Center.Y);
            float num29 = npc.ai[1] - vector7.X;
            float num30 = npc.ai[2] - vector7.Y;

            float rotation7 = (float)Math.Atan2((double)num30, (double)num29) - 1.57f;
            bool flag8 = true;
            while (flag8)
            {
                float num31 = (float)Math.Sqrt((double)(num29 * num29 + num30 * num30));
                if (num31 < 16f)
                {
                    flag8 = false;
                }
                else
                {
                    num31 = 16f / num31;
                    num29 *= num31;
                    num30 *= num31;
                    vector7.X += num29;
                    vector7.Y += num30;
                    num29 = npc.ai[1] - vector7.X;
                    num30 = npc.ai[2] - vector7.Y;

                    Color color7 = Lighting.GetColor((int)vector7.X / 16, (int)(vector7.Y / 16f));
                    Main.spriteBatch.Draw(mod.GetTexture("NPCs/EctoArm"), new Vector2(vector7.X - Main.screenPosition.X, vector7.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, mod.GetTexture("NPCs/EctoArm").Width, mod.GetTexture("NPCs/EctoArm").Height)), Color.White, rotation7, new Vector2(mod.GetTexture("NPCs/EctoArm").Width * 0.5f, mod.GetTexture("NPCs/EctoArm").Height * 0.5f), 1f, SpriteEffects.None, 0f);
                }
            }
            return true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneHellcastle && Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].wall == (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>())
            {
                return 2f;
            }
            return 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int num34 = 0; num34 < 50; num34++)
                {
                    int num35 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.DungeonSpirit, npc.velocity.X, npc.velocity.Y, 0, default(Color), 1f);
                    Main.dust[num35].velocity *= 2f;
                    Main.dust[num35].noGravity = true;
                    Main.dust[num35].scale = 1.4f;
                }
            }
        }
        public override void AI()
        {
            timer++;
            npc.TargetClosest(true);
            int i = (int)(npc.Center.X) / 16;
            int j = (int)(npc.Center.Y) / 16;
            while (j < Main.maxTilesY - 10 && Main.tile[i, j] != null && (!WorldGen.SolidTile2(i, j) && Main.tile[i - 1, j] != null) && (!WorldGen.SolidTile2(i - 1, j) && Main.tile[i + 1, j] != null && !WorldGen.SolidTile2(i + 1, j)))
                j += 2;
            int num = j - 1;
            float worldY = num * 16;
            if (!spawn)
            {
                spawn = true;
                npc.position.Y = worldY;
                PosX = Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f);
                PosY = Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f);
                npc.ai[1] = npc.position.X + (float)(npc.width / 2);
                npc.ai[2] = npc.position.Y + (float)(npc.height / 2);
            }

            if (timer > 180)
            {
                timer = 0;
                PosX = Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f);
                PosY = Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f);
            }
            else if (timer > 110 || npc.Distance(new Vector2(npc.ai[1], npc.ai[2])) > 450)
            {
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f) - Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f), npc.position.Y + (npc.height * 0.5f) - Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f));
                PosX = npc.ai[1] - vector8.X * 1f;
                PosY = npc.ai[2] - vector8.Y * 1f;
            }
            if (PosX < npc.position.X)
            {
                if (npc.velocity.X > -4) { npc.velocity.X -= 0.25f; }
            }
            else if (PosX > npc.Center.X)
            {
                if (npc.velocity.X < 4) { npc.velocity.X += 0.25f; }
            }
            if (PosY < npc.position.Y)
            {
                if (npc.velocity.Y > -4) npc.velocity.Y -= 0.25f;
            }
            else if (PosY > npc.Center.Y)
            {
                if (npc.velocity.Y < 4) npc.velocity.Y += 0.25f;
            }
            Vector2 vector6 = new Vector2(npc.Center.X - npc.ai[1], npc.Center.Y - npc.ai[1]);
            npc.rotation = ((float)Math.Atan2(Main.player[npc.target].Center.Y - (double)npc.Center.Y, Main.player[npc.target].Center.X - (double)npc.Center.X) + 3.14f) * 1f + ((float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X)) * 0.1f;
        }
    }
}
