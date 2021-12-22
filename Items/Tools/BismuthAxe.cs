using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class BismuthAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Axe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 4;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.05f;
            item.axe = 13;
            item.width = dims.Width;
            item.useTime = 17;
            item.knockBack = 4f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 4500;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 25;
            item.height = dims.Height;
        }
    }
}
