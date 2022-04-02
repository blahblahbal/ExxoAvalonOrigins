using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace ExxoAvalonOrigins.NPCs;

public class PlatinumSlime : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Platinum Slime");
        Main.npcFrameCount[NPC.type] = 2;
    }

    public override void SetDefaults()
    {
        NPC.damage = 22;
        NPC.lifeMax = 362;
        NPC.defense = 5;
        NPC.width = 36;
        NPC.aiStyle = 1;
        NPC.value = 1000f;
        NPC.knockBackResist = 0.4f;
        NPC.height = 24;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Banners.PlatinumSlimeBanner>();
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.PlatinumOre, 1, 10, 20));
    }
    public override void FindFrame(int frameHeight)
    {
        var num2 = 0;
        if (NPC.aiAction == 0)
        {
            if (NPC.velocity.Y < 0f)
            {
                num2 = 2;
            }
            else if (NPC.velocity.Y > 0f)
            {
                num2 = 3;
            }
            else if (NPC.velocity.X != 0f)
            {
                num2 = 1;
            }
            else
            {
                num2 = 0;
            }
        }
        else if (NPC.aiAction == 1)
        {
            num2 = 4;
        }
        NPC.frameCounter += 1.0;
        if (num2 > 0)
        {
            NPC.frameCounter += 1.0;
        }
        if (num2 == 4)
        {
            NPC.frameCounter += 1.0;
        }
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

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.player.ZoneRockLayerHeight && !spawnInfo.player.ZoneDungeon && (Main.hardMode || WorldGen.SavedOreTiers.Gold == TileID.Platinum) ? 0.00526f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
    }
}