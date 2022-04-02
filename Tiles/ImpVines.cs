﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class Impvines : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileCut[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;
        soundType = SoundID.Grass;
        dustType = DustID.Torch;

        AddMapEntry(new Color(238, 102, 70));
    }

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        Tile tile = Framing.GetTileSafely(i, j + 1);
        if (tile.HasTile && tile.TileType == Type)
        {
            WorldGen.KillTile(i, j + 1);
        }
    }

    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        Tile tileAbove = Framing.GetTileSafely(i, j - 1);
        int type = -1;
        if (tileAbove.HasTile && !tileAbove.bottomSlope())
        {
            type = tileAbove.TileType;
        }

        if (type == ModContent.TileType<Impgrass>() || type == Type)
        {
            return true;
        }

        WorldGen.KillTile(i, j);
        return true;
    }

    public override void RandomUpdate(int i, int j)
    {
        Tile tileBelow = Framing.GetTileSafely(i, j + 1);
        if (WorldGen.genRand.NextBool(15) && !tileBelow.HasTile && !tileBelow.lava())
        {
            bool placeVine = false;
            int yTest = j;
            while (yTest > j - 10)
            {
                Tile testTile = Framing.GetTileSafely(i, yTest);
                if (testTile.bottomSlope())
                {
                    break;
                }
                else if (!testTile.HasTile || testTile.TileType != ModContent.TileType<Impgrass>())
                {
                    yTest--;
                    continue;
                }
                placeVine = true;
                break;
            }
            if (placeVine)
            {
                tileBelow.TileType = Type;
                tileBelow.active(true);
                WorldGen.SquareTileFrame(i, j + 1, true);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendTileSquare(-1, i, j + 1, 3, TileChangeType.None);
                }
            }
        }
    }
    //public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    //{
    //    Tile tile = Framing.GetTileSafely(i, j);

    //    var source = new Rectangle(tile.frameX, tile.frameY, 16, 16);
    //    Rectangle realSource = source;

    //    float xOff = GetOffset(i, j, tile.frameX); //Sin offset.
    //    Vector2 drawPos = ((new Vector2(i, j)) * 16) - Main.screenPosition;

    //    Color col = Lighting.GetColor(i, j, Color.White);
    //    Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange, Main.offScreenRange);

    //    spriteBatch.Draw(ModContent.GetTexture("ExxoAvalonOrigins/Tiles/ImpVines"), drawPos + zero - new Vector2(xOff, 0), realSource, new Color(col.R, col.G, col.B, 255), 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
    //    return false;
    //}
    //public float GetOffset(int i, int j, int frameX, float sOffset = 0f)
    //{
    //    float sin = (float)Math.Sin((Main.time + (i * 24) + (j * 19)) * (0.04f * (!Lighting.NotRetro ? 0f : 1)) + sOffset) * 1.4f;
    //    if (Framing.GetTileSafely(i, j - 1).type != Type) //Adjusts the sine wave offset to make it look nicer when closer to ground
    //        sin *= 0.25f;
    //    else if (Framing.GetTileSafely(i, j - 2).type != Type)
    //        sin *= 0.5f;
    //    else if (Framing.GetTileSafely(i, j - 3).type != Type)
    //        sin *= 0.75f;

    //    return sin;
    //}
}