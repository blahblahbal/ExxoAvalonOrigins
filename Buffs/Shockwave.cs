using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Shockwave : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shockwave");
            Description.SetDefault("On-screen enemies take damage when you land");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.Avalon().shockWave = true;
            int sw = (Main.screenWidth);
            int sh = (Main.screenHeight);
            int sx = (int)(Main.screenPosition.X);
            int sy = (int)(Main.screenPosition.Y);
            if (player.Avalon().fallStart_old == -1) player.Avalon().fallStart_old = player.fallStart;
            int fall_dist = 0;
            if (player.velocity.Y == 0f) // detect landing from a fall
            {
                fall_dist = (int)(((int)(player.position.Y / 16f) - player.Avalon().fallStart_old) * player.gravDir);
            }
            Vector2 p_pos = player.position + new Vector2(player.width, player.height) / 2f;
            int numOfNPCs = 0;
            if (fall_dist > 3) // just fell
            {
                for (int o = 0; o < Main.npc.Length; o++)
                { // iterate through NPCs
                    NPC N = Main.npc[o];
                    List<NPC> list = new List<NPC>();
                    if (!N.active || N.dontTakeDamage || N.friendly || N.life < 1) continue;
                    if ((N.position.X >= sx) && (N.position.X <= sx + sw) && (N.position.Y >= sy) && (N.position.Y <= sy + sh))
                    {
                        list.Add(N);
                    }
                    Vector2 n_pos = new Vector2(N.position.X + N.width * 0.5f, N.position.Y + N.height * 0.5f); // NPC location
                    int HitDir = -1;
                    if (n_pos.X > p_pos.X) HitDir = 1;
                    if ((N.position.X >= sx) && (N.position.X <= sx + sw) && (N.position.Y >= sy) && (N.position.Y <= sy + sh))
                    { // on screen
                        numOfNPCs++;
                        int multiplier = 2;
                        if (player.Avalon().earthInsig && Main.hardMode) multiplier = 6;
                        else if (!player.Avalon().earthInsig && Main.hardMode) multiplier = 4;
                        else if (player.Avalon().earthInsig && !Main.hardMode) multiplier = 3;
                        else if (!player.Avalon().earthInsig && !Main.hardMode) multiplier = 2;
                        N.StrikeNPC(multiplier * fall_dist, 5f, HitDir);
                        if (Main.netMode != 0) NetMessage.SendData(28, -1, -1, null, o, multiplier * fall_dist, 10f, HitDir, 0); // for multiplayer support
                        if (player.isOnGround() && numOfNPCs == list.Count - 1) break;
                        
                        // optionally add debuff here
                    } // END on screen
                } // END iterate through NPCs
            } // END just fell
            player.Avalon().fallStart_old = player.fallStart;
        }
        //public override void Update(Player player, ref int k)
        //{
        //	player.Avalon().shockWave = true;
        //	var screenWidth = Main.screenWidth;
        //	var screenHeight = Main.screenHeight;
        //	var num3 = (int)Main.screenPosition.X;
        //	var num4 = (int)Main.screenPosition.Y;
        //	if (player.Avalon().fallStart_old == -1)
        //	{
        //		player.Avalon().fallStart_old = player.fallStart;
        //	}
        //	var num5 = 0;
        //	if (player.velocity.Y == 0f)
        //	{
        //		num5 = (int)(((int)(player.position.Y / 16f) - player.Avalon().fallStart_old) * player.gravDir);
        //	}
        //	var vector = player.position + new Vector2(player.width, player.height) / 2f;
        //	if (num5 > 3)
        //	{
        //		for (var num6 = 0; num6 < Main.npc.Length; num6++)
        //		{
        //			var nPC2 = Main.npc[num6];
        //			if (nPC2.active && !nPC2.dontTakeDamage && !nPC2.friendly && nPC2.life >= 1)
        //			{
        //				var vector2 = new Vector2(nPC2.position.X + nPC2.width * 0.5f, nPC2.position.Y + nPC2.height * 0.5f);
        //				var hitDirection = -1;
        //				if (vector2.X > vector.X)
        //				{
        //					hitDirection = 1;
        //				}
        //				if (nPC2.position.X >= num3 && nPC2.position.X <= num3 + screenWidth && nPC2.position.Y >= num4 && nPC2.position.Y <= num4 + screenHeight)
        //				{
        //					nPC2.StrikeNPC((player.Avalon().earthInsig ? 3 : 2) * num5, 5f, hitDirection, false, false);
        //				}
        //			}
        //		}
        //	}
        //	player.Avalon().fallStart_old = player.fallStart;
        //}
    }
}
