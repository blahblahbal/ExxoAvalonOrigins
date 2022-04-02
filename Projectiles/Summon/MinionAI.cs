using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Summon;

public abstract class MinionAI : ModProjectile
{
    public override void AI()
    {
        CheckActive();
        Behavior();
    }

    public abstract void CheckActive();

    public abstract void Behavior();
}