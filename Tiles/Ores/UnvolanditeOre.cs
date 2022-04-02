﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class UnvolanditeOre : ModTile
{
    public override void SetStaticDefaults()
    {
        mineResist = 8f;
        AddMapEntry(new Color(78, 79, 41), LanguageManager.Instance.GetText("Unvolandite"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileValue[Type] = 840;
        Main.tileBlockLight[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 2100;
        drop = Mod.Find<ModItem>("UnvolanditeOre").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        minPick = 250;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (j > Main.rockLayer)
        {
            if (Main.rand.Next(5500) == 0 && Vector2.Distance(Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].position, new Vector2(i * 16, j * 16)) < 12 * 16)
            {
                NPC.NewNPC(i * 16, j * 16, ModContent.NPCType<NPCs.UnvolanditeMiteDigger>());
            }
        }
    }
}