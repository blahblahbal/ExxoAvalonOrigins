using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs.Utils
{
    public class StateParent : State
    {
        protected List<State> states;
        public StateParent(ModNPC modNPC, Action destroyAction = null) : base(modNPC, destroyAction) {}
        protected sealed override void PreStart()
        {
            states = new List<State>();
        }
        protected override void PostUpdate()
        {
            for (var i = 0; i < states.Count; i++)
            {
                if (!states[i].Active)
                {
                    states.RemoveAt(i);
                    i--;
                    continue;
                }
                else
                {
                    states[i].Update(modNPC);
                }
            }
        }
    }
}
