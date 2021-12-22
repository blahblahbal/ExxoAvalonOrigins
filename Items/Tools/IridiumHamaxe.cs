using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class IridiumHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Hamaxe");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 20;
            item.autoReuse = true;
            item.hammer = 75;
            item.useTurn = true;
            item.scale = 1.2f;
            item.axe = 22;
            item.crit += 4;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 13;
            item.knockBack = 2.5f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 50000;
            item.useAnimation = 13;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
