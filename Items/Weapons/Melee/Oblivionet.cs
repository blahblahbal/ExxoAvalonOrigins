using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class Oblivionet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Oblivionet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 70;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.knockBack = 6.2f;
        Item.useTime = 21;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.buyPrice(0, 5, 0, 0);
        Item.useAnimation = 21;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<ExcaliburNet>()).AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 10).AddTile(TileID.Anvils).Register();
    }
}