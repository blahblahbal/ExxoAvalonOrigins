using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Summon;

public class TroxiniumDaggerStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Troxinium Dagger Staff");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Summon;
        Item.damage = 28;
        Item.shootSpeed = 14f;
        Item.mana = 8;
        Item.noMelee = true;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.knockBack = 5.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Summon.TroxiniumDagger>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 3, 20);
        Item.useAnimation = 30;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item44;
    }
    public override bool CanUseItem(Player player)
    {
        return true;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.TroxiniumBar>(), 22).AddTile(TileID.Anvils).Register();
    }
}