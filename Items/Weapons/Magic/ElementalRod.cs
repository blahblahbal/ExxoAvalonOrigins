using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class ElementalRod : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Elemental Rod");
        Tooltip.SetDefault("Will inflict debuffs");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 45;
        Item.channel = true;
        Item.shootSpeed = 9f;
        Item.mana = 19;
        Item.crit += 16;
        Item.rare = ItemRarityID.Yellow;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 23;
        Item.knockBack = 4f;
        Item.shoot = ModContent.ProjectileType<Projectiles.ElementOrb>();
        Item.value = Item.sellPrice(0, 40, 0, 0);
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 23;
        Item.height = dims.Height;
    }
}