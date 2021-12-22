using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class BismuthShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Shortsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 14;
            item.useTurn = true;
            item.scale = 1f;
            item.width = dims.Width;
            item.useTime = 10;
            item.knockBack = 4f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.value = 4600;
            item.useAnimation = 10;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
