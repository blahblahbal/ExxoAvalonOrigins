using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins;

class ExxoAvalonOriginsGlobalProjectile : GlobalProjectile
{
    public static bool[] forceReset = new bool[255];

    public static int cooldown = 0;

    public static int[] notReflect = new int[]
    {
        ProjectileID.RainCloudMoving,
        ProjectileID.RainCloudRaining,
        ProjectileID.BloodCloudMoving,
        ProjectileID.BloodCloudRaining,
        ProjectileID.FrostHydra,
        ProjectileID.InfernoFriendlyBolt,
        ProjectileID.InfernoFriendlyBlast,
        ProjectileID.PhantasmalDeathray,
        ProjectileID.FlyingPiggyBank,
        ProjectileID.Glowstick,
        ProjectileID.BouncyGlowstick,
        ProjectileID.SpelunkerGlowstick,
        ProjectileID.StickyGlowstick,
        ProjectileID.WaterGun,
        ProjectileID.SlimeGun,
        ModContent.ProjectileType<Projectiles.Ghostflame>(),
        ModContent.ProjectileType<Projectiles.WallofSteelLaser>(),
        ModContent.ProjectileType<Projectiles.ElectricBolt>(),
        ModContent.ProjectileType<Projectiles.HomingRocket>(),
        ModContent.ProjectileType<Projectiles.StingerLaser>(),
        ModContent.ProjectileType<Projectiles.CaesiumFireball>(),
        ModContent.ProjectileType<Projectiles.CaesiumCrystal>(),
        ModContent.ProjectileType<Projectiles.CaesiumGas>(),
        ModContent.ProjectileType<Projectiles.SpikyBall>(),
        ModContent.ProjectileType<Projectiles.Spike>(),
        ModContent.ProjectileType<Projectiles.CrystalShard>(),
        ModContent.ProjectileType<Projectiles.WallofSteelLaserEnd>(),
        ModContent.ProjectileType<Projectiles.WallofSteelLaserStart>(),
        ModContent.ProjectileType<Projectiles.CrystalBit>(),
        ModContent.ProjectileType<Projectiles.CrystalBeam>(),
        ModContent.ProjectileType<Projectiles.Mechastinger>(),
    };

    public static Rectangle drawZoneRect = default(Rectangle);

    public static int FindClosestHostile(Vector2 pos, float dist)
    {
        int closest = -1;
        float last = dist;
        for (int i = 0; i < Main.projectile.Length; i++)
        {
            Projectile p = Main.projectile[i];
            if (!p.active || !p.hostile) continue;
            if (Vector2.Distance(pos, p.Center) < last)
            {
                last = Vector2.Distance(pos, p.Center);
                closest = i;
            }
        }
        return closest;
    }

    public static int[] GetNPCs(Vector2 center, int npcType = -1, int[] npcsToExclude = null, float distance = 500f, Func<NPC, bool> CanAdd = null)
    {
        var list = new List<int>();
        for (var i = 0; i < Main.npc.Length; i++)
        {
            var nPC = Main.npc[i];
            if (nPC != null && nPC.active && nPC.life > 0 && (npcType == -1 || nPC.type == npcType) && Vector2.Distance(center, nPC.Center) < distance)
            {
                var flag = true;
                if (npcsToExclude != null)
                {
                    for (var j = 0; j < npcsToExclude.Length; j++)
                    {
                        var num = npcsToExclude[j];
                        if (num == nPC.whoAmI)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if ((!flag || CanAdd == null || CanAdd(nPC)) && flag)
                {
                    list.Add(i);
                }
            }
        }
        return list.ToArray();
    }

    public static Vector2 RotateVector(Vector2 origin, Vector2 vecToRot, float rot)
    {
        var x = (float)(Math.Cos(rot) * (vecToRot.X - origin.X) - Math.Sin(rot) * (vecToRot.Y - origin.Y) + origin.X);
        var y = (float)(Math.Sin(rot) * (vecToRot.X - origin.X) + Math.Cos(rot) * (vecToRot.Y - origin.Y) + origin.Y);
        return new Vector2(x, y);
    }

    public static float RotationTo(Vector2 startPos, Vector2 endPos)
    {
        return (float)Math.Atan2(endPos.Y - startPos.Y, endPos.X - startPos.X);
    }
    //public override void SetDefaults(Projectile projectile)
    //{
    //    switch (projectile.type)
    //    {
    //        case ProjectileID.Stinger:
    //        case ProjectileID.RainCloudMoving:
    //        case ProjectileID.RainCloudRaining:
    //        case ProjectileID.BloodCloudMoving:
    //        case ProjectileID.BloodCloudRaining:
    //        case ProjectileID.FrostHydra:
    //        case ProjectileID.InfernoFriendlyBolt:
    //        case ProjectileID.InfernoFriendlyBlast:
    //        case ProjectileID.PhantasmalDeathray:
    //        case ProjectileID.FlyingPiggyBank:
    //        case ProjectileID.Glowstick:
    //        case ProjectileID.BouncyGlowstick:
    //        case ProjectileID.SpelunkerGlowstick:
    //        case ProjectileID.StickyGlowstick:
    //            projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
    //            break;
    //    }
    //}
    public static void DrawChain(object sb, Texture2D texture, int shader, Vector2 start, Vector2 end, float Jump = 0f, Color? overrideColor = null, float scale = 1f, bool drawEndsUnder = false, Func<Texture2D, Vector2, Vector2, Vector2, Rectangle, Color, float, float, int, bool> OnDrawTex = null)
    {
        DrawChain(sb, new Texture2D[]
        {
            texture,
            texture,
            texture
        }, shader, start, end, Jump, overrideColor, scale, drawEndsUnder, OnDrawTex);
    }

    public static void DrawChain(object sb, Texture2D[] textures, int shader, Vector2 start, Vector2 end, float Jump = 0f, Color? overrideColor = null, float scale = 1f, bool drawEndsUnder = false, Func<Texture2D, Vector2, Vector2, Vector2, Rectangle, Color, float, float, int, bool> OnDrawTex = null)
    {
        if (Jump <= 0f)
        {
            Jump = (textures[1].Height - 2f) * scale;
        }
        var value = end - start;
        value.Normalize();
        var length = Vector2.Distance(start, end);
        var Way = 0f;
        var rotation = RotationTo(start, end) - 1.57f;
        var num = 0;
        var maxTextures = textures.Length - 2;
        var num2 = 0;
        while (Way < length)
        {
            Action action = delegate
            {
                if (textures[0] != null && Way == 0f)
                {
                    float num5 = textures[0].Width;
                    float num6 = textures[0].Height;
                    var vector3 = new Vector2(num5 / 2f, num6 / 2f) * scale;
                    var value2 = start - Main.screenPosition + vector3;
                    var color2 = overrideColor.HasValue ? overrideColor.Value : GetLightColor(start + vector3);
                    if ((OnDrawTex == null || OnDrawTex(textures[0], start + vector3, value2 - vector3, vector3, new Rectangle(0, 0, (int)num5, (int)num6), color2, rotation, scale, -1)) && sb is SpriteBatch)
                    {
                        ((SpriteBatch)sb).Draw(textures[0], value2 - vector3, new Rectangle?(new Rectangle(0, 0, (int)num5, (int)num6)), color2, rotation, vector3, scale, SpriteEffects.None, 0f);
                    }
                }
                if (textures[maxTextures + 1] != null && Way + Jump >= length)
                {
                    float num7 = textures[maxTextures + 1].Width;
                    float num8 = textures[maxTextures + 1].Height;
                    var vector4 = new Vector2(num7 / 2f, num8 / 2f) * scale;
                    var value3 = end - Main.screenPosition + vector4;
                    var color3 = overrideColor.HasValue ? overrideColor.Value : GetLightColor(end + vector4);
                    if (OnDrawTex != null && !OnDrawTex(textures[maxTextures + 1], end + vector4, value3 - vector4, vector4, new Rectangle(0, 0, (int)num7, (int)num8), color3, rotation, scale, -2))
                    {
                        return;
                    }
                    if (sb is SpriteBatch)
                    {
                        ((SpriteBatch)sb).Draw(textures[maxTextures + 1], value3 - vector4, new Rectangle?(new Rectangle(0, 0, (int)num7, (int)num8)), color3, rotation, vector4, scale, SpriteEffects.None, 0f);
                    }
                }
            };
            float num3 = textures[1].Width;
            float num4 = textures[1].Height;
            var vector = new Vector2(num3 / 2f, num4 / 2f) * scale;
            var vector2 = start + value * Way + vector;
            if (InDrawZone(vector2))
            {
                vector2 -= Main.screenPosition;
                if ((Way == 0f || Way + Jump >= length) && drawEndsUnder)
                {
                    action();
                }
                var color = overrideColor.HasValue ? overrideColor.Value : GetLightColor(start + value * Way + vector);
                num++;
                if (num >= maxTextures)
                {
                    num = 0;
                }
                if ((OnDrawTex == null || OnDrawTex(textures[num + 1], start + value * Way + vector, vector2 - vector, vector, new Rectangle(0, 0, (int)num3, (int)num4), color, rotation, scale, num2)) && sb is SpriteBatch)
                {
                    ((SpriteBatch)sb).Draw(textures[num + 1], vector2 - vector, new Rectangle?(new Rectangle(0, 0, (int)num3, (int)num4)), color, rotation, vector, scale, SpriteEffects.None, 0f);
                }
                num2++;
                if ((Way == 0f || Way + Jump >= length) && !drawEndsUnder)
                {
                    action();
                }
            }
            Way += Jump;
        }
    }

    public static bool InDrawZone(Vector2 vec)
    {
        if ((int)Main.screenPosition.X - 300 != drawZoneRect.X || (int)Main.screenPosition.Y - 300 != drawZoneRect.Y)
        {
            drawZoneRect = new Rectangle((int)Main.screenPosition.X - 300, (int)Main.screenPosition.Y - 300, Main.screenWidth + 600, Main.screenHeight + 600);
        }
        return drawZoneRect.Contains((int)vec.X, (int)vec.Y);
    }

    public static Color GetLightColor(Vector2 position)
    {
        return Lighting.GetColor((int)(position.X / 16f), (int)(position.Y / 16f));
    }
    public override void AI(Projectile projectile)
    {
        if (Main.player[projectile.owner].HasBuff(ModContent.BuffType<Buffs.Piercing>()) && projectile.penetrate != -1)
        {
            if (!projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().piercingUp)
            {
                projectile.penetrate++;
                projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().piercingUp = true;
            }
        }
    }

    public override void PostAI(Projectile projectile)
    {
        if ((projectile.type != 10 && projectile.type != 145 && projectile.type != ModContent.ProjectileType<Projectiles.LimeSolution>()) || projectile.owner != Main.myPlayer)
        {
            return;
        }
        int num = (int)(projectile.Center.X / 16f);
        int num2 = (int)(projectile.Center.Y / 16f);
        bool flag = projectile.type == 10;
        for (int i = num - 1; i <= num + 1; i++)
        {
            for (int j = num2 - 1; j <= num2 + 1; j++)
            {
                if (projectile.type == ProjectileID.PureSpray || projectile.type == ProjectileID.PurificationPowder)
                {
                    ExxoAvalonOriginsWorld.ConvertFromThings(i, j, 0, !flag);
                }
                if (projectile.type == ModContent.ProjectileType<Projectiles.LimeSolution>())
                {
                    ExxoAvalonOriginsWorld.ConvertFromThings(i, j, 1, !flag);
                }
                NetMessage.SendTileSquare(-1, i, j, 1, 1);
            }
        }
    }

    public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
    {
        if (Main.player[projectile.owner].Avalon().thornMagic)
            if (projectile.DamageType == DamageClass.Magic)
                if (Main.rand.Next(10) == 0)
                    Projectile.NewProjectile(Main.player[projectile.owner].GetProjectileSource_SetBonus(ProjectileSourceID.None), projectile.Center, new Vector2(0f, -32f), ProjectileID.NettleBurstRight, projectile.damage, projectile.knockBack, projectile.owner);

        return base.OnTileCollide(projectile, oldVelocity);
    }

    public override bool CanHitPlayer(Projectile projectile, Player target)
    {
        if (target.Avalon().beeRepel && projectile.type == ProjectileID.Stinger)
        {
            return false;
        }
        if (target.Avalon().trapImmune && projectile.type == ProjectileID.PoisonDartTrap ||
            target.Avalon().trapImmune && projectile.type == ProjectileID.SpearTrap ||
            target.Avalon().trapImmune && projectile.type == ProjectileID.FlamesTrap ||
            target.Avalon().trapImmune && projectile.type == ProjectileID.FlamethrowerTrap ||
            target.Avalon().trapImmune && projectile.type == ProjectileID.SpikyBallTrap ||
            target.Avalon().trapImmune && projectile.type == ProjectileID.GeyserTrap ||
            target.Avalon().trapImmune && projectile.type == ProjectileID.Boulder)
        {
            return false;
        }
        return base.CanHitPlayer(projectile, target);
    }
    public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
    {
        if (projectile.type == ModContent.ProjectileType<Projectiles.OnyxHook>())
        {
            damage = Main.player[projectile.owner].statDefense;
        }
    }
    public static int howManyProjectiles(int min, int max)
    {
        var output = min;
        for (var i = min; i < max; i++)
        {
            if (Main.rand.Next(2 ^ (max - i)) == 0)
            {
                output++;
            }
        }
        return output;
    }

    public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
    {
        if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().lightOnFire)
        {
            target.AddBuff(BuffID.OnFire, 300, false);
        }
    }

    public override void OnHitPvp(Projectile projectile, Player target, int damage, bool crit)
    {
        if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().lightOnFire)
        {
            target.AddBuff(BuffID.OnFire, 300, false);
        }
    }

    public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
    {
        if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().lightOnFire)
        {
            target.AddBuff(BuffID.OnFire, 420, false);
        }
    }
}
