using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Walls
{
    public class NestWall : ModWall
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(130, 113, 96));
            dustType = DustID.MarblePot;
        }
    }
}