using Microsoft.Xna.Framework;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs
{
	public class CaesiumBrute : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Brute");
			Main.npcFrameCount[NPC.type] = 5;
		}
		public override void SetDefaults()
		{
			NPC.damage = 62;
            NPC.lifeMax = 780;
			NPC.defense = 45;
			NPC.noGravity = true;
			NPC.width = 28;
			NPC.aiStyle = 14;
			NPC.npcSlots = 2f;
			NPC.value = 15000f;
			NPC.height = 48;
            NPC.HitSound = SoundID.NPCHit21;
	        NPC.DeathSound = SoundID.NPCDeath24;
			NPC.knockBackResist = 0.1f;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.CursedInferno] = true;
            NPC.lavaImmune = true;
            //Banner = npc.type;
            //BannerItem = ModContent.ItemType<Items.Banners.CaesiumBruteBanner>();
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.DownedAllMechBosses(), ModContent.ItemType<CaesiumOre>(), 6, 3, 7));
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.45f);
            NPC.damage = (int)(NPC.damage * 0.4f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.Avalon().ZoneCaesium && spawnInfo.player.ZoneUnderworldHeight && !NPC.AnyNPCs(NPCID.WallofFlesh) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.WallofSteel>()))
                return 0.8f;
            return 0;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (NPC.Center.X <= target.Center.X) target.velocity.X += 15;
            else target.velocity.X -= 15;
        }
        public override void AI()
        {
            NPC.ai[0]++;
            if (NPC.ai[0] > 240)
            {
                if (Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                {
                    int increments = 3;
                    float degrees = 15f;
                    float offset = (float)((float)(degrees / increments) / 2f); // IF YOU WANT THE ATTACK TO BE AIMED WITH EVEN INCREMENTS, REMOVE OFFSET FROM THE VELOCITY CALCULATION
                    Vector2 rotation = (Main.player[NPC.target].Center - NPC.Center).SafeNormalize(-Vector2.UnitY);
                    float speed = 7f;
                    for (int i = 0; i < increments; i++)
                    {
                        Vector2 velocity = rotation.RotatedBy(MathHelper.ToRadians(((float)(degrees / 2f) * -1f) + ((float)(degrees / increments) * i) + offset)) * speed;
                        int spray = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.Center, velocity, ModContent.ProjectileType<Projectiles.CaesiumFireball>(), 55, 0f, NPC.target, 1f, 0f);
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, spray);
                        }
                    }
                    SoundEngine.PlaySound(SoundID.Item, (int)NPC.position.X, (int)NPC.position.Y, 8);
                }
                NPC.ai[0] = 0;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;
            NPC.rotation = NPC.velocity.X * 0.1f;
            int num226 = 5;
            int num227 = 5;
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= (double)(num226 * num227))
            {
                NPC.frameCounter = 0.0;
            }
            int num228 = (int)(NPC.frameCounter / (double)num226);
            NPC.frame.Y = num228 * frameHeight;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life > 0)
            {
                SoundEngine.PlaySound(SoundID.NPCHit, (int)NPC.Center.X, (int)NPC.Center.Y, 21, 1.2f, -0.5f);
                if (Main.rand.Next(20) == 0)
                {
                    Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.position, NPC.velocity, ModContent.ProjectileType<Projectiles.CaesiumGas>(), 0, 0);
                }
            }
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/CaesiumBruteHead").Type, 1f);
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/CaesiumBruteWing").Type, 1f);
                Gore.NewGore(NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/CaesiumBruteWing").Type, 1f);
            }
        }
    }
}
