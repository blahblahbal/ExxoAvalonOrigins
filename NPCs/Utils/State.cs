using System;
using System.IO;
using ExxoAvalonOrigins.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs.Utils;

/// <summary>
/// A state who performs an action
/// </summary>
public abstract class State : ISerializable
{
    /// <summary>
    /// Whether or not this state will be updated
    /// </summary>
    public bool Active { get; private set; }

    /// <summary>
    /// A frame time reference with value 1 on first update.
    /// </summary>
    public uint CurrentFrame { get; private set; }

    public Type Type { get; }

    /// <summary>
    /// The state parent controlling this state
    /// </summary>
    public StateParent Parent { get; set; }

    protected ModNPC ModNPC { get; private set; }
    protected NPC npc;
    protected Entity target;
    protected Vector2 vectorToTarget;
    protected Vector2 unitVectorToTarget;
    private int syncedRandomSeed;
    private bool syncedRandomSet;

    private int SyncedRandomSeed
    {
        get => syncedRandomSeed;
        set
        {
            syncedRandomSeed = value;

            syncedRandomSet = true;
            syncedRandom = new Random(syncedRandomSeed);
            var stateParent = this as StateParent;
            if (stateParent?.CurrentState != null)
            {
                stateParent.CurrentState.SyncedRandomSeed = SyncedRandomSeed;
            }
        }
    }

    /// <summary>
    /// An instance of random that is synced on the network
    /// </summary>
    protected Random syncedRandom;

    public bool HasLoaded;

    protected State()
    {
        Type = GetType();
        Active = true;
        HasLoaded = false;
        syncedRandomSet = false;
    }

    public virtual void Write(BinaryWriter writer)
    {
        writer.Write(CurrentFrame);
        if (Parent == null)
        {
            SyncedRandomSeed = Main.rand.Next();
            writer.Write(SyncedRandomSeed);
        }
    }

    public virtual void Read(BinaryReader reader)
    {
        CurrentFrame = reader.ReadUInt32();
        if (Parent == null)
        {
            SyncedRandomSeed = reader.ReadInt32();
        }
    }

    public void UpdateBaseData(ModNPC modNPC)
    {
        ModNPC = modNPC;
        npc = ModNPC.NPC;
        if (!ModNPC.NPC.HasValidTarget)
        {
            return;
        }

        if (ModNPC.NPC.HasPlayerTarget)
        {
            target = Main.player[ModNPC.NPC.target];
        }
        else
        {
            target = Main.npc[ModNPC.NPC.target];
        }
        vectorToTarget = target.Center - ModNPC.NPC.Center;
        unitVectorToTarget = vectorToTarget.SafeNormalize(Vector2.UnitX);

        if (!syncedRandomSet)
        {
            if (Parent == null)
            {
                SyncedRandomSeed = Main.rand.Next();
            }
            else
            {
                SyncedRandomSeed = Parent.SyncedRandomSeed;
            }
        }
    }

    /// <summary>
    /// Method that is run on first update when CurrentFrame = 1
    /// </summary>
    protected virtual void Start()
    {
    }

    /// <summary>
    /// Restarts the state from frame zero and as a result also recalls Start()
    /// </summary>
    public void Restart()
    {
        CurrentFrame = 0;
    }

    /// <summary>
    /// External method to be called by a continually updating method in another class
    /// </summary>
    /// <param name="modNPC"></param>
    public void StartUpdate(ModNPC modNPC)
    {
        UpdateBaseData(modNPC);
        CurrentFrame++;

        if (!HasLoaded)
        {
            Load();
            HasLoaded = true;
        }
        if (CurrentFrame == 1)
        {
            Start();
        }

        Update();
    }

    public virtual void PreDraw(SpriteBatch spriteBatch)
    {
    }

    public virtual void PostDraw(SpriteBatch spriteBatch)
    {
    }

    /// <summary>
    /// The main update method which is called every frame
    /// </summary>
    protected virtual void Update()
    {
    }

    /// <summary>
    /// External method that destroys and unloads the state
    /// </summary>
    public void Destroy()
    {
        PreDestroy();
        if (Parent == null || Parent.RepeatTimes <= 0)
        {
            Unload();
        }
        Active = false;
    }

    /// <summary>
    /// Method that is run before state is destroyed
    /// </summary>
    protected virtual void PreDestroy()
    {
    }

    /// <summary>
    /// Use this method to load any resources or effects used by this state
    /// </summary>
    public virtual void Load()
    {
    }

    /// <summary>
    /// Use this method to unload any resources or effects used by this state
    /// </summary>
    public virtual void Unload()
    {
    }
}