using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class WorldgenHelper : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("WorldGen Helper");
        Tooltip.SetDefault("Use this item to generate a pre-set structure at your location\nDO NOT USE IN NORMAL GAMEPLAY - IT WILL OVERWRITE BLOCKS");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Purple;
        Item.width = dims.Width;
        Item.maxStack = 1;
        Item.useAnimation = Item.useTime = 30;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 0;
        Item.height = dims.Height;
        //item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Scroll");
    }

    public override bool? UseItem(Player player)
    {
        //int x = (int)player.position.X / 16;
        //int y = (int)player.position.Y / 16;
        //int xStored = x;
        //for (int i = x; i < x + 5; i++)
        //{
        //    for (int j = y; j < y + 5; j++)
        //    {
        //        if (Main.tile[i, j].HasTile || Main.tile[i, j].liquid > 0 || Main.tile[i, j].wall > 0)
        //        {
        //            xStored--;
        //            break;
        //        }
        //    }
        //}
        //GetXCoord(x, y, ref xStored);
        //World.Utils.MakeSquareTemp(xStored, y);

        //ExxoAvalonOriginsWorld.GenerateSulphur();
        //ModContent.GetInstance<ExxoAvalonOriginsWorld>().GenerateCrystalMines();
        //World.Structures.SkyFortress.Generate((int)player.position.X / 16, (int)player.position.Y / 16);
        //World.Structures.CaesiumSpike.CreateSpikeUp((int)player.position.X / 16, (int)player.position.Y / 16, (ushort)ModContent.TileType<Tiles.CaesiumOre>());
        return true;
    }
    public static int GetXCoord(int x, int y, ref int xStored)
    {
        if (Main.tile[x, y].HasTile || Main.tile[x, y].liquid > 0 || Main.tile[x, y].WallType > 0)
        {
            xStored--;
            GetXCoord(xStored, y, ref xStored);
        }
        return xStored;
    }
}