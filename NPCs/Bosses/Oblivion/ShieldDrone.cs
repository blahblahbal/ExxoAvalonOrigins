using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs.Bosses.Oblivion;

public class ShieldDrone : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shield Drone");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults()
    {
        NPC.damage = 150;
        NPC.noTileCollide = true;
        NPC.lifeMax = 2500;
        NPC.defense = 50;
        NPC.noGravity = true;
        NPC.width = 48;
        NPC.height = 34;
        NPC.aiStyle = -1;
        NPC.npcSlots = 6f;
        NPC.timeLeft = 750;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit4;
        NPC.DeathSound = SoundID.NPCDeath14;
    }

    private const int AISlotParentID = 0;
    private const int AISlotPosition = 1;
    private const int AISlotMaxDrones = 2;
    private const int AISlotTimer = 3;

    public int AIParentID
    {
        get => (int)NPC.ai[AISlotParentID];
        set => NPC.ai[AISlotParentID] = value;
    }

    public int AIPosition
    {
        get => (int)NPC.ai[AISlotPosition];
        set => NPC.ai[AISlotPosition] = value;
    }

    public int AIMaxDrones
    {
        get => (int)NPC.ai[AISlotMaxDrones];
        set => NPC.ai[AISlotMaxDrones] = value;
    }

    public int AITimer
    {
        get => (int)NPC.ai[AISlotTimer];
        set => NPC.ai[AISlotTimer] = value;
    }

    public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
    {
        Texture2D texture = Mod.Assets.Request<Texture2D>("NPCs/Bosses/Oblivion/ShieldDrone_Glow").Value;
        spriteBatch.Draw
        (
            texture,
            new Vector2
            (
                NPC.position.X - Main.screenPosition.X + (NPC.width * 0.5f),
                NPC.position.Y - Main.screenPosition.Y + NPC.height - (texture.Height * 0.5f) + 2f
            ),
            new Rectangle(0, 0, texture.Width, texture.Height),
            Color.White,
            NPC.rotation,
            texture.Size() * 0.5f,
            NPC.scale,
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
            NPC.active = false;
        }

        // Set rotation outwards from parent
        Vector2 unitVector = (NPC.Center - parentNPC.Center).SafeNormalize(Vector2.UnitX);
        NPC.rotation = (float)Math.Atan2(unitVector.Y, unitVector.X) + (float)(Math.PI / 2);

        // Set velocity and position to go in circular motion
        Vector2 desiredPosition = Vector2.UnitX.RotatedBy((Math.PI * 2 * AIPosition / AIMaxDrones) + (AITimer * 0.01f));
        desiredPosition *= 16f * 8;
        desiredPosition += parentNPC.Center;

        NPC.Center = desiredPosition;
    }
}