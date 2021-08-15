using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria;

namespace ExxoAvalonOrigins.Hooks
{
    class DungeonSide
    {
        public static void ILGenerateWorld(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(i => i.MatchStsfld<WorldGen>(nameof(WorldGen.rockLayerHigh))))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(0)))
                return;

            c.Remove();
            c.EmitDelegate<Func<int>>(() => {
                ExxoAvalonOriginsWorld.dungeonSide = (WorldGen.genRand.Next(2) != 0) ? 1 : (-1);
                return ExxoAvalonOriginsWorld.dungeonSide;
            });

            if (!c.TryGotoNext(i => i.MatchLdcI4(5)))
                return;
            if (!c.TryGotoNext(i => i.MatchConvU2()))
                return;
            c.Index++;

            c.EmitDelegate<Func<ushort, ushort>>((randNum) => {
                if (randNum == 0)
                {
                    return 119;
                }
                else if (randNum == 1)
                {
                    return 120;
                }
                else if (randNum == 2)
                {
                    return 158;
                }
                else if (randNum == 3)
                {
                    return 175;
                }
                else if (randNum == 4)
                {
                    return 45;
                }
                return 119;
            });

        }
    }
}
