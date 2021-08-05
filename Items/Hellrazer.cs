using Microsoft.Xna.Framework;using Microsoft.Xna.Framework.Graphics;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class Hellrazer : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Hellrazer");			Tooltip.SetDefault("Fires a powerful, high velocity bullet\nMost bullets turn into Explosive rounds");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Hellrazer");			item.UseSound = SoundID.Item11;			item.damage = 110;			item.autoReuse = true;			item.useTurn = false;			item.useAmmo = AmmoID.Bullet;			item.shootSpeed = 8f;			item.crit += 10;			item.ranged = true;			item.rare = 8;			item.noMelee = true;			item.width = dims.Width;			item.knockBack = 12f;			item.useTime = 30;			item.shoot = 14;			item.value = Item.sellPrice(0, 30, 0, 0);			item.useStyle = 5;			item.useAnimation = 30;			item.height = dims.Height;
            item.UseSound = SoundID.Item40;
            if (!Main.dedServ)
			{
				item.GetGlobalItem<ItemUseGlow>().glowTexture = mod.GetTexture("Items/Hellrazer_Glow");
			}
			item.GetGlobalItem<ItemUseGlow>().glowOffsetX = -5;
			item.GetGlobalItem<ItemUseGlow>().glowOffsetY = 0;		}
		public override Vector2? HoldoutOffset()		{			return new Vector2(-5, 0);		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Hellrazer_Glow");
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
		}
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)		{			int shotProjectile =				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack);			Main.projectile[shotProjectile].GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().lightOnFire =				true;			return false;		}*/
	}}