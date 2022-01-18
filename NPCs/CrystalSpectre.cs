using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class CrystalSpectre : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Spectre");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.damage = 105;
            npc.netAlways = true;
            npc.scale = 1f;
            npc.noTileCollide = true;
            npc.lifeMax = 3800;
            npc.defense = 50;
            npc.noGravity = true;
            npc.alpha = 50;
            npc.width = 24;
            npc.aiStyle = 22;
            npc.npcSlots = 1f;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.timeLeft = 750;
            npc.height = 44;
            npc.HitSound = SoundID.NPCHit54;
            npc.DeathSound = SoundID.NPCDeath52;
            npc.knockBackResist = 0.05f;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            //banner = npc.type;
            //bannerItem = ModContent.ItemType<Items.Banners.ArmoredWraithBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.35f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
            npc.ai[3]++;
            if (npc.ai[3] >= 180)
            {

                if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].head))
                {
                    if (npc.ai[3] == 180 || npc.ai[3] == 300 || npc.ai[3] == 420 || npc.ai[3] == 540)
                    {
                        npc.velocity.X = 0f;
                        float speedX = npc.velocity.X + Main.rand.Next(-51, 51) * 0.1f;
                        float speedY = npc.velocity.Y + Main.rand.Next(-51, 51) * 0.1f;
                        Projectile.NewProjectile(npc.position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.CrystalBit>(), 0, 0, Main.myPlayer);
                    }
                }
                if (npc.ai[3] == 540) npc.ai[3] = 0;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return !Main.dayTime && Main.hardMode && spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneCrystal ? 0.053f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = 1;
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;
            }
            npc.rotation = npc.velocity.X * 0.1f;
            if (npc.ai[3] < 180)
            {
                npc.frameCounter++;
                if (npc.frameCounter >= 6)
                {
                    npc.frame.Y = npc.frame.Y + frameHeight;
                    npc.frameCounter = 0;
                }
                if (npc.frame.Y >= frameHeight * 4)
                {
                    npc.frame.Y = 0;
                }
            }
            else
            {
                npc.frameCounter++;
                if (npc.frameCounter <= 6)
                {
                    npc.frame.Y = 4 * frameHeight;
                }
                else if (npc.frameCounter <= 12)
                {
                    npc.frame.Y = 5 * frameHeight;
                }
                else if (npc.frameCounter <= 18)
                {
                    npc.frame.Y = 6 * frameHeight;
                }
                else if (npc.frameCounter <= 24)
                {
                    npc.frame.Y = 7 * frameHeight;
                    npc.frameCounter = 0;
                }
                if (npc.frame.Y >= frameHeight * 8)
                {
                    npc.frame.Y = frameHeight * 4;
                }
            }
        }
    }
}
