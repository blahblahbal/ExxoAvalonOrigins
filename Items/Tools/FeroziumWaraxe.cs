using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class FeroziumWaraxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ferozium Waraxe");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 30;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.5f;
            Item.axe = 24;
            Item.crit += 2;
            Item.rare = ItemRarityID.Lime;
            Item.width = dims.Width;
            Item.useTime = 20;
            Item.knockBack = 8f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 350000;
            Item.useAnimation = 20;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
    }
}
