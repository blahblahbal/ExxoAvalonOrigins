using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins
{
    class ExxoAvalonOriginsGlobalProjectile : GlobalProjectile
    {

        public static bool[] forceReset = new bool[255];

        public static int cooldown = 0;

        public static Rectangle drawZoneRect = default(Rectangle);

        public static void AIRotate(Projectile codable, ref float rotation, ref float moveRot, Vector2 rotateCenter, bool absolute = false, float rotDistance = 50f, float rotThreshold = 20f, float rotAmount = 0.024f, bool moveTowards = true)
        {
            if (absolute)
            {
                moveRot += rotAmount;
                var value = RotateVector(default(Vector2), new Vector2(rotDistance, 0f), moveRot) + rotateCenter;
                codable.position = value - new Vector2(codable.width / 2, codable.height / 2);
                value.Normalize();
                rotation = RotationTo(codable.Center, rotateCenter) - 1.57f;
                codable.velocity *= 0f;
                return;
            }
            var num = Vector2.Distance(codable.Center, rotateCenter);
            if (num < rotDistance)
            {
                if (rotDistance - num > rotThreshold)
                {
                    moveRot += rotAmount;
                    var endPos = RotateVector(default(Vector2), new Vector2(rotDistance, 0f), moveRot) + rotateCenter;
                    var num2 = RotationTo(codable.Center, endPos);
                    codable.velocity = RotateVector(default(Vector2), new Vector2(5f, 0f), num2);
                    rotation = RotationTo(codable.Center, codable.Center + codable.velocity);
                    return;
                }
                moveRot += rotAmount;
                var endPos2 = RotateVector(default(Vector2), new Vector2(rotDistance, 0f), moveRot) + rotateCenter;
                var num3 = RotationTo(codable.Center, endPos2);
                codable.velocity = RotateVector(default(Vector2), new Vector2(5f, 0f), num3);
                rotation = RotationTo(codable.Center, codable.Center + codable.velocity);
                return;
            }
            else
            {
                if (moveTowards)
                {
                    codable.velocity = AIVelocityLinear(codable, rotateCenter, rotAmount, rotAmount, true);
                    rotation = RotationTo(codable.Center, rotateCenter) - 1.57f;
                    return;
                }
                codable.velocity *= 0.95f;
                return;
            }
        }

        public static Vector2 AIVelocityLinear(Projectile codable, Vector2 destVec, float moveInterval, float maxSpeed, bool direct = false)
        {
            var result = codable.velocity;
            var flag = codable.tileCollide;
            if (direct)
            {
                var value = RotateVector(codable.Center, codable.Center + new Vector2(maxSpeed, 0f), RotationTo(codable.Center, destVec));
                result = value - codable.Center;
            }
            else
            {
                if (codable.Center.X > destVec.X)
                {
                    result.X = Math.Max(-maxSpeed, result.X - moveInterval);
                }
                else if (codable.Center.X < destVec.X)
                {
                    result.X = Math.Min(maxSpeed, result.X + moveInterval);
                }
                if (codable.Center.Y > destVec.Y)
                {
                    result.Y = Math.Max(-maxSpeed, result.Y - moveInterval);
                }
                else if (codable.Center.Y < destVec.Y)
                {
                    result.Y = Math.Min(maxSpeed, result.Y + moveInterval);
                }
            }
            if (flag)
            {
                result = Collision.TileCollision(codable.position, result, codable.width, codable.height, false, false, 1);
            }
            return result;
        }

        public static void AIWeapon(Projectile codable, ref float[] ai, ref float rotation, Vector2 targetPos, bool justHit = false, int rotTime = 120, int moveTime = 100, float maxSpeed = 6f, float movementScalar = 1f, float rotScalar = 1f)
        {
            if (ai[0] == 0f)
            {
                var vector = codable.Center;
                var num = targetPos.X - vector.X;
                var num2 = targetPos.Y - vector.Y;
                var num3 = (float)Math.Sqrt(num * num + num2 * num2);
                var num4 = 9f / num3;
                codable.velocity.X = num * num4 * movementScalar;
                codable.velocity.Y = num2 * num4 * movementScalar;
                if (codable.velocity.X > maxSpeed)
                {
                    codable.velocity.X = maxSpeed;
                }
                if (codable.velocity.X < -maxSpeed)
                {
                    codable.velocity.X = -maxSpeed;
                }
                if (codable.velocity.Y > maxSpeed)
                {
                    codable.velocity.Y = maxSpeed;
                }
                if (codable.velocity.Y < -maxSpeed)
                {
                    codable.velocity.Y = -maxSpeed;
                }
                rotation = (float)Math.Atan2(codable.velocity.Y, codable.velocity.X);
                ai[0] = 1f;
                ai[1] = 0f;
                return;
            }
            if (ai[0] == 1f)
            {
                if (justHit)
                {
                    ai[0] = 2f;
                    ai[1] = 0f;
                }
                codable.velocity *= 0.99f;
                ai[1] += 1f;
                if (ai[1] < moveTime)
                {
                    return;
                }
                ai[0] = 2f;
                ai[1] = 0f;
                codable.velocity.X = 0f;
                codable.velocity.Y = 0f;
                return;
            }
            else
            {
                if (justHit)
                {
                    ai[0] = 2f;
                    ai[1] = 0f;
                }
                codable.velocity *= 0.96f;
                ai[1] += 1f;
                rotation += (float)(0.1 + ai[1] / rotTime * 0.40000000596046448) * codable.direction * rotScalar;
                if (ai[1] < rotTime)
                {
                    return;
                }
                if (codable != null)
                {
                    codable.netUpdate = true;
                }
                ai[0] = 0f;
                ai[1] = 0f;
                return;
            }
        }

        public static int[] GetProjectiles(Vector2 center, int[] projTypes, int owner = -1, int[] projsToExclude = null, float distance = 500f, Func<Projectile, bool> CanAdd = null)
        {
            var list = new List<int>();
            for (var i = 0; i < Main.projectile.Length; i++)
            {
                var projectile = Main.projectile[i];
                if (projectile != null && projectile.active && (owner == -1 || projectile.owner == owner) && (distance == -1f || Vector2.Distance(center, projectile.Center) < distance))
                {
                    var flag = false;
                    for (var j = 0; j < projTypes.Length; j++)
                    {
                        var num = projTypes[j];
                        if (projectile.type == num)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        var flag2 = true;
                        if (projsToExclude != null)
                        {
                            for (var k = 0; k < projsToExclude.Length; k++)
                            {
                                var num2 = projsToExclude[k];
                                if (num2 == projectile.whoAmI)
                                {
                                    flag2 = false;
                                    break;
                                }
                            }
                        }
                        if ((!flag2 || CanAdd == null || CanAdd(projectile)) && flag2)
                        {
                            list.Add(i);
                        }
                    }
                }
            }
            return list.ToArray();
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
                    NetMessage.SendTileRange(-1, i, j, 1, 1);
                }
            }
        }
         
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (Main.player[projectile.owner].GetModPlayer<ExxoAvalonOriginsModPlayer>().thornMagic)
                if (projectile.magic)
                    if (Main.rand.Next(10) == 0)
                        Projectile.NewProjectile(projectile.Center, new Vector2(0f, -32f), ProjectileID.NettleBurstRight, projectile.damage, projectile.knockBack, projectile.owner);

            return base.OnTileCollide(projectile, oldVelocity);
        }

        public override bool CanHitPlayer(Projectile projectile, Player target)
        {
            if (target.GetModPlayer<ExxoAvalonOriginsModPlayer>().beeRepel && projectile.type == ProjectileID.Stinger)
            {
                return false;
            }
            return base.CanHitPlayer(projectile, target);
        }

        public override void Kill(Projectile projectile, int timeLeft)
        {
            var instance = projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>();
            if (projectile.type == ModContent.ProjectileType<Projectiles.GuardianHammer2>())
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            if (instance.torch) //Implement torch projectiles
            {
                var num = 0;
                var num2 = 0;
                switch (projectile.type)
                {
                    case 505:
                        num = 8;
                        num2 = 0;
                        break;
                    case 506:
                        num = 427;
                        num2 = 1;
                        break;
                    case 507:
                        num = 428;
                        num2 = 2;
                        break;
                    case 508:
                        num = 429;
                        num2 = 3;
                        break;
                    case 509:
                        num = 430;
                        num2 = 4;
                        break;
                    case 510:
                        num = 431;
                        num2 = 5;
                        break;
                    case 511:
                        num = 432;
                        num2 = 6;
                        break;
                    case 512:
                        num = 433;
                        num2 = 7;
                        break;
                    case 513:
                        num = 523;
                        num2 = 8;
                        break;
                    case 514:
                        num = 974;
                        num2 = 9;
                        break;
                    case 515:
                        num = 1245;
                        num2 = 10;
                        break;
                    case 516:
                        num = 1333;
                        num2 = 11;
                        break;
                    case 517:
                        num = 2274;
                        num2 = 12;
                        break;
                    case 518:
                        num = 3100;
                        num2 = 13;
                        break;
                }
                var num3 = (int)(projectile.position.X + projectile.width * 0.5f) / 16;
                var num4 = (int)(projectile.position.Y + projectile.height * 0.5f) / 16;
                if (num3 < 0 || num3 >= Main.maxTilesX || num4 < 0 || num4 >= Main.maxTilesY)
                {
                    projectile.active = false;
                }
                if (!Main.tile[num3, num4].active())
                {
                    WorldGen.PlaceTile(num3, num4, 4, false, true, -1, 0);
                    WorldGen.TileFrame(num3, num4, false, false);
                    Main.tile[num3, num4].frameY = (short)(num2 * 22);
                    projectile.active = false;
                }
                else
                {
                    Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, num, 1, false, 0, false);
                    projectile.active = false;
                }
                if (!Main.tile[num3, num4].active() && (Main.tile[num3 + 1, num4 + 1].active() || Main.tile[num3 - 1, num4 + 1].active() || Main.tile[num3 + 1, num4 - 1].active() || Main.tile[num3 - 1, num4 - 1].active()) && !Main.tile[num3, num4 + 1].active())
                {
                    Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, num, 1, false, 0, false);
                    projectile.active = false;
                }
                if (Main.tile[num3, num4].liquid > 0)
                {
                    Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, 16, 16, num, 1, false, 0, false);
                    projectile.active = false;
                }
                projectile.active = false;
            }
            var proj = Main.projectile;
            //for (var i = 0; i < proj.Length; i++)
            //{
            //    var projectile2 = proj[i];
            //    if (projectile.type == ModContent.ProjectileType<Projectiles.VenoshockPulse>() && projectile2.active && projectile2.type == ModContent.ProjectileType<Projectiles.Venoshock>() && projectile2.owner == projectile.owner)
            //    {
            //        projectile2.Kill();
            //    }
            //    instance.CHARGE = 0;
            //    projectile.active = false;
            //}
            //if (projectile.type == ModContent.ProjectileType<Projectiles.Venoshock>())
            //{
            //    instance.CHARGE = 0;
            //    projectile.active = false;
            //}
            /*if (projectile.type == ModContent.ProjectileType<Projectiles.GoldenFire>())
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 58);
                var num5 = 4f;
                var num6 = ModContent.ProjectileType<Projectiles.GoldenFlamelet>();
                var num7 = projectile.damage;
                var vector = new Vector2(1f, 0f);
                var num8 = Main.rand.Next(5) + 3;
                var num9 = 180 / (num8 - 1);
                var num10 = Main.rand.Next(90);
                vector = new Vector2((float)Math.Cos(num10) * vector.X - (float)Math.Sin(num10) * vector.Y, (float)Math.Sin(num10) * vector.X + (float)Math.Cos(num10) * vector.Y);
                for (var j = 0; j < num8; j++)
                {
                    var num11 = (float)Math.Cos(num9) * vector.X - (float)Math.Sin(num9) * vector.Y;
                    var num12 = (float)Math.Sin(num9) * vector.X + (float)Math.Cos(num9) * vector.Y;
                    vector.X = num11;
                    vector.Y = num12;
                    float num13 = Main.rand.Next(10) / 10;
                    num11 *= num5 + num13;
                    num12 *= num5 + num13;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, num11, num12, num6, num7, 0f, projectile.owner, 0f, 0f);
                }
                projectile.damage <<= 1;
                projectile.penetrate = 10;
                projectile.width <<= 3;
                projectile.height = projectile.width << 3;
                projectile.Damage();
                for (var k = 0; k < 30; k++)
                {
                    var num14 = 2f - Main.rand.Next(20) / 5f;
                    var num15 = 2f - Main.rand.Next(20) / 5f;
                    num14 *= 4f;
                    num15 *= 4f;
                    Dust.NewDust(new Vector2(projectile.position.X - (projectile.width >> 1), projectile.position.Y - (projectile.height >> 1)), projectile.width, projectile.height, DustID.Enchanted_Gold, num14, num15, 160, default(Color), 1.5f);
                }
            }*/
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
}