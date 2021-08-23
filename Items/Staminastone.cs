using Microsoft.Xna.Framework;using Terraria;using Terraria.ModLoader;using Terraria.ID;

namespace ExxoAvalonOrigins.Items{
    class Staminastone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staminastone");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Staminastone");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Staminastone>();
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 2, 50);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }}