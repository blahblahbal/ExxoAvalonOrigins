using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class EnergyRevolver : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Energy Revolver");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 57;
        Item.autoReuse = true;
        Item.shootSpeed = 15f;
        Item.mana = 6;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.knockBack = 2f;
        Item.useTime = 6;
        Item.shoot = ProjectileID.GreenLaser;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = Item.sellPrice(0, 2, 60, 0);
        Item.useAnimation = 6;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item12;
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-10f, 0f);
    }
}