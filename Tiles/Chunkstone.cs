using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class Chunkstone : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(48, 53, 42));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        TileID.Sets.Conversion.Stone[Type] = true;
        Main.tileMerge[Type][TileID.SnowBlock] = true;
        Main.tileMerge[TileID.SnowBlock][Type] = true;
        Main.tileMerge[Type][TileID.Ebonstone] = true;
        Main.tileMerge[TileID.Ebonstone][Type] = true;
        Main.tileMerge[Type][TileID.Crimstone] = true;
        Main.tileMerge[TileID.Crimstone][Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[TileID.Stone][Type] = true;
        Main.tileMerge[Type][TileID.Mud] = true;
        Main.tileMerge[TileID.Mud][Type] = true;
        ItemDrop = Mod.Find<ModItem>("ChunkstoneBlock").Type;
        SoundType = SoundID.Tink;
        SoundStyle = 1;
        MinPick = 60;
        DustType = ModContent.DustType<Dusts.ContagionDust>();
    }
}
