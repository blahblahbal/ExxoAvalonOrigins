using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles{	public class Catalyzer : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(146, 155, 187), LanguageManager.Instance.GetText("Catalyzer"));            Main.tileFrameImportant[Type] = true;
            animationFrameHeight = 38;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.LavaDeath = false;			TileObjectData.addTile(Type);			Main.tileLighted[Type] = true;            dustType = DustID.Stone;		}        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 4)
            {
                frameCounter = 0;
                frame++;
                if (frame >= 12) frame = 0;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)		{   			Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<Items.Catalyzer>());		}	}}