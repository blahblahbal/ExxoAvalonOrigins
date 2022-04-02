﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

public class WarmGemsparkBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Warm Gemspark Block");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.WarmGemsparkBlock>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }

    public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
    {
        spriteBatch.Draw(Main.itemTexture[Item.type], position, frame, new Color(255, Tiles.WarmGemsparkBlock.G, 0), 0f, origin, scale, SpriteEffects.None, 0f);
        return false;
    }

    public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
    {
        spriteBatch.Draw(Main.itemTexture[Item.type], Item.position - Main.screenPosition, null, new Color(255, Tiles.WarmGemsparkBlock.G, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        return false;
    }
}