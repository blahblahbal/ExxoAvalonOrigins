using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tokens
{
    public class SuperhardmodeToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Superhardmode Token");
            Tooltip.SetDefault("Used to make things\nGathered during the start of Superhardmode");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.width = dims.Width;
            Item.rare = ItemRarityID.Red;
            Item.maxStack = 999;
            Item.value = 0;
            Item.height = dims.Height;
        }
    }
}
