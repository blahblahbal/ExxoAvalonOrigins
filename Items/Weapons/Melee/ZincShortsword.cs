using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class ZincShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Shortsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 11;
            Item.useTurn = true;
            Item.scale = 1f;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.knockBack = 4f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.value = 4500;
            Item.useAnimation = 10;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
    }
}
