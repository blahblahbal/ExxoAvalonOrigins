﻿using System;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes
{
    public abstract class ArmorPrefix : ModPrefix
    {
        public int defense { get; internal set; }
        public static bool IsArmor(Item item)
        {
            return item.maxStack == 1 && !item.vanity && (item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1);
        }
        public virtual void UpdateEquip(Player player)
        {
        }
        public virtual int CalcDefense(Player player, Item item)
        {
            return defense;
        }
    }
}