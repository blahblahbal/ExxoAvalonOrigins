using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class OnyxStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Onyx Staff");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.SapphireStaff);
        Item.staff[Item.type] = true;
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.damage = 116;
        Item.autoReuse = true;
        Item.shootSpeed = 9.5f;
        Item.mana = 20;
        Item.rare = ItemRarityID.Cyan;
        Item.useTime = 19;
        Item.useAnimation = 19;
        Item.knockBack = 25.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.OnyxBolt>();
        Item.value = Item.buyPrice(0, 35, 0, 0);
        Item.UseSound = SoundID.Item43;
    }
}