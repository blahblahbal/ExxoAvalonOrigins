using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes, EquipType.Wings)]
    class InertiaBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inertia Boots");
            Tooltip.SetDefault("Allows flight and slow fall and the wearer can run incredibly fast\nThe wearer has a chance to dodge attacks and negates fall damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Accessories/InertiaBoots");
            item.defense = 4;
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 16, 45, 0);
            item.accessory = true;
            item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:Wings");
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.BlackBelt);
            recipe.AddIngredient(ItemID.LunarBar, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().noSticky = true;
            player.accRunSpeed = 10.29f;
            player.rocketBoots = 3;
            player.noFallDmg = true;
            player.blackBelt = true;
            player.iceSkate = true;
            player.wingTime = 1000;

            //if (player.controlUp && player.controlJump)
            //{
            //    player.velocity.Y = player.velocity.Y - 0.3f * player.gravDir;
            //    if (player.gravDir == 1f)
            //    {
            //        if (player.velocity.Y > 0f)
            //        {
            //            player.velocity.Y = player.velocity.Y - 1f;
            //        }
            //        else if (player.velocity.Y > -Player.jumpSpeed)
            //        {
            //            player.velocity.Y = player.velocity.Y - 0.2f;
            //        }
            //        if (player.velocity.Y < -Player.jumpSpeed * 3f)
            //        {
            //            player.velocity.Y = -Player.jumpSpeed * 3f;
            //        }
            //    }
            //    else
            //    {
            //        if (player.velocity.Y < 0f)
            //        {
            //            player.velocity.Y = player.velocity.Y + 1f;
            //        }
            //        else if (player.velocity.Y < Player.jumpSpeed)
            //        {
            //            player.velocity.Y = player.velocity.Y + 0.2f;
            //        }
            //        if (player.velocity.Y > Player.jumpSpeed * 3f)
            //        {
            //            player.velocity.Y = Player.jumpSpeed * 3f;
            //        }
            //    }
            //}

            if (player.controlLeft)
            {
                if (player.velocity.X > -5f)
                {
                    player.velocity.X = player.velocity.X - 0.31f;
                }
                if (player.velocity.X < -5f && player.velocity.X > -10f)
                {
                    player.velocity.X = player.velocity.X - 0.29f;
                }
            }
            if (player.controlRight)
            {
                if (player.velocity.X < 5f)
                {
                    player.velocity.X = player.velocity.X + 0.31f;
                }
                if (player.velocity.X > 5f && player.velocity.X < 10f)
                {
                    player.velocity.X = player.velocity.X + 0.29f;
                }
            }
            if (player.velocity.X > 6f || player.velocity.X < -6f)
            {
                var newColor = default(Color);
                var num = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Cloud, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 100, newColor, 2f);
                Main.dust[num].noGravity = true;
            }
        }
    }
}
