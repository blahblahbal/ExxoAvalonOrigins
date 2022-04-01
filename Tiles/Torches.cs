using ExxoAvalonOrigins.Items.Placeable.Light;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class Torches : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = new[] { 124 };
            TileObjectData.addAlternate(1);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = new[] { 124 };
            TileObjectData.addAlternate(2);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.AnchorWall = true;
            TileObjectData.addAlternate(0);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AddMapEntry(new Color(200, 200, 200));
            dustType = DustID.JungleSpore;
            //disableSmartCursor = true;
            adjTiles = new int[] { TileID.Torches };
            torch = true;
        }

        public override bool Drop(int i, int j)
        {
            var style = Main.tile[i, j].TileFrameY / 22;
            int toDrop = ItemID.Torch;

            switch (style)
            {
                case 0:
                    toDrop = ModContent.ItemType<JungleTorch>();
                    break;
                case 1:
                    toDrop = ModContent.ItemType<PathogenTorch>();
                    break;
                case 2:
                    toDrop = ModContent.ItemType<SlimeTorch>();
                    break;
                case 3:
                    toDrop = ModContent.ItemType<CyanTorch>();
                    break;
                case 4:
                    toDrop = ModContent.ItemType<LimeTorch>();
                    break;
                case 5:
                    toDrop = ModContent.ItemType<BrownTorch>();
                    break;
            }
            Item.NewItem(i * 16, j * 16, 0, 0, toDrop);
            return false;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = Main.rand.Next(1, 3);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            var tile = Main.tile[i, j];
            if (tile.TileFrameX < 66)
            {
                int style = Main.tile[i, j].TileFrameY / 18;
                switch (style)
                {
                    case 0:
                        r = 0.15f;
                        g = 1.28249991f;
                        b = 0.52f;
                        break;
                    case 1:
                        r = 0.5882353f;
                        g = 1f;
                        b = 0.368627459f;
                        break;
                    case 2:
                        r = 0.25f;
                        g = 0.7f;
                        b = 1f;
                        break;
                    case 3:
                        r = 0f;
                        g = 2f;
                        b = 2f;
                        break;
                    case 4:
                        r = 1.427451f;
                        g = 2f;
                        b = 0f;
                        break;
                    case 5:
                        r = 1.51372552f;
                        g = 1.16078436f;
                        b = 0.9254902f;
                        break;
                    default:
                        r = 1f;
                        g = 0.95f;
                        b = 0.8f;
                        break;
                }
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 0;
            if (WorldGen.InWorld(i, j - 1) && WorldGen.SolidTile(i, j - 1))
            {
                offsetY = 2;
                if (WorldGen.InWorld(i - 1, j + 1) && WorldGen.SolidTile(i - 1, j + 1) || WorldGen.InWorld(i + 1, j + 1) && WorldGen.SolidTile(i + 1, j + 1))
                {
                    offsetY = 4;
                }
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            var randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)((ulong)i));
            var color = new Color(100, 100, 100, 0);
            int frameX = Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;
            var width = 20;
            var offsetY = 0;
            var height = 20;
            if (WorldGen.SolidTile(i, j - 1))
            {
                offsetY = 2;
                if (WorldGen.SolidTile(i - 1, j + 1) || WorldGen.SolidTile(i + 1, j + 1))
                {
                    offsetY = 4;
                }
            }
            var zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            for (var k = 0; k < 7; k++)
            {
                var x = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                var y = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
                Main.spriteBatch.Draw(Mod.Assets.Request<Texture2D>("Tiles/Torches_Flame").Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + x, j * 16 - (int)Main.screenPosition.Y + offsetY + y) + zero, new Rectangle(frameX, frameY, width, height), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            var style = Main.tile[i, j].TileFrameY / 22;

            switch (style)
            {
                case 0:
                    player.showItemIcon2 = ModContent.ItemType<JungleTorch>();
                    break;
                case 1:
                    player.showItemIcon2 = ModContent.ItemType<PathogenTorch>();
                    break;
                case 2:
                    player.showItemIcon2 = ModContent.ItemType<SlimeTorch>();
                    break;
                case 3:
                    player.showItemIcon2 = ModContent.ItemType<CyanTorch>();
                    break;
                case 4:
                    player.showItemIcon2 = ModContent.ItemType<LimeTorch>();
                    break;
                case 5:
                    player.showItemIcon2 = ModContent.ItemType<BrownTorch>();
                    break;
            }
        }
    }
}
