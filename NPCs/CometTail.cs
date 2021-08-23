using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
    public class CometTail : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Comet Tail");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.damage = 70;
            npc.lifeMax = 310;
            npc.defense = 20;
            npc.noGravity = true;
            npc.width = 22;
            npc.aiStyle = -1;
            npc.noTileCollide = true;
            npc.value = 400f;
            npc.height = 22;
            npc.knockBackResist = 0.4f;
            npc.HitSound = SoundID.NPCHit3;
	        npc.DeathSound = SoundID.NPCDeath3;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(40) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.HydrolythOre>(), 1, false, 0, false);
            }
        }

        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            var num146 = 1f;
            var num147 = 0.03f;
            var vector17 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            var num149 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            var num150 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
            num149 = (int)(num149 / 8f) * 8;
            num150 = (int)(num150 / 8f) * 8;
            vector17.X = (int)(vector17.X / 8f) * 8;
            vector17.Y = (int)(vector17.Y / 8f) * 8;
            num149 -= vector17.X;
            num150 -= vector17.Y;
            var num151 = (float)Math.Sqrt(num149 * num149 + num150 * num150);
            var num152 = num151;
            if (num151 == 0f)
            {
                num149 = npc.velocity.X;
                num150 = npc.velocity.Y;
            }
            else
            {
                num151 = num146 / num151;
                num149 *= num151;
                num150 *= num151;
            }
            if (Main.player[npc.target].dead)
            {
                num149 = npc.direction * num146 / 2f;
                num150 = -num146 / 2f;
            }
            if (npc.velocity.X < num149)
            {
                npc.velocity.X = npc.velocity.X + num147;
                if (npc.velocity.X < 0f && num149 > 0f)
                {
                    npc.velocity.X = npc.velocity.X + num147;
                }
            }
            else if (npc.velocity.X > num149)
            {
                npc.velocity.X = npc.velocity.X - num147;
                if (npc.velocity.X > 0f && num149 < 0f)
                {
                    npc.velocity.X = npc.velocity.X - num147;
                }
            }
            if (npc.velocity.Y < num150)
            {
                npc.velocity.Y = npc.velocity.Y + num147;
                if (npc.velocity.Y < 0f && num150 > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + num147;
                }
            }
            else if (npc.velocity.Y > num150)
            {
                npc.velocity.Y = npc.velocity.Y - num147;
                if (npc.velocity.Y > 0f && num150 < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - num147;
                }
            }
            if (num149 > 0f)
            {
                npc.spriteDirection = 1;
                npc.rotation = (float)Math.Atan2(num150, num149);
            }
            else if (num149 < 0f)
            {
                npc.spriteDirection = -1;
                npc.rotation = (float)Math.Atan2(num150, num149) + 3.14f;
            }
            var num157 = 0.7f;
            if (npc.collideX)
            {
                npc.netUpdate = true;
                npc.velocity.X = npc.oldVelocity.X * -num157;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
                {
                    npc.velocity.X = 2f;
                }
                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
                {
                    npc.velocity.X = -2f;
                }
            }
            if (npc.collideY)
            {
                npc.netUpdate = true;
                npc.velocity.Y = npc.oldVelocity.Y * -num157;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1.5)
                {
                    npc.velocity.Y = 2f;
                }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1.5)
                {
                    npc.velocity.Y = -2f;
                }
            }
            else
            {
                var num159 = Dust.NewDust(new Vector2(npc.position.X - npc.velocity.X, npc.position.Y - npc.velocity.Y), npc.width, npc.height, DustID.MagicMirror, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[num159].noGravity = true;
                var dust11 = Main.dust[num159];
                dust11.velocity.X = dust11.velocity.X * 0.3f;
                var dust12 = Main.dust[num159];
                dust12.velocity.Y = dust12.velocity.Y * 0.3f;
            }
            if (Main.dayTime || Main.player[npc.target].dead)
            {
                npc.velocity.Y = npc.velocity.Y - num147 * 2f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
            }
            if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
            {
                npc.netUpdate = true;
                return;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 8.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }
    }
}