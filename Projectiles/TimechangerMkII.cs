using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.Localization;namespace ExxoAvalonOrigins.Projectiles{	public class TimechangerMkII : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Timechanger");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/TimechangerMkII");			projectile.aiStyle = -1;			projectile.width = dims.Width;			projectile.height = dims.Height / Main.projFrames[projectile.type];			projectile.damage = 0;			projectile.tileCollide = false;		}		public override void AI()		{			if (projectile.active)			{				if (projectile.type == ModContent.ProjectileType<TimechangerMkII>())				{					if (!projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcRO)					{						projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcMode += 1;						if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcMode >= 4)						{							projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcMode = 0;						}						projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcRO = true;					}					if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcMode == 0)					{						Main.dayTime = false;						Main.time = 0.0;						if (Main.netMode == 0)						{							Main.NewText("It is now Night.", 50, 255, 130, false);						}						else if (Main.netMode == 2)						{							NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("It is now Night."), 255, 50f, 255f, 130f, 0);						}					}					else if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcMode == 1)					{						Main.dayTime = false;						Main.time = 16200.0;						if (Main.netMode == 0)						{							Main.NewText("It is now Midnight.", 50, 255, 130, false);						}						else if (Main.netMode == 2)						{							NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("It is now Midnight."), 255, 50f, 255f, 130f, 0);						}					}					else if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcMode == 2)					{						Main.dayTime = true;						Main.time = 0.0;						if (Main.netMode == 0)						{							Main.NewText("It is now Day.", 50, 255, 130, false);						}						else if (Main.netMode == 2)						{							NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("It is now Day."), 255, 50f, 255f, 130f, 0);						}					}					else if (projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcMode == 3)					{						Main.dayTime = true;						Main.time = 27000.0;						if (Main.netMode == 0)						{							Main.NewText("It is now Midday.", 50, 255, 130, false);						}						else if (Main.netMode == 2)						{							NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("It is now Midday."), 255, 50f, 255f, 130f, 0);						}					}					projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().tmcRO = false;					projectile.active = false;					return;				}			}		}	}}