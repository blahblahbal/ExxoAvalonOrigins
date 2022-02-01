using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class ZincBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Broadsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 13;
            item.useTurn = true;
            item.scale = 1.12f;
            item.width = dims.Width;
            item.useTime = 23;
            item.knockBack = 5.2f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 5500;
            item.useAnimation = 23;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
