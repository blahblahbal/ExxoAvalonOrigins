using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class NaquadahGreataxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naquadah Greataxe");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 29;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1f;
            Item.axe = 18;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.useTime = 18;
            Item.knockBack = 7f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 2, 5, 0);
            Item.useAnimation = 18;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
    }
}
