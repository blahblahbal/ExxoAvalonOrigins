using System;
using System.IO;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs.Utils
{
    /// <summary>
    /// A State which calls and manages other states
    /// </summary>
    public abstract class StateParent : State
    {
        public State CurrentState { get; private set; }

        /// <summary>
        /// <para>An array of all the state types that the parent uses.</para>
        /// <para>Ensures minimal bandwidth is used in serialization of type</para>
        /// </summary>
        public abstract Type[] UsedTypes { get; }

        protected uint framesInactive;
        protected uint statePosition;

        public StateParent() : base()
        {
        }

        public StateParent(ModNPC modNPC, StateParent parent) : base(modNPC, parent)
        {
        }

        public StateParent(ModNPC modNPC, StateParent parent, State nextState = null) : base(modNPC, parent, nextState)
        {
        }

        public byte GetTypeIndex(Type type)
        {
            var arr = UsedTypes;
            int typeIndex;
            for (typeIndex = 0; typeIndex < arr.Length; typeIndex++)
            {
                if (type == arr[typeIndex])
                {
                    break;
                }
            }
            return (byte)typeIndex;
        }

        public override void Write(BinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(framesInactive);
            writer.Write(statePosition);

            bool hasCurrentState = CurrentState != null;
            writer.Write(hasCurrentState);
            if (hasCurrentState)
            {
                writer.Write(GetTypeIndex(CurrentState.Type));
                CurrentState.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            base.Read(reader);
            framesInactive = reader.ReadUInt32();
            statePosition = reader.ReadUInt32();

            bool hasCurrentState = reader.ReadBoolean();
            if (hasCurrentState)
            {
                Type type = UsedTypes[reader.ReadByte()];
                dynamic state = StateFactory.GetDynamicState(this, type);
                state.Read(reader);
                if (type != CurrentState?.Type)
                {
                    CurrentState?.Unload();
                }
                else
                {
                    (state as State).HasLoaded = true;
                }
                CurrentState = state;
            }
        }

        protected void SetState(State state)
        {
            CurrentState = state;
        }

        protected void SetFirstState(State state)
        {
            statePosition = 0;
            SetState(state);
        }

        protected override void PostUpdate()
        {
            if (CurrentState == null)
            {
                framesInactive++;
                InactiveUpdate();
                return;
            }

            if (CurrentState.Active)
            {
                framesInactive = 0;
                CurrentState.Update(ModNPC);
            }
            else if (CurrentState.NextState != null)
            {
                statePosition++;
                PreAdvanceState();
                CurrentState = CurrentState.NextState;
                CurrentState.Update(ModNPC);
            }
            else
            {
                if (framesInactive == 0)
                {
                    statePosition++;
                    PreAdvanceState();
                }
                if (!CurrentState.Active)
                {
                    framesInactive++;
                    InactiveUpdate();
                }
            }
        }

        protected override void PreDestroy()
        {
            CurrentState?.Destroy();
        }

        public override void Unload()
        {
            CurrentState?.Unload();
        }

        protected virtual void InactiveUpdate()
        {
        }

        protected virtual void PreAdvanceState()
        {
        }
    }
}