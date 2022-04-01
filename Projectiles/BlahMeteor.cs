using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

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
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 9;
            Projectile.friendly = true;
            Projectile.scale = 0.5f;
            Projectile.damage = 100;
        }
        public override bool PreAI()
        {
            Lighting.AddLight(Projectile.position, 249 / 255, 201 / 255, 77 / 255);
            return true;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 14);
            Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
            for (int num341 = 0; num341 < 30; num341++)
            {
                int num342 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num342].velocity *= 1.4f;
            }
            for (int num343 = 0; num343 < 20; num343++)
            {
                int num344 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 3.5f);
                Main.dust[num344].noGravity = true;
                Main.dust[num344].velocity *= 7f;
                num344 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num344].velocity *= 3f;
            }
            for (int num345 = 0; num345 < 2; num345++)
            {
                float scaleFactor8 = 0.4f;
                if (num345 == 1)
                {
                    scaleFactor8 = 0.8f;
                }
                int num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A0B0_cp_0 = Main.gore[num346];
                expr_A0B0_cp_0.velocity.X = expr_A0B0_cp_0.velocity.X + 1f;
                Gore expr_A0D0_cp_0 = Main.gore[num346];
                expr_A0D0_cp_0.velocity.Y = expr_A0D0_cp_0.velocity.Y + 1f;
                num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A153_cp_0 = Main.gore[num346];
                expr_A153_cp_0.velocity.X = expr_A153_cp_0.velocity.X - 1f;
                Gore expr_A173_cp_0 = Main.gore[num346];
                expr_A173_cp_0.velocity.Y = expr_A173_cp_0.velocity.Y + 1f;
                num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A1F6_cp_0 = Main.gore[num346];
                expr_A1F6_cp_0.velocity.X = expr_A1F6_cp_0.velocity.X + 1f;
                Gore expr_A216_cp_0 = Main.gore[num346];
                expr_A216_cp_0.velocity.Y = expr_A216_cp_0.velocity.Y - 1f;
                num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A299_cp_0 = Main.gore[num346];
                expr_A299_cp_0.velocity.X = expr_A299_cp_0.velocity.X - 1f;
                Gore expr_A2B9_cp_0 = Main.gore[num346];
                expr_A2B9_cp_0.velocity.Y = expr_A2B9_cp_0.velocity.Y - 1f;
            }
        }
        public override void AI()
        {
            if (Projectile.ai[1] != -1f && Projectile.position.Y > Projectile.ai[1])
            {
                Projectile.tileCollide = true;
            }
            if (Projectile.position.HasNaNs())
            {
                Projectile.Kill();
                return;
            }
            bool num220 = WorldGen.SolidTile(Framing.GetTileSafely((int)Projectile.position.X / 16, (int)Projectile.position.Y / 16));
            Dust dust2 = Main.dust[Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), (int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale), DustID.Torch)];

            dust2.position = new Vector2(Projectile.position.X + (Projectile.width - 0.5f * Projectile.scale), Projectile.position.Y + (Projectile.height - 0.5f * Projectile.scale));
            dust2.velocity = Vector2.Zero;
            dust2.scale = 1.5f;
            dust2.noGravity = true;
            if (num220)
            {
                dust2.noLight = true;
            }
            //left side
            bool num221 = WorldGen.SolidTile(Framing.GetTileSafely((int)Projectile.position.X / 16, (int)Projectile.position.Y / 16));
            dust2 = Main.dust[Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), (int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale), DustID.Torch)];

            dust2.position = new Vector2(Projectile.position.X + (Projectile.width * Projectile.scale), Projectile.position.Y + (Projectile.height - 0.5f * Projectile.scale));
            dust2.velocity = Vector2.Zero;
            dust2.scale = 1.5f;
            dust2.noGravity = true;
            if (num221)
            {
                dust2.noLight = true;
            }
            //right side
            bool num222 = WorldGen.SolidTile(Framing.GetTileSafely((int)Projectile.position.X / 16, (int)Projectile.position.Y / 16));
            dust2 = Main.dust[Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), (int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale), DustID.Torch)];

            dust2.position = new Vector2(Projectile.position.X + (Projectile.width + 0.5f * Projectile.scale), Projectile.position.Y + (Projectile.height - 0.5f * Projectile.scale));
            dust2.velocity = Vector2.Zero;
            dust2.scale = 1.5f;
            dust2.noGravity = true;
            if (num221)
            {
                dust2.noLight = true;
            }
            Projectile.ai[0]++;
            if (Projectile.ai[0] == 20)
            {
                float speedX = Projectile.velocity.X + Main.rand.Next(20, 51) * 0.1f;
                float speedY = Projectile.velocity.Y + Main.rand.Next(20, 51) * 0.1f;
                int p = Projectile.NewProjectile(Projectile.position, new Vector2(speedX, speedY), ModContent.ProjectileType<BlahStar>(), Projectile.damage, Projectile.knockBack);
                Main.projectile[p].friendly = true;
                Main.projectile[p].hostile = false;
                Main.projectile[p].owner = Projectile.owner;
            }
            if (Projectile.ai[0] == 40)
            {
                float speedX = Projectile.velocity.X + Main.rand.Next(-51, -20) * 0.1f;
                float speedY = Projectile.velocity.Y + Main.rand.Next(20, 51) * 0.1f;
                int p = Projectile.NewProjectile(Projectile.position, new Vector2(speedX, speedY), ModContent.ProjectileType<BlahStar>(), Projectile.damage, Projectile.knockBack);
                Main.projectile[p].friendly = true;
                Main.projectile[p].hostile = false;
                Main.projectile[p].owner = Projectile.owner;
                Projectile.ai[0] = 0;
            }
        }
    }
}
