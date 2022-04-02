using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class BronzeStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bronze Staff");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.SapphireStaff);
        Item.staff[Item.type] = true;
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.damage = 17;
        Item.shootSpeed = 7.5f;
        Item.mana = 5;
        Item.rare = ItemRarityID.Blue;
        Item.useTime = 36;
        Item.useAnimation = 36;
        Item.knockBack = 4f;
        Item.shoot = ProjectileID.AmethystBolt;
        Item.value = 4000;
        Item.UseSound = SoundID.Item43;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BronzeBar>(), 10).AddIngredient(ItemID.Topaz, 8).AddTile(TileID.Anvils).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BronzeBar>(), 10).AddIngredient(ItemID.Amethyst, 8).AddTile(TileID.Anvils).Register();
    }
}