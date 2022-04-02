using System;
using ExxoAvalonOrigins.UI;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Hooks;

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
        c.EmitDelegate<Action>(() =>
        {
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
        if (c.Instrs[c.Index - 2].MatchCallvirt(out _) && c.Instrs[c.Index - 3].MatchCall(out _) && c.Instrs[c.Index - 4].MatchLdcI4(out _) && c.Instrs[c.Index - 5].MatchNop())
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
        c.EmitDelegate<Func<bool>>(() =>
        {
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
                ShinyMenu();
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
        optionsList.Add(new ListItem(Language.GetTextValue("LegacyMisc.101"), ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Images/UI/IconCorruption"), delegate
        {
            WorldGen.WorldGenParam_Evil = 0;
            TropicsMenu();
        }));
        optionsList.Add(new ListItem(Language.GetTextValue("LegacyMisc.102"), ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Images/UI/IconCrimson"), delegate
        {
            WorldGen.WorldGenParam_Evil = 1;
            TropicsMenu();
        }));
        optionsList.Add(new ListItem("Contagion", ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconContagion").Value, delegate
        {
            WorldGen.WorldGenParam_Evil = 2;
            TropicsMenu();
        }));
        optionsList.Add(new ListItem(Language.GetTextValue("LegacyMisc.103"), ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconRandom").Value, delegate
        {
            WorldGen.WorldGenParam_Evil = -1;
            TropicsMenu();
        }));
        Main.MenuUI.SetState(new GenericSelectionMenu(Language.GetTextValue("LegacyMisc.100"), optionsList, delegate
        {
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
        optionsList.Add(new ListItem("Jungle", ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconJungle").Value, delegate
        {
            ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.jungle;
            ShinyMenu();
        }));
        optionsList.Add(new ListItem("Tropics", ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconTropics").Value, delegate
        {
            ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.tropics;
            ShinyMenu();
        }));
        optionsList.Add(new ListItem("Random", ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconRandom").Value, delegate
        {
            ExxoAvalonOriginsWorld.jungleMenuSelection = ExxoAvalonOriginsWorld.JungleVariant.random;
            ShinyMenu();
        }));
        Main.MenuUI.SetState(new GenericSelectionMenu("Pick World Wilderness", optionsList, delegate
        {
            EvilMenu();
        }));
    }

    private static void ShinyMenu()
    {
        UIList optionsList = new UIList();
        UIListGrid list;

        #region copper

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconCopper").Value, "Copper", delegate
        {
            ExxoAvalonOriginsWorld.copperOre = ExxoAvalonOriginsWorld.CopperVariant.copper;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconTin").Value, "Tin", delegate
        {
            ExxoAvalonOriginsWorld.copperOre = ExxoAvalonOriginsWorld.CopperVariant.tin;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconBronze").Value, "Bronze", delegate
        {
            ExxoAvalonOriginsWorld.copperOre = ExxoAvalonOriginsWorld.CopperVariant.bronze;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.copperOre = ExxoAvalonOriginsWorld.CopperVariant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Copper Tier Ore", list));

        #endregion

        #region iron

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconIron").Value, "Iron", delegate
        {
            ExxoAvalonOriginsWorld.ironOre = ExxoAvalonOriginsWorld.IronVariant.iron;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconLead").Value, "Lead", delegate
        {
            ExxoAvalonOriginsWorld.ironOre = ExxoAvalonOriginsWorld.IronVariant.lead;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconNickel").Value, "Nickel", delegate
        {
            ExxoAvalonOriginsWorld.ironOre = ExxoAvalonOriginsWorld.IronVariant.nickel;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.ironOre = ExxoAvalonOriginsWorld.IronVariant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Iron Tier Ore", list));

        #endregion

        #region silver

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconSilver").Value, "Silver", delegate
        {
            ExxoAvalonOriginsWorld.silverOre = ExxoAvalonOriginsWorld.SilverVariant.silver;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconTungsten").Value, "Tungsten", delegate
        {
            ExxoAvalonOriginsWorld.silverOre = ExxoAvalonOriginsWorld.SilverVariant.tungsten;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconZinc").Value, "Zinc", delegate
        {
            ExxoAvalonOriginsWorld.silverOre = ExxoAvalonOriginsWorld.SilverVariant.zinc;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.silverOre = ExxoAvalonOriginsWorld.SilverVariant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Silver Tier Ore", list));

        #endregion

        #region gold

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconGold").Value, "Gold", delegate
        {
            ExxoAvalonOriginsWorld.goldOre = ExxoAvalonOriginsWorld.GoldVariant.gold;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconPlatinum").Value, "Platinum", delegate
        {
            ExxoAvalonOriginsWorld.goldOre = ExxoAvalonOriginsWorld.GoldVariant.platinum;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconBismuth").Value, "Bismuth", delegate
        {
            ExxoAvalonOriginsWorld.goldOre = ExxoAvalonOriginsWorld.GoldVariant.bismuth;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.goldOre = ExxoAvalonOriginsWorld.GoldVariant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Gold Tier Ore", list));

        #endregion

        #region rhodium

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconRhodium").Value, "Rhodium", delegate
        {
            ExxoAvalonOriginsWorld.rhodiumOre = ExxoAvalonOriginsWorld.RhodiumVariant.rhodium;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOsmium").Value, "Osmium", delegate
        {
            ExxoAvalonOriginsWorld.rhodiumOre = ExxoAvalonOriginsWorld.RhodiumVariant.osmium;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconIridium").Value, "Iridium", delegate
        {
            ExxoAvalonOriginsWorld.rhodiumOre = ExxoAvalonOriginsWorld.RhodiumVariant.iridium;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.rhodiumOre = ExxoAvalonOriginsWorld.RhodiumVariant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Rhodium Tier Ore", list));

        #endregion

        #region cobalt

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconCobalt").Value, "Cobalt", delegate
        {
            ExxoAvalonOriginsWorld.cobaltOre = ExxoAvalonOriginsWorld.CobaltVariant.cobalt;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconPalladium").Value, "Palladium", delegate
        {
            ExxoAvalonOriginsWorld.cobaltOre = ExxoAvalonOriginsWorld.CobaltVariant.palladium;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconDuratanium").Value, "Duratanium", delegate
        {
            ExxoAvalonOriginsWorld.cobaltOre = ExxoAvalonOriginsWorld.CobaltVariant.duratanium;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.cobaltOre = ExxoAvalonOriginsWorld.CobaltVariant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Cobalt Tier Ore", list));

        #endregion

        #region mythril

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconMythril").Value, "Mythril", delegate
        {
            ExxoAvalonOriginsWorld.mythrilOre = ExxoAvalonOriginsWorld.MythrilVariant.mythril;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOrichalcum").Value, "Orichalcum", delegate
        {
            ExxoAvalonOriginsWorld.mythrilOre = ExxoAvalonOriginsWorld.MythrilVariant.orichalcum;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconNaquadah").Value, "Naquadah", delegate
        {
            ExxoAvalonOriginsWorld.mythrilOre = ExxoAvalonOriginsWorld.MythrilVariant.naquadah;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.mythrilOre = ExxoAvalonOriginsWorld.MythrilVariant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Mythril Tier Ore", list));

        #endregion

        #region adamantite

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconAdamantite").Value, "Adamantite", delegate
        {
            ExxoAvalonOriginsWorld.adamantiteOre = ExxoAvalonOriginsWorld.AdamantiteVariant.adamantite;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconTitanium").Value, "Titanium", delegate
        {
            ExxoAvalonOriginsWorld.adamantiteOre = ExxoAvalonOriginsWorld.AdamantiteVariant.titanium;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconTroxinium").Value, "Troxinium", delegate
        {
            ExxoAvalonOriginsWorld.adamantiteOre = ExxoAvalonOriginsWorld.AdamantiteVariant.troxinium;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.adamantiteOre = ExxoAvalonOriginsWorld.AdamantiteVariant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Adamantite Tier Ore", list));

        #endregion

        #region SHM Tier 1

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconTritanorium").Value, "Tritanorium", delegate
        {
            ExxoAvalonOriginsWorld.shmTier1Ore = ExxoAvalonOriginsWorld.SHMTier1Variant.tritanorium;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconPyroscoric").Value, "Pyroscoric", delegate
        {
            ExxoAvalonOriginsWorld.shmTier1Ore = ExxoAvalonOriginsWorld.SHMTier1Variant.pyroscoric;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.shmTier1Ore = ExxoAvalonOriginsWorld.SHMTier1Variant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Super Hardmode Tier 1 Ore", list));

        #endregion

        #region SHM Tier 2

        list = new UIListGrid();
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconUnvolandite").Value, "Unvolandite", delegate
        {
            ExxoAvalonOriginsWorld.shmTier2Ore = ExxoAvalonOriginsWorld.SHMTier2Variant.unvolandite;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconVorazylcum").Value, "Vorazylcum", delegate
        {
            ExxoAvalonOriginsWorld.shmTier2Ore = ExxoAvalonOriginsWorld.SHMTier2Variant.vorazylcum;
        }));
        list.Add(new UIImageButtonCustom(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/IconOreRandom").Value, "Random", delegate
        {
            ExxoAvalonOriginsWorld.shmTier2Ore = ExxoAvalonOriginsWorld.SHMTier2Variant.random;
        }, true));
        optionsList.Add(new ListItemSelection("Super Hardmode Tier 2 Ore", list));

        #endregion

        Main.MenuUI.SetState(new GenericSelectionMenu("Pick World Shinies", optionsList, delegate
            {
                TropicsMenu();
            },
            delegate
            {
                FinishedMenu();
            }));
    }

    private static void FinishedMenu()
    {
        skipMenus = true;
        finishedMenus = true;
        Main.menuMode = 7;
    }
}
