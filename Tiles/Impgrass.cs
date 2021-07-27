using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{
    public class Impgrass : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(238, 102, 70));
            SetModTree(new ResistantTree());
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;            Main.tileBlendAll[Type] = true;            Main.tileMergeDirt[Type] = true;
            drop = ItemID.AshBlock;
        }
    }}