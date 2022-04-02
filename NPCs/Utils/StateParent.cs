using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.NPCs.Utils;

/// <summary>
/// A State which calls and manages other states
/// </summary>
public abstract class StateParent : State
{
    /// <summary>
    /// The current state being executed
    /// </summary>
    public State CurrentState { get; private set; }
    /// <summary>
    /// Reference to the current state tree being executed by this parent
    /// </summary>
    protected byte TreeID { get; private set; }
    /// <summary>
    /// The position within the current state tree starting from 0
    /// </summary>
    protected byte StatePosition { get; private set; }
    /// <summary>
    /// Whether or not to destroy after first tree has finished
    /// </summary>
    protected abstract bool AutoDestroyOnFinish { get; }

    /// <summary>
    /// Frame counter for the inactive update when no tree is running, starting at 1
    /// </summary>
    protected uint FramesInactive { get; private set; }
    public ushort RepeatTimes { get; private set; }

    public virtual void PreWrite(BinaryWriter writer) { }
    public virtual void PreRead(BinaryReader reader) { }

    public sealed override void Write(BinaryWriter writer)
    {
        PreWrite(writer);
        base.Write(writer);
        writer.Write(FramesInactive);
        writer.Write(StatePosition);
        writer.Write(TreeID);

        bool currentStateActive = CurrentState?.Active != null && CurrentState.Active;
        writer.Write(currentStateActive);
        if (currentStateActive)
        {
            CurrentState.Write(writer);
        }

        writer.Write(RepeatTimes);
    }

    public sealed override void Read(BinaryReader reader)
    {
        PreRead(reader);
        base.Read(reader);
        FramesInactive = reader.ReadUInt32();
        StatePosition = reader.ReadByte();
        TreeID = reader.ReadByte();

        bool currentStateActive = reader.ReadBoolean();
        if (currentStateActive)
        {
            State oldState = CurrentState;
            HandleAdvanceState(false);
            CurrentState.UpdateBaseData(ModNPC);
            CurrentState.Read(reader);
            if (oldState != null)
            {
                if (CurrentState.Type != oldState.Type)
                {
                    oldState.Unload();
                }
                else
                {
                    CurrentState.HasLoaded = oldState.HasLoaded;
                }
            }
        }
        RepeatTimes = reader.ReadUInt16();
    }

    /// <summary>
    /// Sets the current state to the specified state
    /// </summary>
    /// <param name="state">The state to start</param>
    protected void SetState(State state, ushort repeatTimes = 0)
    {
        RepeatTimes = repeatTimes;
        state.Parent = this;
        CurrentState = state;
    }

    /// <summary>
    /// Start the specified tree at state position 0
    /// </summary>
    /// <param name="treeID">The identifier for the state tree</param>
    protected void StartTree(byte treeID)
    {
        TreeID = treeID;
        StatePosition = 0;
        HandleAdvanceState(true);
    }

    /// <summary>
    /// Method to get run before every update
    /// </summary>
    protected virtual void PreUpdate()
    {
    }

    protected sealed override void Update()
    {
        PreUpdate();

        if (CurrentState == null)
        {
            FramesInactive++;
            InactiveUpdate();
            return;
        }

        if (CurrentState.Active)
        {
            FramesInactive = 0;
            CurrentState.StartUpdate(ModNPC);
        }
        else
        {
            if (FramesInactive == 0)
            {
                if (RepeatTimes > 0)
                {
                    RepeatTimes--;
                    bool hasLoaded = CurrentState.HasLoaded;
                    ushort repeatTimes = RepeatTimes;
                    HandleAdvanceState(true);
                    RepeatTimes = repeatTimes;
                    CurrentState.HasLoaded = hasLoaded;
                }
                else
                {
                    StatePosition++;
                    HandleAdvanceState(true);
                    if (CurrentState.Active)
                    {
                        CurrentState.StartUpdate(ModNPC);
                    }
                    else
                    {
                        if (AutoDestroyOnFinish)
                        {
                            Destroy();
                        }
                        else
                        {
                            FramesInactive++;
                            InactiveUpdate();
                        }
                    }
                }
            }
            else
            {
                FramesInactive++;
                InactiveUpdate();
            }
        }
    }

    public override void Unload()
    {
        CurrentState?.Unload();
    }

    protected override void PreDestroy()
    {
        CurrentState?.Destroy();
    }

    /// <summary>
    /// Method to run while no state is being run
    /// </summary>
    protected virtual void InactiveUpdate()
    {
    }

    /// <summary>
    /// Important method that gets run to determine the current state of the parent, use to implement logic and modify state within a tree
    /// Use TreeID and StatePosition as means of branching to the correct state,
    /// Use SetState to set the state to be run for a particular branch,
    /// </summary>
    /// <param name="isNewState">Should be used to run any additional code accompanying a SetState if present</param>
    protected abstract void HandleAdvanceState(bool isNewState);

    public T FindState<T>() where T : State
    {
        if (CurrentState is T t)
        {
            return t;
        }
        else if (CurrentState is StateParent stateParent)
        {
            return stateParent.FindState<T>();
        }
        else
        {
            return null;
        }
    }

    public override void PreDraw(SpriteBatch spriteBatch)
    {
        CurrentState?.PreDraw(spriteBatch);
    }

    public override void PostDraw(SpriteBatch spriteBatch)
    {
        CurrentState?.PostDraw(spriteBatch);
    }
}