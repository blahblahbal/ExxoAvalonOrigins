using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BlahMeteor : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah Meteor");
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.aiStyle = -1;
            projectile.magic = true;
            projectile.penetrate = 9;
            projectile.friendly = true;
            projectile.scale = 0.5f;
            projectile.damage = 100;
        }
        public override bool PreAI()
        {
            Lighting.AddLight(projectile.position, 249 / 255, 201 / 255, 77 / 255);
            return true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 22;
            projectile.height = 22;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            for (int num341 = 0; num341 < 30; num341++)
            {
                int num342 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num342].velocity *= 1.4f;
            }
            for (int num343 = 0; num343 < 20; num343++)
            {
                int num344 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 3.5f);
                Main.dust[num344].noGravity = true;
                Main.dust[num344].velocity *= 7f;
                num344 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num344].velocity *= 3f;
            }
            for (int num345 = 0; num345 < 2; num345++)
            {
                float scaleFactor8 = 0.4f;
                if (num345 == 1)
                {
                    scaleFactor8 = 0.8f;
                }
                int num346 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A0B0_cp_0 = Main.gore[num346];
                expr_A0B0_cp_0.velocity.X = expr_A0B0_cp_0.velocity.X + 1f;
                Gore expr_A0D0_cp_0 = Main.gore[num346];
                expr_A0D0_cp_0.velocity.Y = expr_A0D0_cp_0.velocity.Y + 1f;
                num346 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A153_cp_0 = Main.gore[num346];
                expr_A153_cp_0.velocity.X = expr_A153_cp_0.velocity.X - 1f;
                Gore expr_A173_cp_0 = Main.gore[num346];
                expr_A173_cp_0.velocity.Y = expr_A173_cp_0.velocity.Y + 1f;
                num346 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A1F6_cp_0 = Main.gore[num346];
                expr_A1F6_cp_0.velocity.X = expr_A1F6_cp_0.velocity.X + 1f;
                Gore expr_A216_cp_0 = Main.gore[num346];
                expr_A216_cp_0.velocity.Y = expr_A216_cp_0.velocity.Y - 1f;
                num346 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A299_cp_0 = Main.gore[num346];
                expr_A299_cp_0.velocity.X = expr_A299_cp_0.velocity.X - 1f;
                Gore expr_A2B9_cp_0 = Main.gore[num346];
                expr_A2B9_cp_0.velocity.Y = expr_A2B9_cp_0.velocity.Y - 1f;
            }
        }
        public override void AI()
        {
            if (projectile.ai[1] != -1f && projectile.position.Y > projectile.ai[1])
            {
                projectile.tileCollide = true;
            }
            if (projectile.position.HasNaNs())
            {
                projectile.Kill();
                return;
            }
            bool num220 = WorldGen.SolidTile(Framing.GetTileSafely((int)projectile.position.X / 16, (int)projectile.position.Y / 16));
            Dust dust2 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), (int)(projectile.width * projectile.scale), (int)(projectile.height * projectile.scale), DustID.Fire)];

            dust2.position = new Vector2(projectile.position.X + (projectile.width - 0.5f * projectile.scale), projectile.position.Y + (projectile.height - 0.5f * projectile.scale));
            dust2.velocity = Vector2.Zero;
            dust2.scale = 1.5f;
            dust2.noGravity = true;
            if (num220)
            {
                dust2.noLight = true;
            }
            //left side
            bool num221 = WorldGen.SolidTile(Framing.GetTileSafely((int)projectile.position.X / 16, (int)projectile.position.Y / 16));
            dust2 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), (int)(projectile.width * projectile.scale), (int)(projectile.height * projectile.scale), DustID.Fire)];

            dust2.position = new Vector2(projectile.position.X + (projectile.width * projectile.scale), projectile.position.Y + (projectile.height - 0.5f * projectile.scale));
            dust2.velocity = Vector2.Zero;
            dust2.scale = 1.5f;
            dust2.noGravity = true;
            if (num221)
            {
                dust2.noLight = true;
            }
            //right side
            bool num222 = WorldGen.SolidTile(Framing.GetTileSafely((int)projectile.position.X / 16, (int)projectile.position.Y / 16));
            dust2 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), (int)(projectile.width * projectile.scale), (int)(projectile.height * projectile.scale), DustID.Fire)];

            dust2.position = new Vector2(projectile.position.X + (projectile.width + 0.5f * projectile.scale), projectile.position.Y + (projectile.height - 0.5f * projectile.scale));
            dust2.velocity = Vector2.Zero;
            dust2.scale = 1.5f;
            dust2.noGravity = true;
            if (num221)
            {
                dust2.noLight = true;
            }
            projectile.ai[0]++;
            if (projectile.ai[0] == 20)
            {
                float speedX = projectile.velocity.X + Main.rand.Next(20, 51) * 0.1f;
                float speedY = projectile.velocity.Y + Main.rand.Next(20, 51) * 0.1f;
                int p = Projectile.NewProjectile(projectile.position, new Vector2(speedX, speedY), ModContent.ProjectileType<BlahStar>(), projectile.damage, projectile.knockBack);
                Main.projectile[p].friendly = true;
                Main.projectile[p].hostile = false;
                Main.projectile[p].owner = projectile.owner;
            }
            if (projectile.ai[0] == 40)
            {
                float speedX = projectile.velocity.X + Main.rand.Next(-51, -20) * 0.1f;
                float speedY = projectile.velocity.Y + Main.rand.Next(20, 51) * 0.1f;
                int p = Projectile.NewProjectile(projectile.position, new Vector2(speedX, speedY), ModContent.ProjectileType<BlahStar>(), projectile.damage, projectile.knockBack);
                Main.projectile[p].friendly = true;
                Main.projectile[p].hostile = false;
                Main.projectile[p].owner = projectile.owner;
                projectile.ai[0] = 0;
            }
        }
    }
}
