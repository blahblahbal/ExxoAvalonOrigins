using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items.Placeable{
    class AncientWorkbench : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Workbench");
            Tooltip.SetDefault("Used to craft old-style items");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Placeable/AncientWorkbench");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.AncientWorkbench>();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 20);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HeavyWorkBench);
            recipe.AddIngredient(ItemID.Marble, 10);
            recipe.AddIngredient(ModContent.ItemType<EarthShard>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }}