using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria.ID;

namespace ExxoAvalonOrigins.Hooks
{
    class AIChanges
    {
        public static void ILAI_006_Worms(ILContext il)
        {
            var c = new ILCursor(il);

            FieldReference npcType = null;

            // flag4
            if (!c.TryGotoNext(i => i.MatchStloc(76)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdfld(out npcType)))
                return;

            for (var j = 0; j < 2; j++)
            {
                // 1st run. getZoneCorruption always returns true for devourer
                // 2nd run. getZoneCrimson always returns true for devourer
                if (!c.TryGotoNext(i => i.MatchCallvirt(out _)))
                    return;
                c.Index++;
                c.Emit(OpCodes.Ldarg_0);
                c.Emit(OpCodes.Ldfld, npcType);
                c.EmitDelegate<Func<bool, int, bool>>((orig, type) =>
                {
                    if (type == NPCID.DevourerHead)
                    {
                        return true;
                    }
                    return orig;
                });
            }
        }
    }
}