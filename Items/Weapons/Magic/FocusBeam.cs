using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class FocusBeam : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Focus Beam");
        Tooltip.SetDefault("Fires a wide-beam laser");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 47;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.scale = 1f;
        Item.shootSpeed = 15f;
        Item.crit += 1;
        Item.mana = 18;
        Item.rare = ItemRarityID.Orange;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 27;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.FocusBeam>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 388500;
        Item.useAnimation = 27;
        Item.height = dims.Height;
        Item.UseSound = Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Beam");
    }
}