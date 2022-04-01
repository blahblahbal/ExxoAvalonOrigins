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
            Item.consumable = true;
            Item.width = dims.Width;
            Item.useTime = 20;
            Item.rare = ItemRarityID.Green;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Scroll");
            Item.useAnimation = 20;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ItemID.CloudinaBottle).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
            CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ItemID.BlizzardinaBottle).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
            CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ItemID.SandstorminaBottle).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
            CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ItemID.FartinaJar).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
            CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ItemID.TsunamiInABottle).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
        }
        public override bool CanUseItem(Player player)
        {
            return !player.Avalon().rocketJumpUnlocked;
        }
        public override bool? UseItem(Player player)
        {
            player.Avalon().rocketJumpUnlocked = true;
            return true;
        }
    }
}
