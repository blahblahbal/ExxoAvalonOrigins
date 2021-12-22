using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class OsmiumHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Osmium Hamaxe");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 19;
            item.autoReuse = true;
            item.hammer = 70;
            item.useTurn = true;
            item.scale = 1.3f;
            item.axe = 20;
            item.crit += 5;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.useTime = 14;
            item.knockBack = 2.2f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 50000;
            item.useAnimation = 14;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
