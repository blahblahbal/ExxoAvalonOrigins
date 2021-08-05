using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class HallowedAltar : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(255, 216, 0));
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                18
            };
            TileObjectData.addTile(Type);
            Main.tileHammer[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
		}

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            var brightness = Main.rand.Next(-5, 6) * 0.0025f;
            r = 1f + brightness;
            g = 0.9f + brightness * 2f;
            b = 0f;
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            blockDamaged = false;
            return ExxoAvalonOrigins.superHardmode;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {   
            //TODO: Add SmashHallowAltar
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.Next(80) == 1)
            {
                int num162 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.HallowedWeapons, 0f, 0f, 0, default(Color), 1.5f);
                Main.dust[num162].noGravity = true;
                Main.dust[num162].velocity *= 1f;
            }
        }
    }
}