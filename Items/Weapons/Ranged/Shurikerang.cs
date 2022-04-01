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
            Item.damage = 18;
            Item.noUseGraphic = true;
            Item.scale = 1.2f;
            Item.maxStack = 10;
            Item.shootSpeed = 12f;
            Item.crit += 3;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.UseSound = SoundID.Item1;
            Item.useTime = 12;
            Item.knockBack = 3f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Shurikerang>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 30000;
            Item.useAnimation = 12;
            Item.height = dims.Height;
        }
        public override bool CanUseItem(Player player)
        {
            int stack = Item.stack;
            bool canuse = true;
            for (int m = 0; m < 1000; m++)
            {
                if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == Item.shoot)
                    stack -= 1;
            }
            if (stack <= 0) canuse = false;
            return canuse;
        }
    }
}
