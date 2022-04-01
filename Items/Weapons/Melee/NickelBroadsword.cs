using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class NickelBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Broadsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 11;
            Item.useTurn = true;
            Item.scale = 1.15f;
            Item.width = dims.Width;
            Item.useTime = 21;
            Item.knockBack = 5.2f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 2250;
            Item.useAnimation = 21;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
    }
}
