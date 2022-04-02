using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class PeridotStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Peridot Staff");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.SapphireStaff);
        Item.staff[Item.type] = true;
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.damage = 30;
        Item.autoReuse = true;
        Item.shootSpeed = 7.75f;
        Item.mana = 10;
        Item.rare = ItemRarityID.Blue;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.knockBack = 4.75f;
        Item.shoot = ModContent.ProjectileType<Projectiles.PeridotBolt>();
        Item.value = Item.buyPrice(0, 3, 60, 0);

        Item.UseSound = SoundID.Item43;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Tile.Peridot>(), 15).AddIngredient(ItemID.CrimtaneBar, 20).AddIngredient(ItemID.TissueSample, 5).AddTile(TileID.Anvils).Register();
    }
}