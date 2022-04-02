using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class ZincPickaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zinc Pickaxe");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item1;
        Item.damage = 6;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1f;
        Item.pick = 53;
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.knockBack = 2f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 6250;
        Item.useAnimation = 14;
        Item.height = dims.Height;
    }
}