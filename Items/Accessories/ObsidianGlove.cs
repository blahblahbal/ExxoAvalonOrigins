using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class ObsidianGlove : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Obsidian Glove");
        Tooltip.SetDefault("The wearer can place blocks and walls in midair and in lava\nProvides immunity to fire blocks");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 2, 0, 0);
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().updateInvisibleVanity = true;
    }
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().cloudGloves = true;
    }
    public override void UpdateVanity(Player player, EquipType type)
    {
        player.Avalon().cloudGloves = true;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<CloudGloves>()).AddIngredient(ItemID.ObsidianSkull).AddTile(TileID.TinkerersWorkbench).Register();
    }
}