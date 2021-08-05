using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Walls{
    public class ContagionNaturalWall1 : ModWall
    {
        public override void SetDefaults()
        {            AddMapEntry(new Color(57, 55, 12));
            WallID.Sets.Conversion.Sandstone[Type] = true;
        }
    }}