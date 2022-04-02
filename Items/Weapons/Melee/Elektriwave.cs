using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class Elektriwave : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Elektriwave");
        Tooltip.SetDefault("Has a chance to inflict Electrified");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 106;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1f;
        Item.rare = ItemRarityID.Red;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.knockBack = 6f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 616000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item15;
    }
}