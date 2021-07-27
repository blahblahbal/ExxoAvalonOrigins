using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Items
{
	class RedPresent : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Present");
			Tooltip.SetDefault("Right click to open");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/RedPresent");
			item.consumable = true;
			item.rare = 3;
			item.width = dims.Width;
			item.maxStack = 999;
			item.height = dims.Height;
		}

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.rand.Next(25) == 0 && Main.hardMode)
            {
                int number = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<SackofToys>(), 1, false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(30) == 0)
            {
                int number = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<SantasBeard>(), 1, false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(70) == 0)
            {
                int number2 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<ChristmasTome>(), 1, false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number2, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(10) == 0)
            {
                int number2 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<CandyCane2>(), Main.rand.Next(5, 10), false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number2, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(20) == 0)
            {
                int number2 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.Coal, Main.rand.Next(5, 13), false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number2, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(50) == 0)
            {
                int number3 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<PlatinumCrate>(), 1, false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number3, 1f, 0f, 0f, 0);
                }
                number3 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.GoldCoin, Main.rand.Next(30, 61), false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number3, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(42) == 0)
            {
                int number4 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.ElfHat, 1, false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number4, 1f, 0f, 0f, 0);
                }
                number4 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.ElfShirt, 1, false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number4, 1f, 0f, 0f, 0);
                }
                number4 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.ElfPants, 1, false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number4, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(40) == 0)
            {
                int number4 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<FrostySpectacle>(), 1, false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number4, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(20) == 0)
            {
                int number4 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<FrostShard>(), Main.rand.Next(5, 14), false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number4, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(10) == 0)
            {
                int x = Main.rand.Next(3);
                int item = 0;
                if (x == 0)
                {
                    item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<ChocolateCandyCaneBlock>(), Main.rand.Next(30, 61), false, 0, false);
                }
                else if (x == 1)
                {
                    item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.GreenCandyCaneBlock, Main.rand.Next(30, 61), false, 0, false);
                }
                else if (x == 2)
                {
                    item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.CandyCaneBlock, Main.rand.Next(30, 61), false, 0, false);
                }
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), item, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(9) == 0)
            {
                int number4 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.SilverCoin, Main.rand.Next(30, 71), false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number4, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else if (Main.rand.Next(7) == 0)
            {
                int number4 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.PineTreeBlock, Main.rand.Next(30, 71), false, 0, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), number4, 1f, 0f, 0f, 0);
                    return;
                }
            }
            else
            {
                int x = Main.rand.Next(4);
                int item = 0;
                if (x == 0)
                {
                    item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<StaminaPotion>(), Main.rand.Next(2, 4), false, 0, false);
                }
                else if (x == 1)
                {
                    item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.HealingPotion, Main.rand.Next(2, 4), false, 0, false);
                }
                else if (x == 2)
                {
                    item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ItemID.ManaPotion, Main.rand.Next(2, 4), false, 0, false);
                }
                else if (x == 3)
                {
                    int y = Main.rand.Next(30);
                    if (y < 15)
                    {
                        item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<CrimsonPotion>(), Main.rand.Next(2, 4), false, 0, false);
                    }
                    else if (y >= 15 && y <= 28)
                    {
                        item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<ShockwavePotion>(), Main.rand.Next(2, 4), false, 0, false);
                    }
                    else item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<CrystalEdge>(), 1, false, 0, false);
                }
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, NetworkText.FromLiteral(""), item, 1f, 0f, 0f, 0);
                    return;
                }
            }
        }
    }
}