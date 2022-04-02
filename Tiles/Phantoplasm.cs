using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Tiles;

public class Phantoplasm : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.Red);
        Main.tileSolid[Type] = true;
        drop = Mod.Find<ModItem>("Phantoplasm").Type;
        dustType = DustID.TheDestoryer;
    }
    public override bool KillSound(int i, int j)
    {
        if (Main.rand.Next(10) == 0) SoundEngine.PlaySound(SoundID.NPCKilled, i * 16, j * 16, 6);
        return true;
    }
}