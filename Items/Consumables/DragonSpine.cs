using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
	class DragonSpine : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Spine");
			Tooltip.SetDefault("Summons the Dragon Lord");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.rare = ItemRarityID.LightPurple;
			item.width = dims.Width;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = 0;
			item.maxStack = 20;
			item.useAnimation = 45;
			item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<NPCs.DragonLordHead>())) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position, 0);
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.DragonLordHead>());
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 10);
            r.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5);
            r.AddIngredient(ItemID.SoulofMight, 5);
            r.AddIngredient(ItemID.SoulofFlight, 5);
            r.AddIngredient(ItemID.RottenChunk, 5);
            r.AddIngredient(ItemID.PearlstoneBlock, 20);
            r.AddIngredient(ItemID.LivingFireBlock, 10);
            r.AddTile(ModContent.TileType<Tiles.DragonAltar>());
            r.SetResult(this, 2);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 10);
            r.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5);
            r.AddIngredient(ItemID.SoulofMight, 5);
            r.AddIngredient(ItemID.SoulofFlight, 5);
            r.AddIngredient(ItemID.Vertebrae, 5);
            r.AddIngredient(ItemID.PearlstoneBlock, 20);
            r.AddIngredient(ItemID.LivingFireBlock, 10);
            r.AddTile(ModContent.TileType<Tiles.DragonAltar>());
            r.SetResult(this, 2);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Material.DarkMatterGel>(), 10);
            r.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5);
            r.AddIngredient(ItemID.SoulofMight, 5);
            r.AddIngredient(ItemID.SoulofFlight, 5);
            r.AddIngredient(ModContent.ItemType<Material.YuckyBit>(), 5);
            r.AddIngredient(ItemID.PearlstoneBlock, 20);
            r.AddIngredient(ItemID.LivingFireBlock, 10);
            r.AddTile(ModContent.TileType<Tiles.DragonAltar>());
            r.SetResult(this, 2);
            r.AddRecipe();
        }
    }
}
