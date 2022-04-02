using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class BoundIceman : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bound Iceman");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults()
    {
        NPC.damage = 10;
        NPC.lifeMax = 300;
        NPC.defense = 15;
        NPC.friendly = true;
        NPC.width = 18;
        NPC.aiStyle = -1;
        NPC.height = 40;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.knockBackResist = 0.5f;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.player.ZoneSnow && spawnInfo.player.ZoneRockLayerHeight && !ExxoAvalonOriginsGlobalNPC.savedIceman && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode ? 0.0526f : 0f;
    }

    public override bool CanChat()
    {
        return true;
    }

    public override string GetChat()
    {
        switch (Main.rand.Next(3))
        {
            case 0:
                return "Thanks for dislodging me from that glacier bit. If you hadn't, I'd have probably gone dormant and stayed there for eons!";
            case 1:
                return "Wow! A human! I haven't seen one of you for... I don't know how long!";
            case 2:
                return "Thanks for not flinging matches at me. I hate it when people do that.";
        }
        return string.Empty;
    }

    public override void AI()
    {
        for (var i = 0; i < 255; i++)
        {
            if (Main.player[i].active && Main.player[i].talkNPC == NPC.whoAmI)
            {
                NPC.Transform(ModContent.NPCType<Iceman>());
                ExxoAvalonOriginsGlobalNPC.savedIceman = true;
            }
        }
        NPC.TargetClosest(true);
        NPC.spriteDirection = NPC.direction;
        NPC.velocity.X = NPC.velocity.X * 0.93f;
        if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
        {
            NPC.velocity.X = 0f;
            return;
        }
    }
}