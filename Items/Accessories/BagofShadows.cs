using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class BagofShadows : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bag of Shadows");
			Tooltip.SetDefault("Shadow particles cover you when you move");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.accessory = true;
			item.vanity = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.height = dims.Height;
			item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().updateInvisibleVanity = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.controlRight)
			{
				var num12 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num12].noGravity = true;
			}
			if (player.controlLeft)
			{
				var num13 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num13].noGravity = true;
			}
			if (player.controlJump)
			{
				var num14 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num14].noGravity = true;
			}
			if (player.controlRight)
			{
				var num55 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num55].noGravity = true;
			}
			if (player.controlLeft)
			{
				var num56 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num56].noGravity = true;
			}
			if (player.controlJump)
			{
				var num57 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num57].noGravity = true;
			}
		}

        public override void UpdateVanity(Player player, EquipType type)
        {
			if (player.controlRight)
			{
				var num12 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num12].noGravity = true;
			}
			if (player.controlLeft)
			{
				var num13 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num13].noGravity = true;
			}
			if (player.controlJump)
			{
				var num14 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num14].noGravity = true;
			}
			if (player.controlRight)
			{
				var num55 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num55].noGravity = true;
			}
			if (player.controlLeft)
			{
				var num56 = Dust.NewDust(player.position, player.width + 20, player.height, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num56].noGravity = true;
			}
			if (player.controlJump)
			{
				var num57 = Dust.NewDust(player.position, player.width + 20, player.height + 20, DustID.Shadowflame, 0f, 0f, 100, Color.White, 2f);
				Main.dust[num57].noGravity = true;
			}
		}
	}
}
