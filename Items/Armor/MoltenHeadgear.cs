using ExxoAvalonOrigins.Items.Armor;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class MoltenHeadgear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Headgear");
			Tooltip.SetDefault("Ranged helmet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 5;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
            item.value = 30000;
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.HellstoneBar, 10);
            r.AddIngredient(ModContent.ItemType<Items.Material.FireShard>());
            r.AddTile(TileID.Anvils);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.MoltenBreastplate && legs.type == ItemID.MoltenGreaves;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = "17% increased ranged damage and 20% chance to not consume ammo";
            player.rangedDamage += 0.17f;
            player.ammoCost80 = true;
		}
	}
}
