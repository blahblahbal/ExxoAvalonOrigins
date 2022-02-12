using Mono.Cecil.Cil;
using MonoMod.Cil;

namespace ExxoAvalonOrigins.Hooks
{
    class Debug
    {
        public static void OutputIL(ILContext il)
        {
            var c = new ILCursor(il);
            foreach (Instruction instruction in c.Instrs)
            {
                object obj = (instruction.Operand == null) ? "" : instruction.Operand.ToString();
                ExxoAvalonOrigins.Mod.Logger.Debug($"{instruction.Offset} | {instruction.OpCode} | {obj}");
            }
        }
    }
}
