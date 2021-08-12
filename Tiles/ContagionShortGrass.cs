using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class ContagionShortGrass : ModTile
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
            dustType = 184;
            soundStyle = 1;
            soundType = 6;
            AddMapEntry(new Color(147, 166, 42));
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (Main.tile[i, j].frameX / 18 == 10)
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.ContaminatedMushroom>());
            }
        }
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 2;
        }
        //public override void PlaceInWorld(int i, int j, Item item)
        //{
        //    Main.tile[i, j].frameX = (short)(Main.rand.Next(0, 8) * 18);
        //}
    }
}