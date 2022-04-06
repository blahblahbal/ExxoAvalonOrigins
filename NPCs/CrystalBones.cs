using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs;

public class CrystalBones : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crystal Bones");
        Main.npcFrameCount[NPC.type] = 15;
    }
    public override void SetDefaults()
    {
        NPC.damage = 122;
        NPC.lifeMax = 3500;
        NPC.defense = 15;
        NPC.lavaImmune = true;
        NPC.width = 18;
        NPC.aiStyle = 3;
        NPC.value = 50000f;
        NPC.height = 40;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit2;
        NPC.DeathSound = SoundID.NPCDeath2;
        //Banner = npc.type;
        //BannerItem = ModContent.ItemType<Items.Banners.CrystalBonesBanner>();
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.7f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void FindFrame(int frameHeight)
    {
        if (NPC.velocity.Y == 0f)
        {
            if (NPC.direction == 1)
            {
                NPC.spriteDirection = 1;
            }
            if (NPC.direction == -1)
            {
                NPC.spriteDirection = -1;
            }
            if (NPC.velocity.X == 0f)
            {
                NPC.frame.Y = 0;
                NPC.frameCounter = 0.0;
            }
            else
            {
                NPC.frameCounter += Math.Abs(NPC.velocity.X) * 2f;
                NPC.frameCounter += 1.0;
                if (NPC.frameCounter > 6.0)
                {
                    NPC.frame.Y = NPC.frame.Y + frameHeight;
                    NPC.frameCounter = 0.0;
                }
                if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
                {
                    NPC.frame.Y = frameHeight * 2;
                }
            }
        }
        else
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = frameHeight;
        }
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return Main.hardMode && spawnInfo.player.Avalon().ZoneCrystal ? 0.8f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }
    public override void OnKill()
    {
        for (int i = 0; i < 8; i++)
        {
            float speedX = NPC.velocity.X + Main.rand.Next(-51, 51) * 0.2f;
            float speedY = NPC.velocity.Y + Main.rand.Next(-51, 51) * 0.2f;
            int proj = Projectile.NewProjectile(NPC.GetSpawnSource_ForProjectile(), NPC.position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.CrystalShard>(), 100, 0.3f);
            Main.projectile[proj].timeLeft = 300;
        }
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Placeable.Tile.CrystalStoneBlock>(), 1, 10, 15));
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CrystalBonesHead").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CrystalBonesArm").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CrystalBonesArm").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CrystalBonesLeg").Type, 1f);
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CrystalBonesLeg").Type, 1f);
        }
    }
}