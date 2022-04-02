using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class TroxiniumChainsaw : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Troxinium Chainsaw");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 32;
        Item.noUseGraphic = true;
        Item.channel = true;
        Item.axe = 20;
        Item.shootSpeed = 40f;
        Item.rare = ItemRarityID.Pink;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 6;
        Item.knockBack = 4.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.TroxiniumChainsaw>();
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 114000;
        Item.useAnimation = 25;
        Item.height = dims.Height;
    }
}