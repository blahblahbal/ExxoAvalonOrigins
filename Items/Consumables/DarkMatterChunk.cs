using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Consumables;

class DarkMatterChunk : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dark Matter Chunk");
        Tooltip.SetDefault("Summons the Armageddon Slime");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.rare = ItemRarityID.Pink;
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
        if (NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>())) return false;
        return true;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.EbonstoneBlock, 30).AddIngredient(ItemID.SoulofNight, 8).AddIngredient(ItemID.Ectoplasm, 5).AddIngredient(ModContent.ItemType<Material.EarthStone>()).AddIngredient(ModContent.ItemType<Material.SoulofBlight>()).AddTile(TileID.DemonAltar).Register();
        CreateRecipe(1).AddIngredient(ItemID.CrimstoneBlock, 30).AddIngredient(ItemID.SoulofNight, 8).AddIngredient(ItemID.Ectoplasm, 5).AddIngredient(ModContent.ItemType<Material.EarthStone>()).AddIngredient(ModContent.ItemType<Material.SoulofBlight>()).AddTile(TileID.DemonAltar).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Tile.ChunkstoneBlock>(), 30).AddIngredient(ItemID.SoulofNight, 8).AddIngredient(ItemID.Ectoplasm, 5).AddIngredient(ModContent.ItemType<Material.EarthStone>()).AddIngredient(ModContent.ItemType<Material.SoulofBlight>()).AddTile(TileID.DemonAltar).Register();
    }
    public override bool? UseItem(Player player)
    {
        Main.PlaySound(SoundID.Roar, player.position, 0);
        NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>());
        return true;
    }
}