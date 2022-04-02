using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework.Graphics;

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
        item.damage = 20;
        item.scale = 1.2f;
        item.melee = true;
        item.autoReuse = true;
        item.useTurn = true;
        item.rare = ItemRarityID.Pink;
        item.width = dims.Width;
        item.height = dims.Height;
        item.useTime = 30;
        item.useAnimation = 20;
        item.useStyle = ItemUseStyleID.SwingThrow;
        item.knockBack = 5f;
        item.shoot = ModContent.ProjectileType<Projectiles.Melee.Moonerang>();
        item.shootSpeed = 12f;
        item.UseSound = SoundID.Item1;
        item.value = Item.sellPrice(0, 1, 0, 0);
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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