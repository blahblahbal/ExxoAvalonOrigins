using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material;

class IllegalWeaponInstructions : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Illegal Weapon Instructions");
        Tooltip.SetDefault("'Read if you dare'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.value = 50;
        Item.maxStack = 99;
        Item.height = dims.Height;
    }
}