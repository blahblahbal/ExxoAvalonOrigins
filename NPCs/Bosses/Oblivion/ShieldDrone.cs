using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs.Bosses.Oblivion
{
    public class ShieldDrone : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shield Drone");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.damage = 150;
            npc.noTileCollide = true;
            npc.lifeMax = 2500;
            npc.defense = 50;
            npc.noGravity = true;
            npc.width = 48;
            npc.height = 34;
            npc.aiStyle = -1;
            npc.npcSlots = 6f;
            npc.timeLeft = 750;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
        }

        private const int AISlotParentID = 0;
        private const int AISlotPosition = 1;
        private const int AISlotMaxDrones = 2;
        private const int AISlotTimer = 3;

        public int AIParentID
        {
            get => (int)npc.ai[AISlotParentID];
            set => npc.ai[AISlotParentID] = value;
        }

        public int AIPosition
        {
            get => (int)npc.ai[AISlotPosition];
            set => npc.ai[AISlotPosition] = value;
        }

        public int AIMaxDrones
        {
            get => (int)npc.ai[AISlotMaxDrones];
            set => npc.ai[AISlotMaxDrones] = value;
        }

        public int AITimer
        {
            get => (int)npc.ai[AISlotTimer];
            set => npc.ai[AISlotTimer] = value;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/Bosses/Oblivion/ShieldDrone_Glow");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    npc.position.X - Main.screenPosition.X + (npc.width * 0.5f),
                    npc.position.Y - Main.screenPosition.Y + npc.height - (texture.Height * 0.5f) + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                npc.rotation,
                texture.Size() * 0.5f,
                npc.scale,
                SpriteEffects.None,
                0f
            );
        }

        public override void AI()
        {
            AITimer++;

            NPC parentNPC = Main.npc[AIParentID];

            if (!parentNPC.active)
            {
                npc.active = false;
            }

            // Set rotation outwards from parent
            Vector2 unitVector = (npc.Center - parentNPC.Center).SafeNormalize(Vector2.UnitX);
            npc.rotation = (float)Math.Atan2(unitVector.Y, unitVector.X) + (float)(Math.PI / 2);

            // Set velocity and position to go in circular motion
            Vector2 desiredPosition = Vector2.UnitX.RotatedBy((Math.PI * 2 * AIPosition / AIMaxDrones) + (AITimer * 0.01f));
            desiredPosition *= 16f * 8;
            desiredPosition += parentNPC.Center;

            npc.Center = desiredPosition;
        }
    }
}
