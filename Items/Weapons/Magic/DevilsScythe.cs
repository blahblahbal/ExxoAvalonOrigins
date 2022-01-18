using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class DevilsScythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devil's Scythe");
            Tooltip.SetDefault("Casts a hellfire scythe");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item8;
            item.magic = true;
            item.damage = 61;
            item.autoReuse = true;
            item.scale = 0.9f;
            item.shootSpeed = 1.2f;
            item.mana = 16;
            item.rare = ItemRarityID.Pink;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 20;
            item.knockBack = 4.75f;
            item.shoot = ModContent.ProjectileType<Projectiles.DevilScythe>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 40000;
            item.useAnimation = 20;
            item.height = dims.Height;
        }
    }
}
