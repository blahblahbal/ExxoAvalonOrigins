using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

public class Moonerang : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Moonerang");
        Tooltip.SetDefault("Strengthens at night");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 20;
        Item.scale = 1.2f;
        Item.DamageType = DamageClass.Melee;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.useTime = 30;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Moonerang>();
        Item.shootSpeed = 12f;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(0, 1, 0, 0);
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if(!Main.dayTime)
        {
            damage *= 2;
            return true;
        }
        return false;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        if (!Main.dayTime)
        {
            return new Color(255, 255, 255, 150);
        }
        return lightColor;
    }
}
