using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
	class FalseTreasureMap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("False Treasure Map");
			Tooltip.SetDefault("Cancels a Pirate Invasion");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.rare = ItemRarityID.White;
			item.width = dims.Width;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = 0;
			item.maxStack = 30;
			item.useAnimation = 45;
			item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.invasionSize > 0 && Main.invasionType == InvasionID.PirateInvasion;
        }

        public override bool UseItem(Player player)
        {
            Main.invasionSize = 0;
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }
}
