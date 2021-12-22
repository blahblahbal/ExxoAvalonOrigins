using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
	class OpalGemsparkBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Opal Gemspark Block");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.OpalGemspark>();
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            spriteBatch.Draw(Main.itemTexture[item.type], position, frame, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, origin, scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 iPos = item.position - Main.screenPosition;
            spriteBatch.Draw(Main.itemTexture[item.type], item.position - Main.screenPosition, null, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
