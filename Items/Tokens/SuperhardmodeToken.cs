using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tokens
{
	public class SuperhardmodeToken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Superhardmode Token");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.width = dims.Width;
            item.rare = ItemRarityID.Red;
            item.maxStack = 999;
			item.value = 0;
			item.height = dims.Height;
		}
	}
}
