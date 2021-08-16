﻿using Microsoft.Xna.Framework;
    public class SpiritPoppy : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(0, 0, 200), LanguageManager.Instance.GetText("Spirit Poppy"));
            TileObjectData.addTile(Type);
            Main.tileObsidianKill[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
        }