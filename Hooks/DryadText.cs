using System;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Hooks;

/// <summary>
/// To-Do: Fix it always adding "crimson" for no reason.
/// </summary>
public static class DryadText
{
    // MIGHT CONFLICT WITH OTHER MODS LIKE CONFECTION, WHICH IS GOING TO HAVE BASICALLY SAME IL EDIT!
    public static void ILDryadText(ILContext il)
    {
        var c = new ILCursor(il);

        if (!c.TryGotoNext(i => i.MatchLdloc(0)))
            return;
        c.Remove(); // Remove Ldloc.0

        c.Emit(OpCodes.Ldloc_1);
        c.Emit(OpCodes.Ldloc_2);
        c.Emit(OpCodes.Ldloc_3);
        c.EmitDelegate<Func<int, int, int, string>>((tGood, tEvil, tBlood) =>
        {
            int tGross = 1;

            string text = "";
            if (tGood > 0 && tEvil > 0 && tBlood > 0 && tGross > 0)
            {
                text = Language.GetTextValue("Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusAll", Main.worldName, tGood, tEvil, tBlood, tGross);
            }

            // Combinations of good and evils
            else if (tGood > 0 && tEvil > 0) // Hallow, Corruption
            {
                text = Language.GetTextValue("DryadSpecialText.WorldStatusHallowCorrupt", Main.worldName, tGood, tEvil);
            }
            else if (tGood > 0 && tEvil > 0 && tGross > 0) // Hallow, Corruption, Contagion
            {
                text = Language.GetTextValue("Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusHallowCorruptContagion", Main.worldName, tGood, tEvil, tGross);
            }
            else if (tGood > 0 && tBlood > 0) // Hallow, Crimson
            {
                text = Language.GetTextValue("DryadSpecialText.WorldStatusHallowCrimson", Main.worldName, tGood, tBlood);
            }
            else if (tGood > 0 && tBlood > 0 && tEvil > 0) // Hallow, Crimson, Corruption
            {
                text = Language.GetTextValue("DryadSpecialText.WorldStatusHallowCrimson", Main.worldName, tGood, tBlood, tEvil);
            }
            else if (tEvil > 0 && tBlood > 0) // Corruption, Crimson
            {
                text = Language.GetTextValue("DryadSpecialText.WorldStatusCorruptCrimson", Main.worldName, tEvil, tBlood);
            }
            else if (tEvil > 0 && tGross > 0) // Corruption, Contagion
            {
                text = Language.GetTextValue("Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusCorruptContagion", Main.worldName, tEvil, tGross);
            }
            else if (tEvil > 0 && tBlood > 0 && tGross > 0) // Corruption, Crimson, Contagion
            {
                text = Language.GetTextValue("Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusCorruptCrimsonContagion", Main.worldName, tEvil, tBlood, tGross);
            }
            else if (tBlood > 0 && tGross > 0) // Crimson, Contagion
            {
                text = Language.GetTextValue("Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusCrimsonContagion", Main.worldName, tBlood, tGross);
            }

            // "Singular" evils
            else if (tEvil > 0)
            {
                text = Language.GetTextValue("DryadSpecialText.WorldStatusCorrupt", Main.worldName, tEvil);
            }
            else if (tBlood > 0)
            {
                text = Language.GetTextValue("DryadSpecialText.WorldStatusCrimson", Main.worldName, tBlood);
            }
            else if (tGross > 0)
            {
                text = Language.GetTextValue("Mods.ExxoAvalonOrigins.DryadSpecialText.WorldStatusContagion", Main.worldName, tGross);
            }

            // Good
            else
            {
                if (tGood <= 0) // ... if no hallow, then pure
                {
                    return Language.GetTextValue("DryadSpecialText.WorldStatusPure", Main.worldName);
                }
                text = Language.GetTextValue("DryadSpecialText.WorldStatusHallow", Main.worldName, tGood);
            }

            string str;
            if (tGood * 1.2 >= (tEvil + tBlood + tGross) && tGood * 0.8 <= (tEvil + tBlood + tGross))
            {
                str = Language.GetTextValue("DryadSpecialText.WorldDescriptionBalanced");
            }
            else if (tGood >= tEvil + tBlood + tGross)
            {
                str = Language.GetTextValue("DryadSpecialText.WorldDescriptionFairyTale");
            }
            else if (tEvil + tBlood + tGross > tGood + 20)
            {
                str = Language.GetTextValue("DryadSpecialText.WorldDescriptionGrim");
            }
            else if (tEvil + tBlood + tGross <= 10)
            {
                str = Language.GetTextValue("DryadSpecialText.WorldDescriptionClose");
            }
            else
            {
                str = Language.GetTextValue("DryadSpecialText.WorldDescriptionWork");
            }

            return $"{text} {str}";
        });

        c.Emit(OpCodes.Ret);
    }
}