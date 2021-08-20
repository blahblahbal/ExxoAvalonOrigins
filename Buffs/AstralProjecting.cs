﻿using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class AstralProjecting : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Astral Projecting");
            Description.SetDefault("You are immune to damage, but cannot attack anything - touch mobs to inflict a debuff on them");
        }

        public override void Update(Player player, ref int k)
        {
            player.immune = true;
            player.immuneAlpha = 100;
            player.noItems = true;

            foreach (NPC n in Main.npc)
            {
                if (player.getRect().Intersects(n.getRect()))
                {
                    n.AddBuff(ModContent.BuffType<AstralCurse>(), int.MaxValue);
                }
            }
        }
    }
}