using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class Snotsand : ModTile	{		public override void SetDefaults()		{			AddMapEntry(new Color(136, 157, 56));			Main.tileSolid[Type] = true;			Main.tileBlockLight[Type] = true;            Main.tileMergeDirt[Type] = true;
			//Merge with Sand
			Main.tileMerge[Type][TileID.Sand] = true;
			Main.tileMerge[TileID.Sand][Type] = true;
			//Merge with Ebonsand
			Main.tileMerge[Type][TileID.Ebonsand] = true;
			Main.tileMerge[TileID.Ebonsand][Type] = true;
			//Merge with Crimsand
			Main.tileMerge[Type][TileID.Crimsand] = true;
			Main.tileMerge[TileID.Crimsand][Type] = true;
			//Merge with Pearlsand
			Main.tileMerge[Type][TileID.Pearlsand] = true;
			Main.tileMerge[TileID.Pearlsand][Type] = true;
			Main.tileSand[Type] = true;
			TileID.Sets.TouchDamageSands[Type] = 15;
			TileID.Sets.Conversion.Sand[Type] = true;
			TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true;
			TileID.Sets.Falling[Type] = true;			drop = mod.ItemType("SnotsandBlock");            dustType = 184;
        }		//public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
		//{
		//	if (WorldGen.noTileActions)
		//		return true;

		//	Tile above = Main.tile[i, j - 1];
		//	Tile below = Main.tile[i, j + 1];
		//	bool canFall = true;

		//	if (below == null || below.active())
		//		canFall = false;

		//	if (above.active() && (TileID.Sets.BasicChest[above.type] || TileID.Sets.BasicChestFake[above.type] || above.type == TileID.PalmTree || TileLoader.IsDresser(above.type)))
		//		canFall = false;

		//	if (canFall)
		//	{
		//		int projectileType = ModContent.ProjectileType<Projectiles.SnotsandBall>();
		//		float positionX = i * 16 + 8;
		//		float positionY = j * 16 + 8;

		//		if (Main.netMode == NetmodeID.SinglePlayer)
		//		{
		//			Main.tile[i, j].ClearTile();
		//			int proj = Projectile.NewProjectile(positionX, positionY, 0f, 0.41f, projectileType, 10, 0f, Main.myPlayer);
		//			Main.projectile[proj].ai[0] = 1f;
		//			WorldGen.SquareTileFrame(i, j);
		//		}
		//		else if (Main.netMode == NetmodeID.Server)
		//		{
		//			Main.tile[i, j].active(false);
		//			bool spawnProj = true;

		//			for (int k = 0; k < 1000; k++)
		//			{
		//				Projectile otherProj = Main.projectile[k];

		//				if (otherProj.active && otherProj.owner == Main.myPlayer && otherProj.type == projectileType && Math.Abs(otherProj.timeLeft - 3600) < 60 && otherProj.Distance(new Vector2(positionX, positionY)) < 4f)
		//				{
		//					spawnProj = false;
		//					break;
		//				}
		//			}

		//			if (spawnProj)
		//			{
		//				int proj = Projectile.NewProjectile(positionX, positionY, 0f, 2.5f, projectileType, 10, 0f, Main.myPlayer);
		//				Main.projectile[proj].velocity.Y = 0.5f;
		//				Main.projectile[proj].position.Y += 2f;
		//				Main.projectile[proj].netUpdate = true;
		//			}

		//			NetMessage.SendTileSquare(-1, i, j, 1);
		//			WorldGen.SquareTileFrame(i, j);
		//		}
		//		return false;
		//	}
		//	return true;
		//}
		public override bool HasWalkDust()
		{
			return Main.rand.Next(3) == 0;
		}
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;	}}