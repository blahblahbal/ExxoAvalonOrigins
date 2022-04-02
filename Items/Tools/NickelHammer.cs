using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class NickelHammer : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Nickel Hammer");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 8;
        Item.autoReuse = true;
        Item.hammer = 45;
        Item.useTurn = true;
        Item.scale = 1.22f;
        Item.width = dims.Width;
        Item.useTime = 17;
        Item.knockBack = 4.5f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 2000;
        Item.useAnimation = 27;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
}