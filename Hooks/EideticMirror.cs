using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace ExxoAvalonOrigins.Hooks
{
    class EideticMirror
    {
        public static void OnTakeUnityItem(On.Terraria.Player.orig_TakeUnityPotion orig, Player self)
        {
            if (self.HasItem(ModContent.ItemType<Items.Tools.EideticMirror>())) return;

            orig(self);
        }

        public static bool OnHasUnityItem(On.Terraria.Player.orig_HasUnityPotion orig, Player self)
        {
            if (self.HasItem(ModContent.ItemType<Items.Tools.EideticMirror>())) return true;
            return orig(self);
        }
    }
}
