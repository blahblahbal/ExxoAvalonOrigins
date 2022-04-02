using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class NaquadahSword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Naquadah Sword");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 43;
        Item.useTurn = true;
        Item.scale = 1f;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 24;
        Item.knockBack = 4f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 2, 64, 0);
        Item.useAnimation = 24;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
}