using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
	class SunCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sun Charm");
			Tooltip.SetDefault("Summons a Solar Eclipse");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.useTime = 40;
			item.shoot = ModContent.ProjectileType<Projectiles.SunCharm>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.useAnimation = 40;
			item.height = dims.Height;
		}

        public override bool CanUseItem(Player player)
        {
            if (!Main.dayTime) return false;
            return true;
        }
    }
}
