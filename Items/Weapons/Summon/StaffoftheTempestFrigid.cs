using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Summon;

class StaffoftheTempestFrigid : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Staff of the Tempest Frigid");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Summon;
        Item.damage = 152;
        Item.shootSpeed = 14f;
        Item.mana = 30;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.knockBack = 8.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Summon.IceGolemSummon>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 30, 0, 0);
        Item.useAnimation = 30;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item44;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.StaffoftheFrostHydra).AddIngredient(ModContent.ItemType<Material.SoulofIce>(), 75).AddIngredient(ItemID.FrostCore, 10).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20).AddIngredient(ModContent.ItemType<Placeable.Bar.HydrolythBar>(), 40).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).ReplaceResult(ModContent.ItemType<StaffoftheTempestFrigid>());
    }
}