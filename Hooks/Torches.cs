using System;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    class Torches
    {
        // Adds modded torches to smart cursor
        public static void ILSmartCursor_Torch(ILContext il)
        {
            var c = new ILCursor(il);

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdfld<Item>(nameof(Item.createTile))))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(4)))
                return;

            // Automatically shift cursor after each emit
            c.MoveAfterLabels();

            c.EmitDelegate<Func<int, int>>((createTile) =>
          {
              if (createTile == ModContent.TileType<Tiles.Torches>())
              {
                  return 4;
              }
              return createTile;
          });
        }

    }
}
