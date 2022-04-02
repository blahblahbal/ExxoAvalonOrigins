using System;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks;

class MicroBiomes
{
    private static readonly ushort[] invalidWalls = new ushort[]
    {
        7, 94, 95, 8, 98, 99, 9, 96, 97, 3,
        83, 87, (ushort) ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>(), 86
    };

    public static void ILTrackGeneratorTrackCanBePlaced(ILContext il)
    {
        var c = new ILCursor(il);

        if (!c.TryGotoNext(i => i.MatchLdelemU1()))
            return;
        if (!c.TryGotoPrev(i => i.MatchLdsfld(out _)))
            return;

        Utils.SoftReplaceAllMatchingInstructionsWithMethod(il, c.Next, typeof(MicroBiomes).GetMethod(nameof(ReturnInvalidWalls)));

        if (!c.TryGotoNext(i => i.MatchLdelemU1()))
            return;

        c.Remove();
        c.Emit(OpCodes.Ldelem_U2);
    }

    public static ushort[] ReturnInvalidWalls()
    {
        return invalidWalls;
    }

    public static void ILMiningExplosivesBiomePlace(ILContext il)
    {
        var c = new ILCursor(il);

        if (!c.TryGotoNext(i => i.MatchConvU2()))
            return;
        if (!c.TryGotoNext(i => i.MatchStelemI2()))
            return;

        c.Emit(OpCodes.Pop);
        c.EmitDelegate<Func<ushort>>(() =>
        {
            return WorldGen.SavedOreTiers.Gold;
        });

        if (!c.TryGotoNext(i => i.MatchConvU2()))
            return;
        if (!c.TryGotoNext(i => i.MatchStelemI2()))
            return;

        c.Emit(OpCodes.Pop);
        c.EmitDelegate<Func<ushort>>(() =>
        {
            return WorldGen.SavedOreTiers.Silver;
        });

        if (!c.TryGotoNext(i => i.MatchConvU2()))
            return;
        if (!c.TryGotoNext(i => i.MatchStelemI2()))
            return;

        c.Emit(OpCodes.Pop);
        c.EmitDelegate<Func<ushort>>(() =>
        {
            return WorldGen.SavedOreTiers.Iron;
        });

        if (!c.TryGotoNext(i => i.MatchConvU2()))
            return;
        if (!c.TryGotoNext(i => i.MatchStelemI2()))
            return;

        c.Emit(OpCodes.Pop);
        c.EmitDelegate<Func<ushort>>(() =>
        {
            return WorldGen.SavedOreTiers.Copper;
        });
    }

    public static void OnCaveHouseBiome(On.Terraria.GameContent.Biomes.CaveHouseBiome.orig_cctor orig)
    {
        orig();
        Terraria.GameContent.Biomes.CaveHouseBiome._blacklistedTiles = Terraria.ID.TileID.Sets.Factory.CreateBoolSet(true, 225, 41, 43, 44, 226, ModContent.TileType<Tiles.TuhrtlBrick>(), 203, 112, 25, 151);
    }
}
