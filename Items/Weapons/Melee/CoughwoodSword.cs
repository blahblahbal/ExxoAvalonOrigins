using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class CoughwoodSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coughwood Sword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 10;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 18;
            item.scale = 1f;
            item.knockBack = 3f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 4, 0);
            item.useAnimation = 18;
            item.height = dims.Height;
        }
    }
}
