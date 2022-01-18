using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class FieryBladeofGrass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiery Blade of Grass");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 33;
            item.useTurn = item.autoReuse = true;
            item.scale = 1f;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 23;
            item.knockBack = 3.5f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 54, 0);
            item.useAnimation = 23;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
