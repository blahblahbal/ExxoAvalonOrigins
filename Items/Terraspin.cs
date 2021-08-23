using Microsoft.Xna.Framework;using Microsoft.Xna.Framework.Graphics;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class Terraspin : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Terraspin");			Tooltip.SetDefault("Fires a spread of typhoons");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Terraspin");
			item.UseSound = SoundID.Item84;			item.magic = true;			item.damage = 185;			item.autoReuse = true;			item.channel = true;			item.useTurn = false;			item.shootSpeed = 9f;			item.crit += 9;			item.mana = 26;			item.noMelee = true;			item.rare = ItemRarityID.Cyan;			item.width = dims.Width;			item.knockBack = 7f;			item.useTime = 30;			item.shoot = ModContent.ProjectileType<Projectiles.TerraTyphoon>();			item.useStyle = ItemUseStyleID.HoldingOut;			item.value = Item.sellPrice(0, 50, 0, 0);			item.useAnimation = 30;			item.height = dims.Height;
			if (!Main.dedServ)
			{
				item.GetGlobalItem<ItemUseGlow>().glowTexture = mod.GetTexture("Items/Terraspin_Glow");
			}
			item.GetGlobalItem<ItemUseGlow>().glowOffsetX = 2;
			item.GetGlobalItem<ItemUseGlow>().glowOffsetY = 0;		}
		public override Vector2? HoldoutOffset()		{			return new Vector2(2, 0);		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Terraspin_Glow");
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
		}		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,			ref float knockBack)		{			for (int num212 = 0; num212 < 2; num212++)			{				float num213 = speedX;				float num214 = speedY;				num213 += (float)Main.rand.Next(-30, 31) * 0.05f;				num214 += (float)Main.rand.Next(-30, 31) * 0.05f;				Projectile.NewProjectile(position.X, position.Y, num213, num214, type, damage, knockBack, player.whoAmI, 0f, 0f);			}			return false;		}	}}