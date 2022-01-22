using System;
using MonoMod.Cil;

namespace ExxoAvalonOrigins.Hooks
{
    public static class DryadText
    {
        public static void ILDryadText(ILContext il)
        {
            var c = new ILCursor(il);

            // This code replaces tEvil with your custom value, once someone will add it
            /*if (!c.TryGotoNext(i => i.MatchStloc(out _)))
                return;
            if (!c.TryGotoNext(i => i.MatchStloc(out _)))
                return;
            int tGross = 0;
            if (!c.TryGotoNext(i => i.MatchStloc(out tGross)))
                return;
            if (!c.TryGotoNext(i => i.MatchStloc(out _)))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldloc, tGross);
            c.EmitDelegate<Func<int, int>>((orig) =>
            {
                if (ExxoAvalonOriginsWorld.contagion)
                {
                    orig = WorldGen.tGood; // Replace vanilla value with custom
                }
                return orig;
            });
            c.Emit(OpCodes.Stloc, tGross);*/


            if (!c.TryGotoNext(i => i.MatchLdstr("DryadSpecialText.WorldStatusAll")))
                return;
            c.Index++;
            c.EmitDelegate<Func<string, string>>((orig) =>
            {
                return "Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusAll";
            });
            if (!c.TryGotoNext(i => i.MatchLdstr("DryadSpecialText.WorldStatusHallowCorrupt")))
                return;
            c.Index++;
            c.EmitDelegate<Func<string, string>>((orig) =>
            {
                if (ExxoAvalonOriginsWorld.contagion)
                    return "Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusHallowContagion";
                return orig;
            });
            if (!c.TryGotoNext(i => i.MatchLdstr("DryadSpecialText.WorldStatusCorruptCrimson")))
                return;
            c.Index++;
            c.EmitDelegate<Func<string, string>>((orig) =>
            {
                if (ExxoAvalonOriginsWorld.contagion)
                    return "Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusContagionCrimson";
                return orig;
            });
            if (!c.TryGotoNext(i => i.MatchLdstr("DryadSpecialText.WorldStatusCorrupt")))
                return;
            c.Index++;
            c.EmitDelegate<Func<string, string>>((orig) =>
            {
                if (ExxoAvalonOriginsWorld.contagion)
                    return "Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusContagion";
                return orig;
            });
        }
    }
}
