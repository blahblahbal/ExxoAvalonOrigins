using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class SolariumStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solarium Staff");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SapphireStaff);
            Item.staff[Item.type] = true;
            Rectangle dims = this.GetDims();
            Item.width = dims.Width;
            Item.height = dims.Height;
            Item.damage = 59;
            Item.autoReuse = true;
            Item.shootSpeed = 9f;
            Item.mana = 19;
            Item.rare = ItemRarityID.Cyan;
            Item.knockBack = 6f;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.shoot = ModContent.ProjectileType<Projectiles.SolarBolt>();
            Item.value = Item.sellPrice(0, 10, 0, 0);
        }
    }
}
