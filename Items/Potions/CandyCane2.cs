using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions;

class CandyCane2 : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Candy Cane");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.potion = true;
        Item.consumable = true;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 70;
        Item.value = 100;
        Item.useAnimation = 15;
        Item.healLife = 60;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item2;
    }
}