using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins
{
    class ExxoAvalonOriginsGlobalProjectileInstance : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get { return true; }
        }

        public override GlobalProjectile NewInstance(Projectile projectile)
        {
            return base.NewInstance(projectile);
        }
        public Vector2 bloodArrowPos = Vector2.Zero;

        public int Pindex = -1;
        public Vector2 StartReal = new Vector2(0f, 0f);
        public int CHARGE = 0;
        public bool DrawLazer = true;
        public int DT = 44;
        public Color Color1 = Color.White;
        public Color Color2 = Color.Green;
        public float dustSpeed = 4f;
        public bool torch = false;
        public int master = -1;

        public bool piercingUp = false;

        public int ballType;

        public bool notReflect;
        public int setMasterDelay = 3;

        public NPC target = new NPC();

        public float moveMax = 3f;

        public float moveScale = 1f;

        public float minDistFromPlayer = 120f;

        public float maxDistFromPlayer = 600f;

        public float maxDistFromPlayerTele = 1000f;

        public float maxDistToAttack = 500f;

        public float rot;

        public float lastRot = -1f;

        public float rotInit = -1f;

        public int moveTime = -1;

        public bool hasTarget;

        public bool rotate;

        public bool returnToPlayer;

        public Vector2 destination = new Vector2(0f, 0f);

        public int channeling;
        public bool tmcRO;
        public byte tmcMode;
        public float dustSpeed2 = 1f;
        public bool DrawLazer2 = true;
        public float Lr = 0.2275f;

        public float Lg = 0.8509f;

        public float Lb = 0.2588f;

        public float aLr = 1f;

        public float aLg = 1f;

        public float aLb = 1f;

        public float Ds = 2f;

        public Color DC = Color.Green;

        public bool lightOnFire;

        public void TotalRotate(int index, Vector2 O, Vector2 A)
        {
            Main.projectile[index].position = O;
            Main.projectile[index].GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().StartReal = O;
            Main.projectile[index].velocity = A;
        }

        public void SetRot(Projectile projectile)
        {
            var num = projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().rotInit;
            var distance = 95f;
            var projectiles = ExxoAvalonOriginsGlobalProjectile.GetProjectiles(Main.player[projectile.owner].Center + new Vector2(0f, Main.player[projectile.owner].gfxOffY), new int[]
            {
                568,
                569,
                570
            }, projectile.owner, null, distance, null);
            projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().rotInit = ((projectiles.Length == 0) ? 0f : (6.28318548f / projectiles.Length));
            if (ExxoAvalonOriginsGlobalProjectile.forceReset[projectile.owner] || projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().rotInit != num)
            {
                var num2 = 0;
                for (var i = 0; i < projectiles.Length; i++)
                {
                    if (projectiles[i] == projectile.whoAmI)
                    {
                        num2 = i;
                    }
                }
                projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().rot = projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().rotInit * (num2 + 1f);
                projectile.netUpdate = true;
            }
        }

        public void AIFlail(Projectile projectile, ref float[] ai, bool noKill = false, float chainDistance = 160f)
        {
            if (Main.player[projectile.owner] != null)
            {
                if (Main.player[projectile.owner].dead)
                {
                    projectile.Kill();
                    return;
                }
                Main.player[projectile.owner].itemAnimation = 10;
                Main.player[projectile.owner].itemTime = 10;
            }
            projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().AIFlail(projectile, ref ai, Main.player[projectile.owner].Center, Main.player[projectile.owner].velocity, Main.player[projectile.owner].meleeSpeed, Main.player[projectile.owner].channel, noKill, chainDistance);
            Main.player[projectile.owner].direction = projectile.direction;
        }

        public void AIFlail(Projectile p, ref float[] ai, Vector2 connectedPoint, Vector2 connectedPointVelocity, float meleeSpeed, bool channel, bool noKill = false, float chainDistance = 160f)
        {
            p.direction = ((p.Center.X > connectedPoint.X) ? 1 : -1);
            var num = connectedPoint.X - p.Center.X;
            var num2 = connectedPoint.Y - p.Center.Y;
            var num3 = (float)Math.Sqrt(num * num + num2 * num2);
            if (ai[0] == 0f)
            {
                p.tileCollide = true;
                if (num3 > chainDistance)
                {
                    ai[0] = 1f;
                    p.netUpdate = true;
                }
                else if (!channel)
                {
                    if (p.velocity.Y < 0f)
                    {
                        p.velocity.Y = p.velocity.Y * 0.9f;
                    }
                    p.velocity.Y = p.velocity.Y + 1f;
                    p.velocity.X = p.velocity.X * 0.9f;
                }
            }
            else if (ai[0] == 1f)
            {
                var num4 = 14f / meleeSpeed;
                var num5 = 0.9f / meleeSpeed;
                var num6 = chainDistance + 140f;
                Math.Abs(num);
                Math.Abs(num2);
                if (ai[1] == 1f)
                {
                    p.tileCollide = false;
                }
                if (!channel || num3 > num6 || !p.tileCollide)
                {
                    ai[1] = 1f;
                    if (p.tileCollide)
                    {
                        p.netUpdate = true;
                    }
                    p.tileCollide = false;
                    if (!noKill && num3 < 20f)
                    {
                        p.Kill();
                    }
                }
                if (!p.tileCollide)
                {
                    num5 *= 2f;
                }
                if (num3 > 60f || !p.tileCollide)
                {
                    num3 = num4 / num3;
                    num *= num3;
                    num2 *= num3;
                    new Vector2(p.velocity.X, p.velocity.Y);
                    var num7 = num - p.velocity.X;
                    var num8 = num2 - p.velocity.Y;
                    var num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
                    num9 = num5 / num9;
                    num7 *= num9;
                    num8 *= num9;
                    p.velocity.X = p.velocity.X * 0.98f;
                    p.velocity.Y = p.velocity.Y * 0.98f;
                    p.velocity.X = p.velocity.X + num7;
                    p.velocity.Y = p.velocity.Y + num8;
                }
                else
                {
                    if (Math.Abs(p.velocity.X) + Math.Abs(p.velocity.Y) < 6f)
                    {
                        p.velocity.X = p.velocity.X * 0.96f;
                        p.velocity.Y = p.velocity.Y + 0.2f;
                    }
                    if (connectedPointVelocity.X == 0f)
                    {
                        p.velocity.X = p.velocity.X * 0.96f;
                    }
                }
            }
            p.rotation = (float)Math.Atan2(num2, num) - p.velocity.X * 0.1f;
        }

        public void AIFlail(Projectile projectile, ref float[] ai, Vector2 connectedPoint, Vector2 connectedPointVelocity, float meleeSpeed, bool channel, float chainDistance = 160f)
        {
            projectile.direction = ((projectile.Center.X > connectedPoint.X) ? 1 : -1);
            var num = connectedPoint.X - projectile.Center.X;
            var num2 = connectedPoint.Y - projectile.Center.Y;
            var num3 = (float)Math.Sqrt(num * num + num2 * num2);
            var flag = true;
            if (ai[0] == 0f)
            {
                projectile.tileCollide = true;
                if (num3 > chainDistance)
                {
                    ai[0] = 1f;
                    projectile.netUpdate = true;
                }
                else if (!channel)
                {
                    if (projectile.velocity.Y < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y * 0.9f;
                    }
                    projectile.velocity.Y = projectile.velocity.Y + 1f;
                    projectile.velocity.X = projectile.velocity.X * 0.9f;
                }
            }
            else if (ai[0] == 1f)
            {
                var num4 = 14f / meleeSpeed;
                var num5 = 0.9f / meleeSpeed;
                var num6 = chainDistance + 140f;
                Math.Abs(num);
                Math.Abs(num2);
                if (ai[1] == 1f)
                {
                    projectile.tileCollide = false;
                }
                if (!channel || num3 > num6 || !projectile.tileCollide)
                {
                    ai[1] = 1f;
                    if (projectile.tileCollide)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.tileCollide = false;
                    var scaleFactor = 1f;
                    if (num3 <= 15f)
                    {
                        flag = false;
                        scaleFactor = 0.5f;
                    }
                    if (num3 <= 5f)
                    {
                        projectile.velocity = default(Vector2);
                        var num7 = Main.player[projectile.owner].Center.X - projectile.Center.X;
                        var num8 = Main.player[projectile.owner].Center.Y - projectile.Center.Y;
                        projectile.rotation = (float)Math.Atan2(num8, num7) - projectile.velocity.X * 0.1f;
                        return;
                    }
                    projectile.velocity *= scaleFactor;
                }
                if (!projectile.tileCollide)
                {
                    num5 *= 2f;
                }
                if (num3 > 60f || !projectile.tileCollide)
                {
                    num3 = num4 / num3;
                    num *= num3;
                    num2 *= num3;
                    new Vector2(projectile.velocity.X, projectile.velocity.Y);
                    var num9 = num - projectile.velocity.X;
                    var num10 = num2 - projectile.velocity.Y;
                    var num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
                    num11 = num5 / num11;
                    num9 *= num11;
                    num10 *= num11;
                    projectile.velocity.X = projectile.velocity.X * 0.98f;
                    projectile.velocity.Y = projectile.velocity.Y * 0.98f;
                    projectile.velocity.X = projectile.velocity.X + num9;
                    projectile.velocity.Y = projectile.velocity.Y + num10;
                }
                else
                {
                    if (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) < 6f)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.96f;
                        projectile.velocity.Y = projectile.velocity.Y + 0.2f;
                    }
                    if (connectedPointVelocity.X == 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.96f;
                    }
                }
                if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().master >= 0 && Math.Abs(Main.projectile[projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().master].velocity.X) <= 0.025f)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.8f;
                }
                if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().master >= 0 && Math.Abs(Main.projectile[projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().master].velocity.Y) <= 0.025f)
                {
                    projectile.velocity.Y = projectile.velocity.Y * 0.8f;
                }
            }
            if (flag)
            {
                projectile.rotation = (float)Math.Atan2(num2, num) - projectile.velocity.X * 0.1f;
            }
        }

        public void SetMaster(Projectile projectile, params object[] args)
        {
            var num = (int)args[0];
            var num2 = (int)args[1];
            projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().master = num;
            if (num != -2 && num2 < 10)
            {
                projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().ballType = num2;
                projectile.Name = ((projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().ballType == 0) ? "Demonic" : ((projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().ballType == 1) ? "Aqua" : "Flare")) + " Ball";
            }
        }

        public void Target(Projectile projectile)
        {
            var vector = Main.player[projectile.owner].Center;
            this.returnToPlayer = (this.returnToPlayer && Vector2.Distance(vector, projectile.Center) > this.minDistFromPlayer);
            if (Vector2.Distance(vector, projectile.Center) > this.maxDistFromPlayerTele)
            {
                projectile.position = vector - new Vector2(Main.player[projectile.owner].width / 2, Main.player[projectile.owner].height / 2);
                this.returnToPlayer = true;
                this.target.whoAmI = -1;
            }
            else if (Vector2.Distance(vector, projectile.Center) > this.maxDistFromPlayer)
            {
                this.returnToPlayer = true;
                this.target.whoAmI = -1;
            }
            else
            {
                if (this.target != null && this.target.whoAmI != -1 && !this.CanTarget(this.target, vector))
                {
                    this.target.whoAmI = -1;
                }
                if ((this.target == null || this.target.whoAmI == -1) && Vector2.Distance(vector, projectile.Center) <= this.maxDistFromPlayer)
                {
                    var nPCs = ExxoAvalonOriginsGlobalProjectile.GetNPCs(vector, -1, null, this.maxDistToAttack, null);
                    var num = this.maxDistToAttack;
                    var array = nPCs;
                    for (var i = 0; i < array.Length; i++)
                    {
                        var num2 = array[i];
                        var nPC = Main.npc[num2];
                        var num3 = Vector2.Distance(vector, nPC.Center);
                        if (this.CanTarget(nPC, vector) && num3 < num)
                        {
                            this.target = nPC;
                            num = num3;
                        }
                    }
                }
            }
            this.hasTarget = (this.target.whoAmI != -1);
            projectile.direction = ((this.target.Center.X < projectile.Center.X) ? -1 : 1);
        }

        public bool CanTarget(NPC npc, Vector2 startPos)
        {
            return npc.active && npc.life > 0 && !npc.friendly && !npc.dontTakeDamage && npc.lifeMax > 5 && Vector2.Distance(startPos, npc.Center) < this.maxDistToAttack;
        }

        public Vector2 RotateByRightAngle(Vector2 vector)
        {
            return new Vector2(vector.Y, -vector.X);
        }

        public Vector2 RotateByLeftAngle(Vector2 vector)
        {
            return new Vector2(-vector.Y, vector.X);
        }

        public Vector2 RotateAboutOrigin(Vector2 point, float rotation)
        {
            if (rotation < 0f)
            {
                rotation += 12.566371f;
            }
            var value = point;
            if (value == Vector2.Zero)
            {
                return point;
            }
            var num = (float)Math.Atan2(value.Y, value.X);
            num += rotation;
            return value.Length() * new Vector2((float)Math.Cos(num), (float)Math.Sin(num));
        }
    }
}
