using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class CrystalBits : ModTile
	{
        public override void SetDefaults()
		{

			AddMapEntry(new Color(152, 13, 121));
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
                ModContent.TileType<CrystalStone>(),
                TileID.CrystalBlock
            };
            TileObjectData.addTile(Type);
            Main.tileSolid[Type] = false;
            soundType = SoundID.Item;
            soundStyle = 27;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            if (Main.tile[i, j].frameY == 0 || Main.tile[i, j].frameY == 54) num = DustID.PurpleCrystalShard;
            else if (Main.tile[i, j].frameY == 18 || Main.tile[i, j].frameY == 72) num = DustID.BlueCrystalShard;
            else if (Main.tile[i, j].frameY == 36 || Main.tile[i, j].frameY == 90) num = DustID.PinkCrystalShard;
        }
        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].frameX / 18)
            {
                case 0:
                case 3:
                    type = DustID.PurpleCrystalShard;
                    break;
                case 1:
                case 4:
                    type = DustID.BlueCrystalShard;
                    break;
                case 2:
                case 5:
                    type = DustID.PinkCrystalShard;
                    break;
            }
            return base.CreateDust(i, j, ref type);
        }
    }
}


