using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Walls{
    public class ContagionGrassWall : ModWall
    {
        public override void SetDefaults()
        {            AddMapEntry(new Color(82, 91, 69));
            soundType = SoundID.Grass;
            soundStyle = 1;
            WallID.Sets.Conversion.Grass[base.Type] = true;
        }
    }}