using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
    class RockTumble : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rock Tumble");
            Tooltip.SetDefault("Casts boulders");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/RockTumble");
            item.damage = 78;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1;
            item.shootSpeed = 8f;
            item.rare = 8;
            item.width = dims.Width;
            item.useTime = 30;
            item.knockBack = 5f;
            item.noMelee = true;
            item.mana = 25;
            item.crit += 3;
            item.shoot = ModContent.ProjectileType<Projectiles.Rock>();
            item.UseSound = SoundID.Item20;
            item.magic = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.useAnimation = 30;
            item.height = dims.Height;
        }
        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 45);
        //    recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 40);
        //    recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 45);
        //    recipe.AddIngredient(ModContent.ItemType<ElementalExcalibur>());
        //    recipe.AddIngredient(ModContent.ItemType<BerserkerBlade>());
        //    recipe.AddIngredient(ModContent.ItemType<PumpkingsSword>());
        //    recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num194 = 0; num194 < 5; num194++)
            {
                float num195 = speedX;
                float num196 = speedY;
                num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
                num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num195, num196, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}