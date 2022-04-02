using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class BismuthSwordNet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bismuth Sword Net");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 16;
        Item.autoReuse = true;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.knockBack = 5f;
        Item.useTime = 23;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.buyPrice(0, 1, 0, 0);
        Item.useAnimation = 23;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<BismuthBroadsword>()).AddIngredient(ItemID.BugNet).AddTile(TileID.Anvils).Register();
    }
}