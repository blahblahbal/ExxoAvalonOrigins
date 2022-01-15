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
			Tooltip.SetDefault("Summons the Dragon Lord\nUse at the Dragon Altar in the Sky Fortress");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.value = 0;
			item.maxStack = 20;
			item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<NPCs.DragonLordHead>())) return false;
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<DragonBait>());
            r.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5);
            r.AddIngredient(ItemID.SoulofMight, 5);
            r.AddIngredient(ItemID.SoulofFlight, 5);
            r.AddIngredient(ItemID.RottenChunk, 5);
            r.AddIngredient(ItemID.PearlstoneBlock, 20);
            r.AddTile(ModContent.TileType<Tiles.DragonAltar>());
            r.SetResult(this, 2);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<DragonBait>());
            r.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5);
            r.AddIngredient(ItemID.SoulofMight, 5);
            r.AddIngredient(ItemID.SoulofFlight, 5);
            r.AddIngredient(ItemID.Vertebrae, 5);
            r.AddIngredient(ItemID.PearlstoneBlock, 20);
            r.AddTile(ModContent.TileType<Tiles.DragonAltar>());
            r.SetResult(this, 2);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<DragonBait>());
            r.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5);
            r.AddIngredient(ItemID.SoulofMight, 5);
            r.AddIngredient(ItemID.SoulofFlight, 5);
            r.AddIngredient(ModContent.ItemType<Material.YuckyBit>(), 5);
            r.AddIngredient(ItemID.PearlstoneBlock, 20);
            r.AddTile(ModContent.TileType<Tiles.DragonAltar>());
            r.SetResult(this, 2);
            r.AddRecipe();
        }
    }
}
