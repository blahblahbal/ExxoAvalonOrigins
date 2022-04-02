using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class InstantaniumPicksaw : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Instantanium Picksaw");
        Tooltip.SetDefault("'The ultimate tool'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 30;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1.15f;
        Item.axe = 35;
        Item.pick = 350;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.useTime = 5;
        Item.knockBack = 5.5f;
        Item.DamageType = DamageClass.Melee;
        Item.tileBoost += 4;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 416000;
        Item.useAnimation = 11;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }

    public override void HoldItem(Player player)
    {
        if (player.inventory[player.selectedItem].type == Mod.Find<ModItem>("InstantaniumPicksaw").Type)
        {
            player.pickSpeed -= 0.5f;
        }
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Picksaw).AddIngredient(ItemID.TitaniumBar, 30).AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 5).AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 10).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).ReplaceResult(ModContent.ItemType<InstantaniumPicksaw>());
        CreateRecipe(1).AddIngredient(ItemID.Picksaw).AddIngredient(ModContent.ItemType<Placeable.Bar.TroxiniumBar>(), 30).AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 5).AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 10).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).ReplaceResult(ModContent.ItemType<InstantaniumPicksaw>());
        CreateRecipe(1).AddIngredient(ItemID.Picksaw).AddIngredient(ItemID.AdamantiteBar, 30).AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 5).AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 10).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).ReplaceResult(ModContent.ItemType<InstantaniumPicksaw>());
    }
}