using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class PoisonSpike : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(95, 95, 36), LanguageManager.Instance.GetText("Poison Spike"));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = Mod.Find<ModItem>("PoisonSpike").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Grass;
        }
    }
}