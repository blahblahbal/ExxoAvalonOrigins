using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour.HookGen;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    class Utils
    {
        public static void AddAlternativeIDCheck(ILContext il, ushort val1, int val2)
        {
            var c = new ILCursor(il);

            ILLabel exit = null;
            while (c.TryGotoNext(i => i.MatchBeq(out exit) || i.MatchBneUn(out exit)))
            {
                if (c.Next.Offset != 0 && c.Prev.MatchLdcI4(val1))
                {
                    c.Index--;
                    c.EmitDelegate<Func<ushort, ushort>>((id) => { 
                        if (id == val2)
                        {
                            return val1;
                        }
                        return id;
                    });
                    c.Index += 2;

                    // if type == val2 return val1
                    //c.Index--;
                    //c.Remove();
                    //c.EmitDelegate<Func<int, bool>>((id) =>
                    //{
                    //    if (id == val1 || id == val2)
                    //    {
                    //        return true;
                    //    }
                    //    return false;
                    //});
                    //c.Remove();
                    //c.Emit(OpCodes.Brtrue, exit);
                }
            }
        }
        public static void ReplaceIDIfMatch(ILContext il, ushort val1, ushort val2, FieldInfo field, int matchInt)
        {
            var c = new ILCursor(il);

            while (c.TryGotoNext(i => i.MatchLdcI4(val1)))
            {
                // Ensure not replacing anything added by an IL hook
                if (c.Next.Offset != 0 && !(c.Prev.MatchCall(out _) && c.Prev.Offset == 0))
                {
                    c.Remove();
                    ILLabel endif = c.DefineLabel();
                    ILLabel path = c.DefineLabel();
                    c.Emit(OpCodes.Ldsfld, field);
                    c.Emit(OpCodes.Ldc_I4, matchInt);
                    c.Emit(OpCodes.Beq, path);
                    c.Emit(OpCodes.Ldc_I4, val1);
                    c.Emit(OpCodes.Br, endif);
                    c.MarkLabel(path);
                    c.Emit(OpCodes.Ldc_I4, val2);
                    c.MarkLabel(endif);
                }
            }
        }
    }
}
