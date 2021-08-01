using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    internal class MechanicalLeechHead : AvalonWorm
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
        }

        //private int attackCounter;
        //public override void SendExtraAI(BinaryWriter writer)
        //{
        //    writer.Write(attackCounter);
        //}

        //public override void ReceiveExtraAI(BinaryReader reader)
        //{
        //    attackCounter = reader.ReadInt32();
        //}

        //public override void CustomBehavior()
        //{
        //    if (Main.netMode != NetmodeID.MultiplayerClient)
        //    {
        //        if (attackCounter > 0)
        //        {
        //            attackCounter--;
        //        }

        //        Player target = Main.player[npc.target];
        //        if (attackCounter <= 0 && Vector2.Distance(npc.Center, target.Center) < 200 && Collision.CanHit(npc.Center, 1, 1, target.Center, 1, 1))
        //        {
        //            Vector2 direction = (target.Center - npc.Center).SafeNormalize(Vector2.UnitX);
        //            direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

        //            int projectile = Projectile.NewProjectile(npc.Center, direction * 1, ProjectileID.ShadowBeamHostile, 5, 0, Main.myPlayer);
        //            Main.projectile[projectile].timeLeft = 300;
        //            attackCounter = 500;
        //            npc.netUpdate = true;
        //        }
        //    }
        //}
    }

    internal class MechanicalLeechBody : AvalonWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/MechanicalLeechBody";

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

    internal class MechanicalLeechTail : AvalonWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/MechanicalLeechTail";

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
}