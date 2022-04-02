using System.Collections.Generic;
using ExxoAvalonOrigins.Projectiles.Summon;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Players;

public class ExxoSummonPlayer : ModPlayer
{
    private readonly List<bool> daggerSummons = new();

    public int HandleDaggerSummon()
    {
        if (Player.ownedProjectileCounts[ModContent.ProjectileType<AdamantiteDagger>()] > daggerSummons.Count)
        {
            daggerSummons.Add(true);
            return daggerSummons.Count - 1;
        }

        int index = daggerSummons.FindIndex(val => !val);
        daggerSummons[index] = true;
        return index;
    }

    public void RemoveDaggerSummon(int index)
    {
        if (index == daggerSummons.Count - 1)
        {
            daggerSummons.RemoveAt(index);
        }
        else
        {
            daggerSummons[index] = false;
        }
    }

    public void CheckDaggerSummon()
    {
        int diff = Player.ownedProjectileCounts[ModContent.ProjectileType<AdamantiteDagger>()] - daggerSummons.Count;
        if (diff > 0)
        {
            daggerSummons.Capacity = Player.ownedProjectileCounts[ModContent.ProjectileType<AdamantiteDagger>()];
            for (int i = 0; i < diff; i++)
            {
                daggerSummons.Add(true);
            }
        }
    }
}
