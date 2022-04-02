using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class MucusHammer : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mucus Hammer");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.damage = 25;
        Item.autoReuse = true;
        Item.hammer = 55;
        Item.useTurn = true;
        Item.scale = 1.2f;
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.useTime = 35;
        Item.knockBack = 6f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 0, 36, 0);
        Item.useAnimation = 35;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 11).AddIngredient(ModContent.ItemType<Material.Booger>(), 4).AddTile(TileID.Anvils).Register();
    }
}