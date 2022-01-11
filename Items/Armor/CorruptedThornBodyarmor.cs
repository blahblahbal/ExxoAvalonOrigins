using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class CorruptedThornBodyarmor : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrupted Thorn Bodyarmor");
			Tooltip.SetDefault("10% increased critical strike chance" +
				"\n50% increased critical damage" +
				"\nMax life increased by 100");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/CorruptedThornBodyarmor");
			item.defense = 18;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 1, 90, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike, 25);
            recipe.AddIngredient(ModContent.ItemType<Material.CorruptShard>(), 25);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateEquip(Player player)
		{
			player.magicCrit += 10;
			player.meleeCrit += 10;
			player.rangedCrit += 10;
			player.thrownCrit += 10;
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().critDamageMult += 0.50f;
			player.statLifeMax2 += 100;
		}
	}
}
