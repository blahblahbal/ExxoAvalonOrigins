using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs.Utils
{
    public abstract class State
    {
        public bool Active { get; private set; }
        protected float currentFrame;
        protected Action destroyAction;
        protected ModNPC modNPC;
        protected NPC npc;
        protected Entity target;
        protected Vector2 vectorToTarget;
        protected Vector2 unitVectorToTarget;

        public State(ModNPC modNPC, Action destroyAction = null)
        {
            Active = true;
            this.modNPC = modNPC;
            OnDestroy += destroyAction;
            this.destroyAction = destroyAction;

            Start();
        }

        private void UpdateData()
        {
            npc = modNPC.npc;
            if (!modNPC.npc.HasValidTarget)
            {
                return;
            }

            if (modNPC.npc.HasPlayerTarget)
            {
                target = Main.player[modNPC.npc.target];
            }
            else
            {
                target = Main.npc[modNPC.npc.target];
            }
            vectorToTarget = target.Center - modNPC.npc.Center;
            unitVectorToTarget = vectorToTarget.SafeNormalize(Vector2.UnitX);
        }

        protected void Start()
        {
            currentFrame = 0;

            PreStart();
            UpdateData();
            OnStart?.Invoke();
            PostStart();
        }

        protected event Action OnStart;
        protected virtual void PreStart() { }
        protected virtual void PostStart() { }

        public void Update(ModNPC modNPC)
        {
            this.modNPC = modNPC;
            currentFrame++;

            UpdateData();
            OnUpdate?.Invoke();
            PostUpdate();
        }

        protected event Action OnUpdate;
        protected virtual void PostUpdate() { }

        public void Destroy()
        {
            PreDestroy();
            OnDestroy?.Invoke();
            Active = false;
        }

        protected event Action OnDestroy;

        protected virtual void PreDestroy() { }
    }
}