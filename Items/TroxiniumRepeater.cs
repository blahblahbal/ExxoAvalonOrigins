using Microsoft.Xna.Framework;using Microsoft.Xna.Framework.Graphics;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TroxiniumRepeater : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Troxinium Repeater");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TroxiniumRepeater");			item.UseSound = SoundID.Item5;			item.damage = 42;			item.autoReuse = true;			item.useAmmo = AmmoID.Arrow;			item.shootSpeed = 10.5f;			item.ranged = true;			item.noMelee = true;			item.rare = 5;			item.width = dims.Width;			item.useTime = 21;			item.knockBack = 1.5f;			item.shoot = 1;			item.useStyle = 5;			item.value = 100000;			item.useAnimation = 21;			item.height = dims.Height;
			if (!Main.dedServ)
			{
				item.GetGlobalItem<ItemUseGlow>().glowTexture = mod.GetTexture("Items/TroxiniumRepeater_Glow");
			}
			item.GetGlobalItem<ItemUseGlow>().glowOffsetX = -5;
			item.GetGlobalItem<ItemUseGlow>().glowOffsetY = 0;		}		public override Vector2? HoldoutOffset()		{			return new Vector2(-5, 0);		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/TroxiniumRepeater_Glow");
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