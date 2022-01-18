using System;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour.HookGen;
using Terraria;

namespace ExxoAvalonOrigins.Hooks
{
    class GenPasses
    {
        private static Assembly assembly;
        private static MethodInfo resetInfo;
        private static MethodInfo dirtWallBackgroundsInfo;
        private static MethodInfo jungleInfo;
        private static MethodInfo cleanUpDirtInfo;
        private static MethodInfo wetJungleInfo;
        private static MethodInfo mudWallsInJungleInfo;
        private static MethodInfo wallVarietyInfo;
        private static MethodInfo iceWallsInfo;
        private static MethodInfo grassWallInfo;
        private static MethodInfo junglePlantsInfo;
        private static MethodInfo mudCavesToGrassInfo;
        private static MethodInfo potsInfo;
        private static MethodInfo pilesInfo;
        public static event ILContext.Manipulator Hook_GenPassReset
        {
            add => HookEndpointManager.Modify(resetInfo, value);
            remove => HookEndpointManager.Unmodify(resetInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassDirtWallBackgrounds
        {
            add => HookEndpointManager.Modify(dirtWallBackgroundsInfo, value);
            remove => HookEndpointManager.Unmodify(dirtWallBackgroundsInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassJungle
        {
            add => HookEndpointManager.Modify(jungleInfo, value);
            remove => HookEndpointManager.Unmodify(jungleInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassCleanUpDirt
        {
            add => HookEndpointManager.Modify(cleanUpDirtInfo, value);
            remove => HookEndpointManager.Unmodify(cleanUpDirtInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassWetJungle
        {
            add => HookEndpointManager.Modify(wetJungleInfo, value);
            remove => HookEndpointManager.Unmodify(wetJungleInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassMudWallsInJungle
        {
            add => HookEndpointManager.Modify(mudWallsInJungleInfo, value);
            remove => HookEndpointManager.Unmodify(mudWallsInJungleInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassWallVariety
        {
            add => HookEndpointManager.Modify(wallVarietyInfo, value);
            remove => HookEndpointManager.Unmodify(wallVarietyInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassIceWalls
        {
            add => HookEndpointManager.Modify(iceWallsInfo, value);
            remove => HookEndpointManager.Unmodify(iceWallsInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassGrassWall
        {
            add => HookEndpointManager.Modify(grassWallInfo, value);
            remove => HookEndpointManager.Unmodify(grassWallInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassJunglePlants
        {
            add => HookEndpointManager.Modify(junglePlantsInfo, value);
            remove => HookEndpointManager.Unmodify(junglePlantsInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassMudCavesToGrass
        {
            add => HookEndpointManager.Modify(mudCavesToGrassInfo, value);
            remove => HookEndpointManager.Unmodify(mudCavesToGrassInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassPots
        {
            add => HookEndpointManager.Modify(potsInfo, value);
            remove => HookEndpointManager.Unmodify(potsInfo, value);
        }
        public static event ILContext.Manipulator Hook_GenPassPiles
        {
            add => HookEndpointManager.Modify(pilesInfo, value);
            remove => HookEndpointManager.Unmodify(pilesInfo, value);
        }
        public static void ILGenerateWorld(ILContext il)
        {
            assembly = typeof(Main).Assembly;

            resetInfo = GetGenPassInfo(il, "Reset");
            dirtWallBackgroundsInfo = GetGenPassInfo(il, "Dirt Wall Backgrounds");
            jungleInfo = GetGenPassInfo(il, "Jungle");
            cleanUpDirtInfo = GetGenPassInfo(il, "Clean Up Dirt");
            wetJungleInfo = GetGenPassInfo(il, "Wet Jungle");
            mudWallsInJungleInfo = GetGenPassInfo(il, "Muds Walls In Jungle");
            wallVarietyInfo = GetGenPassInfo(il, "Wall Variety");
            iceWallsInfo = GetGenPassInfo(il, "Ice Walls");
            grassWallInfo = GetGenPassInfo(il, "Grass Wall");
            junglePlantsInfo = GetGenPassInfo(il, "Jungle Plants");
            mudCavesToGrassInfo = GetGenPassInfo(il, "Mud Caves To Grass");
            potsInfo = GetGenPassInfo(il, "Pots");
            pilesInfo = GetGenPassInfo(il, "Piles");
        }
        public static void ILGenPassReset(ILContext il)
        {
            var c = new ILCursor(il);
            int endCrimsonIndex = 0;

            if (!c.TryGotoNext(i => i.MatchStsfld<WorldGen>(nameof(WorldGen.crimson))))
                return;
            if (!c.TryGotoNext(i => i.MatchLdfld(out _)))
                return;
            if (!c.TryGotoPrev(i => i.MatchStsfld<WorldGen>(nameof(WorldGen.crimson))))
                return;

            endCrimsonIndex = c.Index + 1;

            if (!c.TryGotoPrev(i => i.MatchCallvirt(out _)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(0)))
                return;

            c.RemoveRange(endCrimsonIndex - c.Index);
            c.Emit(OpCodes.Pop);

            FieldReference dungeonSideField = null;

            if (!c.TryGotoNext(i => i.MatchRet()))
                return;
            if (!c.TryGotoPrev(i => i.MatchStfld(out dungeonSideField)))
                return;
            if (!c.TryGotoNext(i => i.MatchRet()))
                return;

            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldfld, dungeonSideField);
            c.EmitDelegate<Action<int>>((dungeonSide) =>
            {
                ExxoAvalonOriginsWorld.dungeonSide = dungeonSide;
            });
        }
        private static MethodInfo GetGenPassInfo(ILContext il, string name)
        {
            var c = new ILCursor(il);

            MethodReference methodReference = null;
            Type type;

            if (!c.TryGotoNext(i => i.MatchLdstr(name)))
                return null;
            if (!c.TryGotoNext(i => i.MatchLdftn(out methodReference)))
                return null;

            type = assembly.GetType("Terraria.WorldGen+" + methodReference.DeclaringType.Name);
            return type.GetMethod(methodReference.Name, BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }
}
