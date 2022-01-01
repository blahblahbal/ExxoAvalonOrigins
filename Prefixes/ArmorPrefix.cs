using System;
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
            return item.maxStack == 1 && !item.vanity && (item.headSlot > 0 || item.bodySlot > 0 || item.legSlot > 0);
        }
        public virtual void UpdateEquip(Player player)
        {
        }
        public virtual void InsertTooltips(Item item, List<TooltipLine> tooltips, int index)
        {
        }
        public virtual int CalcDefense(Player player, Item item)
        {
            return defense;
        }
        public static TooltipLine PrefixLine(bool? good, string text)
        {
            bool? flag = good;
            bool value = flag.GetValueOrDefault();
            return new TooltipLine(ModContent.GetInstance<ExxoAvalonOrigins>(), "PrefixLine", ((!flag.HasValue) ? "" : (value ? "+" : "-")) + text)
            {
                isModifier = true,
                isModifierBad = !good.GetValueOrDefault(true)
            };
        }
        public void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int defense = CalcDefense(Main.LocalPlayer, item);
            TooltipLine defenseLine;
            if (defense != 0 && (defenseLine = tooltips.Find((TooltipLine t) => t.Name == "Defense")) != null)
            {
                string color = ((defense < 0) ? "[c/BE7878:" : "[c/78BE78:");
                defenseLine.text = string.Format("{0} {1}({2}{3})]{4}", item.defense + defense, color, (defense < 0) ? "-" : "+", Math.Abs(defense), Language.GetTextValue("LegacyTooltip.25"));
            }
            int insertIndex = tooltips.FindIndex((TooltipLine t) => t.Name == "SetBonus");
            if (insertIndex == -1)
            {
                insertIndex = tooltips.FindIndex((TooltipLine t) => t.Name == "Price");
            }
            if (insertIndex == -1)
            {
                insertIndex = tooltips.Count;
            }
            InsertTooltips(item, tooltips, insertIndex);
        }
    }
}
