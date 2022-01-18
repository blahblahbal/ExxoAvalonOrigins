using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class Beak : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry((Color.DarkOrange), LanguageManager.Instance.GetText("Beak"));
            Main.tileSolid[Type] = true;
            drop = mod.ItemType("Beak");
            soundType = SoundID.NPCHit;
            soundStyle = 2;
        }
    }
}