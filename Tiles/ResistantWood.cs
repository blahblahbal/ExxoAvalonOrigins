using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Terraria.Localization;namespace ExxoAvalonOrigins.Tiles{
    public class ResistantWood : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(50, 50, 50));            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;            Main.tileSpelunker[Type] = true;            drop = mod.ItemType("ResistantWood");        }
    }}