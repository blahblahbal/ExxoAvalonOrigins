using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class Omnibag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omnibag");
            Tooltip.SetDefault("A lot of particles cover you when you move");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Omnibag");
            item.rare = 7;
            item.width = dims.Width;
            item.accessory = true;
            item.vanity = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().updateInvisibleVanity = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BagofIck>());
            recipe.AddIngredient(ModContent.ItemType<BagofBlood>());
            recipe.AddIngredient(ModContent.ItemType<BagofShadows>());
            recipe.AddIngredient(ModContent.ItemType<BagofHallows>());
            recipe.AddIngredient(ModContent.ItemType<BagofFrost>());
            recipe.AddIngredient(ModContent.ItemType<BagofFire>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.controlRight)
            {
                int dust = Dust.NewDust(player.position, player.width - 20, player.height, 6, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width - 20, player.height, 27, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width - 20, player.height, 57, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                int dust3 = Dust.NewDust(player.position, player.width - 20, player.height, 182, 0, 0, 100, Color.White, .9f);
                Main.dust[dust3].noGravity = true;
                int dust2 = Dust.NewDust(player.position, player.width - 20, player.height, 5, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                dust = Dust.NewDust(player.position, player.width - 20, player.height, 18, 0, 0, 100, Color.White, .9f);
                Main.dust[dust].noGravity = true;
                dust2 = Dust.NewDust(player.position, player.width - 20, player.height, 18, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                for (int num126 = 0; num126 < 4; num126++)
                {
                    float num127 = player.velocity.X / 3f * (float)num126;
                    float num128 = player.velocity.Y / 3f * (float)num126;
                    int num129 = 4;
                    int num130 = Dust.NewDust(new Vector2(player.position.X + (float)num129, player.position.Y + (float)num129), player.width - num129 * 2, player.height - num129 * 2, 135, 0f, 0f, 100, default(Color), 1.8f);
                    Main.dust[num130].noGravity = true;
                    Main.dust[num130].velocity *= 0.1f;
                    Main.dust[num130].velocity += player.velocity * 0.1f;
                    Main.dust[num130].position.X -= num127;
                    Main.dust[num130].position.Y -= num128;
                }
                if (Main.rand.Next(3) == 0)
                {
                    int num131 = 4;
                    int num132 = Dust.NewDust(new Vector2(player.position.X + (float)num131, player.position.Y + (float)num131), player.width - num131 * 2, player.height - num131 * 2, 15, 0f, 0f, 100, default(Color), 0.6f);
                    Main.dust[num132].noGravity = true;
                    Main.dust[num132].velocity *= 0.25f;
                    Main.dust[num132].velocity += player.velocity * 0.5f;
                }
            }
            if (player.controlLeft)
            {
                int dust = Dust.NewDust(player.position, player.width + 20, player.height, 6, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height, 27, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height, 57, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                int dust3 = Dust.NewDust(player.position, player.width + 20, player.height, 182, 0, 0, 100, Color.White, .9f);
                Main.dust[dust3].noGravity = true;
                int dust2 = Dust.NewDust(player.position, player.width + 20, player.height, 5, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height, 18, 0, 0, 100, Color.White, .9f);
                Main.dust[dust].noGravity = true;
                dust2 = Dust.NewDust(player.position, player.width + 20, player.height, 18, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                for (int num126 = 0; num126 < 4; num126++)
                {
                    float num127 = player.velocity.X / 3f * (float)num126;
                    float num128 = player.velocity.Y / 3f * (float)num126;
                    int num129 = 4;
                    int num130 = Dust.NewDust(new Vector2(player.position.X + (float)num129, player.position.Y + (float)num129), player.width - num129 * 2, player.height - num129 * 2, 135, 0f, 0f, 100, default(Color), 1.8f);
                    Main.dust[num130].noGravity = true;
                    Main.dust[num130].velocity *= 0.1f;
                    Main.dust[num130].velocity += player.velocity * 0.1f;
                    Main.dust[num130].position.X -= num127;
                    Main.dust[num130].position.Y -= num128;
                }
                if (Main.rand.Next(3) == 0)
                {
                    int num131 = 4;
                    int num132 = Dust.NewDust(new Vector2(player.position.X + (float)num131, player.position.Y + (float)num131), player.width - num131 * 2, player.height - num131 * 2, 15, 0f, 0f, 100, default(Color), 0.6f);
                    Main.dust[num132].noGravity = true;
                    Main.dust[num132].velocity *= 0.25f;
                    Main.dust[num132].velocity += player.velocity * 0.5f;
                }
            }
            if (player.controlJump)
            {
                int dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, 6, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, 27, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, 57, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                int dust3 = Dust.NewDust(player.position, player.width + 20, player.height + 20, 182, 0, 0, 100, Color.White, .9f);
                Main.dust[dust3].noGravity = true;
                int dust2 = Dust.NewDust(player.position, player.width + 20, player.height + 20, 5, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, 18, 0, 0, 100, Color.White, .9f);
                Main.dust[dust].noGravity = true;
                dust2 = Dust.NewDust(player.position, player.width + 20, player.height + 20, 18, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                dust = Dust.NewDust(player.position, player.width - 20, player.height, 135, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
            }
        }        public override void UpdateVanity(Player player, EquipType type)        {
            if (player.controlRight)
            {
                int dust = Dust.NewDust(player.position, player.width - 20, player.height, 6, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width - 20, player.height, 27, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width - 20, player.height, 57, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                int dust3 = Dust.NewDust(player.position, player.width - 20, player.height, 182, 0, 0, 100, Color.White, .9f);
                Main.dust[dust3].noGravity = true;
                int dust2 = Dust.NewDust(player.position, player.width - 20, player.height, 5, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                dust = Dust.NewDust(player.position, player.width - 20, player.height, 18, 0, 0, 100, Color.White, .9f);
                Main.dust[dust].noGravity = true;
                dust2 = Dust.NewDust(player.position, player.width - 20, player.height, 18, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                for (int num126 = 0; num126 < 4; num126++)
                {
                    float num127 = player.velocity.X / 3f * (float)num126;
                    float num128 = player.velocity.Y / 3f * (float)num126;
                    int num129 = 4;
                    int num130 = Dust.NewDust(new Vector2(player.position.X + (float)num129, player.position.Y + (float)num129), player.width - num129 * 2, player.height - num129 * 2, 135, 0f, 0f, 100, default(Color), 1.8f);
                    Main.dust[num130].noGravity = true;
                    Main.dust[num130].velocity *= 0.1f;
                    Main.dust[num130].velocity += player.velocity * 0.1f;
                    Main.dust[num130].position.X -= num127;
                    Main.dust[num130].position.Y -= num128;
                }
                if (Main.rand.Next(3) == 0)
                {
                    int num131 = 4;
                    int num132 = Dust.NewDust(new Vector2(player.position.X + (float)num131, player.position.Y + (float)num131), player.width - num131 * 2, player.height - num131 * 2, 15, 0f, 0f, 100, default(Color), 0.6f);
                    Main.dust[num132].noGravity = true;
                    Main.dust[num132].velocity *= 0.25f;
                    Main.dust[num132].velocity += player.velocity * 0.5f;
                }
            }
            if (player.controlLeft)
            {
                int dust = Dust.NewDust(player.position, player.width + 20, player.height, 6, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height, 27, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height, 57, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                int dust3 = Dust.NewDust(player.position, player.width + 20, player.height, 182, 0, 0, 100, Color.White, .9f);
                Main.dust[dust3].noGravity = true;
                int dust2 = Dust.NewDust(player.position, player.width + 20, player.height, 5, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height, 18, 0, 0, 100, Color.White, .9f);
                Main.dust[dust].noGravity = true;
                dust2 = Dust.NewDust(player.position, player.width + 20, player.height, 18, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                for (int num126 = 0; num126 < 4; num126++)
                {
                    float num127 = player.velocity.X / 3f * (float)num126;
                    float num128 = player.velocity.Y / 3f * (float)num126;
                    int num129 = 4;
                    int num130 = Dust.NewDust(new Vector2(player.position.X + (float)num129, player.position.Y + (float)num129), player.width - num129 * 2, player.height - num129 * 2, 135, 0f, 0f, 100, default(Color), 1.8f);
                    Main.dust[num130].noGravity = true;
                    Main.dust[num130].velocity *= 0.1f;
                    Main.dust[num130].velocity += player.velocity * 0.1f;
                    Main.dust[num130].position.X -= num127;
                    Main.dust[num130].position.Y -= num128;
                }
                if (Main.rand.Next(3) == 0)
                {
                    int num131 = 4;
                    int num132 = Dust.NewDust(new Vector2(player.position.X + (float)num131, player.position.Y + (float)num131), player.width - num131 * 2, player.height - num131 * 2, 15, 0f, 0f, 100, default(Color), 0.6f);
                    Main.dust[num132].noGravity = true;
                    Main.dust[num132].velocity *= 0.25f;
                    Main.dust[num132].velocity += player.velocity * 0.5f;
                }
            }
            if (player.controlJump)
            {
                int dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, 6, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, 27, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, 57, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
                int dust3 = Dust.NewDust(player.position, player.width + 20, player.height + 20, 182, 0, 0, 100, Color.White, .9f);
                Main.dust[dust3].noGravity = true;
                int dust2 = Dust.NewDust(player.position, player.width + 20, player.height + 20, 5, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                dust = Dust.NewDust(player.position, player.width + 20, player.height + 20, 18, 0, 0, 100, Color.White, .9f);
                Main.dust[dust].noGravity = true;
                dust2 = Dust.NewDust(player.position, player.width + 20, player.height + 20, 18, 0, 0, 100, Color.White, 1.5f);
                Main.dust[dust2].noGravity = true;
                dust = Dust.NewDust(player.position, player.width - 20, player.height, 135, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
            }
        }
    }}