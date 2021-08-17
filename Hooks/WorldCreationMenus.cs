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
        public static bool finishedMenus = false;
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

            ILLabel nextMenu = c.DefineLabel();

            if (c.Next.Offset != 0)
            {
                c.EmitDelegate<Action>(() => {
                    Main.menuMode = 7;
                });
                c.Emit(OpCodes.Br, nextMenu);
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

            c.EmitDelegate<Func<bool>>(() => {
                if (!finishedMenus)
                {
                    EvilMenu();
                    return false;
                }
                else
                {
                    finishedMenus = false;
                    return true;
                }
            });
            ILLabel skip = c.DefineLabel();
            c.Emit(OpCodes.Brfalse, skip);
            if (!c.TryGotoNext(i => i.MatchLdcI4(888)))
                return;
            c.MarkLabel(skip);
        }
        public static void EvilMenu()
        {
            UIList optionsList = new UIList();
            optionsList.Add(new UI.ListItem(Language.GetTextValue("LegacyMisc.101"), TextureManager.Load("Images/UI/IconCorruption"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                WorldGen.WorldGenParam_Evil = 0;
                TropicsMenu();
            }));
            optionsList.Add(new UI.ListItem(Language.GetTextValue("LegacyMisc.102"), TextureManager.Load("Images/UI/IconCrimson"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                WorldGen.WorldGenParam_Evil = 1;
                TropicsMenu();
            }));
            optionsList.Add(new UI.ListItem("Contagion", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconContagion"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                WorldGen.WorldGenParam_Evil = 2;
                TropicsMenu();
            }));
            optionsList.Add(new UI.ListItem(Language.GetTextValue("LegacyMisc.103"), ExxoAvalonOrigins.mod.GetTexture("Sprites/IconRandom"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                WorldGen.WorldGenParam_Evil = -1;
                TropicsMenu();
            }));
            Main.MenuUI.SetState(new UI.GenericSelectionMenu(Language.GetTextValue("LegacyMisc.100"), optionsList, delegate {
                Main.PlaySound(SoundID.MenuClose);
                Main.menuMode = -7;
            }));
        }
        public static void TropicsMenu()
        {
            UIList optionsList = new UIList();
            optionsList.Add(new UI.ListItem("Jungle", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconJungle"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.jungle;
                OsmiumMenu();
            }));
            optionsList.Add(new UI.ListItem("Tropics", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconTropics"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.tropics;
                OsmiumMenu();
            }));
            optionsList.Add(new UI.ListItem("Random", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconRandom"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.random;
                OsmiumMenu();
            }));
            Main.MenuUI.SetState(new UI.GenericSelectionMenu("Choose World Wilderness", optionsList, delegate {
                Main.PlaySound(SoundID.MenuClose);
                EvilMenu();
            }));
        }
        public static void OsmiumMenu()
        {
            UIList optionsList = new UIList();
            optionsList.Add(new UI.ListItem("Rhodium", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconRhodium"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                ExxoAvalonOriginsWorld.osmiumOre = ExxoAvalonOriginsWorld.OsmiumVariant.rhodium;
                FinishedMenu();
            }));
            optionsList.Add(new UI.ListItem("Osmium", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconOsmium"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                ExxoAvalonOriginsWorld.osmiumOre = ExxoAvalonOriginsWorld.OsmiumVariant.osmium;
                FinishedMenu();
            }));
            optionsList.Add(new UI.ListItem("Iridium", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconIridium"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                ExxoAvalonOriginsWorld.osmiumOre = ExxoAvalonOriginsWorld.OsmiumVariant.iridium;
                FinishedMenu();
            }));
            optionsList.Add(new UI.ListItem("Random", ExxoAvalonOrigins.mod.GetTexture("Sprites/IconRandom"), delegate {
                Main.PlaySound(SoundID.MenuOpen);
                ExxoAvalonOriginsWorld.osmiumOre = ExxoAvalonOriginsWorld.OsmiumVariant.random;
                FinishedMenu();
            }));
            Main.MenuUI.SetState(new UI.GenericSelectionMenu("Choose World Shinies", optionsList, delegate {
                Main.PlaySound(SoundID.MenuClose);
                TropicsMenu();
            }));
        }
        public static void FinishedMenu()
        {
            Main.menuMode = 7;
            finishedMenus = true;
        }
    }
}