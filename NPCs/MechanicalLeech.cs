using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    internal class MechanicalLeechHead : MechanicalLeechWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/MechanicalLeechHead";

        public override void SetDefaults()
        {
            npc.width = 14;
            npc.height = 14;
            npc.aiStyle = 6;
            npc.netAlways = true;
            npc.damage = 40;
            npc.defense = 6;
            npc.lifeMax = 300;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit14;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
        }

        public override void Init()
        {
            base.Init();
            head = true;
            minLength = 6;
            maxLength = 10;
        }
    }

    internal class MechanicalLeechBody : MechanicalLeechWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/MechanicalLeechBody";
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override void SetDefaults()
        {
            npc.width = 14;
            npc.height = 14;
            npc.aiStyle = 6;
            npc.netAlways = true;
            npc.damage = 35;
            npc.defense = 6;
            npc.lifeMax = 300;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit14;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
        }
    }

    internal class MechanicalLeechTail : MechanicalLeechWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/MechanicalLeechTail";
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override void SetDefaults()
        {
            npc.width = 14;
            npc.height = 14;
            npc.aiStyle = 6;
            npc.netAlways = true;
            npc.damage = 30;
            npc.defense = 15;
            npc.lifeMax = 300;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit14;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
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
}