using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class BrokenVigilanteTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Vigilante Tome");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.height = dims.Height;
        }
    }
}
