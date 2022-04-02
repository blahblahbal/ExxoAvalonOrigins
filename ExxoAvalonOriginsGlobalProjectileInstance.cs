using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins;

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
    public bool returnToPlayer;
    public Vector2 destination = new Vector2(0f, 0f);
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

    public bool CanTarget(NPC npc, Vector2 startPos)
    {
        return npc.active && npc.life > 0 && !npc.friendly && !npc.dontTakeDamage && npc.lifeMax > 5 && Vector2.Distance(startPos, npc.Center) < this.maxDistToAttack;
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