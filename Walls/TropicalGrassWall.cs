using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Walls{
    public class TropicalGrassWall : ModWall
    {
        public override void SetDefaults()
        {            AddMapEntry(new Color(35, 76, 0));            soundType = SoundID.Grass;            soundStyle = 1;            dustType = DustID.GrassBlades;
        }
    }}