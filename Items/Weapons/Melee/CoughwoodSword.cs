using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class CoughwoodSword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Coughwood Sword");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.damage = 10;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 18;
        Item.scale = 1f;
        Item.knockBack = 3f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 0, 4, 0);
        Item.useAnimation = 18;
        Item.height = dims.Height;
    }
}