using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class TomeoftheDistantPast : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tome of the Distant Past");
        Tooltip.SetDefault("Summons a bone barrage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 30;
        Item.autoReuse = true;
        Item.shootSpeed = 7f;
        Item.crit += -1;
        Item.mana = 6;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.knockBack = 4f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Bones>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 27000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}