using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Summon;

public class StingerProbeMinion : ModProjectile
{
    bool initialised = false;
    int id;
    int projTimer;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Stinger Probe");
        Main.projPet[Projectile.type] = true;
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Summon/StingerProbeMinion");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height;
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.light = 0.3f;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.timeLeft = 60;
    }

    public override bool? CanCutTiles() { return false; }

    public override void AI()
    {
        Player player = Main.player[Projectile.owner];
        ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();

        if (player.HasBuff(ModContent.BuffType<Buffs.StingerProbe>()))
        {
            Projectile.timeLeft = 2;
        }

        #region Get ID
        if (!initialised)
        {
            bool found = false;
            for (int i = 0; i < modPlayer.StingerProbeActiveIds.Count; i++)
            {
                if (!modPlayer.StingerProbeActiveIds[i])
                {
                    id = i;
                    modPlayer.StingerProbeActiveIds[i] = true;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                id = modPlayer.StingerProbeActiveIds.Count;
                modPlayer.StingerProbeActiveIds.Add(true);
            }
            initialised = true;
        }
        #endregion

        #region reflect
        // yoinked from reflex charm
        var projWS = new Rectangle((int)Projectile.Center.X - 32, (int)Projectile.Center.Y - 32, 64, 64);
        foreach (Projectile Pr in Main.projectile)
        {
            if (!Pr.friendly && !Pr.bobber &&
                Pr.type != ProjectileID.RainCloudMoving && Pr.type != ProjectileID.RainCloudRaining &&
                Pr.type != ProjectileID.BloodCloudMoving && Pr.type != ProjectileID.BloodCloudRaining &&
                Pr.type != 50 && Pr.type != ProjectileID.Stinger &&
                Pr.type != 53 && Pr.type != 358 &&
                Pr.type != ProjectileID.FrostHydra && Pr.type != ProjectileID.InfernoFriendlyBolt &&
                Pr.type != ProjectileID.InfernoFriendlyBlast && Pr.type != ProjectileID.FlyingPiggyBank &&
                Pr.type != ProjectileID.PhantasmalDeathray && Pr.type != ProjectileID.SpiritHeal &&
                Pr.type != ProjectileID.SpectreWrath && Pr.type != ModContent.ProjectileType<Projectiles.Ghostflame>() &&
                Pr.type != ModContent.ProjectileType<Projectiles.WallofSteelLaser>() && Pr.type != ModContent.ProjectileType<Projectiles.PhantasmLaser>() &&
                Pr.type != ModContent.ProjectileType<Projectiles.PhantasmLaser>() && Pr.type != ModContent.ProjectileType<Projectiles.ElectricBolt>() &&
                Pr.type != ModContent.ProjectileType<Projectiles.HomingRocket>() && Pr.type != ModContent.ProjectileType<Projectiles.StingerLaser>() &&
                Pr.type != ModContent.ProjectileType<Projectiles.SpectreSplit>())
            {
                Rectangle proj2 = new Rectangle((int)Pr.position.X, (int)Pr.position.Y, Pr.width, Pr.height);
                bool reflect = false, check = false;

                if (proj2.Intersects(projWS) && !reflect)
                    reflect = true;

                else check = true;
                if (reflect && !check)
                {
                    for (int thingy = 0; thingy < 5; thingy++)
                    {
                        int dust = Dust.NewDust(Pr.position, Pr.width, Pr.height, DustID.MagicMirror, 0f, 0f, 100, new Color(), 1f);
                        Main.dust[dust].noGravity = true;
                    }
                    Pr.hostile = false;
                    Pr.friendly = true;
                    Pr.velocity.X *= -1f;
                    Pr.velocity.Y *= -1f;

                    Projectile.Kill();
                }
            }
        }
        foreach (NPC N in Main.npc)
        {
            if (!N.friendly && N.aiStyle == 9)
            {
                Rectangle npc = new Rectangle((int)N.position.X, (int)N.position.Y, N.width, N.height);
                bool reflect = false, check = false;
                int rn = Main.rand.Next(2);
                if (rn == 0)
                {
                    if (npc.Intersects(projWS) && !reflect) reflect = true;
                }
                else check = true;
                if (reflect && !check)
                {
                    for (int varlex = 0; varlex < 5; varlex++)
                    {
                        int dust = Dust.NewDust(N.position, N.width, N.height, DustID.MagicMirror, 0f, 0f, 100, new Color(), 1f);
                        Main.dust[dust].noGravity = true;
                    }
                    N.friendly = true;
                    N.velocity.X *= -1f;
                    N.velocity.Y *= -1f;

                    Projectile.Kill();
                }
            }
        }
        #endregion

        #region movement
        int radius = 75;
        float speed = 0.1f;
        Vector2 target = player.Center + Vector2.One.RotatedBy(MathHelper.ToRadians(((360f / modPlayer.StingerProbeActiveIds.Where(i => i == true).Count()) * id) + modPlayer.StingerProbeRotTimer)) * radius;
        Vector2 error = target - Projectile.Center;

        Projectile.velocity = player.velocity + (error * speed);
        //projectile.Center = target;
        #endregion

        #region projectile
        Vector2 dirToCursor = (modPlayer.MousePosition - Projectile.Center).SafeNormalize(-Vector2.UnitY);
        Projectile.rotation = dirToCursor.ToRotation() + MathHelper.ToRadians(180f);

        if (projTimer-- < 0)
            projTimer = 0;

        if (player.itemAnimation != 0 && player.HeldItem.damage != 0 && projTimer == 0)
        {
            int laser = Projectile.NewProjectile(Projectile.Center, dirToCursor * 36f, ModContent.ProjectileType<Projectiles.StingerLaser>(), Projectile.damage, 0f, Projectile.owner);
            Main.projectile[laser].hostile = false;
            Main.projectile[laser].friendly = true;
            Main.projectile[laser].tileCollide = false;
            SoundEngine.PlaySound(SoundID.Item, Projectile.Center, 12);
            projTimer = 120 + Main.rand.Next(60);
        }
        #endregion
    }

    public override void Kill(int timeLeft)
    {
        Player player = Main.player[Projectile.owner];
        ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();

        SoundEngine.PlaySound(SoundID.NPCKilled, Projectile.position, 14);

        for (int i = 0; i < 2; i++)
        {
            int randomSize = Main.rand.Next(1, 4) / 2;
            int num161 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
            Gore gore30 = Main.gore[num161];
            Gore gore40 = gore30;
            gore40.velocity *= 0.3f;
            gore40.scale *= randomSize;
            Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
            Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
        }
        int bomb = Projectile.NewProjectile(Projectile.position, Vector2.Zero, ProjectileID.Grenade, 50, 3f);
        Main.projectile[bomb].timeLeft = 1;

        modPlayer.StingerProbeActiveIds[id] = false;
        base.Kill(timeLeft);
    }
}