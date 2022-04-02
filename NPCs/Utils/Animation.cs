using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;

namespace ExxoAvalonOrigins.NPCs.Utils;

public class Vector2Tween : Network.ISerializable
{
    private readonly uint frameDuration;
    private readonly Func<float, float> easeFunction;
    public Vector2 StartPosition { get; private set; }
    public Vector2 EndPosition { get; private set; }
    private Vector2 vectorBetween;
    private uint frameCounter;
    public bool Finished { get; private set; }
    public Vector2Tween(uint frameDuration, Func<float, float> easeFunction, Vector2 startPosition, Vector2 endPosition)
    {
        Finished = false;
        frameCounter = 0;
        StartPosition = startPosition;
        EndPosition = endPosition;
        vectorBetween = endPosition - startPosition;
        this.frameDuration = frameDuration;
        this.easeFunction = easeFunction;
    }

    public Vector2 Update()
    {
        if (frameCounter >= frameDuration)
        {
            Finished = true;
        }
        else
        {
            frameCounter++;
        }
        return StartPosition + (vectorBetween * easeFunction((float)frameCounter / (float)frameDuration));
    }
    public void Write(BinaryWriter writer)
    {
        writer.WriteVector2(StartPosition);
        writer.WriteVector2(EndPosition);
        writer.Write(frameCounter);
    }

    public void Read(BinaryReader reader)
    {
        StartPosition = reader.ReadVector2();
        EndPosition = reader.ReadVector2();
        vectorBetween = EndPosition - StartPosition;
        frameCounter = reader.ReadUInt32();
        if (frameCounter >= frameDuration)
        {
            Finished = true;
        }
    }
}
// --- ANIMATION FUNCTIONS ---
// View https://easings.net/ for easy visual reference
// Above each function is a comment with each function in latex format,
// you can also paste these into online graphing calculators such as desmos
public static class CubicEase
{
    // f(x) = x^{3}
    public static float In(float x)
    {
        return x * x * x;
    }

    // f(x) = 1-\left(1-x\right)^{3}
    public static float Out(float x)
    {
        return 1 - In(1 - x);
    }

    // f(x) = (4x^{3} WHEN x < 0.5) OR (4\left(\left(x-1\right)^{3}\right)+1 WHEN x >= 0.5)
    public static float InOut(float x)
    {
        if (x < 0.5f)
        {
            return 4 * In(x);
        }
        else
        {
            return (4 * In(x - 1)) + 1;
        }
    }
}