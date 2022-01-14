using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class BismuthPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Pickaxe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 6;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1f;
            item.pick = 59;
            item.width = dims.Width;
            item.useTime = 10;
            item.knockBack = 2f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 4500;
            item.useAnimation = 14;
            item.height = dims.Height;
        }
    }
}
