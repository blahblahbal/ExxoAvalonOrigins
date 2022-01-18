using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class TheBanhammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Banhammer");
            Tooltip.SetDefault("Strong enough to destroy Hallowed Altars");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 30;
            item.autoReuse = true;
            item.hammer = 100;
            item.useTurn = true;
            item.scale = 1f;
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.useTime = 10;
            item.knockBack = 12f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.useAnimation = 17;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
