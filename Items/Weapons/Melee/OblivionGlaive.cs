using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class OblivionGlaive : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblivion Glaive");
            Tooltip.SetDefault("Striking an enemy causes shadow glaives to rain down");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 120;
            Item.UseSound = SoundID.Item1;
            Item.noUseGraphic = true;
            Item.scale = 1f;
            Item.shootSpeed = 5f;
            Item.rare = ItemRarityID.Cyan;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.knockBack = 4.5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.OblivionGlaive>();
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
    }
}
