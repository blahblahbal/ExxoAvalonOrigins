using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class GuardianHammer : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Guardian Hammer");
        Tooltip.SetDefault("'Lightning strikes with each hit'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 120;
        Item.noUseGraphic = true;
        Item.shootSpeed = 14f;
        Item.rare = ItemRarityID.Red;
        Item.autoReuse = true;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 13;
        Item.knockBack = 12f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Melee.GuardianHammer>();
        Item.DamageType = DamageClass.Melee;
        Item.value = Item.sellPrice(0, 25, 0, 0);
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 13;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
    public override bool CanUseItem(Player player)
    {
        return (!(player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Melee.GuardianHammer>()] > 0));
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.PaladinsHammer).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20).AddIngredient(ItemID.Ectoplasm, 15).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
}