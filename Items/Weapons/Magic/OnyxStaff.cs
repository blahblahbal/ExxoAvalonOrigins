using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class OnyxStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyx Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SapphireStaff);
            Item.staff[item.type] = true;
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.height = dims.Height;
            item.damage = 116;
            item.autoReuse = true;
            item.shootSpeed = 9.5f;
            item.mana = 20;
            item.rare = ItemRarityID.Cyan;
            item.useTime = 19;
            item.useAnimation = 19;
            item.knockBack = 25.5f;
            item.shoot = ModContent.ProjectileType<Projectiles.OnyxBolt>();
            item.value = Item.buyPrice(0, 35, 0, 0);
            item.UseSound = SoundID.Item43;
        }
    }
}
