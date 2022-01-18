using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class ObsidianLavaTube : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("ObsidianLavaTubeWall");
            AddMapEntry(new Color(51, 47, 96));
            dustType = DustID.Obsidian;
        }
    }
}