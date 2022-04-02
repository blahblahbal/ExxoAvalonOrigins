using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Furniture;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Tiles;

public class LockedImperviousDoor : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSolid[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileID.Sets.NotReallySolid[Type] = true;
        TileID.Sets.DrawsWalls[Type] = true;
        TileID.Sets.HasOutlines[Type] = true;
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(0, 1);
        TileObjectData.addAlternate(0);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(0, 2);
        TileObjectData.addAlternate(0);
        TileObjectData.addTile(Type);
        var name = CreateMapEntryName();
        name.SetDefault("Locked Impervious Door");
        AddMapEntry(new Color(119, 105, 79), name);
        disableSmartCursor = true;
        adjTiles = new int[] { TileID.ClosedDoor };
        minPick = 2000;
        dustType = DustID.Wraith;
    }

    public override bool CanKillTile(int i, int j, ref bool blockDamaged)
    {
        blockDamaged = false;
        return false;
    }

    public override bool HasSmartInteract()
    {
        return true;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = 1;
    }

    public override void RightClick(int i, int j)
    {
        Player player = Main.LocalPlayer;
        Tile tile = Main.tile[i, j];
        Main.mouseRightRelease = false;
        for (int num146 = 0; num146 < player.inventory.Length; num146++)
        {
            if (player.inventory[num146].type == ModContent.ItemType<ImperviousKey>() && player.inventory[num146].stack > 0)
            {
                player.inventory[num146].stack--;
                if (player.inventory[num146].stack <= 0)
                {
                    player.inventory[num146] = new Item();
                }
                UnlockDoor(i, j);
            }
        }
    }
    public static void UnlockDoor(int i, int j)
    {
        int num = j;
        //if (type == ModContent.TileType<LockedImperviousDoor>())
        //{
        while (Main.tile[i, num].TileFrameY != 0)
        {
            num--;
            if (Main.tile[i, num].TileFrameY < 0 || num <= 0)
            {
                return;
            }
        }
        //}
        SoundEngine.PlaySound(SoundID.Unlock, i * 16, num * 16 + 16, 1);
        for (int k = num; k <= num + 2; k++)
        {
            if (Main.tile[i, k] == null)
            {
                Main.tile[i, k] = new Tile();
            }
            Main.tile[i, k].TileType = (ushort)ModContent.TileType<ClosedImperviousDoor>();
            for (int l = 0; l < 4; l++)
            {
                Dust.NewDust(new Vector2((float)(i * 16), (float)(k * 16)), 16, 16, DustID.Silver, 0f, 0f, 0, default(Color), 1f);
            }
        }
    }
    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 16, 48, ModContent.ItemType<ImperviousDoor>());
    }

    public override void MouseOver(int i, int j)
    {
        var player = Main.LocalPlayer;
        player.noThrow = 2;
        player.showItemIcon = true;
        player.showItemIcon2 = ModContent.ItemType<ImperviousKey>();
    }
}