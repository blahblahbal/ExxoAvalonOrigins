using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Hooks;
public class DeathMessages
{
    public static NetworkText OnCreateDeathMessage(On.Terraria.Lang.orig_CreateDeathMessage orig, string deadPlayerName, int plr = -1, int npc = -1, int proj = -1, int other = -1, int projType = 0, int plrItemType = 0)
    {
        NetworkText networkText = NetworkText.Empty;
        NetworkText networkText2 = NetworkText.Empty;
        NetworkText networkText3 = NetworkText.Empty;
        NetworkText networkText4 = NetworkText.Empty;
        if (proj >= 0)
        {
            networkText = NetworkText.FromKey(Lang.GetProjectileName(projType).Key);
        }
        if (npc >= 0)
        {
            networkText2 = Main.npc[npc].GetGivenOrTypeNetName();
        }
        if (plr >= 0 && plr < 255)
        {
            networkText3 = NetworkText.FromLiteral(Main.player[plr].name);
        }
        if (plrItemType >= 0)
        {
            networkText4 = NetworkText.FromKey(Lang.GetItemName(plrItemType).Key);
        }
        bool flag = networkText != NetworkText.Empty;
        bool flag2 = plr >= 0 && plr < 255;
        bool flag3 = networkText2 != NetworkText.Empty;
        NetworkText result = NetworkText.Empty;
        NetworkText empty = NetworkText.Empty;
        empty = NetworkText.FromKey(Language.RandomFromCategory("DeathTextGeneric").Key, deadPlayerName, Main.worldName);
        if (Main.rand.Next(4) == 0)
        {
            int msg = Main.rand.Next(4);
            if (msg == 0)
            {
                empty = NetworkText.FromLiteral(deadPlayerName + " was tickled to smithereens");
            }
            if (msg == 1)
            {
                empty = NetworkText.FromLiteral(deadPlayerName + " was reduced to a fine paste");
            }
            if (msg == 2)
            {
                empty = NetworkText.FromLiteral(deadPlayerName + " became a tombstone dispenser");
            }
            if (msg == 3)
            {
                empty = NetworkText.FromLiteral(deadPlayerName + ".exe has stopped working. Program was closed");
            }
        }
        if (flag2)
        {
            result = NetworkText.FromKey("DeathSource.Player", empty, networkText3, flag ? networkText : networkText4);
        }
        else if (flag3)
        {
            result = NetworkText.FromKey("DeathSource.NPC", empty, networkText2);
        }
        else if (flag)
        {
            result = NetworkText.FromKey("DeathSource.Projectile", empty, networkText);
        }
        else
        {
            #region falling
            if (other == 0)
            {
                int rn = Main.rand.Next(9) + 1;
                switch (rn)
                {
                    case 1:
                        result = NetworkText.FromKey("DeathText.Fell_1", deadPlayerName);
                        break;
                    case 2:
                        result = NetworkText.FromKey("DeathText.Fell_2", deadPlayerName);
                        break;
                    case 3:
                        result = NetworkText.FromLiteral(deadPlayerName + " made a satisfying SPLAT when they hit the ground.");
                        break;
                    case 4:
                        result = NetworkText.FromLiteral(deadPlayerName + " took a leap of faith...");
                        break;
                    case 5:
                        result = NetworkText.FromLiteral(deadPlayerName + ", gravity sucks, y'know?");
                        break;
                    case 6:
                        result = NetworkText.FromLiteral(deadPlayerName + " dreamt of flying.");
                        break;
                    case 7:
                        result = NetworkText.FromLiteral(deadPlayerName + " is literally six feet under.");
                        break;
                    case 8:
                        result = NetworkText.FromLiteral(deadPlayerName + "'s parachute was just a backpack.");
                        break;
                    case 9:
                        result = NetworkText.FromLiteral(deadPlayerName + " got splattered all over " + Main.worldName);
                        break;
                }
            }
            #endregion
            #region drowing
            else if (other == 1)
            {
                int rn = Main.rand.Next(7) + 1;
                switch (rn)
                {
                    case 1:
                        result = NetworkText.FromKey("DeathText.Drowned_1", deadPlayerName);
                        break;
                    case 2:
                        result = NetworkText.FromKey("DeathText.Drowned_2", deadPlayerName);
                        break;
                    case 3:
                        result = NetworkText.FromKey("DeathText.Drowned_3", deadPlayerName);
                        break;
                    case 4:
                        result = NetworkText.FromKey("DeathText.Drowned_4", deadPlayerName);
                        break;
                    case 5:
                        result = NetworkText.FromLiteral(deadPlayerName + " blub blub blub...");
                        break;
                    case 6:
                        result = NetworkText.FromLiteral(deadPlayerName + " thought they could breathe water.");
                        break;
                    case 7:
                        result = NetworkText.FromLiteral(deadPlayerName + " asphyxiated.");
                        break;
                }
            }
            #endregion
            #region lava
            else if (other == 2)
            {
                int rn = Main.rand.Next(7) + 1;
                switch (rn)
                {
                    case 1:
                        result = NetworkText.FromKey("DeathText.Lava_1", deadPlayerName);
                        break;
                    case 2:
                        result = NetworkText.FromKey("DeathText.Lava_2", deadPlayerName);
                        break;
                    case 3:
                        result = NetworkText.FromKey("DeathText.Lava_3", deadPlayerName);
                        break;
                    case 4:
                        result = NetworkText.FromKey("DeathText.Lava_4", deadPlayerName);
                        break;
                    case 5:
                        result = NetworkText.FromLiteral(deadPlayerName + " took a bath in a lake of fire.");
                        break;
                    case 6:
                        result = NetworkText.FromLiteral(deadPlayerName + " became a charcoal briquette.");
                        break;
                    case 7:
                        result = NetworkText.FromLiteral(deadPlayerName + " is HOT HOT HOT.");
                        break;
                }
            }
            #endregion
            #region petrification
            else if (other == 5)
            {
                int rn = Main.rand.Next(5) + 1;
                switch (rn)
                {
                    case 1:
                        result = NetworkText.FromKey("DeathText.Petrified_1", deadPlayerName);
                        break;
                    case 2:
                        result = NetworkText.FromKey("DeathText.Petrified_2", deadPlayerName);
                        break;
                    case 3:
                        result = NetworkText.FromKey("DeathText.Petrified_3", deadPlayerName);
                        break;
                    case 4:
                        result = NetworkText.FromKey("DeathText.Petrified_4", deadPlayerName);
                        break;
                    case 5:
                        result = NetworkText.FromLiteral(deadPlayerName + " was stoned.");
                        break;
                }
            }
            #endregion
            #region electrocution
            else if (other == 10)
            {
                int rn = Main.rand.Next(3) + 1;
                switch (rn)
                {
                    case 1:
                        result = NetworkText.FromKey("DeathText.Electrocuted", deadPlayerName);
                        break;
                    case 2:
                        result = NetworkText.FromLiteral(deadPlayerName + " got zzzzapped.");
                        break;
                    case 3:
                        result = NetworkText.FromLiteral(deadPlayerName + " had an electrifying personality.");
                        break;
                }
            }
            #endregion
            else
            {
                switch (other)
                {
                    case 3:
                        result = NetworkText.FromKey("DeathText.Default", empty);
                        break;
                    case 4:
                        result = NetworkText.FromKey("DeathText.Slain", deadPlayerName);
                        break;
                    case 6:
                        result = NetworkText.FromKey("DeathText.Stabbed", deadPlayerName);
                        break;
                    case 7:
                        result = NetworkText.FromKey("DeathText.Suffocated", deadPlayerName);
                        break;
                    case 8:
                        result = NetworkText.FromKey("DeathText.Burned", deadPlayerName);
                        break;
                    case 9:
                        result = NetworkText.FromKey("DeathText.Poisoned", deadPlayerName);
                        break;
                    case 11:
                        result = NetworkText.FromKey("DeathText.TriedToEscape", deadPlayerName);
                        break;
                    case 12:
                        result = NetworkText.FromKey("DeathText.WasLicked", deadPlayerName);
                        break;
                    case 13:
                        result = NetworkText.FromKey("DeathText.Teleport_1", deadPlayerName);
                        break;
                    case 14:
                        result = NetworkText.FromKey("DeathText.Teleport_2_Male", deadPlayerName);
                        break;
                    case 15:
                        result = NetworkText.FromKey("DeathText.Teleport_2_Female", deadPlayerName);
                        break;
                    case 16:
                        result = NetworkText.FromKey("DeathText.Inferno", deadPlayerName);
                        break;
                    case 17:
                        result = NetworkText.FromKey("DeathText.DiedInTheDark", deadPlayerName);
                        break;
                    case 18:
                        result = NetworkText.FromKey("DeathText.Starved", deadPlayerName);
                        break;
                    case 254:
                        result = NetworkText.Empty;
                        break;
                    case 255:
                        result = NetworkText.FromKey("DeathText.Slain", deadPlayerName);
                        break;
                }
            }
        }
        return result;
    }
}
