using Microsoft.Xna.Framework;using Terraria;using Terraria.ID;using Terraria.ModLoader;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{
    public class LibraryAltar : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            //TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(Color.Gray);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.LibraryAltar>());
        }
    }}