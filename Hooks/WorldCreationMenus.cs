using System;
using Mono.Cecil;
using MonoMod.Cil;
using Terraria;
using Terraria.Localization;
using static Mono.Cecil.Cil.OpCodes;

namespace ExxoAvalonOrigins.Hooks
{
    public class WorldCreationMenus
    {        
        public static void ILDrawMenu(ILContext il)
        {
            var c = new ILCursor(il);

            int evilMenuMode = -71;
            int tropicsMenuMode = -72;
            int rhodiumMenuMode = -73;

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdcI4(evilMenuMode)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdloc(26))) // array9
                return;
            if (!c.TryGotoNext(i => i.MatchLdloc(26))) // array9
                return;

            // Go to assignment of last array4 element
            if (!c.TryGotoPrev(i => i.MatchStelemI4()))
                return;

            // Get index and value of assigned value
            int num = -1;
            int index = -1;
            if (!c.TryGotoPrev(i => i.MatchLdcI4(out num)))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdcI4(out index)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(num)))
                return;

            // Replace spacing of last element from num to 30
            c.Remove();
            c.Emit(Ldc_I4, 30);

            // Go after stelem to shift old end element to new end element
            if (!c.TryGotoNext(i => i.MatchStelemI4()))
                return;
            c.Index++;

            // array4[index + 1] = num
            c.Emit(Ldloc, 19); // array4
            c.Emit(Ldc_I4, index + 1);
            c.Emit(Ldc_I4, num);
            c.Emit(Stelem_I4);

            // Change to reflect that there is one extra element
            if (!c.TryGotoNext(i => i.MatchLdcI4(index + 1)))
                return;
            c.Remove();
            c.Emit(Ldc_I4, index + 2);

            FieldReference selectedMenu = null;
            FieldReference menuMode = null;

            // Replace all returns to menuMode (7) to tropics menu
            if (!c.TryGotoNext(i => i.MatchPop()))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(7)))
                return;

            c.Remove();
            c.Emit(Ldc_I4, tropicsMenuMode);

            if (!c.TryGotoNext(i => i.MatchPop()))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(7)))
                return;

            c.Remove();
            c.Emit(Ldc_I4, tropicsMenuMode);

            if (!c.TryGotoNext(i => i.MatchPop()))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(7)))
                return;

            c.Remove();
            c.Emit(Ldc_I4, tropicsMenuMode);

            if (!c.TryGotoNext(i => i.MatchLdstr("UI.Back")))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdfld(out selectedMenu)))
                return;
            if (!c.TryGotoPrev(i => i.MatchAdd()))
                return;

            c.Emit(Add);
            c.Emit(Stloc, 47);

            c.Emit(Ldloc, 26);
            c.Emit(Ldloc, 47);
            c.Emit(Ldarg_0);
            c.Emit(Ldfld, selectedMenu);
            c.EmitDelegate<Action< String[],int, int>>((nameArray, currentIndex, selectedIndex) =>
            {
                nameArray[currentIndex] = "Contagion";
                if (selectedIndex == currentIndex)
                {
                    WorldGen.WorldGenParam_Evil = 2;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                    Main.menuMode = tropicsMenuMode; // custom menumode
                }
            });

            c.Emit(Ldloc, 47);
            c.Emit(Ldc_I4, 1);

            ILLabel brExit = null;

            if (!c.TryGotoNext(i => i.MatchBneUn(out _)))
                return;
            if (!c.TryGotoNext(i => i.MatchBneUn(out _)))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdcI4(7)))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdsfld(out menuMode)))
                return;
            if (!c.TryGotoPrev(i => i.MatchBr(out brExit)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdsfld(menuMode)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(7)))
                return;

            // TROPICS
            ILLabel endif = c.DefineLabel();
            c.Emit(Ldc_I4, tropicsMenuMode);
            c.Emit(Bne_Un, endif);

            c.Emit(Ldc_I4, 200);
            c.Emit(Stloc, 5); // num2
            c.Emit(Ldc_I4, 60);
            c.Emit(Stloc, 7); // num4
            c.Emit(Ldc_I4, 5); // elements in UI screen (title, jungle, tropics, random, back)
            c.Emit(Stloc, 8); // num5

            c.Emit(Ldloc, 16); // array
            c.Emit(Ldc_I4_0);
            c.Emit(Ldc_I4_1);
            c.Emit(Stelem_I1);

            c.Emit(Ldloc, 19);
            c.Emit(Ldloc, 26);
            c.Emit(Ldloc, 25);
            c.Emit(Ldarg_0);
            c.Emit(Ldfld, selectedMenu);
            c.EmitDelegate<Action<int[], string[], bool, int>>((array4, array9, flag5, val) =>
            {
                array4[1] = 30;
                array4[2] = 30;
                array4[3] = 30;
                array4[4] = 70;

                ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.random;

                int num17 = 0;
                array9[num17] = "Pick world jungle type";
                num17++;
                array9[num17] = "Jungle";
                if (val == num17)
                {
                    ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.jungle;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                    Main.menuMode = rhodiumMenuMode;
                }
                num17++;
                array9[num17] = "Tropics";
                if (val == num17)
                {
                    ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.tropics;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                    Main.menuMode = rhodiumMenuMode;
                }
                num17++;
                array9[num17] = Lang.misc[103].Value; // Random
                if (val == num17)
                {
                    ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.random;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                    Main.menuMode = rhodiumMenuMode;
                }
                num17++;
                array9[num17] = Language.GetTextValue("UI.Back");
                if (val == num17 || flag5)
                {
                    flag5 = false;
                    Main.PlaySound(11, -1, -1, 1, 1f, 0f);
                    Main.menuMode = evilMenuMode;
                }
                num17++;
                Main.clrInput();
            });

            c.Emit(Br, brExit);
            c.MarkLabel(endif);
            endif = c.DefineLabel();
            c.Emit(Ldsfld, menuMode);

            // RHODIUM
            endif = c.DefineLabel();
            c.Emit(Ldc_I4, rhodiumMenuMode);
            c.Emit(Bne_Un, endif);

            c.Emit(Ldc_I4, 200);
            c.Emit(Stloc, 5); // num2
            c.Emit(Ldc_I4, 60);
            c.Emit(Stloc, 7); // num4
            c.Emit(Ldc_I4, 6); // elements in UI screen (title, rhodium, osmium, iridium, random, back)
            c.Emit(Stloc, 8); // num5

            c.Emit(Ldloc, 16); // array
            c.Emit(Ldc_I4_0);
            c.Emit(Ldc_I4_1);
            c.Emit(Stelem_I1);

            c.Emit(Ldloc, 19);
            c.Emit(Ldloc, 26);
            c.Emit(Ldloc, 25);
            c.Emit(Ldarg_0);
            c.Emit(Ldfld, selectedMenu);
            c.EmitDelegate<Action<int[], string[], bool, int>>((array4, array9, flag5, val) =>
            {
                array4[1] = 30;
                array4[2] = 30;
                array4[3] = 30;
                array4[4] = 30;
                array4[5] = 70;

                ExxoAvalonOriginsWorld.osmiumMenuSelection = ExxoAvalonOriginsWorld.OsmiumVariant.random;

                int num17 = 0;
                array9[num17] = "Pick ore type";
                num17++;
                array9[num17] = "Rhodium";
                if (val == num17)
                {
                    ExxoAvalonOriginsWorld.osmiumMenuSelection = ExxoAvalonOriginsWorld.OsmiumVariant.rhodium;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                    Main.menuMode = 7;
                }
                num17++;
                array9[num17] = "Osmium";
                if (val == num17)
                {
                    ExxoAvalonOriginsWorld.osmiumMenuSelection = ExxoAvalonOriginsWorld.OsmiumVariant.osmium;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                    Main.menuMode = 7;
                }
                num17++;
                array9[num17] = "Iridium";
                if (val == num17)
                {
                    ExxoAvalonOriginsWorld.osmiumMenuSelection = ExxoAvalonOriginsWorld.OsmiumVariant.iridium;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                    Main.menuMode = 7;
                }
                num17++;
                array9[num17] = Lang.misc[103].Value; // Random
                if (val == num17)
                {
                    ExxoAvalonOriginsWorld.osmiumMenuSelection = ExxoAvalonOriginsWorld.OsmiumVariant.random;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                    Main.menuMode = 7;
                }
                num17++;
                array9[num17] = Language.GetTextValue("UI.Back");
                if (val == num17 || flag5)
                {
                    flag5 = false;
                    Main.PlaySound(11, -1, -1, 1, 1f, 0f);
                    Main.menuMode = tropicsMenuMode;
                }
                num17++;
                Main.clrInput();
            });

            c.Emit(Br, brExit);
            c.MarkLabel(endif);
            c.Emit(Ldsfld, menuMode);
        }
    }
}