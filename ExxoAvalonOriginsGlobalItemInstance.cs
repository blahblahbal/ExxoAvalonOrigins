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

namespace ExxoAvalonOrigins
{
    internal class ExxoAvalonOriginsGlobalItemInstance : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public bool invince;
        public int torch = 0;
        public int wallWand = -1;
        public int healStamina;
        public bool tome = false;
        public bool updateInvisibleVanity = false;
        public AvalonRarity avalonRarity;

        List<int> blahRarityItems = new List<int>
        {
            ModContent.ItemType<Items.Ammo.BlahBullet>(),
            ModContent.ItemType<Items.Weapons.Melee.BlahsEnergyBlade>(),
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
            ModContent.ItemType<Items.Armor.AvalonCuisses>()
        };
        List<int> rainbowRarityItems = new List<int>
        {
            ModContent.ItemType<Items.Placeable.Tile.Opal>(),
            ItemID.RainbowBrick,
            ItemID.RainbowBrickWall,
            ModContent.ItemType<Items.Armor.BlahsHelmet>(),
            ModContent.ItemType<Items.Armor.BlahsBodyarmor>(),
            ModContent.ItemType<Items.Armor.BlahsCuisses>(),
            ModContent.ItemType<Items.Tools.Quack>(),
            ModContent.ItemType<Items.Accessories.TitanGauntlets>(),
            ModContent.ItemType<Items.Material.SpikedBlastShell>(),
            ModContent.ItemType<Items.Tools.BlahsPicksaw>(),
            ModContent.ItemType<Items.Accessories.TerraClaws>(),
            ModContent.ItemType<Items.Placeable.Trophy.EggmanTrophy>(),
            ModContent.ItemType<Items.Placeable.Tile.OpalGemsparkBlock>(),
        };

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tooltipLine = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "ItemName" && x.mod == "Terraria");
            if (tooltipLine != null)
            {
                if (tooltipLine.Name == "Knockback") // && LanguageManager.Instance.ActiveCulture == GameCulture.English)
                {
                    if (item.knockBack > 15f)
                    {
                        tooltipLine.text = "Absurd knockback";
                    }
                    else if(item.knockBack > 17f)
                    {
                        tooltipLine.text = "Ridiculous knockback";
                    }
                    else if (item.knockBack > 19f)
                    {
                        tooltipLine.text = "Godly knockback";
                    }
                }
                if (tooltipLine.Name == "Speed" && LanguageManager.Instance.ActiveCulture == GameCulture.English)
                {
                    if (item.useAnimation >= 58f)
                    {
                        tooltipLine.text = "Slowpoke speed";
                    }
                }
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
