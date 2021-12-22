using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class DarkMatterGel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Gel");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.White;
			item.width = dims.Width;
			item.scale = 1f;
			item.maxStack = 999;
			item.value = 20;
			item.height = dims.Height;
		}

        public override bool CanUseItem(Player player)
        {
            if (!Main.hardMode) return false;
            if (NPC.AnyNPCs(ModContent.NPCType<NPCs.ArmageddonSlime>())) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.ArmageddonSlime>());
            return true;
        }
    }
}