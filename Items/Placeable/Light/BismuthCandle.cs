using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light
{
    class BismuthCandle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Candle");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Placeable/Light/BismuthCandle");
            item.autoReuse = true;
            item.noWet = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.BismuthCandle>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 99;
            item.useAnimation = 15;
            item.holdStyle = 1;
            item.flame = true;
            item.height = dims.Height;
        }

        //This whole section is just copied from the vanilla code for gold/platinum candles, is it possible to just reuse the vanilla code instead?
        public override void HoldItem(Player player)
        {
            if (!player.wet && !player.pulley)
            {
                int maxValue2 = 20;
                if (player.itemAnimation > 0)
                {
                    maxValue2 = 7;
                }
                if (player.direction == -1)
                {
                    if (Main.rand.Next(maxValue2) == 0)
                    {
                        int num52 = Dust.NewDust(new Vector2(player.itemLocation.X - 12f, player.itemLocation.Y - 20f * player.gravDir), 4, 4, 6, 0f, 0f, 100);
                        if (Main.rand.Next(3) != 0)
                        {
                            Main.dust[num52].noGravity = true;
                        }
                        Main.dust[num52].velocity *= 0.3f;
                        Main.dust[num52].velocity.Y -= 1.5f;
                        Main.dust[num52].position = player.RotatedRelativePoint(Main.dust[num52].position);
                    }
                    Lighting.AddLight(player.RotatedRelativePoint(new Vector2(player.itemLocation.X - 16f + player.velocity.X, player.itemLocation.Y - 14f)), 1f, 0.95f, 0.8f);
                }
                else
                {
                    if (Main.rand.Next(maxValue2) == 0)
                    {
                        int num53 = Dust.NewDust(new Vector2(player.itemLocation.X + 4f, player.itemLocation.Y - 20f * player.gravDir), 4, 4, 6, 0f, 0f, 100);
                        if (Main.rand.Next(3) != 0)
                        {
                            Main.dust[num53].noGravity = true;
                        }
                        Main.dust[num53].velocity *= 0.3f;
                        Main.dust[num53].velocity.Y -= 1.5f;
                        Main.dust[num53].position = player.RotatedRelativePoint(Main.dust[num53].position);
                    }
                    Lighting.AddLight(player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 6f + player.velocity.X, player.itemLocation.Y - 14f)), 1f, 0.95f, 0.8f);
                }
            }
        }
    }
}