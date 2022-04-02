using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class CoughwoodHammer : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Coughwood Hammer");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.damage = 7;
        Item.autoReuse = true;
        Item.hammer = 42;
        Item.useTurn = true;
        Item.scale = 1.2f;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.knockBack = 5.5f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 50;
        Item.useAnimation = 30;
        Item.height = dims.Height;
    }
}