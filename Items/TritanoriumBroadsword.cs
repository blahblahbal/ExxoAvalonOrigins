using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TritanoriumBroadsword : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Tritanorium Broadsword");		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 200);
		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TritanoriumBroadsword");			item.damage = 110;			item.autoReuse = true;			item.useTurn = true;			item.scale = 1.2f;			item.rare = 11;			item.width = dims.Width;			item.useTime = 16;			item.knockBack = 15f;			item.melee = true;			item.useStyle = 1;			item.value = Item.sellPrice(2, 10, 0, 0);			item.useAnimation = 16;			item.height = dims.Height;            item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<Projectiles.TritonWave>();
			item.shootSpeed = 20;
        }
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int num162 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.TritanoriumFlame>(), 0f, 0f, 0, default(Color), 2f);
				Main.dust[num162].noGravity = true;
			}
		}		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}	}}