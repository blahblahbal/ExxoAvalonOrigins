using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class ZincBroadsword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zinc Broadsword");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 13;
        Item.useTurn = true;
        Item.scale = 1.12f;
        Item.width = dims.Width;
        Item.useTime = 23;
        Item.knockBack = 5.2f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 5500;
        Item.useAnimation = 23;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
}