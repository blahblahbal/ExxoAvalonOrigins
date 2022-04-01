using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class VenomSpike : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(132, 65, 172), LanguageManager.Instance.GetText("Venom Spike"));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = Mod.Find<ModItem>("VenomSpike").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = ModContent.DustType<Dusts.BismuthDust>();
        }
        public override bool Slope(int i, int j)
        {
            return false;
        }
    }
}