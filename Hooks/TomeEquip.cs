using MonoMod.RuntimeDetour.HookGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Hooks
{
    class TomeEquip
    {
        public static void OnEquipPage(On.Terraria.UI.ItemSlot.orig_EquipPage orig, Item item)
        {
            orig(item);
            if (item.type > ItemID.None && item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome)
            {
                Main.EquipPage = 2;
            }
        }

        public delegate void orig_UpdateVanity(object threadContext);
        public delegate void hook_UpdateVanity(orig_UpdateVanity orig, Terraria.Player player);

        public static event hook_UpdateVanity UpdateVanity
        {
            add => HookEndpointManager.Add(typeof(ItemLoader).GetMethod("UpdateVanity"), value);
            remove => HookEndpointManager.Remove(typeof(ItemLoader).GetMethod("UpdateVanity"), value);
        }

        public static void OnUpdateVanity(orig_UpdateVanity orig, Player player)
        {
            orig(player);
            for (int k = 13; k < 18 + player.extraAccessorySlots; k++)
            {
                Item item = player.armor[k];
                if (item.exists() &&
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().updateInvisibleVanity)
                {
                    item.modItem.UpdateVanity(player, EquipType.Back);
                }
            }
        }
    }
}
