using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class Elektriwave : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elektriwave");
            Tooltip.SetDefault("Has a chance to inflict Electrified");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 106;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1f;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.useTime = 15;
            item.knockBack = 6f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 616000;
            item.useAnimation = 15;
            item.height = dims.Height;
            item.UseSound = SoundID.Item15;
        }
    }
}
