using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
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
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.value = 50;
            item.maxStack = 99;
            item.height = dims.Height;
        }
    }
}
