using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class EmeraldAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Amulet");
            Tooltip.SetDefault("5% increased ranged damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 0, 50);
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 0.05f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Emerald, 12).AddIngredient(ItemID.Chain).AddTile(TileID.Anvils).Register();
        }
    }
}
