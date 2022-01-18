using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class DesertLongSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Longsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 29;
            item.useTurn = true;
            item.scale = 1f;
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.useTime = 27;
            item.knockBack = 3f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 54, 0);
            item.useAnimation = 27;
            item.height = dims.Height;
        }
    }
}
