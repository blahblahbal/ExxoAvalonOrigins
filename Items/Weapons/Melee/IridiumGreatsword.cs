using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class IridiumGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Greatsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 30;
            item.crit = 6;
            item.rare = ItemRarityID.LightRed;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.4f;
            item.width = dims.Width;
            item.useTime = 18;
            item.knockBack = 5.4f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 50000;
            item.useAnimation = 18;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
    }
}
