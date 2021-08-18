using System;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.Graphics;
using Terraria.Localization;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;

namespace ExxoAvalonOrigins.Hooks
{
    public class WorldCreationMenus
    {        
        private static bool finishedMenus;
        private static bool runBeforeMenus;
        private static bool skipMenus;
        private static int count;
        private static bool isFirst;
        private static readonly bool replacingEvilMenu = true;
        public static void ILDrawMenu(ILContext il)
        {
            var c = new ILCursor(il);

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdloc(47)))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdcI4(-71)))
                return;
            if (!c.TryGotoNext(i => i.MatchBneUn(out _)))
                return;
            c.Index++;

            // Reset variables and go to menumode that we've centred our logic around
            c.EmitDelegate<Action>(() => {
                finishedMenus = false;
                runBeforeMenus = true;
                isFirst = false;
                count = 0;
                skipMenus = false;
                if (replacingEvilMenu)
                {
                    Main.menuMode = 7;
                }
            });

            ILLabel nextMenu = c.DefineLabel();

            // Skip all vanilla evil menu logic
            if (replacingEvilMenu)
            {
                if (!(c.Instrs[c.Index].MatchLdcI4(out _) &&
                    c.Instrs[c.Index + 1].MatchCall(out _) &&
                    c.Instrs[c.Index + 2].MatchCallvirt(out _) &&
                    c.Instrs[c.Index + 3].MatchBr(out _)))
                {
                    c.Emit(OpCodes.Br, nextMenu);
                }
            }

            if (!c.TryGotoNext(i => i.MatchCall(typeof(Main).GetMethod(nameof(Main.clrInput)))))
                return;
            c.MarkLabel(nextMenu);

            if (!c.TryGotoNext(i => i.MatchLdcI4(7)))
                return;
            if (!c.TryGotoNext(i => i.MatchBneUn(out _)))
                return;

            if (!c.TryGotoNext(i => i.MatchLdsfld(out _)))
                return;

            ILLabel skipMenu = c.DefineLabel();

            // Check for another delegate and unique nop placed before to signify another mods ui to work around
            if (c.Instrs[c.Index-2].MatchCallvirt(out _) && c.Instrs[c.Index-3].MatchCall(out _) && c.Instrs[c.Index-4].MatchLdcI4(out _) && c.Instrs[c.Index-5].MatchNop())
            {
                if (!c.TryGotoPrev(i => i.MatchLdcI4(out _)))
                    return;
                // Allows control over if the previous menu should be skipped or not
                c.EmitDelegate<Func<bool>>(() =>
                {
                    return runBeforeMenus;
                });
                c.Emit(OpCodes.Brfalse, skipMenu);

                if (!c.TryGotoNext(i => i.MatchLdsfld(out _)))
                    return;
            }

            // Main menu logic
            c.MarkLabel(skipMenu);
            c.Emit(OpCodes.Nop);
            c.EmitDelegate<Func<bool>>(() => {
                runBeforeMenus = false;
                // Determines if this is the first menu element by if it hasn't been skipped by any other ui before running
                if (count == 0)
                {
                    isFirst = true;
                }

                // Used to move logic to the next menu ui so that it can lock this method out of operation
                if (skipMenus)
                {
                    skipMenus = false;
                    return true;
                }

                if (!finishedMenus)
                {
                    // First menu to run
                    EvilMenu();
                    return false;
                }
                else
                {
                    // Last menu if mod menu ahead decides go back from their position ahead and call this method
                    finishedMenus = false;
                    OsmiumMenu();
                    return false;
                }
            });

            ILLabel skip = c.DefineLabel();
            // Skip to end of sequence if returning false 
            c.Emit(OpCodes.Brfalse, skip);
            if (!c.TryGotoNext(i => i.MatchLdcI4(888)))
                return;
            c.MarkLabel(skip);
            c.Index++;
            // Incrementing count every time a ui menu has been called
            c.EmitDelegate<Action>(() =>
            {
                count++;
            });
        }
        private static void EvilMenu()
        {
            UIList optionsList = new UIList();
            optionsList.Add(new UI.ListItem(Language.GetTextValue("LegacyMisc.101"), TextureManager.Load("Images/UI/IconCorruption"), delegate {
                WorldGen.WorldGenParam_Evil = 0;
                TropicsMenu();
            }));
            optionsList.Add(new UI.ListItem(Language.GetTextValue("LegacyMisc.102"), TextureManager.Load("Images/UI/IconCrimson"), delegate {
                WorldGen.WorldGenParam_Evil = 1;
                TropicsMenu();
            }));
            optionsList.Add(new UI.ListItem("Contagion", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconContagion"), delegate {
                WorldGen.WorldGenParam_Evil = 2;
                TropicsMenu();
            }));
            optionsList.Add(new UI.ListItem(Language.GetTextValue("LegacyMisc.103"), ExxoAvalonOrigins.mod.GetTexture("Sprites/IconRandom"), delegate {
                WorldGen.WorldGenParam_Evil = -1;
                TropicsMenu();
            }));
            Main.MenuUI.SetState(new UI.GenericSelectionMenu(Language.GetTextValue("LegacyMisc.100"), optionsList, delegate {
                if (isFirst)
                {
                    Main.menuMode = -7;
                }
                else
                {
                    runBeforeMenus = true;
                    Main.menuMode = 7;
                }
            }));
        }
        private static void TropicsMenu()
        {
            UIList optionsList = new UIList();
            optionsList.Add(new UI.ListItem("Jungle", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconJungle"), delegate {
                ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.jungle;
                OsmiumMenu();
            }));
            optionsList.Add(new UI.ListItem("Tropics", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconTropics"), delegate {
                ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.tropics;
                OsmiumMenu();
            }));
            optionsList.Add(new UI.ListItem("Random", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconRandom"), delegate {
                ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.random;
                OsmiumMenu();
            }));
            Main.MenuUI.SetState(new UI.GenericSelectionMenu("Pick World Wilderness", optionsList, delegate {
                EvilMenu();
            }));
        }
        private static void OsmiumMenu()
        {
            UIList optionsList = new UIList();
            optionsList.Add(new UI.ListItem("Rhodium", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconRhodium"), delegate {
                ExxoAvalonOriginsWorld.osmiumOre = ExxoAvalonOriginsWorld.OsmiumVariant.rhodium;
                FinishedMenu();
            }));
            optionsList.Add(new UI.ListItem("Osmium", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconOsmium"), delegate {
                ExxoAvalonOriginsWorld.osmiumOre = ExxoAvalonOriginsWorld.OsmiumVariant.osmium;
                FinishedMenu();
            }));
            optionsList.Add(new UI.ListItem("Iridium", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconIridium"), delegate {
                ExxoAvalonOriginsWorld.osmiumOre = ExxoAvalonOriginsWorld.OsmiumVariant.iridium;
                FinishedMenu();
            }));
            optionsList.Add(new UI.ListItem("Random", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconOreRandom"), delegate {
                ExxoAvalonOriginsWorld.osmiumOre = ExxoAvalonOriginsWorld.OsmiumVariant.random;
                FinishedMenu();
            }));
            Main.MenuUI.SetState(new UI.GenericSelectionMenu("Pick World Shinies", optionsList, delegate {
                TropicsMenu();
            }));
        }
        private static void FinishedMenu()
        {
            skipMenus = true;
            finishedMenus = true;
            Main.menuMode = 7;
        }
    }
}