using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class MechanicalWasp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Wasp");
            Tooltip.SetDefault("Summons Mechasting");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.consumable = true;
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = 0;
            Item.maxStack = 20;
            Item.useAnimation = 45;
            Item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Mechasting>())) return false;
            return true;
        }

        public override bool? UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position, 0);
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Mechasting>());
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Stinger, 9).AddIngredient(ItemID.HallowedBar, 10).AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 2).AddIngredient(ItemID.SoulofFlight, 15).AddTile(ModContent.TileType<Tiles.HallowedAltar>()).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.MosquitoProboscis>(), 9).AddIngredient(ItemID.HallowedBar, 10).AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 2).AddIngredient(ItemID.SoulofFlight, 15).AddTile(ModContent.TileType<Tiles.HallowedAltar>()).Register();
        }
    }
}
