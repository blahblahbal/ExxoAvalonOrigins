using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class ViruthornScalemail : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viruthorn Scalemail");
			Tooltip.SetDefault("7% increased melee speed");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 8;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 0, 54, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.07f;
		}
	}
}