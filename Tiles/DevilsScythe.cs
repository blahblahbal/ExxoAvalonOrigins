using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
    public class DevilsScythe : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.addTile(Type);
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(170, 48, 114));
        }
        public override bool NewRightClick(int i, int j)
        {
            Item.NewItem(new Rectangle(i * 16, j * 16, 16, 16), ModContent.ItemType<Items.DevilsScythe>(), prefixGiven: -1);
            Main.tile[i, j].active(false);
            Main.PlaySound(SoundID.Dig, new Vector2(i * 16, j * 16), 1);
            return true;
        }
        public override void MouseOver(int i, int j)
        {
            var player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ModContent.ItemType<Items.DevilsScythe>();
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (Main.tile[i, j].frameX == 0 && Main.tile[i, j].frameY == 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, ModContent.ItemType<Items.DevilsScythe>());
            }
        }
    }
}