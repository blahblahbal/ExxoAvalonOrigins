using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles
{
    public class HerbologyBench : ModTile
    {
        public override void SetDefaults()
        {
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
			TileID.Sets.HasOutlines[Type] = true;
            Main.tileFrameImportant[Type] = true;
            AddMapEntry(new Color(153, 77, 86), LanguageManager.Instance.GetText("Herbology Bench"));
			disableSmartCursor = true;
        }
		
		public override bool HasSmartInteract()
		{
			return true;
		}

        public override bool NewRightClick(int i, int j)
        {
            Main.playerInventory = true;
            if (Main.netMode != NetmodeID.Server) Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb = !Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb;
            Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbX = Player.tileTargetX;
            Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbY = Player.tileTargetY;
            Main.mouseRightRelease = false;
            if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb) Main.PlaySound(10, -1, -1, 1);
            else Main.PlaySound(11, -1, -1, 1);
            return true;
        }

        //public override void RightClick(int i, int j)
        //{
        //    Main.playerInventory = true;
        //    ExxoAvalonOrigins.herb = !ExxoAvalonOrigins.herb;
        //    if (ExxoAvalonOrigins.herb)
        //    {
        //        Main.PlaySound(10, -1, -1, 1);
        //    }
        //    else
        //    {
        //        Main.PlaySound(11, -1, -1, 1);
        //        Main.player[Main.myPlayer].dropItemCheck();
        //    }
        //}
        public override void MouseOver(int i, int j)
        {
            var player = Main.player[Main.myPlayer];
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ModContent.ItemType<Items.HerbologyBench>();
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 64, 32, ModContent.ItemType<Items.HerbologyBench>());
        }
    }
}