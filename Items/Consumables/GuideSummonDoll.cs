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
			item.autoReuse = true;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.maxStack = 999;
			item.useAnimation = 30;
			item.height = dims.Height;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.TungstenOre, 5);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.ZincOre>(), 5);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player) => true;

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.Guide);
			return base.ConsumeItem(player);
		}
	}
}
