﻿using System;
using System.Reflection;
using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace ExxoAvalonOrigins.Hooks
{
    internal class Utils
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
                    c.EmitDelegate<Func<ushort, ushort>>((id) =>
                    {
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
        public static void SoftReplaceAllMatchingInstructions(ILContext il, Instruction i1, Instruction i2)
        {
            var c = new ILCursor(il);

            while (c.TryGotoNext(i => i.OpCode == i1.OpCode && (i1.Operand == null || i.Operand == i1.Operand)))
            {
                // Ensure not replacing anything added by an IL hook
                if (c.Next.Offset != 0)
                {
                    c.Index++;
                    c.Emit(OpCodes.Pop);
                    c.Emit(i2.OpCode, i2.Operand);
                }
            }
        }
        public static void HardReplaceAllMatchingInstructions(ILContext il, Instruction i1, Instruction i2)
        {
            var c = new ILCursor(il);

            while (c.TryGotoNext(i => i.OpCode == i1.OpCode && (i1.Operand == null || i.Operand == i1.Operand)))
            {
                // Ensure not replacing anything added by an IL hook
                if (c.Next.Offset != 0)
                {
                    c.Remove();
                    c.Emit(i2.OpCode, i2.Operand);
                }
            }
        }
        public static void SoftReplaceAllMatchingInstructionsWithMethod(ILContext il, Instruction i1, MethodBase method)
        {
            var c = new ILCursor(il);

            while (c.TryGotoNext(i => i.OpCode == i1.OpCode && (i1.Operand == null || i.Operand == i1.Operand)))
            {
                // Ensure not replacing anything added by an IL hook
                if (c.Next.Offset != 0)
                {
                    c.Index++;
                    c.Emit(OpCodes.Pop);
                    c.Emit(OpCodes.Call, method);
                }
            }
        }
    }
}
