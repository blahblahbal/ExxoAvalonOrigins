namespace ExxoAvalonOrigins.Hooks
{
    class Hooks
    {
        public static void AddHooks()
        {
            On.Terraria.Lang.GetRandomGameTitle += EditTerrariaName.OnGetRandomGameTitle;
            On.Terraria.Player.HasUnityPotion += EideticMirror.OnHasUnityItem;
            On.Terraria.Player.TakeUnityPotion += EideticMirror.OnTakeUnityItem;
            On.Terraria.UI.ItemSlot.EquipPage += TomeEquip.OnEquipPage;
            On.Terraria.WorldGen.JungleRunner += JungleCoords.OnJungleRunner;
            TomeEquip.UpdateVanity += TomeEquip.OnUpdateVanity;
            On.Terraria.Main.DrawInterface_Resources_Life += ExtraHealth.OnDrawInterface_Resources_Life;
            On.Terraria.Main.DrawInterface_Resources_Mana += ExtraHealth.OnDrawInterface_Resources_Mana;
            On.Terraria.Collision.HurtTiles += TrapCollision.OnHurtTiles;
            On.Terraria.WorldGen.SmashAltar += EvilAltar.OnSmashAltar;
            IL.Terraria.Main.DrawMenu += WorldCreationMenus.ILDrawMenu;
            IL.Terraria.Main.DrawPlayer += LargeGem.ILDrawPlayer;
            IL.Terraria.Player.SmartCursor_Torch += Torches.ILSmartCursor_Torch;
            On.Terraria.GameContent.UI.Elements.UIWorldListItem.GetIcon += UIMenuContagion.OnGetIcon;
            On.Terraria.Main.EraseWorld += UIMenuContagion.OnEraseWorld;
            IL.Terraria.GameContent.UI.Elements.UIGenProgressBar.DrawSelf += UIMenuContagion.ILDrawSelf;
            On.Terraria.Player.PickAmmo += BuffEffects.OnPickAmmo;
            IL.Terraria.Projectile.FishingCheck += BuffEffects.ILCatchFish;
            IL.Terraria.Player.Update += ExtraHealth.ILUpdate;

            IL.Terraria.WorldGen.generateWorld += GenPasses.ILGenerateWorld;

            GenPasses.Hook_GenPassReset += GenPasses.ILGenPassReset;
            GenPasses.Hook_GenPassDirtWallBackgrounds += Tropics.ILGenPassDirtWallBackgrounds;
            GenPasses.Hook_GenPassJungle += Tropics.ILGenPassJungle;
            GenPasses.Hook_GenPassCleanUpDirt += Tropics.ILCleanUpDirt;
            GenPasses.Hook_GenPassWetJungle += Tropics.ILWetJungle;
            GenPasses.Hook_GenPassMudWallsInJungle += Tropics.ILMudWallsInJungle;
            GenPasses.Hook_GenPassWallVariety += Tropics.ILWallVariety;
            //GenPasses.Hook_GenPassIceWalls += Tropics.ILIceWalls;
            GenPasses.Hook_GenPassGrassWall += Tropics.ILGrassWall;
            GenPasses.Hook_GenPassJunglePlants += Tropics.ILJunglePlants;
            GenPasses.Hook_GenPassMudCavesToGrass += Tropics.ILMudCavesToGrass;
            IL.Terraria.WorldGen.TileRunner += Tropics.ILTileRunner;
            IL.Terraria.GameContent.Biomes.DesertBiome.FindStart += Tropics.ILFindStart;
            IL.Terraria.WorldGen.GrowUndergroundTree += Tropics.ILGrowUndergroundTree;
            On.Terraria.WorldGen.SpreadGrass += Tropics.OnSpreadGrass;

            On.Terraria.WorldGen.Spread.Wall2 += Tropics.OnSpreadWall2;
            On.Terraria.WorldGen.TileRunner += BacciliteReplacement.OnTileRunner;
        }
    }
}
