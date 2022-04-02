using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class SolarFlaresword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Solar Flaresword");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 82;
        Item.autoReuse = true;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.knockBack = 7f;
        Item.useTime = 25;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 9, 87, 65);
        Item.useAnimation = 25;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
}