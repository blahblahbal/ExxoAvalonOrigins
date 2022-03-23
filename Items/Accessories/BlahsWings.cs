using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    class BlahsWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah's Wings");
            Tooltip.SetDefault("Allows flight and slow fall and the wearer can run incredibly fast\nThe wearer has a chance to dodge attacks and negates fall damage\nOther various effects");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 4;
            item.rare = 11;
            item.width = dims.Width;
            item.value = Item.sellPrice(2, 0, 0, 0);
            item.accessory = true;
            item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<Placeable.Tile.Phantoplasm>(), 40);
            r.AddIngredient(ModContent.ItemType<Placeable.Bar.SuperhardmodeBar>(), 20);
            r.AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 25);
            r.AddIngredient(ModContent.ItemType<InertiaBoots>());
            r.AddIngredient(ModContent.ItemType<GuardianBoots>());
            r.AddIngredient(ItemID.PhilosophersStone);
            r.AddIngredient(ModContent.ItemType<SouloftheGolem>());
            r.AddIngredient(ModContent.ItemType<ForsakenRelic>());
            r.AddIngredient(ModContent.ItemType<BubbleBoost>());
            r.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            r.SetResult(this);
            r.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().noSticky = true;
            player.pStone = true;
            player.Avalon().bubbleBoost = true;
            player.Avalon().trapImmune =
            player.Avalon().heartGolem =
            player.Avalon().ethHeart =
            player.Avalon().longInvince2 = true;
            player.wingTime = 1000;
            if (player.immune)
            {
                player.AllCrit(7);
                player.allDamage += 0.07f;
            }
            player.accRunSpeed = 10.29f;
            player.rocketBoots = 2;
            player.meleeSpeed += 0.15f;
            player.noFallDmg = true;
            player.blackBelt = true;
            player.iceSkate = true;

            if (player.controlUp && player.controlJump)
            {
                player.velocity.Y = player.velocity.Y - 1f * player.gravDir;
                if (player.gravDir == 1f)
                {
                    if (player.velocity.Y > 0f)
                    {
                        player.velocity.Y = player.velocity.Y - 1f;
                    }
                    else if (player.velocity.Y > -Player.jumpSpeed)
                    {
                        player.velocity.Y = player.velocity.Y - 0.5f;
                    }
                    if (player.velocity.Y < -Player.jumpSpeed * 6f)
                    {
                        player.velocity.Y = -Player.jumpSpeed * 6f;
                    }
                }
                else
                {
                    if (player.velocity.Y < 0f)
                    {
                        player.velocity.Y = player.velocity.Y + 1f;
                    }
                    else if (player.velocity.Y < Player.jumpSpeed)
                    {
                        player.velocity.Y = player.velocity.Y + 0.5f;
                    }
                    if (player.velocity.Y > Player.jumpSpeed * 6f)
                    {
                        player.velocity.Y = Player.jumpSpeed * 6f;
                    }
                }
            }

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
                var newColor2 = default(Color);
                var num2 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Fire, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 100, newColor2, 2f);
                Main.dust[num2].noGravity = true;
            }
            player.wallSpeed += 4.5f;
            player.tileSpeed += 4.5f;
        }
    }
}
