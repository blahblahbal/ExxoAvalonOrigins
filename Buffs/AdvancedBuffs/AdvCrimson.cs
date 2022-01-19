using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs
{
    public class AdvCrimson : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Crimson Drain");
            Description.SetDefault("On-screen enemies take damage");
        }

        public override void Update(Player player, ref int k)
        {
            var num7 = (int)player.position.X;
            var num8 = (int)player.position.Y;
            for (var num9 = 0; num9 < Main.npc.Length; num9++)
            {
                var nPC3 = Main.npc[num9];
                if (!nPC3.townNPC && nPC3.active && !nPC3.dontTakeDamage && !nPC3.friendly && nPC3.life >= 1 && nPC3.position.X >= num7 - 620 && nPC3.position.X <= num7 + 620 && nPC3.position.Y >= num8 - 620 && nPC3.position.Y <= num8 + 620)
                {
                    player.Avalon().crimsonCount++;
                    if (player.Avalon().crimsonCount % 50 == 0)
                    {
                        var npc = Main.npc;
                        for (var l = 0; l < npc.Length; l++)
                        {
                            var nPC4 = npc[l];
                            if (nPC4.position.X >= num7 - 620 && nPC4.position.X <= num7 + 620 && nPC4.position.Y >= num8 - 620 && nPC4.position.Y <= num8 + 620 && nPC4.active && !nPC4.dontTakeDamage && !nPC4.townNPC && nPC4.life >= 1 && !nPC4.boss && nPC4.realLife < 0 && nPC4.type != NPCID.GrayGrunt)
                            {
                                nPC4.StrikeNPC(2, 0f, 1, false, false);
                            }
                        }
                        player.Avalon().crimsonCount = 0;
                    }
                }
            }
        }
    }
}