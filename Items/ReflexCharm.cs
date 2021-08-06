using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class ReflexCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reflex Charm");
			Tooltip.SetDefault("Gives a chance to reflect projectiles");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ReflexCharm");
			item.defense = 2;
			item.rare = 4;
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
                if (!Pr.friendly && !Pr.bobber && Pr.type != 237 && Pr.type != 238 && Pr.type != 243 && Pr.type != 244 && Pr.type != ProjectileID.Stinger && Pr.type != 308 && Pr.type != 295 && Pr.type != 296 && Pr.type != 50 && Pr.type != 53 && Pr.type != 358 &&                    Pr.type != ProjectileID.PhantasmalDeathray && Pr.type != ModContent.ProjectileType<Projectiles.Ghostflame>() && Pr.type != ModContent.ProjectileType<Projectiles.WallofSteelLaser>() && Pr.type != ModContent.ProjectileType<Projectiles.PhantasmLaser>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.ElectricBolt>() && Pr.type != ModContent.ProjectileType<Projectiles.HomingRocket>() && Pr.type != ModContent.ProjectileType<Projectiles.StingerLaser>())
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
                            int dust = Dust.NewDust(Pr.position, Pr.width, Pr.height, 15, 0f, 0f, 100, new Color(), 1f);
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
                            int dust = Dust.NewDust(N.position, N.width, N.height, 15, 0f, 0f, 100, new Color(), 1f);
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