using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class RocketJumpScroll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rocket Jump Scroll");
            Tooltip.SetDefault("Unlocks stamina rocket jump");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.consumable = true;
            item.width = dims.Width;
            item.useTime = 20;
            item.rare = ItemRarityID.Green;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Scroll");
            item.useAnimation = 20;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Book);
            r.AddIngredient(ItemID.CloudinaBottle);
            r.AddIngredient(ModContent.ItemType<StaminaCrystal>());
            r.AddTile(TileID.Bookcases);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Book);
            r.AddIngredient(ItemID.BlizzardinaBottle);
            r.AddIngredient(ModContent.ItemType<StaminaCrystal>());
            r.AddTile(TileID.Bookcases);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Book);
            r.AddIngredient(ItemID.SandstorminaBottle);
            r.AddIngredient(ModContent.ItemType<StaminaCrystal>());
            r.AddTile(TileID.Bookcases);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Book);
            r.AddIngredient(ItemID.FartinaJar);
            r.AddIngredient(ModContent.ItemType<StaminaCrystal>());
            r.AddTile(TileID.Bookcases);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Book);
            r.AddIngredient(ItemID.TsunamiInABottle);
            r.AddIngredient(ModContent.ItemType<StaminaCrystal>());
            r.AddTile(TileID.Bookcases);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            return !player.Avalon().rocketJumpUnlocked;
        }
        public override bool UseItem(Player player)
        {
            player.Avalon().rocketJumpUnlocked = true;
            return true;
        }
    }
}
