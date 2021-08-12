using MonoMod.RuntimeDetour.HookGen;
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
            TomeEquip.UpdateVanity += TomeEquip.OnUpdateVanity;
            On.Terraria.Main.DrawInterface_Resources_Life += ExtraHealth.OnDrawInterface_Resources_Life;
            On.Terraria.Main.DrawInterface_Resources_Mana += ExtraHealth.OnDrawInterface_Resources_Mana;
            On.Terraria.Collision.HurtTiles += TrapCollision.OnHurtTiles;
            On.Terraria.WorldGen.SmashAltar += EvilAltar.OnSmashAltar;
            IL.Terraria.Main.DrawMenu += EvilChooserMenu.ILDrawMenu;
            IL.Terraria.WorldGen.hardUpdateWorld += ContagionSpread.ILHardUpdateWorld;
            IL.Terraria.Main.DrawPlayer += LargeGem.ILDrawPlayer;
            IL.Terraria.Player.SmartCursor_Torch += Torches.ILSmartCursor_Torch;
            On.Terraria.GameContent.UI.Elements.UIWorldListItem.GetIcon += UIMenuContagion.OnGetIcon;
            IL.Terraria.GameContent.UI.Elements.UIGenProgressBar.DrawSelf += UIMenuContagion.ILDrawSelf;
        }
    }
}
