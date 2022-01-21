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
            item.damage = 120;
            item.UseSound = SoundID.Item1;
            item.noUseGraphic = true;
            item.scale = 1f;
            item.shootSpeed = 5f;
            item.rare = ItemRarityID.Cyan;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 14;
            item.useAnimation = 14;
            item.knockBack = 4.5f;
            item.shoot = ModContent.ProjectileType<Projectiles.OblivionGlaive>();
            item.melee = true;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}
