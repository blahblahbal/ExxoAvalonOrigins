using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class BacterialTotem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infested Carcass");
			Tooltip.SetDefault("Summons Bacterium Prime");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BacterialTotem");
			item.consumable = true;
			item.width = dims.Width;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = 0;
			item.maxStack = 20;
			item.useAnimation = 45;
			item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<NPCs.BacteriumPrime>()) && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.BacteriumPrime>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }
}