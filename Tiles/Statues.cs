using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.World.Generation;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles
{
    public class Statues : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(144, 148, 144), Language.GetText("MapObject.Statue"));
            name.SetDefault("Sculpture");
			AddMapEntry(new Color(175, 216, 235), name);
			AddMapEntry(new Color(201, 188, 170), Language.GetText("MapObject.Vase"));
			AddMapEntry(new Color(13, 47, 84));
			dustType = DustID.Stone;
            disableSmartCursor = true;
        }
		
		public override ushort GetMapOption(int i, int j)
		{
			switch (Main.tile[i, j].frameX / 36)
			{
				case 2:
				case 9:
				case 10:
				return 1;
				break;
				
				case 3:
				return 2;
				break;
				
				case 6:
				return 3;
				break;
			}
			return 0;
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameX / 36)
            {
                case 0:
                    item = ModContent.ItemType<Items.ShellStatue>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.DNAStatue>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.IceSculpture>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.OrangeDungeonVase>();
                    break;
                case 4:
                    item = ModContent.ItemType<Items.TomeStatue>();
                    break;
                case 5:
                    item = ModContent.ItemType<Items.HallowStatue>();
                    break;
                case 6:
                    item = ModContent.ItemType<Items.BlueLihzahrdStatue>();
                    break;
                case 7:
                    item = ModContent.ItemType<Items.ContagionStatue>();
                    break;
                case 8:
                    item = ModContent.ItemType<Items.CrimsonStatue>();
                    break;
                case 9:
                    item = ModContent.ItemType<Items.AngelSculpture>();
                    break;
                case 10:
                    item = ModContent.ItemType<Items.DNASculpture>();
                    break;
            }
            if (item > 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, item);
            }
        }
		
		public override bool CreateDust(int i, int j, ref int type)
		{
			switch (Main.tile[i, j].frameX / 36)
			{
				case 2:
				case 9:
				case 10:
					Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Ice);
				return false;
				break;
				case 3:
					Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Coralstone);
				return false;
				break;
				case 6:
					Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.t_Granite);
				return false;
				break;
			}
			return base.CreateDust(i, j, ref type);
		}
    }
    //public class ExampleStatueItem : ModItem
    //{
    //    public override void SetStaticDefaults()
    //    {
    //        DisplayName.SetDefault("Golden Fish Statue");
    //    }

    //    public override void SetDefaults()
    //    {
    //        item.CloneDefaults(ItemID.ArmorStatue);
    //        item.createTile = ModContent.TileType<ExampleStatue>();
    //        item.placeStyle = 0;
    //    }
    //}

    public class ExampleStatueModWorld : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ResetIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Reset"));
            if (ResetIndex != -1)
            {
                tasks.Insert(ResetIndex + 1, new PassLegacy("Avalon Statue Setup", delegate (GenerationProgress progress) {
                    progress.Message = "Adding Avalon Statues";

                    // Not necessary, just a precaution.
                    if (WorldGen.statueList.Any(point => point.X == ModContent.TileType<Statues>()))
                    {
                        return;
                    }
                    // Make space in the statueList array, and then add a Point16 of (TileID, PlaceStyle)
                    Array.Resize(ref WorldGen.statueList, WorldGen.statueList.Length + 9);
                    WorldGen.statueList[WorldGen.statueList.Length - 9] = new Point16(ModContent.TileType<Statues>(), 0);
                    WorldGen.statueList[WorldGen.statueList.Length - 8] = new Point16(ModContent.TileType<Statues>(), 1);
                    WorldGen.statueList[WorldGen.statueList.Length - 7] = new Point16(ModContent.TileType<Statues>(), 2);
                    WorldGen.statueList[WorldGen.statueList.Length - 6] = new Point16(ModContent.TileType<Statues>(), 4);
                    WorldGen.statueList[WorldGen.statueList.Length - 5] = new Point16(ModContent.TileType<Statues>(), 5);
                    WorldGen.statueList[WorldGen.statueList.Length - 4] = new Point16(ModContent.TileType<Statues>(), 7);
                    WorldGen.statueList[WorldGen.statueList.Length - 3] = new Point16(ModContent.TileType<Statues>(), 8);
                    WorldGen.statueList[WorldGen.statueList.Length - 2] = new Point16(ModContent.TileType<Statues>(), 9);
                    WorldGen.statueList[WorldGen.statueList.Length - 1] = new Point16(ModContent.TileType<Statues>(), 10);
                    //for (int i = WorldGen.statueList.Length - 9; i < WorldGen.statueList.Length; i++)
                    //{
                    //    if (i == )
                    //    WorldGen.statueList[i] = new Point16(ModContent.TileType<Statues>(), 0);
                    //}
                }));
            }
        }
    }
}
