using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class CursedFlamelash : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Flamelash");
            Tooltip.SetDefault("Summons a controllable ball of cursed fire");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item20;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 40;
            Item.channel = true;
            Item.shootSpeed = 6f;
            Item.mana = 17;
            Item.rare = ItemRarityID.Pink;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 23;
            Item.knockBack = 4f;
            Item.shoot = ModContent.ProjectileType<Projectiles.CursedFlamelash>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 250000;
            Item.useAnimation = 23;
            Item.height = dims.Height;
        }
    }
}
