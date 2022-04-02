using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.NPCs.Utils.States;

public class MoveToPosition : State
{
    private readonly uint frameDuration;
    private readonly Func<float, float> easeFunction;
    private readonly bool relativeToTarget;
    private readonly bool relativeToTargetedPosition;
    private readonly Vector2 position;
    private readonly Vector2 targetedPosition;
    private Vector2Tween movementTween;

    public MoveToPosition(Vector2 position, uint frameDuration, Func<float, float> easeFunction, bool relativeToTarget = false)
    {
        this.frameDuration = frameDuration;
        this.easeFunction = easeFunction;
        this.relativeToTarget = relativeToTarget;
        relativeToTargetedPosition = false;

        this.position = position;
        targetedPosition = Vector2.Zero;
    }

    public MoveToPosition(Vector2 position, uint frameDuration, Func<float, float> easeFunction, Vector2 targetedPosition) : this(position, frameDuration, easeFunction, false)
    {
        this.targetedPosition = targetedPosition;
        relativeToTargetedPosition = true;
    }

    public override void Write(BinaryWriter writer)
    {
        base.Write(writer);
        movementTween.Write(writer);
    }

    public override void Read(BinaryReader reader)
    {
        base.Read(reader);
        movementTween = new Vector2Tween(frameDuration, easeFunction, Vector2.Zero, Vector2.Zero);
        movementTween.Read(reader);
    }

    public override void PostDraw(SpriteBatch spriteBatch)
    {
        if (movementTween != null)
        {
            Utils.Debug.DrawIndicator(spriteBatch, movementTween.EndPosition);
        }
    }

    protected override void Start()
    {
        if (relativeToTarget)
        {
            movementTween = new Vector2Tween(frameDuration, easeFunction, npc.Center - target.Center, position);
        }
        else
        {
            if (relativeToTargetedPosition)
            {
                movementTween = new Vector2Tween(frameDuration, easeFunction, npc.Center, position + targetedPosition);
            }
            else
            {
                movementTween = new Vector2Tween(frameDuration, easeFunction, npc.Center, position);
            }
        }
    }

    protected override void Update()
    {
        npc.velocity = Vector2.Zero;

        if (relativeToTarget)
        {
            npc.Center = target.Center + movementTween.Update();
        }
        else
        {
            npc.Center = movementTween.Update();
        }

        if (movementTween.Finished)
        {
            Destroy();
        }
    }
}