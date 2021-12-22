using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class ZincShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Shortsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 11;
            item.useTurn = true;
            item.scale = 1f;
            item.width = dims.Width;
            item.useTime = 10;
            item.knockBack = 4f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.value = 1700;
            item.useAnimation = 10;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
