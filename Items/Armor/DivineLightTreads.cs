using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class DivineLightTreads : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Divine Light Treads");
        Tooltip.SetDefault("25% increased movement speed" +
                           "\n20% increased arrow damage and velocity");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 15;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 1, 80, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.PixieDust, 20)
            .AddIngredient(ModContent.ItemType<Placeable.Bar.CaesiumBar>(), 15)
            .AddIngredient(ItemID.SoulofLight, 15).AddTile(TileID.MythrilAnvil).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.25f;
        player.archery = true;
    }
}
