using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class NickelAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Axe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 7;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.05f;
            Item.axe = 10;
            Item.width = dims.Width;
            Item.useTime = 18;
            Item.knockBack = 4f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 2000;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 26;
            Item.height = dims.Height;
        }
    }
}
