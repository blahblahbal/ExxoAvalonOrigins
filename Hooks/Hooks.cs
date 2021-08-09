using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

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
            On.Terraria.WorldGen.TileRunner += BacciliteReplacement.OnTileRunner;
            On.Terraria.WorldGen.JungleRunner += JungleCoords.OnJungleRunner;
            TomeEquip.UpdateVanity_Hook += TomeEquip.UpdateInvisibleVanity;
            On.Terraria.Main.DrawInterface_Resources_Life += ExtraHealth.DrawExtraHearts;
            On.Terraria.Main.DrawInterface_Resources_Mana += ExtraHealth.DrawExtraMana;
            On.Terraria.Collision.HurtTiles += ExxoAvalonOriginsCollisions.HurtExtraTiles;
            On.Terraria.WorldGen.SmashAltar += EvilAltar.OnSmashAltar;
            IL.Terraria.Main.DrawMenu += EvilChooserMenu.HookEvilMenu;
            IL.Terraria.WorldGen.hardUpdateWorld += ContagionSpread.ILHardUpdateWorld;
            IL.Terraria.Main.DrawPlayer += LargeGem.ILDrawPlayer;
            IL.Terraria.Player.SmartCursor_Torch += Torches.ILSmartCursor_Torch;
        }
    }
}
