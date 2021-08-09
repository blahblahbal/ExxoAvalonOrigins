using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExxoAvalonOrigins.Hooks
{
    class EditTerrariaName
    {
        public static string OnGetRandomGameTitle(On.Terraria.Lang.orig_GetRandomGameTitle orig)
        {
            var output = orig().Replace("Terraria", "Exxo Avalon Origins");
            var gameTitleSize = Terraria.Localization.Language.GetCategorySize("GameTitle");
            return output;
        }
    }
}
