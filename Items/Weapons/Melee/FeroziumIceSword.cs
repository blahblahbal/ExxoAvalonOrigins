using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

class FeroziumIceSword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ferozium Icesword");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 50;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1.5f;
        Item.shootSpeed = 15f;
        Item.crit += 2;
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.knockBack = 6f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Icicle>();
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 350000;
        Item.useAnimation = 20;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item1;
    }
}