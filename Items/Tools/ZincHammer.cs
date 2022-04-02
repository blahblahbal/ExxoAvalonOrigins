using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class ZincHammer : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zinc Hammer");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 9;
        Item.autoReuse = true;
        Item.hammer = 49;
        Item.useTurn = true;
        Item.scale = 1.2f;
        Item.width = dims.Width;
        Item.useTime = 18;
        Item.knockBack = 4.5f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 5000;
        Item.useAnimation = 28;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
}