using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
	class EyeofOblivionAncient : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Oblivion");
			Tooltip.SetDefault("Summons Ancient Oblivion\nUse with care");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.rare = ItemRarityID.Yellow;
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
            return !NPC.AnyNPCs(ModContent.NPCType<NPCs.AncientOblivionPhase1Dead>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.AncientOblivionPhase1>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.AncientOblivionHead1>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.AncientOblivionHead2>()) && !Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.AncientOblivionPhase1>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }
}
