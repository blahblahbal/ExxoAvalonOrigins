using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class BlahsHauberk : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah's Hauberk");
			Tooltip.SetDefault("30% decreased mana usage and increases your max number of minions by 12\nIncreases maximum mana by 800");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 100;
			item.rare = ItemRarityID.Purple;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
            item.width = dims.Width;
			item.value = Item.sellPrice(2, 0, 0, 0);
			item.height = dims.Height;
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "ItemName")
                {
                    List<Color> colors = new List<Color>
                    {
                        new Color(252, 66, 0),
                        new Color(203, 203, 203)
                    };
                    int num = (int)(Main.GlobalTime / 2f % colors.Count);
                    Color orange = colors[num];
                    Color silver = colors[(num + 1) % colors.Count];
                    line.overrideColor = Color.Lerp(orange, silver, (Main.GlobalTime % 2f > 1f) ? 1f : (Main.GlobalTime % 1f));
                }
            }
        }
        public override void UpdateEquip(Player player)
		{
			player.aggro += 1000;
			player.manaCost -= 0.3f;
			player.statManaMax2 += 800;
			player.maxMinions += 12;
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return (head.type == ModContent.ItemType<BlahsHeadguard>() && body.type == ModContent.ItemType<BlahsHauberk>() && legs.type == ModContent.ItemType<BlahsCuisses2>());
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Melee Stealth, Ranged Stealth, Attackers also take double full damage, and Spectre Heal";
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().doubleDamage = player.ghostHeal = player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ghostSilence = player.GetModPlayer<ExxoAvalonOriginsModPlayer>().meleeStealth = player.shroomiteStealth = true;
        }
    }
}
