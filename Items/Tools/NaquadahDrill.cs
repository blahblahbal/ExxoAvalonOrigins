using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class NaquadahDrill : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Naquadah Drill");
        Tooltip.SetDefault("Can mine Adamantite, Titanium, and Troxinium");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 12;
        Item.noUseGraphic = true;
        Item.channel = true;
        Item.shootSpeed = 32f;
        Item.pick = 150;
        Item.rare = ItemRarityID.LightRed;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 13;
        Item.knockBack = 0f;
        Item.shoot = ModContent.ProjectileType<Projectiles.NaquadahDrill>();
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 102500;
        Item.useAnimation = 25;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item23;
    }
}