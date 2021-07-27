using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Walls{
    public class ImperviousBrickWallUnsafe : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = false;
            drop = mod.ItemType("ImperviousBrickWall");
        }
    }}