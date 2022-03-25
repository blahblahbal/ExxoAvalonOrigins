using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvShockwave : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Shockwave");
            Description.SetDefault("Enemies take damage when you land");
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
    }
}
