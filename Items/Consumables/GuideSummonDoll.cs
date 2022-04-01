using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class GuideSummonDoll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guide Summon Doll");
            Tooltip.SetDefault("Summons the Guide");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.maxStack = 999;
            Item.useAnimation = 30;
            Item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            CreateRecipe(5).AddIngredient(ItemID.GuideVoodooDoll).AddIngredient(ItemID.Cobweb, 50).AddIngredient(ItemID.SilverOre, 5).AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5).AddTile(TileID.Anvils).Register();
            CreateRecipe(5).AddIngredient(ItemID.GuideVoodooDoll).AddIngredient(ItemID.Cobweb, 50).AddIngredient(ItemID.TungstenOre, 5).AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5).AddTile(TileID.Anvils).Register();
            CreateRecipe(5).AddIngredient(ItemID.GuideVoodooDoll).AddIngredient(ItemID.Cobweb, 50).AddIngredient(ModContent.ItemType<Placeable.Tile.ZincOre>(), 5).AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5).AddTile(TileID.Anvils).Register();
        }

        public override bool CanUseItem(Player player) => true;

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.Guide);
            return base.ConsumeItem(player);
        }
    }
}
