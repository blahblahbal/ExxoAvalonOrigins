using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExxoAvalonOrigins.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace ExxoAvalonOrigins;

public class ExxoAvalonOriginsGlobalItemInstance : GlobalItem
{
    public override bool InstancePerEntity => true;
    public bool invince;
    public int torch = 0;
    public int spike = 0;
    public int healStamina;
    public bool wasMech = false;
    public bool tome = false;
    public bool updateInvisibleVanity = false;

    List<int> rainbowRarityItems = new List<int>
    {
        ItemID.RainbowBrick,
        ItemID.RainbowBrickWall,
    };
    Dictionary<int, int> allowedPrefixes = new Dictionary<int, int>()
    {
        { 0, ModContent.PrefixType<Prefixes.Barbaric>() },
        { 1, ModContent.PrefixType<Prefixes.Boosted>() },
        { 2, ModContent.PrefixType<Prefixes.Busted>() },
        { 3, ModContent.PrefixType<Prefixes.Confused>() },
        { 4, ModContent.PrefixType<Prefixes.Disgusting>() },
        { 5, ModContent.PrefixType<Prefixes.Fluidic>() },
        { 6, ModContent.PrefixType<Prefixes.Glorious>() },
        { 7, ModContent.PrefixType<Prefixes.Handy>() },
        { 8, ModContent.PrefixType<Prefixes.Insane>() },
        { 9, ModContent.PrefixType<Prefixes.Loaded>() },
        { 10, ModContent.PrefixType<Prefixes.Messy>() },
        { 11, ModContent.PrefixType<Prefixes.Mythic>() },
        { 12, ModContent.PrefixType<Prefixes.Protective>() },
        { 13, ModContent.PrefixType<Prefixes.Silly>() },
        { 14, ModContent.PrefixType<Prefixes.Slimy>() }

    };
    public bool IsArmor(Item item)
    {
        if (item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1)
        {
            return !item.vanity;
        }
        return false;
    }
    public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand)
    {
        if (IsArmor(item) && pre == -3)
        {
            return true;
        }
        return base.PrefixChance(item, pre, rand);
    }
    public override int ChoosePrefix(Item item, UnifiedRandom rand)
    {
        if (IsArmor(item))
        {
            return allowedPrefixes[rand.Next(allowedPrefixes.Count)];
        }
        return base.ChoosePrefix(item, rand);
    }
    public override void PostReforge(Item item)
    {
        if (IsArmor(item))
        {
            switch (Main.rand.Next(15))
            {
                case 0:
                    item.prefix = ModContent.PrefixType<Prefixes.Barbaric>();
                    break;
                case 1:
                    item.prefix = ModContent.PrefixType<Prefixes.Boosted>();
                    break;
                case 2:
                    item.prefix = ModContent.PrefixType<Prefixes.Busted>();
                    break;
                case 3:
                    item.prefix = ModContent.PrefixType<Prefixes.Confused>();
                    break;
                case 4:
                    item.prefix = ModContent.PrefixType<Prefixes.Disgusting>();
                    break;
                case 5:
                    item.prefix = ModContent.PrefixType<Prefixes.Fluidic>();
                    break;
                case 6:
                    item.prefix = ModContent.PrefixType<Prefixes.Glorious>();
                    break;
                case 7:
                    item.prefix = ModContent.PrefixType<Prefixes.Handy>();
                    break;
                case 8:
                    item.prefix = ModContent.PrefixType<Prefixes.Insane>();
                    break;
                case 9:
                    item.prefix = ModContent.PrefixType<Prefixes.Loaded>();
                    break;
                case 10:
                    item.prefix = ModContent.PrefixType<Prefixes.Messy>();
                    break;
                case 11:
                    item.prefix = ModContent.PrefixType<Prefixes.Mythic>();
                    break;
                case 12:
                    item.prefix = ModContent.PrefixType<Prefixes.Protective>();
                    break;
                case 13:
                    item.prefix = ModContent.PrefixType<Prefixes.Silly>();
                    break;
                case 14:
                    item.prefix = ModContent.PrefixType<Prefixes.Slimy>();
                    break;
            }
        }
    }
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        TooltipLine tooltipLine = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "ItemName" && x.mod == "Terraria");
        TooltipLine lineKB = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Knockback" && x.mod == "Terraria");
        TooltipLine lineSpeed = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Speed" && x.mod == "Terraria");
        if (lineKB != null)
        {
            if (LanguageManager.Instance.ActiveCulture.LegacyId == (int)GameCulture.CultureName.English)
            {
                if (item.knockBack > 0f && item.knockBack < 1.5f)
                {
                    lineKB.text = "Puny knockback";
                }
                if (item.knockBack > 15f)
                {
                    lineKB.text = "Absurd knockback";
                }
                if (item.knockBack > 17f)
                {
                    lineKB.text = "Ridiculous knockback";
                }
                if (item.knockBack > 19f)
                {
                    lineKB.text = "Godly knockback";
                }
            }
        }
        if (lineSpeed != null)
        {
            if (LanguageManager.Instance.ActiveCulture.LegacyId == (int)GameCulture.CultureName.English)
            {
                if (item.useAnimation <= 5f)
                {
                    lineSpeed.text = "Lightning speed";
                }
                if (item.useAnimation >= 58f)
                {
                    lineSpeed.text = "Slowpoke speed";
                }
            }
        }
    }
}
