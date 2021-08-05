using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Walls{
    public class ContagionNaturalWall2 : ModWall
    {
        public override void SetDefaults()
        {            AddMapEntry(new Color(81, 86, 47));
            WallID.Sets.Conversion.HardenedSand[Type] = true;
        }
    }}