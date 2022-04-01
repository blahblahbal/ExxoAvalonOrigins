using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class DarklightLance : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darklight Lance");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 99;
            Item.noUseGraphic = true;
            Item.scale = 1f;
            Item.shootSpeed = 4f;
            Item.rare = ItemRarityID.Yellow;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 5.5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.DarklightLance>();
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 40, 0, 0);
            Item.height = dims.Height;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
    }
}
