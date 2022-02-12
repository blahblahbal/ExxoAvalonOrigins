using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class NickelBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Broadsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 11;
            item.useTurn = true;
            item.scale = 1.15f;
            item.width = dims.Width;
            item.useTime = 21;
            item.knockBack = 5.2f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 2250;
            item.useAnimation = 21;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
