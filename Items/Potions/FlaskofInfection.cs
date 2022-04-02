using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class FlaskofInfection : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Flask of Infection");
        Tooltip.SetDefault("Melee attacks inflict Infected on enemies");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.useTurn = true;
        Item.maxStack = 100;
        Item.buffType = ModContent.BuffType<Buffs.WeaponImbuePathogen>();
        Item.consumable = true;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 17;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.value = Item.sellPrice(0, 0, 5, 0);
        Item.useAnimation = 17;
        Item.height = dims.Height;
        Item.buffTime = 54000;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.BottledWater).AddIngredient(ModContent.ItemType<Material.Pathogen>(), 5).AddTile(TileID.ImbuingStation).Register();
    }
}