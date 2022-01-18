using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class ReflexCharm : ModItem
	{
        public int[] notReflect = new int[]
        {
            ProjectileID.Stinger,
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
            ModContent.ProjectileType<Projectiles.CrystalBeam>()
        };

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reflex Charm");
			Tooltip.SetDefault("Gives a chance to reflect projectiles");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 2;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 8, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            Rectangle playerWS = new Rectangle((int)player.Center.X - 32, (int)player.Center.Y - 32, 64, 64);
            foreach (Projectile Pr in Main.projectile)
            {
                if (!Pr.friendly && !Pr.bobber && !notReflect.Contains(Pr.type))
                {
                    Rectangle proj2 = new Rectangle((int)Pr.position.X, (int)Pr.position.Y, Pr.width, Pr.height);
                    bool reflect = false, check = false;
                    int rn = Main.rand.Next(4);
                    if (rn == 0)
                    {
                        if (proj2.Intersects(playerWS) && !reflect) reflect = true;
                    }
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
                    }
                }
            }
            foreach (NPC N in Main.npc)
            {
                if (!N.friendly && N.aiStyle == 9)
                {
                    Rectangle npc = new Rectangle((int)N.position.X, (int)N.position.Y, N.width, N.height);
                    bool reflect = false, check = false;
                    int rn = Main.rand.Next(4);
                    if (rn == 0)
                    {
                        if (npc.Intersects(playerWS) && !reflect) reflect = true;
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
                    }
                }
            }
        }
	}
}
