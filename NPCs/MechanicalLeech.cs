using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs;

public class MechanicalLeechHead : MechanicalLeechWorm
{
    public override string Texture => "ExxoAvalonOrigins/NPCs/MechanicalLeechHead";

    public override void SetDefaults()
    {
        NPC.width = 14;
        NPC.height = 14;
        NPC.aiStyle = 6;
        NPC.netAlways = true;
        NPC.damage = 40;
        NPC.defense = 6;
        NPC.lifeMax = 300;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.knockBackResist = 0f;
        NPC.behindTiles = true;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.8f);
    }
    public override void Init()
    {
        base.Init();
        head = true;
        minLength = 6;
        maxLength = 10;
    }
}

public class MechanicalLeechBody : MechanicalLeechWorm
{
    public override string Texture => "ExxoAvalonOrigins/NPCs/MechanicalLeechBody";
    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return false;
    }
    public override void SetDefaults()
    {
        NPC.width = 14;
        NPC.height = 14;
        NPC.aiStyle = 6;
        NPC.netAlways = true;
        NPC.damage = 35;
        NPC.defense = 6;
        NPC.lifeMax = 300;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.knockBackResist = 0f;
        NPC.behindTiles = true;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.8f);
    }
}

public class MechanicalLeechTail : MechanicalLeechWorm
{
    public override string Texture => "ExxoAvalonOrigins/NPCs/MechanicalLeechTail";
    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return false;
    }
    public override void SetDefaults()
    {
        NPC.width = 14;
        NPC.height = 14;
        NPC.aiStyle = 6;
        NPC.netAlways = true;
        NPC.damage = 30;
        NPC.defense = 15;
        NPC.lifeMax = 300;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.knockBackResist = 0f;
        NPC.behindTiles = true;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.8f);
    }
    public override void Init()
    {
        base.Init();
        tail = true;
    }
}
public abstract class MechanicalLeechWorm : Worm
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mechanical Leech");
    }

    public override void Init()
    {
        minLength = 6;
        maxLength = 10;
        tailType = ModContent.NPCType<MechanicalLeechTail>();
        bodyType = ModContent.NPCType<MechanicalLeechBody>();
        headType = ModContent.NPCType<MechanicalLeechHead>();
        speed = 5.5f;
        turnSpeed = 0.045f;
    }
}