using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class BismuthHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Hammer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 11;
            item.autoReuse = true;
            item.hammer = 61;
            item.useTurn = true;
            item.scale = 1.2f;
            item.width = dims.Width;
            item.useTime = 18;
            item.knockBack = 4.5f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 4500;
            item.useAnimation = 28;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
