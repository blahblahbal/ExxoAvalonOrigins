using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class CandyCane2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Candy Cane");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.potion = true;
            item.consumable = true;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 70;
            item.value = 100;
            item.useAnimation = 15;
            item.healLife = 60;
            item.height = dims.Height;
            item.UseSound = SoundID.Item2;
        }
    }
}
