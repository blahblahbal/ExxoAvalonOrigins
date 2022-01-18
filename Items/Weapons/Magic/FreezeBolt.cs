using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class FreezeBolt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freeze Bolt");
            Tooltip.SetDefault("Casts a fast-moving bolt of ice");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.magic = true;
            item.damage = 43;
            item.autoReuse = true;
            item.useTurn = true;
            item.shootSpeed = 7f;
            item.mana = 11;
            item.rare = ItemRarityID.Pink;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 17;
            item.knockBack = 5f;
            item.shoot = ModContent.ProjectileType<Projectiles.FreezeBolt>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 50000;
            item.useAnimation = 17;
            item.height = dims.Height;
            item.UseSound = SoundID.Item21;
        }
    }
}
