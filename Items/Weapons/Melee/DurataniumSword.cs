using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class DurataniumSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duratanium Sword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 40;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1f;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 24;
            item.knockBack = 5f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 1, 62, 0);
            item.useAnimation = 24;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
