using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class ObsidianRoseShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Rose Shield");
            Tooltip.SetDefault("Reduces damage from touching lava\nGrants immunity to fire blocks and knockback");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.LightPurple;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 3);
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lavaRose = player.fireWalk = player.noKnockback = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.ObsidianShield).AddIngredient(ItemID.ObsidianRose).AddTile(TileID.TinkerersWorkbench).Register();
        }
    }
}
