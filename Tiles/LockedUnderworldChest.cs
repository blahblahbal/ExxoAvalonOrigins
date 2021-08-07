using System;using Microsoft.Xna.Framework;using Terraria;using Terraria.DataStructures;using Terraria.Enums;using Terraria.ID;using Terraria.Localization;using Terraria.ModLoader;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{
    public class LockedUnderworldChest : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileContainer[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1200;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileValue[Type] = 500;
            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            var name = CreateMapEntryName();
            name.SetDefault("Locked Underworld Chest");
            AddMapEntry(new Color(200, 20, 0), name, MapChestName);
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.Containers };
            chest = "Locked Underworld Chest";
            chestDrop = ModContent.ItemType<Items.UnderworldChest>();
        }

        public override bool HasSmartInteract()
        {
            return true;
        }

        public string MapChestName(string name, int i, int j)
        {
            var left = i;
            var top = j;
            var tile = Main.tile[i, j];
            if (tile.frameX % 36 != 0)
            {
                left--;
            }
            if (tile.frameY != 0)
            {
                top--;
            }
            var chest = Chest.FindChest(left, top);
            if (Main.chest[chest].name == "")
            {
                return name;
            }
            else
            {
                return name + ": " + Main.chest[chest].name;
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 1;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 32, chestDrop);
            Chest.DestroyChest(i, j);
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            blockDamaged = false;
            return false;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public static void Unlock(int X, int Y)
        {
            if (Main.tile[X, Y] == null)
            {
                return;
            }
            Main.PlaySound(22, X * 16, Y * 16, 1);
            for (int i = X; i <= X + 1; i++)
            {
                for (int j = Y; j <= Y + 1; j++)
                {
                    Main.tile[i, j].type = (ushort)ModContent.TileType<UnderworldChest>();
                    for (int k = 0; k < 4; k++)
                    {
                        Dust.NewDust(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16, 6, 0f, 0f, 0, default(Color), 1f);
                    }
                }
            }
        }
        public override void RightClick(int i, int j)
        {
            int num148;
            for (num148 = (int)(Main.tile[i, j].frameX / 18); num148 > 1; num148 -= 2)
            {
            }
            num148 = i - num148;
            int num149 = j - (int)(Main.tile[i, j].frameY / 18);
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            Main.mouseRightRelease = false;
            for (int num146 = 0; num146 < player.inventory.Length; num146++)
            {
                if (player.inventory[num146].type == ModContent.ItemType<Items.UnderworldKey>() && player.inventory[num146].stack > 0)
                {
                    player.inventory[num146].stack--;
                    if (player.inventory[num146].stack <= 0)
                    {
                        player.inventory[num146] = new Item();
                    }
                    Unlock(i, j);
                }
            }
        }

        public override void MouseOver(int i, int j)
        {
            var player = Main.LocalPlayer;
            var tile = Main.tile[i, j];
            var left = i;
            var top = j;
            if (tile.frameX % 36 != 0)
            {
                left--;
            }
            if (tile.frameY != 0)
            {
                top--;
            }
            var chest = Chest.FindChest(left, top);
            player.showItemIcon2 = -1;
            if (chest < 0)
            {
                player.showItemIconText = Language.GetTextValue("LegacyChestType.0");
            }
            else
            {
                player.showItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : "Locked Underworld Chest";
                if (player.showItemIconText == "Locked Underworld Chest")
                {
                    player.showItemIcon2 = ModContent.ItemType<Items.UnderworldKey>();
                    player.showItemIconText = "";
                }
            }
            player.noThrow = 2;
            player.showItemIcon = true;
        }

        public override void MouseOverFar(int i, int j)
        {
            MouseOver(i, j);
            var player = Main.LocalPlayer;
            if (player.showItemIconText == "")
            {
                player.showItemIcon = false;
                player.showItemIcon2 = 0;
            }
        }
    }}