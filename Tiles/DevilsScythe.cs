using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles;

public class DevilsScythe : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.addTile(Type);
        Main.tileLighted[Type] = true;
        AddMapEntry(new Color(170, 48, 114));
    }
    public override bool RightClick(int i, int j)
    {
        WorldGen.KillTile(i, j);
        if (!Main.tile[i, j].HasTile && Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, i, j);
        }
        return true;
    }
    public override void MouseOver(int i, int j)
    {
        Player player = Main.LocalPlayer;
        player.noThrow = 2;
        player.showItemIcon = true;
        player.showItemIcon2 = ModContent.ItemType<Items.Weapons.Magic.DevilsScythe>();
    }
    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Weapons.Magic.DevilsScythe>());
    }
}