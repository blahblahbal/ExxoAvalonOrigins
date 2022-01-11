﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Buffs
{
	public class Leaping : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Leaping");
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