using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    internal class PyrasiteHead : AvalonWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/PyrasiteHead";

        public override void SetDefaults()
        {
            npc.damage = 15;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 70;
            npc.defense = 0;
            npc.noGravity = true;
            npc.width = 26;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.value = 500f;
            npc.height = 26;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && spawnInfo.player.position.Y < Main.worldSurface) ? 0.05f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PyrasiteHead"), 1f);
            }
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

    internal class PyrasiteBody : AvalonWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/PyrasiteBody";

        public override void SetDefaults()
        {
            npc.damage = 8;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 70;
            npc.defense = 4;
            npc.noGravity = true;
            npc.width = 26;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.value = 500f;
            npc.height = 26;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PyrasiteBody"), 1f);
            }
        }

    }

    internal class PyrasiteTail : AvalonWorm
    {
        public override string Texture => "ExxoAvalonOrigins/NPCs/PyrasiteTail";

        public override void SetDefaults()
        {
            npc.damage = 8;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 70;
            npc.defense = 6;
            npc.noGravity = true;
            npc.width = 26;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.value = 500f;
            npc.height = 26;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PyrasiteTail"), 1f);
            }
        }

        public override void Init()
        {
            base.Init();
            tail = true;
        }
    }
}