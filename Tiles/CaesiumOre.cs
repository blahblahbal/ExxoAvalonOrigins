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
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles
{
	public class CaesiumOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 5f;
			AddMapEntry(new Color(86, 190, 74), LanguageManager.Instance.GetText("Caesium"));
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 720;
            //Main.tileMerge[Type][TileID.Ash] = true;
            //Main.tileMerge[TileID.Ash][Type] = true;
            drop = mod.ItemType("CaesiumOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 200;
            ExxoAvalonOrigins.MergeWith(Type, TileID.Ash);
            ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<Impgrass>());
            dustType = ModContent.DustType<Dusts.CaesiumDust>();
            //ExxoAvalonOrigins.MergeWith(TileID.Ash, Type);
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, TileID.Ash, false, false, false, false, resetFrame);
            return false;
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (j > Main.maxTilesY - 190 && i > (Main.maxTilesX - Main.maxTilesX / 5))
            {
                if (Main.tile[i, j].active() && !Main.tile[i, j - 1].active() ||
                    Main.tile[i, j].active() && !Main.tile[i, j + 1].active() ||
                    Main.tile[i, j].active() && !Main.tile[i - 1, j].active() ||
                    Main.tile[i, j].active() && !Main.tile[i + 1, j].active())
                {
                    if (Main.rand.Next(7000) == 0)
                    {
                        Projectile.NewProjectile(new Vector2(i, j) * 16, new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f)), ModContent.ProjectileType<Projectiles.CaesiumGas>(), 0, 0);
                    }
                }
            }
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (j > Main.maxTilesY - 190 && i > (Main.maxTilesX - Main.maxTilesX / 5))
            {
                if (Main.rand.Next(27) == 0)
                {
                    int proj = Projectile.NewProjectile(new Vector2(i, j) * 16, new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f)), ModContent.ProjectileType<Projectiles.CaesiumGas>(), 0, 0);
                }
            }
        }
    }
}
