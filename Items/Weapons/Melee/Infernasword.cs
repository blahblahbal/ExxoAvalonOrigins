using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class Infernasword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Infernasword");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 80;
        Item.autoReuse = true;
        Item.shootSpeed = 4f;
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.knockBack = 4f;
        Item.useTime = 20;
        Item.shoot = ModContent.ProjectileType<Projectiles.Melee.InfernoScythe>();
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 5);
        Item.useAnimation = 20;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.EnchantedSword).AddIngredient(ItemID.LivingFireBlock, 100).AddIngredient(ItemID.SoulofMight, 16).AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 7).AddTile(TileID.MythrilAnvil).Register();
    }
}
