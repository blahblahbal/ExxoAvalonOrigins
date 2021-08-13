using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TrueAeonsEternity : ModItem	{		int swingCounter = 0;		public override void SetStaticDefaults()		{			DisplayName.SetDefault("True Aeon's Eternity");			Tooltip.SetDefault("Fires a burst of stars every six swings");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TrueAeonsEternity");			item.damage = 63;			item.autoReuse = true;
			item.UseSound = SoundID.Item1;			item.useTurn = true;			item.scale = 1.1f;			item.shootSpeed = 11f;			item.rare = 8;			item.width = dims.Width;			item.useTime = 35;			item.knockBack = 5f;			item.shoot = ModContent.ProjectileType<Projectiles.AeonBeam>();			item.melee = true;			item.useStyle = 1;			item.value = Item.sellPrice(0, 3, 0, 0);			item.useAnimation = 20;			item.height = dims.Height;		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);			swingCounter += 1;			if (swingCounter >= 6)			{				for (int num185 = 0; num185 < 6; num185++)				{					float num186 = speedX;					float num187 = speedY;					num186 += (float)Main.rand.Next(-40, 41) * 0.05f;					num187 += (float)Main.rand.Next(-40, 41) * 0.05f;					Projectile.NewProjectile(position.X, position.Y, num186, num187, ProjectileID.Starfury, damage, knockBack, player.whoAmI, 0f, 0f);				}				swingCounter = 0;			}			return false;		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(5) == 0)
			{
				int num208 = Main.rand.Next(3);
				if (num208 == 0)
				{
					num208 = 15;
				}
				else if (num208 == 1)
				{
					num208 = 57;
				}
				else if (num208 == 2)
				{
					num208 = 58;
				}
				int num209 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, num208);
				Dust dust = Main.dust[num209];
				dust.velocity *= 0.2f;
				dust.scale = 1.3f;
			}
		}	}}