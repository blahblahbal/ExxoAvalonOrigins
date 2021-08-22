using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    internal class DevourerHead : DevourerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/DevourerHead";

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 18, 1f);
            }
        }

        public override void SetDefaults()
        {
            npc.width = 14;
            npc.height = 14;
            npc.aiStyle = 6;
            npc.netAlways = true;
            npc.damage = 40;
            npc.defense = 6;
            npc.lifeMax = 300;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCHit1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
        }

        public override void Init()
        {
            base.Init();
            head = true;
            minLength = 10;
            maxLength = 13;
        }
    }

    internal class DevourerBody : DevourerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/DevourerBody";

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 19, 1f);
            }
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
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCHit1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.behindTiles = true;
        }
    }

    internal class DevourerTail : DevourerWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/DevourerTail";

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 20, 1f);
            }
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
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCHit1;
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
    public abstract class DevourerWorm : Worm
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devourer");
        }

        public override void Init()
        {
            minLength = 10;
            maxLength = 13;
            tailType = ModContent.NPCType<DevourerTail>();
            bodyType = ModContent.NPCType<DevourerBody>();
            headType = ModContent.NPCType<DevourerHead>();
            speed = 5.5f;
            turnSpeed = 0.045f;
        }
    }
}