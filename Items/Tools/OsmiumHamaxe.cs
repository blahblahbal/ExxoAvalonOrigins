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
            Item.damage = 19;
            Item.autoReuse = true;
            Item.hammer = 70;
            Item.useTurn = true;
            Item.scale = 1.3f;
            Item.axe = 20;
            Item.crit += 5;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 14;
            Item.knockBack = 2.2f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 50000;
            Item.useAnimation = 14;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
    }
}
