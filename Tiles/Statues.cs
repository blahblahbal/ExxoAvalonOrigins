using System;
using System.Collections.Generic;
using System.Linq;
using ExxoAvalonOrigins.Items.Placeable.Furniture;
using ExxoAvalonOrigins.Items.Placeable.Statue;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.World.Generation;

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
                case 3:
                    return 2;
                case 6:
                    return 3;
            }
            return 0;
        }
        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].frameX >= 396 && Main.tile[i, j].frameX <= 430)
            {
                Main.tile[i, j].frameX += 36;
                WorldGen.SquareTileFrame(i, j);
            }
            else if (Main.tile[i, j].frameX >= 432 && Main.tile[i, j].frameX <= 466)
            {
                Main.tile[i, j].frameX -= 36;
                WorldGen.SquareTileFrame(i, j);
            }
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.tile[i, j].frameX >= 432 && Main.tile[i, j].frameX <= 466)
            {
                Lighting.AddLight(new Vector2(i * 16, j * 16), new Vector3(1f, 0.1f, 0.1f));
            }
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameX / 36)
            {
                case 0:
                    item = ModContent.ItemType<ShellStatue>();
                    break;
                case 1:
                    item = ModContent.ItemType<DNAStatue>();
                    break;
                case 2:
                    item = ModContent.ItemType<IceSculpture>();
                    break;
                case 3:
                    item = ModContent.ItemType<OrangeDungeonVase>();
                    break;
                case 4:
                    item = ModContent.ItemType<TomeStatue>();
                    break;
                case 5:
                    item = ModContent.ItemType<HallowStatue>();
                    break;
                case 6:
                    item = ModContent.ItemType<BlueLihzahrdStatue>();
                    break;
                case 7:
                    item = ModContent.ItemType<ContagionStatue>();
                    break;
                case 8:
                    item = ModContent.ItemType<CrimsonStatue>();
                    break;
                case 9:
                    item = ModContent.ItemType<AngelSculpture>();
                    break;
                case 10:
                    item = ModContent.ItemType<DNASculpture>();
                    break;
                case 11:
                case 12:
                    item = ModContent.ItemType<TurretStatue>();
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
                case 3:
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Coralstone);
                    return false;
                case 6:
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.t_Granite);
                    return false;
            }
            return base.CreateDust(i, j, ref type);
        }
    }

    public class ExampleStatueModWorld : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ResetIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Reset"));
            if (ResetIndex != -1)
            {
                tasks.Insert(ResetIndex + 1, new PassLegacy("Avalon Statue Setup", delegate (GenerationProgress progress)
                {
                    progress.Message = "Adding Avalon Statues";

                    // Not necessary, just a precaution.
                    if (WorldGen.statueList.Any(point => point.X == ModContent.TileType<Statues>()))
                    {
                        return;
                    }
                    // Make space in the statueList array, and then add a Point16 with (TileID, PlaceStyle)
                    Array.Resize(ref WorldGen.statueList, WorldGen.statueList.Length + 10);
                    WorldGen.statueList[WorldGen.statueList.Length - 10] = new Point16(ModContent.TileType<Statues>(), 0);
                    WorldGen.statueList[WorldGen.statueList.Length - 9] = new Point16(ModContent.TileType<Statues>(), 1);
                    WorldGen.statueList[WorldGen.statueList.Length - 8] = new Point16(ModContent.TileType<Statues>(), 2);
                    WorldGen.statueList[WorldGen.statueList.Length - 7] = new Point16(ModContent.TileType<Statues>(), 4);
                    WorldGen.statueList[WorldGen.statueList.Length - 6] = new Point16(ModContent.TileType<Statues>(), 5);
                    WorldGen.statueList[WorldGen.statueList.Length - 5] = new Point16(ModContent.TileType<Statues>(), 7);
                    WorldGen.statueList[WorldGen.statueList.Length - 4] = new Point16(ModContent.TileType<Statues>(), 8);
                    WorldGen.statueList[WorldGen.statueList.Length - 3] = new Point16(ModContent.TileType<Statues>(), 9);
                    WorldGen.statueList[WorldGen.statueList.Length - 2] = new Point16(ModContent.TileType<Statues>(), 10);
                    WorldGen.statueList[WorldGen.statueList.Length - 1] = new Point16(ModContent.TileType<Statues>(), 11);
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
