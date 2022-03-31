using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins
{
    class ExxoAvalonOriginsGlobalNPCInstance : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get { return true; }
        }

        public override GlobalNPC NewInstance(NPC npc)
        {
            return base.NewInstance(npc);
        }

        public bool jugRunonce = false;
        public bool lavaWalk = false;
        public bool electrified = false;
        public bool frozen = false;
        public int breathCD = 45;
        public bool dlBreath = false;
        public bool silenced = false;
        public bool astigSpawned = false;
        public bool infernaSpawned = false;
        public int oRebirth = 0;
        public int slimeHitCounter = 0;
        public bool noOneHitKill = false;
        public int spikeTimer;
        public bool malaria;
        public bool bleeding;
        public int bleedStacks = 1;
        public bool isBleedingHMBleed = false;
        public bool slowed = false;
    }
}
