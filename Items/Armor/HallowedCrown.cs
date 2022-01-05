using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	class HallowedCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Crown");
			Tooltip.SetDefault("12% increased minion damage and knockback\nIncreases your max number of minions by 2");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.defense = 12;
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
			item.value = 250000;
			item.height = dims.Height;
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Minion damage is increased by 5%";
            player.minionDamage += 0.05f;
        }

        public override void UpdateEquip(Player player)
		{
			player.minionKB += 0.12f;
			player.minionDamage += 0.12f;
			player.maxMinions += 2;
		}
	}
}
