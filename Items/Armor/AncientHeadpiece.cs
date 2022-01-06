using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class AncientHeadpiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Headpiece");
			Tooltip.SetDefault("20% increased damage\n5% increased critical strike chance");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 30;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 50, 0, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.SolarFlareHelmet);
            r.AddIngredient(ItemID.FragmentNebula, 10);
            r.AddIngredient(ItemID.FragmentStardust, 10);
            r.AddIngredient(ItemID.FragmentVortex, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.NebulaHelmet);
            r.AddIngredient(ItemID.FragmentSolar, 10);
            r.AddIngredient(ItemID.FragmentStardust, 10);
            r.AddIngredient(ItemID.FragmentVortex, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.StardustHelmet);
            r.AddIngredient(ItemID.FragmentNebula, 10);
            r.AddIngredient(ItemID.FragmentSolar, 10);
            r.AddIngredient(ItemID.FragmentVortex, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.VortexHelmet);
            r.AddIngredient(ItemID.FragmentNebula, 10);
            r.AddIngredient(ItemID.FragmentStardust, 10);
            r.AddIngredient(ItemID.FragmentSolar, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<AncientBodyplate>() && legs.type == ModContent.ItemType<AncientLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();
			player.setBonus = "Ancient costs 50% less mana"
				+ "\nEnemies killed with a ranged weapon violently explode"
				+ "\nHas a chance to summon a sand vortex that pulls enemies in on true melee hits"
				+ "\nRight-click and hold while holding a summon weapon to direct your minions";
			modPlayer.ancientLessCost = true;
			modPlayer.ancientGunslinger = true;
            modPlayer.ancientMinionGuide = true;
            modPlayer.ancientSandVortex = true;
        }

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.2f;
			player.meleeDamage += 0.2f;
			player.minionDamage += 0.2f;
			player.magicDamage += 0.2f;
            player.thrownDamage += 0.2f;
			player.magicCrit += 5;
			player.meleeCrit += 5;
			player.rangedCrit += 5;
            player.thrownCrit += 5;
		}
	}
}
