using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tokens;

class DarkMatterToken : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dark Matter Token");
        Tooltip.SetDefault("Used to make things\nGathered after Armageddon Slime is defeated");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.rare = ItemRarityID.LightPurple;
        Item.maxStack = 999;
        Item.value = 0;
        Item.height = dims.Height;
    }
}