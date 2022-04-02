using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class VorazylcumPicksaw : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Vorazylcum Picksaw");
        Tooltip.SetDefault("Can mine Oblivion Ore");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 30;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1.15f;
        Item.axe = 25;
        Item.pick = 310;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.useTime = 13;
        Item.knockBack = 5.5f;
        Item.DamageType = DamageClass.Melee;
        Item.tileBoost += 6;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 516000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void HoldItem(Player player)
    {
        if (player.inventory[player.selectedItem].type == Item.type)
        {
            player.pickSpeed -= 0.35f;
        }
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.VorazylcumBar>(), 20).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
}