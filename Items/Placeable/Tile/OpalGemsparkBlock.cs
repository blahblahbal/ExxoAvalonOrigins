using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile;

class OpalGemsparkBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Opal Gemspark Block");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.OpalGemspark>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.rare = ModContent.RarityType<Rarities.RainbowRarity>();
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.rare = ItemRarityID.Purple;
    }
    public override void AddRecipes()
    {
        CreateRecipe(20).AddIngredient(ItemID.Glass, 20).AddIngredient(ModContent.ItemType<Opal>()).AddTile(TileID.WorkBenches).Register();
    }
    public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
    {
        spriteBatch.Draw(Terraria.GameContent.TextureAssets.Item[Item.type], position, frame, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, origin, scale, SpriteEffects.None, 0f);
        return false;
    }
    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
    {
        Vector2 iPos = Item.position - Main.screenPosition;
        spriteBatch.Draw(Terraria.GameContent.TextureAssets.Item[Item.type], Item.position - Main.screenPosition, null, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
    }
}
