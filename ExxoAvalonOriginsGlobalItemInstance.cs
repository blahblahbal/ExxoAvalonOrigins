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

namespace ExxoAvalonOrigins
{
    internal class ExxoAvalonOriginsGlobalItemInstance : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public bool invince;
        public int torch = 0;
        public int spike = 0;
        public int healStamina;
        public bool wasMech = false;
        public bool tome = false;
        public bool updateInvisibleVanity = false;
        public AvalonRarity avalonRarity;

        List<int> blahRarityItems = new List<int>
        {
            ModContent.ItemType<Items.Ammo.BlahBullet>(),
            ModContent.ItemType<Items.Weapons.Melee.BlahsEnergyBlade>(),
            ModContent.ItemType<Items.Weapons.Magic.BlahStaff>(),
            ModContent.ItemType<Items.Weapons.Ranged.TacticalBlahncher>(),
            ModContent.ItemType<Items.Accessories.BlahsWings>(),
            ModContent.ItemType<Items.Armor.BlahsHeadguard>(),
            ModContent.ItemType<Items.Armor.BlahsHauberk>(),
            ModContent.ItemType<Items.Armor.BlahsCuisses2>(),
            ModContent.ItemType<Items.Potions.BlahPotion>(),
            ModContent.ItemType<Items.Tools.BlahsPicksawTierII>(),
            ModContent.ItemType<Items.Tools.BlahsWarhammer>()
        };
        List<int> avalonRarityItems = new List<int>
        {
            ModContent.ItemType<Items.Armor.AvalonHelmet>(),
            ModContent.ItemType<Items.Armor.AvalonBodyarmor>(),
            ModContent.ItemType<Items.Armor.AvalonCuisses>(),
			ModContent.ItemType<Items.Other.MechanicalWhoopieCushion>()
        };
        List<int> rainbowRarityItems = new List<int>
        {
            ModContent.ItemType<Items.Placeable.Tile.Opal>(),
            ItemID.RainbowBrick,
            ItemID.RainbowBrickWall,
            ModContent.ItemType<Items.Armor.BlahsHelmet>(),
            ModContent.ItemType<Items.Armor.BlahsBodyarmor>(),
            ModContent.ItemType<Items.Armor.BlahsCuisses>(),
            ModContent.ItemType<Items.Other.Quack>(),
            ModContent.ItemType<Items.Accessories.TitanGauntlets>(),
            ModContent.ItemType<Items.Material.SpikedBlastShell>(),
            ModContent.ItemType<Items.Tools.BlahsPicksaw>(),
            ModContent.ItemType<Items.Accessories.TerraClaws>(),
            ModContent.ItemType<Items.Placeable.Trophy.EggmanTrophy>(),
            ModContent.ItemType<Items.Placeable.Tile.OpalGemsparkBlock>(),
        };
        Dictionary<int, byte> allowedPrefixes = new Dictionary<int, byte>()
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

        public override void OnCraft(Item item, Recipe recipe)
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
                if (LanguageManager.Instance.ActiveCulture == GameCulture.English)
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
                if (LanguageManager.Instance.ActiveCulture == GameCulture.English)
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
            if (tooltipLine != null)
            {
                if (blahRarityItems.Contains(item.type))
                {
                    List<Color> colors = new List<Color>
                    {
                        new Color(252, 66, 0),
                        new Color(203, 203, 203)
                    };
                    int num = (int)(Main.GlobalTime / 2f % colors.Count);
                    Color orange = colors[num];
                    Color silver = colors[(num + 1) % colors.Count];
                    tooltipLine.overrideColor = Color.Lerp(orange, silver, (Main.GlobalTime % 2f > 1f) ? 1f : (Main.GlobalTime % 1f));
                }
                if (avalonRarityItems.Contains(item.type))
                {
                    List<Color> colors = new List<Color>
                    {
                        new Color(71, 142, 147),
                        new Color(255, 242, 0)
                    };
                    int num = (int)(Main.GlobalTime / 2f % colors.Count);
                    Color teal = colors[num];
                    Color yellow = colors[(num + 1) % colors.Count];
                    tooltipLine.overrideColor = Color.Lerp(teal, yellow, (Main.GlobalTime % 2f > 1f) ? 1f : (Main.GlobalTime % 1f));
                }
                if (rainbowRarityItems.Contains(item.type))
                {
                    tooltipLine.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                }
            }
        }

        public override GlobalItem NewInstance(Item item)
        {
            return base.NewInstance(item);
        }

        public override bool NeedsSaving(Item item)
        {
            return true;
        }

        public override TagCompound Save(Item item)
        {
            return new TagCompound
            {
                ["ExxoAvalonOrigins:Rarity"] = (int)avalonRarity
            };
        }

        public override void Load(Item item, TagCompound tag)
        {
            avalonRarity = (AvalonRarity)tag.GetInt("ExxoAvalonOrigins:Rarity");
        }

        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write((int)avalonRarity);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            avalonRarity = (AvalonRarity)reader.ReadInt32();
        }
    }
}
