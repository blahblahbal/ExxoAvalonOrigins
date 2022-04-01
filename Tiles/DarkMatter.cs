using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class DarkMatter : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(135, 15, 170));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = Mod.Find<ModItem>("DarkMatterBlock").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = ModContent.DustType<Dusts.DarkMatterDust>();
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail)
            {
                ExxoAvalonOriginsWorld.WorldDarkMatterTiles--;
            }
            base.KillTile(i, j, ref fail, ref effectOnly, ref noItem);
        }
    }
}