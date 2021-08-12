using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;using Terraria.Localization;namespace ExxoAvalonOrigins.Tiles{
    public class SpiritPoppy : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(0, 0, 200), LanguageManager.Instance.GetText("Spirit Poppy"));            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);
            Main.tileObsidianKill[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
        }        public override void KillMultiTile(int i, int j, int frameX, int frameY)        {            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.XeradonAnvil>());        }    }}