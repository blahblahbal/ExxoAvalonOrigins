using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class ResistantWood : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(50, 50, 50));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            drop = Mod.Find<ModItem>("ResistantWood").Type;
            dustType = DustID.Wraith;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}