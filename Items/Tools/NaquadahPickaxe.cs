using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class NaquadahPickaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Naquadah Pickaxe");
        Tooltip.SetDefault("Can mine Adamantite, Titanium, and Troxinium");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 12;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1f;
        Item.pick = 150;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.knockBack = 1f;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 2, 5, 0);
        Item.useAnimation = 20;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
}