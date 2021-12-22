using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
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
			item.shoot = ModContent.ProjectileType<Projectiles.BloodyAmulet>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 20;
			item.useAnimation = 40;
			item.height = dims.Height;
		}
        public override bool CanUseItem(Player player)
        {
            if (Main.pumpkinMoon) return false;
            if (Main.snowMoon) return false;
            if (Main.dayTime) return false;
            return true;
        }
    }
}
