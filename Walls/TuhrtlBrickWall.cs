using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Walls{
    public class TuhrtlBrickWall : ModWall
    {
        public override void SetDefaults()
        {            AddMapEntry(new Color(39, 31, 28));
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("TuhrtlBrickWall");
            dustType = 1;
        }
    }}