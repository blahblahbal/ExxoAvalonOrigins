using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BismuthDagger : ModProjectile
    {
        bool initialised = false;
        int id;
        int projTimer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Dagger");
            //Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/BismuthDagger");
            projectile.width = dims.Width;
            projectile.height = dims.Height;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.light = 0.3f;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.minionSlots = 1f;
            projectile.timeLeft = 60;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 60;
            //aiType = 388;
        }

        public override bool? CanCutTiles() { return false; }
        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();
            modPlayer.daggerStaffActiveIDs[id] = false;
            base.Kill(timeLeft);
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();
            Main.player[projectile.owner].AddBuff(ModContent.BuffType<Buffs.BismuthDagger>(), 3600);
            if (projectile.type == ModContent.ProjectileType<BismuthDagger>())
            {
                if (Main.player[projectile.owner].dead)
                {
                    Main.player[projectile.owner].Avalon().bismuthDagger = false;
                }
                if (Main.player[projectile.owner].Avalon().bismuthDagger)
                {
                    projectile.timeLeft = 2;
                }
            }
            if (Main.player[projectile.owner].slotsMinions + projectile.minionSlots > Main.player[projectile.owner].maxMinions && projectile.owner == Main.myPlayer)
            {
                projectile.Kill();
            }
            else
            {
                Main.player[projectile.owner].numMinions++;
                Main.player[projectile.owner].slotsMinions += projectile.minionSlots;
            }
            #region Get ID
            if (!initialised)
            {
                bool found = false;
                for (int i = 0; i < modPlayer.daggerStaffActiveIDs.Count; i++)
                {
                    if (!modPlayer.daggerStaffActiveIDs[i])
                    {
                        id = i;
                        modPlayer.daggerStaffActiveIDs[i] = true;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    id = modPlayer.daggerStaffActiveIDs.Count;
                    modPlayer.daggerStaffActiveIDs.Add(true);
                }
                initialised = true;
            }
            #endregion

            #region movement
            int closestNPC = projectile.FindClosestNPC(16 * 40);
            if (closestNPC == -1)
            {
                int radius = 50;
                float speed = 0.1f;
                Vector2 target = player.Center + Vector2.One.RotatedBy(MathHelper.ToRadians(((360f / modPlayer.daggerStaffActiveIDs.Where(i => i == true).Count()) * id) + modPlayer.daggerStaffRotTimer)) * radius;
                Vector2 error = target - projectile.Center;
                
                projectile.velocity = player.velocity + (error * speed);
                projectile.rotation = projectile.velocity.ToRotation();
            }
            else
            {

                Vector2 vector56 = projectile.position;
                float num768 = 400f;
                bool flag31 = false;
                for (int num769 = 0; num769 < 200; num769++)
                {
                    NPC nPC4 = Main.npc[num769];
                    if (nPC4.active && !nPC4.dontTakeDamage && !nPC4.friendly && nPC4.lifeMax > 5)
                    {
                        float num770 = Vector2.Distance(nPC4.Center, projectile.Center);
                        if (((Vector2.Distance(projectile.Center, vector56) > num770 && num770 < num768) || !flag31) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, nPC4.position, nPC4.width, nPC4.height))
                        {
                            num768 = num770;
                            vector56 = nPC4.Center;
                            flag31 = true;
                        }
                    }
                }
                if (flag31 && projectile.ai[0] == 0f)
                {
                    Vector2 vector57 = vector56 - projectile.Center; // npc center minus projectile center
                    float num772 = vector57.Length(); // distance between npc and proj
                    vector57.Normalize();
                    if (num772 > 200f)
                    {
                        float scaleFactor5 = 8f;
                        vector57 *= scaleFactor5;
                        projectile.velocity = (projectile.velocity * 40f + vector57) / 41f;
                    }
                    else
                    {
                        float num773 = 4f;
                        vector57 *= -num773;
                        projectile.velocity = (projectile.velocity * 40f + vector57) / 41f;
                    }
                }
                else
                {
                    float num774 = 6f;
                    if (projectile.ai[0] == 1f)
                    {
                        num774 = 15f;
                    }
                    Vector2 value19 = projectile.Center;
                    Vector2 vector58 = Main.player[projectile.owner].Center - value19 + new Vector2(0f, -60f);
                    float num775 = vector58.Length();
                    if (num775 > 200f && num774 < 8f)
                    {
                        num774 = 8f;
                    }
                    if (num775 < 150f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                    {
                        projectile.ai[0] = 0f;
                        projectile.netUpdate = true;
                    }
                    if (num775 > 70f)
                    {
                        vector58.Normalize();
                        vector58 *= num774;
                        projectile.velocity = (projectile.velocity * 40f + vector58) / 41f;
                    }
                    else if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                    {
                        projectile.velocity.X = -0.15f;
                        projectile.velocity.Y = -0.05f;
                    }
                }
                projectile.rotation = projectile.velocity.ToRotation() + 1.57079633f; // + 3.14159274f;
                if (projectile.ai[1] > 0)
                {
                    projectile.ai[1] += Main.rand.Next(1, 4);
                }
                if (projectile.ai[1] > 50)
                {
                    projectile.ai[1] = 0;
                    projectile.netUpdate = true;
                }

                if ((projectile.type == ModContent.ProjectileType<BismuthDagger>()) && projectile.ai[1] == 0f && flag31 && num768 < 500f)
                {
                    projectile.ai[1]++;
                    if (Main.myPlayer == projectile.owner)
                    {
                        projectile.ai[0] = 2f;
                        Vector2 value21 = vector56 - projectile.Center;
                        value21.Normalize();
                        projectile.velocity = value21 * 8f;
                        projectile.netUpdate = true;
                    }
                }
            }
            //projectile.Center = target;
            #endregion
        }
    }
}
