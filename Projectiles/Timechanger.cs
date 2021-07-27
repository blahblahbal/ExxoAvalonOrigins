using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.Localization;namespace ExxoAvalonOrigins.Projectiles{	public class Timechanger : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Timechanger");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/Timechanger");			projectile.aiStyle = -1;			projectile.width = dims.Width;			projectile.height = dims.Height / Main.projFrames[projectile.type];			projectile.damage = 0;			projectile.tileCollide = false;		}		public override void AI()		{			if (projectile.active)			{				if (projectile.type == ModContent.ProjectileType<Timechanger>())				{                    if (Main.dayTime)                    {                        Main.time = 53999;                    }                    else                    {                        Main.time = 32399;                    }                    if (Main.dayTime)					{						if (Main.netMode == 0)						{							Main.NewText("It is now Day.", 50, 255, 130, false);						}						else						{							NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("It is now Day."), 255, 50f, 255f, 130f, 0);						}					}					else if (Main.netMode == 0)					{						Main.NewText("It is now Night.", 50, 255, 130, false);					}					else					{						NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("It is now Night."), 255, 50f, 255f, 130f, 0);					}					projectile.active = false;					return;				}			}		}	}}