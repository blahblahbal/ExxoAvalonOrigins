using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class MagicGrenade : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Magic Grenade");
        Tooltip.SetDefault("A small explosion that will not destroy tiles");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 85;
        Item.noUseGraphic = true;
        Item.shootSpeed = 8f;
        Item.mana = 40;
        Item.rare = ItemRarityID.Cyan;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.knockBack = 8f;
        Item.useTime = 27;
        Item.shoot = ModContent.ProjectileType<Projectiles.MagicGrenade>();
        Item.value = Item.sellPrice(0, 10, 0, 0);
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 27;
        Item.height = dims.Height;
    }
}