using System;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.Utils;
using Terraria;
using Terraria.Localization;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using static Mono.Cecil.Cil.OpCodes;

namespace ExxoAvalonOrigins.UI
{
    public class EvilChooserMenu
    {        
        public static void HookEvilMenu(ILContext il)
        {
            var rightTarget = false;
            var c = new ILCursor(il);
            while (!rightTarget)
            {
                if (!c.TryGotoNext(i => i.MatchLdcI4(-71)))
                    throw new Exception("Couldn't find case: -71");
                if (!c.Next.Next.MatchBneUn(out _))
                    continue;
                if (!c.Next.Next.Next.MatchLdcI4(200))
                    continue;
                rightTarget = true;
            }
            c.TryGotoNext(i => i.MatchLdcI4(3));
            int buttonVerticalSpacingIndex = -1;
            c.TryGotoNext(i => i.MatchLdloc(out buttonVerticalSpacingIndex));
            if (buttonVerticalSpacingIndex == -1)
                throw new Exception("Couldn't find the variable index for buttonVerticalSpacing");
            c.TryGotoNext(i => i.MatchLdcI4(4));
            c.TryGotoNext(i => i.MatchLdcI4(70));
            c.Remove();
            c.Emit(Ldc_I4_S, (sbyte) 30);
            c.TryGotoNext(i => i.MatchStelemI4());
            c.Emit(Ldloc_S, (byte) buttonVerticalSpacingIndex);
            c.Emit(Ldc_I4_5);
            c.Emit(Ldc_I4_S, (sbyte) 70);
            c.Emit(Stelem_I4);
            c.TryGotoNext(i => i.MatchLdcI4(5));
            c.Remove();
            c.Emit(Ldc_I4_6);
            var buttonNames = -1;
            c.TryGotoNext(i => i.MatchLdloc(out buttonNames));
            if (buttonNames == -1)
                throw new Exception("Couldn't find the variable index for buttonNames");
            FieldReference selectedMenu = null;
            c.TryGotoNext(i => i.MatchLdarg(0));
            c.TryGotoNext(i => i.MatchLdfld(out selectedMenu));
            if (selectedMenu == null)
                throw new Exception("Couldn't find the private variable selectedMenu");
            var index9 = il.AddVariable(typeof(int));
            c.TryGotoNext(i => i.MatchLdstr("UI.Back"));
            c.TryGotoPrev(i => i.MatchAdd());
            c.Index--;
            c.TryGotoPrev(i => i.MatchAdd());
            c.Emit(Add);
            c.Emit(Stloc_S, (byte) index9);
            c.Emit(Ldloc_S, (byte) buttonNames);
            c.Emit(Ldloc_S, (byte) index9);
            c.Emit(Ldstr, "Contagion");
            c.Emit(Call, typeof(Language).GetMethod("GetTextValue", new[] {typeof(string)}));
            c.Emit(Stelem_Ref);
            c.Emit(Ldarg_0);
            c.Emit(Ldfld, selectedMenu);
            c.Emit(Ldloc_S, (byte) index9);
            var endif = il.DefineLabel();
            c.Emit(Bne_Un_S, endif);
            c.Emit(Ldc_I4_2);
            c.Emit(Stsfld, typeof(WorldGen).GetField(nameof(WorldGen.WorldGenParam_Evil)));
            c.Emit(Ldc_I4_S, (sbyte) 10);
            c.Emit(Ldc_I4_M1);
            c.Emit(Ldc_I4_M1);
            c.Emit(Ldc_I4_1);
            c.Emit(Ldc_R4, 1f);
            c.Emit(Ldc_R4, 0f);
            c.Emit(Call, typeof(Main).GetMethod("PlaySound", new[] {typeof(Int32), typeof(Int32), typeof(Int32), typeof(Int32), typeof(float), typeof(float)}));
            c.Emit(Pop);
            c.Emit(Ldc_I4_7);
            c.Emit(Stsfld, typeof(Main).GetField(nameof(Main.menuMode)));
            c.MarkLabel(endif);
            c.Emit(Ldloc_S, (byte) index9);
            c.Emit(Ldc_I4_1);
        }
    }
}