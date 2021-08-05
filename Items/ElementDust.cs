using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Items{	class ElementDust : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Element Dust");			Tooltip.SetDefault("Compound of the five elements");		}
        public override Color? GetAlpha(Color lightColor)
        {
			return new Color(200, 200, 200, 100);
		}
        public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ElementDust");			item.rare = 2;			item.width = dims.Width;			item.value = Item.sellPrice(0, 0, 2, 0);			item.maxStack = 999;			item.height = dims.Height;		}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
			if (Main.rand.Next(6) == 0)
			{
				int num28 = Dust.NewDust(item.position, item.width, item.height, 156, 0f, 0f, 200, item.color);
				Main.dust[num28].velocity *= 0.3f;
				Main.dust[num28].scale *= 0.5f;
				Main.dust[num28].noGravity = true;
			}
		}
    }}