using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class Shurikerang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shurikerang");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 18;
            item.noUseGraphic = true;
            item.scale = 1.2f;
            item.maxStack = 10;
            item.shootSpeed = 12f;
            item.crit += 3;
            item.ranged = true;
            item.noMelee = true;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.UseSound = SoundID.Item1;
            item.useTime = 12;
            item.knockBack = 3f;
            item.shoot = ModContent.ProjectileType<Projectiles.Shurikerang>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 30000;
            item.useAnimation = 12;
            item.height = dims.Height;
        }
        public override bool CanUseItem(Player player)
        {
            int stack = item.stack;
            bool canuse = true;
            for (int m = 0; m < 1000; m++)
            {
                if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == item.shoot)
                    stack -= 1;
            }
            if (stack <= 0) canuse = false;
            return canuse;
        }
    }
}
