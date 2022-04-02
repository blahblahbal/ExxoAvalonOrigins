using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class Boomlash : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Boomlash");
        Tooltip.SetDefault("Summons a terrain-destroying missile");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item20;
        Item.DamageType = DamageClass.Magic;
        Item.damage = 80;
        Item.channel = true;
        Item.shootSpeed = 4f;
        Item.mana = 40;
        Item.rare = ItemRarityID.Yellow;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.knockBack = 12f;
        Item.useTime = 30;
        Item.shoot = ModContent.ProjectileType<Projectiles.Boomlash>();
        Item.value = Item.sellPrice(0, 2, 0, 0);
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 30;
        Item.height = dims.Height;
    }
}