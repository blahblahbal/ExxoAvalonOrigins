using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class TourmalineStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tourmaline Staff");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.SapphireStaff);
        Item.staff[Item.type] = true;
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.damage = 28;
        Item.autoReuse = true;
        Item.shootSpeed = 7.5f;
        Item.mana = 9;
        Item.rare = ItemRarityID.Blue;
        Item.useTime = 28;
        Item.useAnimation = 28;
        Item.knockBack = 4.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.TourmalineBolt>();
        Item.value = Item.buyPrice(0, 3, 50, 0);
        Item.UseSound = SoundID.Item43;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Tile.Tourmaline>(), 15).AddIngredient(ItemID.DemoniteBar, 20).AddIngredient(ItemID.ShadowScale, 5).AddTile(TileID.Anvils).Register();
    }
}