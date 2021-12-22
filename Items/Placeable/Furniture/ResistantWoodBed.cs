using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture
{
	class ResistantWoodBed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Resistant Wood Bed");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.ResistantWoodBed>();
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 99;
			item.value = 2000;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
