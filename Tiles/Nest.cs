using Microsoft.Xna.Framework;
            ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<TropicalGrass>());
        }
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, ModContent.TileType<TropicalMud>(), false, false, false, false, resetFrame);
            return false;
        }
    }