using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    internal class CoolGemsparkBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cool Gemspark Block");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.CoolGemsparkBlock>();
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
            spriteBatch.Draw(Main.itemTexture[item.type], position, frame, new Color(Tiles.CoolGemsparkBlock.R, Tiles.CoolGemsparkBlock.G, Tiles.CoolGemsparkBlock.B), 0f, origin, scale, SpriteEffects.None, 0f);
            return false;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            spriteBatch.Draw(Main.itemTexture[item.type], item.position - Main.screenPosition, null, new Color(Tiles.CoolGemsparkBlock.R, Tiles.CoolGemsparkBlock.G, Tiles.CoolGemsparkBlock.B), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
