using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Summon;

public class HungrySummon : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hungry");
        Main.projFrames[Projectile.type] = 3;
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Summon/HungrySummon");
        Projectile.netImportant = true;
        Projectile.width = 22;
        Projectile.height = 36;
        //projectile.aiStyle = -1;
        Projectile.penetrate = -1;
        Projectile.timeLeft *= 5;
        Projectile.minion = true;
        Projectile.minionSlots = 1f;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.friendly = true;
        //Main.projPet[projectile.type] = true;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        return false;
    }
    public override void AI()
    {
        Main.player[Projectile.owner].AddBuff(ModContent.BuffType<Buffs.Hungry>(), 3600);
        if (Projectile.type == ModContent.ProjectileType<HungrySummon>())
        {
            if (Main.player[Projectile.owner].dead)
            {
                Main.player[Projectile.owner].Avalon().hungryMinion = false;
            }
            if (Main.player[Projectile.owner].Avalon().hungryMinion)
            {
                Projectile.timeLeft = 2;
            }
        }
        var num820 = 0.05f;
        for (var num821 = 0; num821 < 1000; num821++)
        {
            if (num821 != Projectile.whoAmI && Main.projectile[num821].active && Main.projectile[num821].owner == Projectile.owner && (Main.projectile[num821].type == 387 || Main.projectile[num821].type == 388 || Main.projectile[num821].type == 485 || Main.projectile[num821].type == 498) && Math.Abs(Projectile.position.X - Main.projectile[num821].position.X) + Math.Abs(Projectile.position.Y - Main.projectile[num821].position.Y) < Projectile.width)
            {
                if (Projectile.position.X < Main.projectile[num821].position.X)
                {
                    Projectile.velocity.X = Projectile.velocity.X - num820;
                }
                else
                {
                    Projectile.velocity.X = Projectile.velocity.X + num820;
                }
                if (Projectile.position.Y < Main.projectile[num821].position.Y)
                {
                    Projectile.velocity.Y = Projectile.velocity.Y - num820;
                }
                else
                {
                    Projectile.velocity.Y = Projectile.velocity.Y + num820;
                }
            }
        }
        if (Projectile.ai[0] == 2f && (Projectile.type == ModContent.ProjectileType<HungrySummon>()))
        {
            Projectile.ai[1] += 1f;
            Projectile.MaxUpdates = 1;
            Projectile.rotation = Projectile.velocity.ToRotation() + 3.14159274f;
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 1)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > 2)
            {
                Projectile.frame = 0;
            }
            if (Projectile.ai[1] <= 40f)
            {
                return;
            }
            Projectile.ai[1] = 1f;
            Projectile.ai[0] = 0f;
            Projectile.MaxUpdates = 0;
            Projectile.numUpdates = 0;
            Projectile.netUpdate = true;
        }
        var vector57 = Projectile.position;
        var num822 = 400f;
        var flag32 = false;
        //if (projectile.ai[0] != 1f)
        //{
        //	projectile.tileCollide = true;
        //}
        for (var num823 = 0; num823 < 200; num823++)
        {
            var nPC5 = Main.npc[num823];
            if (nPC5.active && !nPC5.dontTakeDamage && !nPC5.friendly && nPC5.lifeMax > 5)
            {
                var num824 = Vector2.Distance(nPC5.Center, Projectile.Center);
                if (((Vector2.Distance(Projectile.Center, vector57) > num824 && num824 < num822) || !flag32) && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, nPC5.position, nPC5.width, nPC5.height))
                {
                    num822 = num824;
                    vector57 = nPC5.Center;
                    flag32 = true;
                }
            }
        }
        var num825 = 500;
        if (flag32)
        {
            num825 = 1000;
        }
        var player2 = Main.player[Projectile.owner];
        if (Vector2.Distance(player2.Center, Projectile.Center) > num825)
        {
            Projectile.ai[0] = 1f;
            Projectile.tileCollide = false;
            Projectile.netUpdate = true;
        }
        if (flag32 && Projectile.ai[0] == 0f)
        {
            var vector58 = vector57 - Projectile.Center;
            var num826 = vector58.Length();
            vector58.Normalize();
            if (num826 > 200f)
            {
                var scaleFactor5 = 6f;
                if (Projectile.type == ProjectileID.Spazmamini || Projectile.type == ModContent.ProjectileType<HungrySummon>())
                {
                    scaleFactor5 = 8f;
                }
                vector58 *= scaleFactor5;
                Projectile.velocity = (Projectile.velocity * 40f + vector58) / 41f;
            }
            else
            {
                var num827 = 4f;
                vector58 *= -num827;
                Projectile.velocity = (Projectile.velocity * 40f + vector58) / 41f;
            }
        }
        else
        {
            var num828 = 6f;
            if (Projectile.ai[0] == 1f)
            {
                num828 = 15f;
            }
            var value22 = Projectile.Center;
            var vector59 = player2.Center - value22 + new Vector2(0f, -60f);
            var num829 = vector59.Length();
            if (num829 > 200f && num828 < 8f)
            {
                num828 = 8f;
            }
            if (num829 < 150f && Projectile.ai[0] == 1f && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
            {
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;
            }
            if (num829 > 2000f)
            {
                Projectile.position.X = Main.player[Projectile.owner].Center.X - Projectile.width / 2;
                Projectile.position.Y = Main.player[Projectile.owner].Center.Y - Projectile.height / 2;
                Projectile.netUpdate = true;
            }
            if (num829 > 70f)
            {
                vector59.Normalize();
                vector59 *= num828;
                Projectile.velocity = (Projectile.velocity * 40f + vector59) / 41f;
            }
            else if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f)
            {
                Projectile.velocity.X = -0.15f;
                Projectile.velocity.Y = -0.05f;
            }
        }
        if (Projectile.type == ProjectileID.Spazmamini || Projectile.type == ModContent.ProjectileType<HungrySummon>())
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + 3.14159274f;
        }
        if (Projectile.type == ProjectileID.Retanimini)
        {
            if (flag32)
            {
                Projectile.rotation = (vector57 - Projectile.Center).ToRotation() + 3.14159274f;
            }
            else
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + 3.14159274f;
            }
        }
        Projectile.frameCounter++;
        if (Projectile.frameCounter > 3)
        {
            Projectile.frame++;
            Projectile.frameCounter = 0;
        }
        if (Projectile.frame > 2)
        {
            Projectile.frame = 0;
        }
        if (Projectile.ai[1] > 0f)
        {
            Projectile.ai[1] += Main.rand.Next(1, 4);
        }
        if ((Projectile.ai[1] > 40f && Projectile.type == ProjectileID.Spazmamini) || (Projectile.ai[1] > 50f && Projectile.type == ModContent.ProjectileType<HungrySummon>()))
        {
            Projectile.ai[1] = 0f;
            Projectile.netUpdate = true;
        }
        if (Projectile.ai[0] == 0f)
        {
            if (Projectile.type == ModContent.ProjectileType<HungrySummon>() && Projectile.ai[1] == 0f && flag32 && num822 < 500f)
            {
                Projectile.ai[1] += 1f;
                if (Main.myPlayer == Projectile.owner)
                {
                    Projectile.ai[0] = 2f;
                    var value25 = vector57 - Projectile.Center;
                    value25.Normalize();
                    if (Projectile.type == ModContent.ProjectileType<HungrySummon>())
                    {
                        Projectile.velocity = value25 * 5f;
                    }
                    Projectile.netUpdate = true;
                }
            }
        }
    }
}