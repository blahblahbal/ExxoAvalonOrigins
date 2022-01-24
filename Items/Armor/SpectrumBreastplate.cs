using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class SpectrumBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectrum Breastplate");
            Tooltip.SetDefault("Ranged projectiles have a chance to split in two");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 33;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 23);
            recipe.AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<AncientBodyplate>());
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 4);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = mod.GetTexture("Items/Armor/SpectrumBreastplate_Glow");
            spriteBatch.Draw(texture, position, frame, new Color(SpectrumHelmet.R, SpectrumHelmet.G, SpectrumHelmet.B), 0f, origin, scale, SpriteEffects.None, 0f);
        }
        public override void UpdateEquip(Player player)
        {
            player.Avalon().splitProj = true;
        }
    }
}
