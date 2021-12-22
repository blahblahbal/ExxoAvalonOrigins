using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class BerserkerCuisses : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Cuisses");
			Tooltip.SetDefault("Melee stealth when standing still\nLightning strikes when damaged");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 32;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 65, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().LightningInABottle = true;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().meleeStealth = true;
		}
	}
}