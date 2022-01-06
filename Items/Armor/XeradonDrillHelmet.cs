using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class XeradonDrillHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xeradon Drill Helmet");
			Tooltip.SetDefault("15% increased mining speed\n15% increased block placement speed");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 10;
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
            item.value = Item.sellPrice(0, 2);
			item.height = dims.Height;
		}
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<XeradonArmor>() && legs.type == ModContent.ItemType<XeradonLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+5 block range and Spelunker effect";
            Player.tileRangeX += 5;
            Player.tileRangeY += 5;
            player.findTreasure = true;
        }
        public override void UpdateEquip(Player player)
		{
            player.wallSpeed += 0.15f;
            player.tileSpeed += 0.15f;
            player.pickSpeed -= 0.15f;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.MiningHelmet);
            r.AddIngredient(ItemID.AdamantiteBar, 3);
            r.AddIngredient(ItemID.TitaniumBar, 3);
            r.AddIngredient(ModContent.ItemType<Placeable.Bar.TroxiniumBar>(), 3);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
