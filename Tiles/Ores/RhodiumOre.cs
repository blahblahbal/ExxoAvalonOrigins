using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores
{
    public class RhodiumOre : ModTile
    {
        public override void SetDefaults()
        {
            mineResist = 2f;
            AddMapEntry(new Color(142, 91, 91), LanguageManager.Instance.GetText("Rhodium"));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 420;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1150;
            drop = mod.ItemType("RhodiumOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 60;
            dustType = DustID.t_LivingWood;
        }
    }
}
