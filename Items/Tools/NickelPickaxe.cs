using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class NickelPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Pickaxe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 6;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1f;
            item.pick = 44;
            item.width = dims.Width;
            item.useTime = 12;
            item.knockBack = 2f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 850;
            item.useAnimation = 19;
            item.height = dims.Height;
        }
    }
}
