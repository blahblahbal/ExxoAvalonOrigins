using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.NPCs;

public class CrystalSpectre : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crystal Spectre");
        Main.npcFrameCount[NPC.type] = 8;
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.Confused,
                BuffID.OnFire,
                BuffID.CursedInferno
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 105;
        NPC.netAlways = true;
        NPC.scale = 1f;
        NPC.noTileCollide = true;
        NPC.lifeMax = 3800;
        NPC.defense = 50;
        NPC.noGravity = true;
        NPC.alpha = 50;
        NPC.width = 24;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = Item.buyPrice(0, 1, 0, 0);
        NPC.timeLeft = 750;
        NPC.height = 44;
        NPC.HitSound = SoundID.NPCHit54;
        NPC.DeathSound = SoundID.NPCDeath52;
        NPC.knockBackResist = 0.05f;
        //Banner = npc.type;
        //BannerItem = ModContent.ItemType<Items.Banners.CrystalSpectreBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.35f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void AI()
    {
        NPC.spriteDirection = NPC.direction;
        NPC.ai[3]++;
        if (NPC.ai[3] >= 180)
        {

            if (Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].head))
            {
                if (NPC.ai[3] == 180 || NPC.ai[3] == 300 || NPC.ai[3] == 420 || NPC.ai[3] == 540)
                {
                    NPC.velocity.X = 0f;
                    float speedX = NPC.velocity.X + Main.rand.Next(-51, 51) * 0.1f;
                    float speedY = NPC.velocity.Y + Main.rand.Next(-51, 51) * 0.1f;
                    Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.CrystalBit>(), 0, 0, Main.myPlayer);
                }
            }
            if (NPC.ai[3] == 540) NPC.ai[3] = 0;
        }
        if (NPC.justHit)
        {
            NPC.ai[2] = 0f;
        }
        if (NPC.ai[2] >= 0f)
        {
            int num391 = 16;
            bool flag35 = false;
            bool flag36 = false;
            if (NPC.position.X > NPC.ai[0] - num391 && NPC.position.X < NPC.ai[0] + num391)
            {
                flag35 = true;
            }
            else if ((NPC.velocity.X < 0f && NPC.direction > 0) || (NPC.velocity.X > 0f && NPC.direction < 0))
            {
                flag35 = true;
            }
            num391 += 24;
            if (NPC.position.Y > NPC.ai[1] - num391 && NPC.position.Y < NPC.ai[1] + num391)
            {
                flag36 = true;
            }
            if (flag35 && flag36)
            {
                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= 60f)
                {
                    NPC.ai[2] = -200f;
                    NPC.direction *= -1;
                    NPC.velocity.X = NPC.velocity.X * -1f;
                    NPC.collideX = false;
                }
            }
            else
            {
                NPC.ai[0] = NPC.position.X;
                NPC.ai[1] = NPC.position.Y;
                NPC.ai[2] = 0f;
            }
            NPC.TargetClosest(true);
        }
        NPC.ai[2]++;
        if (Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 > NPC.position.X + NPC.width / 2)
        {
            NPC.direction = 1;
        }
        else
        {
            NPC.direction = -1;
        }

        int num392 = (int)((NPC.position.X + NPC.width / 2) / 16f) + NPC.direction * 2;
        int num393 = (int)((NPC.position.Y + NPC.height) / 16f);
        if (NPC.collideX)
        {
            NPC.velocity.X = NPC.oldVelocity.X * -0.4f;
            if (NPC.direction == -1 && NPC.velocity.X > 0f && NPC.velocity.X < 1f)
            {
                NPC.velocity.X = 1f;
            }
            if (NPC.direction == 1 && NPC.velocity.X < 0f && NPC.velocity.X > -1f)
            {
                NPC.velocity.X = -1f;
            }
        }
        if (NPC.collideY)
        {
            NPC.velocity.Y = NPC.oldVelocity.Y * -0.25f;
            if (NPC.velocity.Y > 0f && NPC.velocity.Y < 1f)
            {
                NPC.velocity.Y = 1f;
            }
            if (NPC.velocity.Y < 0f && NPC.velocity.Y > -1f)
            {
                NPC.velocity.Y = -1f;
            }
        }
        float num418 = 2f;
        if (NPC.direction == -1 && NPC.velocity.X > -num418)
        {
            NPC.velocity.X = NPC.velocity.X - 0.1f;
            if (NPC.velocity.X > num418)
            {
                NPC.velocity.X = NPC.velocity.X - 0.1f;
            }
            else if (NPC.velocity.X > 0f)
            {
                NPC.velocity.X = NPC.velocity.X + 0.05f;
            }
            if (NPC.velocity.X < -num418)
            {
                NPC.velocity.X = -num418;
            }
        }
        else if (NPC.direction == 1 && NPC.velocity.X < num418)
        {
            NPC.velocity.X = NPC.velocity.X + 0.1f;
            if (NPC.velocity.X < -num418)
            {
                NPC.velocity.X = NPC.velocity.X + 0.1f;
            }
            else if (NPC.velocity.X < 0f)
            {
                NPC.velocity.X = NPC.velocity.X - 0.05f;
            }
            if (NPC.velocity.X > num418)
            {
                NPC.velocity.X = num418;
            }
        }
        if (NPC.directionY == -1 && NPC.velocity.Y > -1.5)
        {
            NPC.velocity.Y = NPC.velocity.Y - 0.04f;
            if (NPC.velocity.Y > 1.5)
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.05f;
            }
            else if (NPC.velocity.Y > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.03f;
            }
            if (NPC.velocity.Y < -1.5)
            {
                NPC.velocity.Y = -1.5f;
            }
        }
        else if (NPC.directionY == 1 && NPC.velocity.Y < 1.5)
        {
            NPC.velocity.Y = NPC.velocity.Y + 0.04f;
            if (NPC.velocity.Y < -1.5)
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.05f;
            }
            else if (NPC.velocity.Y < 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.03f;
            }
            if (NPC.velocity.Y > 1.5)
            {
                NPC.velocity.Y = 1.5f;
            }
        }
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return !Main.dayTime && Main.hardMode && spawnInfo.player.Avalon().ZoneCrystal ? 0.5f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Placeable.Tile.CrystalStoneBlock>(), 1, 10, 15));
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            for (int num333 = 0; num333 < 20; num333++)
            {
                int num334 = Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 0f, 0f, 50, default, 1.5f);
                Main.dust[num334].velocity *= 2f;
                Main.dust[num334].noGravity = true;
            }
            int num335 = Gore.NewGore(new Vector2(NPC.position.X, NPC.position.Y - 10f), new Vector2(hitDirection, 0f), 99, NPC.scale);
            Main.gore[num335].velocity *= 0.3f;
            num335 = Gore.NewGore(new Vector2(NPC.position.X, NPC.position.Y + NPC.height / 2 - 15f), new Vector2(hitDirection, 0f), 99, NPC.scale);
            Main.gore[num335].velocity *= 0.3f;
            num335 = Gore.NewGore(new Vector2(NPC.position.X, NPC.position.Y + NPC.height - 20f), new Vector2(hitDirection, 0f), 99, NPC.scale);
            Main.gore[num335].velocity *= 0.3f;
        }
    }
    public override void FindFrame(int frameHeight)
    {
        if (NPC.velocity.X > 0f)
        {
            NPC.spriteDirection = 1;
        }
        if (NPC.velocity.X < 0f)
        {
            NPC.spriteDirection = -1;
        }
        NPC.rotation = NPC.velocity.X * 0.1f;
        if (NPC.ai[3] < 180)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 6)
            {
                NPC.frame.Y = NPC.frame.Y + frameHeight;
                NPC.frameCounter = 0;
            }
            if (NPC.frame.Y >= frameHeight * 4)
            {
                NPC.frame.Y = 0;
            }
        }
        else
        {
            NPC.frameCounter++;
            if (NPC.frameCounter <= 6)
            {
                NPC.frame.Y = 4 * frameHeight;
            }
            else if (NPC.frameCounter <= 12)
            {
                NPC.frame.Y = 5 * frameHeight;
            }
            else if (NPC.frameCounter <= 18)
            {
                NPC.frame.Y = 6 * frameHeight;
            }
            else if (NPC.frameCounter <= 24)
            {
                NPC.frame.Y = 7 * frameHeight;
                NPC.frameCounter = 0;
            }
            if (NPC.frame.Y >= frameHeight * 8)
            {
                NPC.frame.Y = frameHeight * 4;
            }
        }
    }
}
