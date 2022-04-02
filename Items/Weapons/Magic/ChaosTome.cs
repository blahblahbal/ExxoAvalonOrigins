using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class ChaosTome : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Chaos Tome");
        Tooltip.SetDefault("Casts a chaos bolt");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item20;
        Item.DamageType = DamageClass.Magic;
        Item.damage = 24;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.shootSpeed = 8f;
        Item.mana = 8;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.useTime = 25;
        Item.knockBack = 4f;
        Item.shoot = ModContent.ProjectileType<Projectiles.ChaosBolt>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 18400;
        Item.useAnimation = 25;
        Item.height = dims.Height;
    }
}