using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    class Tropics
    {
        public static void ILFindStart(ILContext il)
        {
            var c = new ILCursor(il);
            ILLabel returnLabel = null;
            int typeLoc = 5;

            if (!c.TryGotoNext(i => i.MatchLdcI4(59)))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdloc(out typeLoc)))
                return;
            if (!c.TryGotoNext(i => i.MatchBeq(out returnLabel)))
                return;
            c.Index++;

            c.Emit(OpCodes.Ldloc, typeLoc);
            c.EmitDelegate<Func<ushort>>(() =>
            {
                return (ushort)ModContent.TileType<Tiles.TropicalMud>();
            });
            c.Emit(OpCodes.Beq, returnLabel);

            c.Emit(OpCodes.Ldloc, typeLoc);
            c.EmitDelegate<Func<ushort>>(() =>
            {
                return (ushort)ModContent.TileType<Tiles.TropicalGrass>();
            });
            c.Emit(OpCodes.Beq, returnLabel);

            if (!c.TryGotoNext(i => i.MatchLdcI4(0)))
                return;

        }
    }
}
