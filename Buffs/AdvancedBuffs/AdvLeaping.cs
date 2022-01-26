﻿using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvLeaping : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Leaping");
            Description.SetDefault("Vertical acceleration is increased");
        }

        public override void Update(Player player, ref int k)
        {
            if (player.controlJump && player.wingsLogic != 0)
            {
                player.velocity.Y = player.velocity.Y - 0.7f * player.gravDir;
                if (player.gravDir == 1f)
                {
                    if (player.velocity.Y > 0f)
                    {
                        player.velocity.Y = player.velocity.Y - 1f;
                    }
                    else if (player.velocity.Y > -Player.jumpSpeed)
                    {
                        player.velocity.Y = player.velocity.Y - 0.5f;
                    }
                    if (player.velocity.Y < -Player.jumpSpeed * 4.5f)
                    {
                        player.velocity.Y = -Player.jumpSpeed * 4.5f;
                    }
                }
                else
                {
                    if (player.velocity.Y < 0f)
                    {
                        player.velocity.Y = player.velocity.Y + 1f;
                    }
                    else if (player.velocity.Y < Player.jumpSpeed)
                    {
                        player.velocity.Y = player.velocity.Y + 0.5f;
                    }
                    if (player.velocity.Y > Player.jumpSpeed * 4.5f)
                    {
                        player.velocity.Y = Player.jumpSpeed * 4.5f;
                    }
                }
            }
        }
    }
}
