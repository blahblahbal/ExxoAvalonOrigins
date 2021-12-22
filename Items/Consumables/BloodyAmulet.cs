using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
	class BloodyAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Amulet");
			Tooltip.SetDefault("Summons a Blood Moon");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item4;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.useTime = 40;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 20;
			item.useAnimation = 40;
			item.height = dims.Height;
		}
        public override bool CanUseItem(Player player)
        {
            if (Main.pumpkinMoon) return false;
            if (Main.snowMoon) return false;
            return true;
        }
        public override bool UseItem(Player player)
        {
            Main.dayTime = false;
            Main.time = 0;
            Main.bloodMoon = true;
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText("The Blood Moon is rising...", 50, 255, 130);
            }
            else if (Main.netMode == NetmodeID.Server) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon is rising..."), new Color(50, 255, 130));
            return true;
        }
    }
}
