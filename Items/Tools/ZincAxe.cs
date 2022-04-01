using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class ZincAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Axe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 8;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.05f;
            Item.axe = 11;
            Item.width = dims.Width;
            Item.useTime = 17;
            Item.knockBack = 4f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 4000;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 25;
            Item.height = dims.Height;
        }
    }
}
