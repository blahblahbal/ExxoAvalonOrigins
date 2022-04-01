using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class SpectrumGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectrum Greaves");
            Tooltip.SetDefault("20% chance to not consume ammo\n10% increased movement speed");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 25;
            Item.rare = ItemRarityID.Red;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 40, 0, 0);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 17).AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 40).AddIngredient(ModContent.ItemType<AncientLeggings>()).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 3).AddIngredient(ModContent.ItemType<Placeable.Tile.Opal>(), 10).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = Mod.Assets.Request<Texture2D>("Items/Armor/SpectrumGreaves_Glow").Value;
            spriteBatch.Draw(texture, position, frame, new Color(SpectrumHelmet.R, SpectrumHelmet.G, SpectrumHelmet.B), 0f, origin, scale, SpriteEffects.None, 0f);
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
            player.ammoCost80 = true;
        }
    }
}
