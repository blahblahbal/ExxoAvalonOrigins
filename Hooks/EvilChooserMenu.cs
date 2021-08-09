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

namespace ExxoAvalonOrigins.Hooks
{
    public class EvilChooserMenu
    {        
        public static void ILDrawMenu(ILContext il)
        {
            var c = new ILCursor(il);

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdcI4(-71)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdloc(26)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdloc(26)))
                return;
            if (!c.TryGotoPrev(i => i.MatchStelemI4()))
                return;
            int num = -1;
            int index = -1;
            if (!c.TryGotoPrev(i => i.MatchLdcI4(out num)))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdcI4(out index)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(num)))
                return;

            // Automatically shift cursor after each emit
            c.MoveAfterLabels();

            c.Remove();
            c.Emit(Ldc_I4, 30);
            if (!c.TryGotoNext(i => i.MatchStelemI4()))
                return;

            c.Emit(Ldloc, 19);
            c.Emit(Ldc_I4, index + 1);
            c.Emit(Ldc_I4, num);
            c.Emit(Stelem_I4);

            if (!c.TryGotoNext(i => i.MatchLdcI4(index + 1)))
                return;
            c.Remove();
            c.Emit(Ldc_I4, index + 2);

            FieldReference selectedMenu = null;
            
            if (!c.TryGotoNext(i => i.MatchLdstr("UI.Back")))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdfld(out selectedMenu)))
                return;
            if (!c.TryGotoPrev(i => i.MatchAdd()))
                return;

            c.Emit(Add);
            c.Emit(Stloc, 47);
            //FOR SOME CURSED REASON IT MUST BE BETWEEN THE ADD

            c.Emit(Ldloc, 26);
            c.Emit(Ldloc, 47);
            c.Emit(Ldarg_0);
            c.Emit(Ldfld, selectedMenu);
            c.EmitDelegate<Action< String[],int, int>>((butt,num17, val) =>
            {
                butt[num17] = "Contagion";
                if (val == num17)
                {
                    WorldGen.WorldGenParam_Evil = 2;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                    Main.menuMode = 7;
                }
            });

            //FOR SOME CURSED REASON IT MUST BE BETWEEN THE ADD
            c.Emit(Ldloc, 47);
            c.Emit(Ldc_I4, 1);
        }
    }
}