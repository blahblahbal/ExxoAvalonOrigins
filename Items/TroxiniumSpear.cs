using Microsoft.Xna.Framework;using Microsoft.Xna.Framework.Graphics;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TroxiniumSpear : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Troxinium Spear");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TroxiniumSpear");
			item.UseSound = SoundID.Item1;			item.damage = 41;			item.noUseGraphic = true;			item.scale = 1.1f;			item.shootSpeed = 5f;			item.rare = 5;			item.noMelee = true;			item.width = dims.Width;			item.useTime = 23;			item.knockBack = 5.6f;			item.shoot = ModContent.ProjectileType<Projectiles.TroxiniumSpear>();			item.melee = true;			item.useStyle = 5;			item.value = 105000;			item.useAnimation = 23;			item.height = dims.Height;		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/TroxiniumSpear_Glow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}	}}