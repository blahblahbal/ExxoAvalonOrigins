using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour.HookGen;
using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    class MicroBiomes
    {
        public static void ILTrackGeneratorTrackCanBePlaced(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(i => i.MatchLdelemU1()))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdsfld(out _)))
                return;

            Utils.SoftReplaceAllMatchingInstructionsWithMethod(il, c.Next, typeof(MicroBiomes).GetMethod(nameof(ReturnInvalidWalls)));

            Instruction i1 = Instruction.Create(OpCodes.Ldelem_U1);
            Instruction i2 = Instruction.Create(OpCodes.Ldelem_U2);

            Utils.HardReplaceAllMatchingInstructions(il, i1, i2);
        }
        public static ushort[] ReturnInvalidWalls()
        {
            return new ushort[]
                {
                    7, 94, 95, 8, 98, 99, 9, 96, 97, 3,
                    83, 87, (ushort)ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>(), 86
                };
        }
    }
}
