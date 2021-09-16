using System.IO;

namespace ExxoAvalonOrigins.NPCs.Utils
{
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
        protected uint TreeID { get; private set; }
        /// <summary>
        /// The position within the current state tree starting from 0
        /// </summary>
        protected uint StatePosition { get; private set; }
        /// <summary>
        /// Whether or not to destroy after first tree has finished
        /// </summary>
        public abstract bool AutoDestroyOnFinish { get; }

        /// <summary>
        /// Frame counter for the inactive update when no tree is running, starting at 1
        /// </summary>
        protected uint FramesInactive { get; private set; }

        public override void Write(BinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(FramesInactive);
            writer.Write(StatePosition);
            writer.Write(TreeID);

            bool currentStateActive = CurrentState != null && CurrentState.Active;
            writer.Write(currentStateActive);
            if (currentStateActive)
            {
                CurrentState.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            base.Read(reader);
            FramesInactive = reader.ReadUInt32();
            StatePosition = reader.ReadUInt32();
            TreeID = reader.ReadUInt32();

            bool currentStateActive = reader.ReadBoolean();
            if (currentStateActive)
            {
                State oldState = CurrentState;
                HandleAdvanceState();
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
        }

        /// <summary>
        /// Sets the current state to the specified state
        /// </summary>
        /// <param name="state">The state to start</param>
        protected void SetState(State state)
        {
            state.Parent = this;
            CurrentState = state;
        }

        /// <summary>
        /// Start the specified tree at state position 0
        /// </summary>
        /// <param name="treeID">The identifier for the state tree</param>
        protected void StartTree(uint treeID)
        {
            TreeID = treeID;
            StatePosition = 0;
            HandleAdvanceState();
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
                    StatePosition++;
                    HandleAdvanceState();
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
        /// Method that gets run after a state has finished, use to implement logic and modify state within a tree
        /// </summary>
        protected abstract void HandleAdvanceState();
    }
}