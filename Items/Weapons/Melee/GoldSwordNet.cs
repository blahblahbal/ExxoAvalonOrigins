using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class GoldSwordNet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gold Sword Net");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 13;
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
        CreateRecipe(1).AddIngredient(ItemID.GoldBroadsword).AddIngredient(ItemID.BugNet).AddTile(TileID.Anvils).Register();
    }
}