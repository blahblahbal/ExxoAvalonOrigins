namespace ExxoAvalonOrigins.Hooks
{
    public static class HooksManager
    {
        public static void Load()
        {
            ExtraHealth.Load();
        }
        public static void ApplyHooks()
        {
            On.Terraria.Lang.GetRandomGameTitle += EditTerrariaName.OnGetRandomGameTitle;
            On.Terraria.Player.HasUnityPotion += EideticMirror.OnHasUnityItem;
            On.Terraria.Player.TakeUnityPotion += EideticMirror.OnTakeUnityItem;
            On.Terraria.UI.ItemSlot.EquipPage += TomeEquip.OnEquipPage;
            On.Terraria.WorldGen.JungleRunner += JungleCoords.OnJungleRunner;
            TomeEquip.UpdateVanity += TomeEquip.OnUpdateVanity;
            On.Terraria.Main.DrawInterface_Resources_Life += ExtraHealth.OnDrawInterface_Resources_Life;
            On.Terraria.Main.DrawInterface_Resources_Mana += ExtraHealth.OnDrawInterface_Resources_Mana;
            IL.Terraria.Main.GUIBarsMouseOverMana += ExtraHealth.ILGUIBarsMouseOverMana;
            On.Terraria.Collision.HurtTiles += TrapCollision.OnHurtTiles;
            On.Terraria.WorldGen.SmashAltar += EvilAltar.OnSmashAltar;
            IL.Terraria.Main.DrawMenu += WorldCreationMenus.ILDrawMenu;
            IL.Terraria.Main.DrawPlayer += LargeGem.ILDrawPlayer;
            IL.Terraria.Player.SmartCursor_Torch += Torches.ILSmartCursor_Torch;
            On.Terraria.GameContent.UI.Elements.UIWorldListItem.GetIcon += WorldUI.OnGetIcon;
            On.Terraria.Main.EraseWorld += WorldUI.OnEraseWorld;
            IL.Terraria.GameContent.UI.Elements.UIGenProgressBar.DrawSelf += WorldUI.ILDrawSelf;
            On.Terraria.Player.PickAmmo += BuffEffects.OnPickAmmo;
            On.Terraria.Player.AddBuff += BuffEffects.OnAddBuff;
            On.Terraria.Player.OpenBossBag += BossBagDrops.OnOpenBossBag;
            IL.Terraria.Projectile.FishingCheck += BuffEffects.ILCatchFish;
            IL.Terraria.Player.Update += ExtraHealth.ILUpdate;
            IL.Terraria.Lang.GetDryadWorldStatusDialog += DryadText.ILDryadText;
            IL.Terraria.Main.DrawUnderworldBackground += CaesiumUnderworldBackground.ILDoSelf;
            //IL.Terraria.Main.OldDrawBackground += CaesiumUnderworldBackground.ILDoOld;

            IL.Terraria.WorldGen.generateWorld += GenPasses.ILGenerateWorld;

            GenPasses.Hook_GenPassReset += GenPasses.ILGenPassReset;
            GenPasses.Hook_GenPassDirtWallBackgrounds += Tropics.ILGenPassDirtWallBackgrounds;
            GenPasses.Hook_GenPassJungle += Tropics.ILGenPassJungle;
            GenPasses.Hook_GenPassCleanUpDirt += Tropics.ILCleanUpDirt;
            GenPasses.Hook_GenPassWetJungle += Tropics.ILWetJungle;
            GenPasses.Hook_GenPassMudWallsInJungle += Tropics.ILMudWallsInJungle;
            GenPasses.Hook_GenPassWallVariety += Tropics.ILWallVariety;
            GenPasses.Hook_GenPassIceWalls += Tropics.ILIceWalls;
            GenPasses.Hook_GenPassGrassWall += Tropics.ILGrassWall;
            GenPasses.Hook_GenPassJunglePlants += Tropics.ILJunglePlants;
            GenPasses.Hook_GenPassMudCavesToGrass += Tropics.ILMudCavesToGrass;
            IL.Terraria.WorldGen.TileRunner += Tropics.ILTileRunner;
            IL.Terraria.GameContent.Biomes.DesertBiome.FindStart += Tropics.ILFindStart;
            IL.Terraria.WorldGen.GrowUndergroundTree += Tropics.ILGrowUndergroundTree;
            On.Terraria.WorldGen.SpreadGrass += Tropics.OnSpreadGrass;
            On.Terraria.GameContent.Biomes.CaveHouseBiome.cctor += MicroBiomes.OnCaveHouseBiome;
            On.Terraria.Wiring.Actuate += Tropics.OnActuate;
            On.Terraria.Wiring.ActuateForced += Tropics.OnActuateForced;
            IL.Terraria.Wiring.HitWireSingle += Tropics.ILHitWireSingle;

            IL.Terraria.GameContent.Generation.TrackGenerator.CanTrackBePlaced += MicroBiomes.ILTrackGeneratorTrackCanBePlaced;
            IL.Terraria.GameContent.Biomes.MiningExplosivesBiome.Place += MicroBiomes.ILMiningExplosivesBiomePlace;

            IL.Terraria.WorldGen.Spread.Wall += Tropics.ILSpreadWall;
            IL.Terraria.WorldGen.Spread.Wall2 += Tropics.ILSpreadWall2;
            On.Terraria.WorldGen.TileRunner += BacciliteReplacement.OnTileRunner;
            On.Terraria.WorldGen.SquareTileFrame += TileCount.OnSquareTileFrame;
            IL.Terraria.NPC.AI_006_Worms += AIChanges.ILAI_006_Worms;

            On.Terraria.UI.Chat.ChatManager.DrawColorCodedStringWithShadow_SpriteBatch_DynamicSpriteFont_string_Vector2_Color_float_Vector2_Vector2_float_float += UIChanges.OnDrawColorCodedStringWithShadow;
            // Character list stamina stat addition
            IL.Terraria.GameContent.UI.Elements.UICharacterListItem.DrawSelf += UIChanges.ILUICharacterListItemDrawSelf;
            IL.Terraria.GameContent.UI.Elements.UICharacterListItem.ctor += UIChanges.ILUICharacterListItemCtor;
            On.Terraria.Main.DrawInterface += UIChanges.OnMainDrawInterface;
            IL.Terraria.UI.UserInterface.Update += UIChanges.ILUserInterfaceUpdate;
            IL.Terraria.UI.UIElement.GetElementAt += UIChanges.ILUIElementGetElementAt;
            IL.Terraria.UI.UIElement.Recalculate += UIChanges.ILUIElementRecalculate;
            IL.Terraria.UI.UIElement.GetClippingRectangle += UIChanges.ILUIElementGetClippingRectangle;
            IL.Terraria.UI.UIElement.Draw += UIChanges.ILUIElementDraw;
            On.Terraria.UI.UIElement.Remove += UIChanges.OnUIElementRemove;
            On.Terraria.Main.DrawInventory += UIChanges.OnMainDrawInventory;
            On.Terraria.Utils.DrawBorderString += UIChanges.OnUtilsDrawBorderString;
            On.Terraria.Utils.DrawBorderStringBig += UIChanges.OnUtilsDrawBorderStringBig;
        }
    }
}
