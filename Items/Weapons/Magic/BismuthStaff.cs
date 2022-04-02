using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class BismuthStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bismuth Staff");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.SapphireStaff);
        Item.staff[Item.type] = true;
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.damage = 27;
        Item.shootSpeed = 7.5f;
        Item.mana = 10;
        Item.rare = ItemRarityID.Orange;
        Item.useTime = 24;
        Item.useAnimation = 24;
        Item.knockBack = 4f;
        Item.shoot = ProjectileID.DiamondBolt;
        Item.value = 20000;
        Item.UseSound = SoundID.Item43;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 10).AddIngredient(ItemID.Ruby, 8).AddTile(TileID.Anvils).Register();
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 10).AddIngredient(ItemID.Diamond, 8).AddTile(TileID.Anvils).Register();
    }
}