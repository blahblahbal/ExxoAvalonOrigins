﻿using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class TroxiniumDagger : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Troxinium Dagger");
            Description.SetDefault("The dagger will fight for you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int k)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.TroxiniumDagger>()] > 0)
            {
                player.Avalon().troxiniumDagger = true;
            }
            if (!player.Avalon().troxiniumDagger)
            {
                player.DelBuff(k);
                k--;
            }
            else
            {
                player.buffTime[k] = 18000;
            }
            player.Avalon().daggerStaffRotTimer += 0.5f;
            if (player.Avalon().daggerStaffRotTimer >= 360)
                player.Avalon().daggerStaffRotTimer = 0;
        }
    }
}