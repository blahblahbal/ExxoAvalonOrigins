using ExxoAvalonOrigins.Network;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs.Utils
{
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
        /// A frame time reference with value 1 on first state update.
        /// </summary>
        public uint CurrentFrame { get; private set; }

        public Type Type { get; private set; }

        /// <summary>
        /// The state parent controlling this state
        /// </summary>
        public StateParent Parent { get; private set; }

        /// <summary>
        /// The next state to be executed after destruction
        /// </summary>
        public State NextState { get; private set; }

        public bool HasNextState { get; private set; }
        protected ModNPC ModNPC { get; private set; }
        protected NPC npc;
        protected Entity target;
        protected Vector2 vectorToTarget;
        protected Vector2 unitVectorToTarget;
        // TODO: Implement random number syncing
        //private bool seedSet;
        //private int syncedSeed;
        //protected int SyncedSeed
        //{
        //    get => syncedSeed;
        //    private set
        //    {
        //        syncedSeed = value;
        //        syncedRandom = new Random(syncedSeed);
        //        seedSet = true;
        //    }
        //}
        //protected Random syncedRandom;
        public bool HasLoaded;

        public State()
        {
            Type = GetType();
            Active = true;
            HasLoaded = false;
            //seedSet = false;
        }

        public State(ModNPC modNPC, StateParent parent) : this()
        {
            ModNPC = modNPC;
            Parent = parent;
            HasNextState = false;
        }

        public State(ModNPC modNPC, StateParent parent, State nextState = null) : this(modNPC, parent)
        {
            NextState = nextState;
            HasNextState = (NextState != null);
        }

        public virtual void Write(BinaryWriter writer)
        {
            writer.Write(CurrentFrame);
            if (Parent == null)
            {
                //SyncedSeed = Main.rand.Next();
                //writer.Write(SyncedSeed);
            }

            writer.Write(HasNextState);
            if (HasNextState)
            {
                writer.Write(Parent.GetTypeIndex(NextState.Type));
                dynamic state = Convert.ChangeType(NextState, NextState.Type);
                state.Write(writer);
            }
        }

        public virtual void Read(BinaryReader reader)
        {
            CurrentFrame = reader.ReadUInt32();
            //if (Parent == null)
            //{
                //SyncedSeed = reader.ReadInt32();
            //}

            HasNextState = reader.ReadBoolean();
            if (HasNextState)
            {
                Type type = Parent.UsedTypes[reader.ReadByte()];
                dynamic state = StateFactory.GetDynamicState(Parent, type);
                state.Read(reader);
                NextState = state;
            }
        }

        private void UpdateData()
        {
            npc = ModNPC.npc;
            if (!ModNPC.npc.HasValidTarget)
            {
                return;
            }

            if (ModNPC.npc.HasPlayerTarget)
            {
                target = Main.player[ModNPC.npc.target];
            }
            else
            {
                target = Main.npc[ModNPC.npc.target];
            }
            vectorToTarget = target.Center - ModNPC.npc.Center;
            unitVectorToTarget = vectorToTarget.SafeNormalize(Vector2.UnitX);
        }

        private void Start()
        {
            UpdateData();
            PostStart();
        }

        /// <summary>
        /// Restarts the state from frame zero and as a result also recalls Start()
        /// </summary>
        protected void Restart()
        {
            CurrentFrame = 0;
        }

        /// <summary>
        /// Method that is run on first update when CurrentFrame = 1
        /// </summary>
        protected virtual void PostStart()
        {
        }

        public void Update(ModNPC modNPC)
        {
            ModNPC = modNPC;
            UpdateData();
            CurrentFrame++;

            //if (!seedSet)
            //{
            //    if (Parent != null)
            //    {
            //        SyncedSeed = Parent.SyncedSeed;
            //    }
            //    else
            //    {
            //        SyncedSeed = Main.rand.Next();
            //    }
            //}
            if (!HasLoaded)
            {
                Load();
                HasLoaded = true;
            }
            if (CurrentFrame == 1)
            {
                Start();
            }

            PostUpdate();
        }

        protected virtual void PostUpdate()
        {
        }

        public void Destroy()
        {
            Unload();
            PreDestroy();
            Active = false;
        }

        protected virtual void PreDestroy()
        {
        }

        public void AssignFactoryValues(StateParent parent)
        {
            Parent = parent;
            ModNPC = parent.ModNPC;
        }

        public virtual void Load()
        {
        }

        public virtual void Unload()
        {
        }
    }

    public static class StateFactory
    {
        public static dynamic GetDynamicState(StateParent parent, Type type)
        {
            dynamic state = Activator.CreateInstance(type);
            (state as State).AssignFactoryValues(parent);

            return state;
        }
    }
}