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

namespace ExxoAvalonOrigins.Tiles
{
    public class PlacedBars : ModTile
    {
        public override void SetDefaults()
        {
            
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.CoordinatePadding = 2;
            //TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileShine[Type] = 1100;
        }

        // selects the map entry depending on the frameX
        public override ushort GetMapOption(int i, int j)
        {
            return (ushort)(Main.tile[i, j].frameX / 18);
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail)
            {
                return;
            }
            var toDrop = 0;
            switch (Main.tile[i, j].frameX / 18)
            {
                case 0:
                    toDrop = ModContent.ItemType<Items.CaesiumBar>();
					dustType = ModContent.DustType<Dusts.CaesiumDust>();
                    break;
                case 1:
                    toDrop = ModContent.ItemType<Items.OblivionBar>();
					dustType = DustID.Adamantine;
                    break;
                case 2:
                    toDrop = ModContent.ItemType<Items.HydrolythBar>();
					dustType = DustID.MagicMirror;
                    break;
                case 3:
                    toDrop = ModContent.ItemType<Items.RhodiumBar>();
					dustType = DustID.t_LivingWood;
                    break;
                case 4:
                    toDrop = ModContent.ItemType<Items.OsmiumBar>();
					dustType = ModContent.DustType<Dusts.OsmiumDust>();
                    break;
                case 5:
                    toDrop = ModContent.ItemType<Items.FeroziumBar>();
					dustType = DustID.Ultrabright;
                    break;
                case 6:
                    toDrop = ModContent.ItemType<Items.UnvolanditeBar>();
					dustType = DustID.Dirt;
                    break;
                case 7:
                    toDrop = ModContent.ItemType<Items.VorazylcumBar>();
					dustType = DustID.VilePowder;
                    break;
                case 8:
                    toDrop = ModContent.ItemType<Items.TritanoriumBar>();
					dustType = DustID.Stone;
                    break;
                case 9:
                    toDrop = ModContent.ItemType<Items.DurataniumBar>();
					dustType = ModContent.DustType<Dusts.DurataniumDust>();
                    break;
                case 10:
                    toDrop = ModContent.ItemType<Items.NaquadahBar>();
					dustType = ModContent.DustType<Dusts.NaquadahDust>();
                    break;
                case 11:
                    toDrop = ModContent.ItemType<Items.TroxiniumBar>();
					dustType = ModContent.DustType<Dusts.TroxiniumDust>();
                    break;
                case 12:
                    toDrop = ModContent.ItemType<Items.BacciliteBar>();
					dustType = DustID.JungleSpore;
                    break;
                case 13:
                    toDrop = ModContent.ItemType<Items.PyroscoricBar>();
					dustType = DustID.InfernoFork;
                    break;
                case 14:
                    toDrop = ModContent.ItemType<Items.BeetleBar>();
					dustType = DustID.RainCloud;
                    break;
                case 15:
                    toDrop = ModContent.ItemType<Items.SuperhardmodeBar>();
					dustType = DustID.CrimtaneWeapons;
                    break;
                case 16:
                    toDrop = ModContent.ItemType<Items.EnchantedBar>();
                    break;
                case 17:
                    toDrop = ModContent.ItemType<Items.BerserkerBar>();
					dustType = DustID.Ice_Pink;
                    break;
                case 18:
                    toDrop = ModContent.ItemType<Items.BronzeBar>();
					dustType = ModContent.DustType<Dusts.BronzeDust>();
                    break;
                case 19:
                    toDrop = ModContent.ItemType<Items.NickelBar>();
					dustType = ModContent.DustType<Dusts.NickelDust>();
                    break;
                case 20:
                    toDrop = ModContent.ItemType<Items.ZincBar>();
					dustType = ModContent.DustType<Dusts.ZincDust>();
                    break;
                case 21:
                    toDrop = ModContent.ItemType<Items.BismuthBar>();
					dustType = ModContent.DustType<Dusts.BismuthDust>();
                    break;
                case 22:
                    toDrop = ModContent.ItemType<Items.IridiumBar>();
					dustType = ModContent.DustType<Dusts.IridiumDust>();
                    break;
                case 23:
                    toDrop = ModContent.ItemType<Items.Placeable.XanthophyteBar>();
					dustType = DustID.Moss_Yellow;
                    break;
            }
            Item.NewItem(i * 16, j * 16, 16, 16, toDrop);
        }
			
		public override bool CreateDust(int i, int j, ref int type)
		{
			if (Main.tile[i, j].frameX / 18 == 16)
			{
				Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.MagicMirror);
				Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Enchanted_Gold);
				Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Enchanted_Pink);
				return false;
			}
			return base.CreateDust(i, j, ref type);
		}
    }
}