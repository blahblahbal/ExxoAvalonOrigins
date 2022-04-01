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
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.value = 0;
            Item.maxStack = 20;
            Item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<NPCs.DragonLordHead>())) return false;
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe(2).AddIngredient(ModContent.ItemType<DragonBait>()).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5).AddIngredient(ItemID.SoulofMight, 5).AddIngredient(ItemID.SoulofFlight, 5).AddIngredient(ItemID.RottenChunk, 5).AddIngredient(ItemID.PearlstoneBlock, 20).AddTile(ModContent.TileType<Tiles.DragonAltar>()).Register();
            CreateRecipe(2).AddIngredient(ModContent.ItemType<DragonBait>()).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5).AddIngredient(ItemID.SoulofMight, 5).AddIngredient(ItemID.SoulofFlight, 5).AddIngredient(ItemID.Vertebrae, 5).AddIngredient(ItemID.PearlstoneBlock, 20).AddTile(ModContent.TileType<Tiles.DragonAltar>()).Register();
            CreateRecipe(2).AddIngredient(ModContent.ItemType<DragonBait>()).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5).AddIngredient(ItemID.SoulofMight, 5).AddIngredient(ItemID.SoulofFlight, 5).AddIngredient(ModContent.ItemType<Material.YuckyBit>(), 5).AddIngredient(ItemID.PearlstoneBlock, 20).AddTile(ModContent.TileType<Tiles.DragonAltar>()).Register();
        }
    }
}
