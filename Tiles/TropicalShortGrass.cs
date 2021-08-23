using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class TropicalShortGrass : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileCut[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorValidTiles = new int[1] { ModContent.TileType<TropicalGrass>() };
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            dustType = DustID.Grass;
            soundStyle = 1;
            soundType = SoundID.Grass;
            AddMapEntry(new Color(58, 188, 32));
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            //if (Main.tile[i, j].frameX / 18 == 10)
            //{
            //    Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.ContaminatedMushroom>());
            //}
        }
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 2;
        }
    }
}