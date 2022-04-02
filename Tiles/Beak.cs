using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class Beak : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry((Color.DarkOrange), LanguageManager.Instance.GetText("Beak"));
        Main.tileSolid[Type] = true;
        ItemDrop = Mod.Find<ModItem>("Beak").Type;
        SoundType = SoundID.NPCHit;
        SoundStyle = 2;
    }
}
