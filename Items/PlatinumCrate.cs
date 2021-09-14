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
	class PlatinumCrate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Crate");
			Tooltip.SetDefault("Right click to open");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/PlatinumCrate");
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.height = dims.Height;
		}

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            var flag4 = true;
            while (flag4)
            {
                if (ExxoAvalonOrigins.superHardmode && flag4 && Main.rand.Next(50) == 0)
                {
                    var number19 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<IllegalWeaponInstructions>(), 1, false, 0, false);
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), number19, 1f, 0f, 0f, 0);
                    }
                    flag4 = false;
                }
                if (Main.rand.Next(7) == 0)
                {
                    int type13;
                    int stack18;
                    if (Main.rand.Next(6) == 0)
                    {
                        type13 = ItemID.PlatinumCoin;
                        stack18 = Main.rand.Next(1, 5);
                    }
                    else
                    {
                        type13 = ItemID.GoldCoin;
                        stack18 = Main.rand.Next(20, 91);
                    }
                    var number20 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type13, stack18, false, 0, false);
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), number20, 1f, 0f, 0f, 0);
                    }
                    flag4 = false;
                }
                if (Main.rand.Next(7) == 0)
                {
                    var num12 = Main.rand.Next(8);
                    if (num12 == 0)
                    {
                        num12 = ItemID.CopperOre;
                    }
                    else if (num12 == 1)
                    {
                        num12 = ItemID.IronOre;
                    }
                    else if (num12 == 2)
                    {
                        num12 = ItemID.SilverOre;
                    }
                    else if (num12 == 3)
                    {
                        num12 = ItemID.GoldOre;
                    }
                    else if (num12 == 4)
                    {
                        num12 = ItemID.TinOre;
                    }
                    else if (num12 == 5)
                    {
                        num12 = ItemID.LeadOre;
                    }
                    else if (num12 == 6)
                    {
                        num12 = ItemID.TungstenOre;
                    }
                    else if (num12 == 7)
                    {
                        num12 = ItemID.PlatinumOre;
                    }
                    if (Main.hardMode && Main.rand.Next(2) == 0)
                    {
                        num12 = Main.rand.Next(6);
                        if (num12 == 0)
                        {
                            num12 = ItemID.CobaltOre;
                        }
                        else if (num12 == 1)
                        {
                            num12 = ItemID.MythrilOre;
                        }
                        else if (num12 == 2)
                        {
                            num12 = ItemID.AdamantiteOre;
                        }
                        else if (num12 == 3)
                        {
                            num12 = ItemID.PalladiumOre;
                        }
                        else if (num12 == 4)
                        {
                            num12 = ItemID.OrichalcumOre;
                        }
                        else if (num12 == 5)
                        {
                            num12 = ItemID.TitaniumOre;
                        }
                    }
                    if (ExxoAvalonOrigins.superHardmode && Main.rand.Next(3) == 0)
                    {
                        num12 = Main.rand.Next(6);
                        if (num12 == 0)
                        {
                            num12 = ModContent.ItemType<OblivionOre>();
                        }
                        else if (num12 == 1)
                        {
                            num12 = ModContent.ItemType<CaesiumOre>();
                        }
                        else if (num12 == 2)
                        {
                            num12 = ModContent.ItemType<SolariumOre>();
                        }
                        else if (num12 == 3)
                        {
                            num12 = ModContent.ItemType<HydrolythOre>();
                        }
                        else if (num12 == 4)
                        {
                            num12 = ModContent.ItemType<Onyx>();
                        }
                        else if (num12 == 5)
                        {
                            num12 = ModContent.ItemType<Opal>();
                        }
                    }
                    var stack19 = Main.rand.Next(15, 35);
                    if (ExxoAvalonOrigins.superHardmode)
                    {
                        stack19 = Main.rand.Next(10, 24);
                    }
                    var number21 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, num12, stack19, false, 0, false);
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), number21, 1f, 0f, 0f, 0);
                    }
                    flag4 = false;
                }
                if (Main.rand.Next(8) == 0)
                {
                    var num13 = Main.rand.Next(8);
                    if (num13 == 0)
                    {
                        num13 = ItemID.CopperBar;
                    }
                    else if (num13 == 1)
                    {
                        num13 = ItemID.IronBar;
                    }
                    else if (num13 == 2)
                    {
                        num13 = ItemID.SilverBar;
                    }
                    else if (num13 == 3)
                    {
                        num13 = ItemID.GoldBar;
                    }
                    else if (num13 == 4)
                    {
                        num13 = ItemID.TinBar;
                    }
                    else if (num13 == 5)
                    {
                        num13 = ItemID.LeadBar;
                    }
                    else if (num13 == 6)
                    {
                        num13 = ItemID.TungstenBar;
                    }
                    else if (num13 == 7)
                    {
                        num13 = ItemID.PlatinumBar;
                    }
                    var num14 = Main.rand.Next(10, 24);
                    if (Main.hardMode && Main.rand.Next(2) == 0)
                    {
                        num13 = Main.rand.Next(6);
                        if (num13 == 0)
                        {
                            num13 = ItemID.CobaltBar;
                        }
                        else if (num13 == 1)
                        {
                            num13 = ItemID.PalladiumBar;
                        }
                        else if (num13 == 2)
                        {
                            num13 = ItemID.MythrilBar;
                        }
                        else if (num13 == 3)
                        {
                            num13 = ItemID.OrichalcumBar;
                        }
                        else if (num13 == 4)
                        {
                            num13 = ItemID.AdamantiteBar;
                        }
                        else if (num13 == 5)
                        {
                            num13 = ItemID.TitaniumBar;
                        }
                        num14 -= Main.rand.Next(2);
                    }
                    if (ExxoAvalonOrigins.superHardmode && Main.rand.Next(2) == 0)
                    {
                        num13 = Main.rand.Next(4);
                        if (num13 == 0)
                        {
                            num13 = ModContent.ItemType<OblivionBar>();
                        }
                        else if (num13 == 1)
                        {
                            num13 = ModContent.ItemType<CaesiumBar>();
                        }
                        else if (num13 == 2)
                        {
                            num13 = ModContent.ItemType<SolariumStar>();
                        }
                        else if (num13 == 3)
                        {
                            num13 = ModContent.ItemType<HydrolythBar>();
                        }
                        num14 -= Main.rand.Next(4);
                    }
                    var number22 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, num13, num14, false, 0, false);
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), number22, 1f, 0f, 0f, 0);
                    }
                    flag4 = false;
                }
                if (Main.rand.Next(7) == 0 && ExxoAvalonOrigins.superHardmode)
                {
                    var num15 = Main.rand.Next(10);
                    if (num15 == 0)
                    {
                        num15 = ModContent.ItemType<ElixirofLife>();
                    }
                    else if (num15 == 1)
                    {
                        num15 = ModContent.ItemType<SuperStaminaPotion>();
                    }
                    else if (num15 == 2)
                    {
                        num15 = ModContent.ItemType<CrimsonPotion>();
                    }
                    else if (num15 == 3)
                    {
                        num15 = ModContent.ItemType<ShockwavePotion>();
                    }
                    else if (num15 == 4)
                    {
                        num15 = ModContent.ItemType<StarbrightPotion>();
                    }
                    else if (num15 == 5)
                    {
                        num15 = ModContent.ItemType<TimeShiftPotion>();
                    }
                    else if (num15 == 6)
                    {
                        num15 = ModContent.ItemType<GPSPotion>();
                    }
                    else if (num15 == 7)
                    {
                        num15 = ModContent.ItemType<DarkMatterGel>();
                    }
                    else if (num15 == 8)
                    {
                        num15 = ModContent.ItemType<Phantoplasm>();
                    }
                    else if (num15 == 9)
                    {
                        num15 = ItemID.TrapsightPotion;
                    }
                    var stack20 = Main.rand.Next(1, 4);
                    if (num15 == ModContent.ItemType<DarkMatterGel>())
                    {
                        stack20 = Main.rand.Next(20, 45);
                    }
                    if (num15 == ModContent.ItemType<Phantoplasm>())
                    {
                        stack20 = 1;
                    }
                    var number23 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, num15, stack20, false, 0, false);
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), number23, 1f, 0f, 0f, 0);
                    }
                    flag4 = false;
                }
            }
            if (Main.hardMode)
            {
                if (Main.rand.Next(3) == 0)
                {
                    var num16 = Main.rand.Next(2);
                    if (num16 == 0)
                    {
                        num16 = ItemID.GreaterHealingPotion;
                    }
                    else if (num16 == 1)
                    {
                        num16 = ItemID.SuperManaPotion;
                    }
                    var stack21 = Main.rand.Next(5, 16);
                    var number24 = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, num16, stack21, false, 0, false);
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.FromLiteral(""), number24, 1f, 0f, 0f, 0);
                        return;
                    }
                }
            }
        }
    }
}