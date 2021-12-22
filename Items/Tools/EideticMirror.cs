using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class EideticMirror : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Team Mirror");
			Tooltip.SetDefault("Teleports you to a team member in multiplayer\nCan also be used as a magic mirror");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.LightPurple;
			item.width = dims.Width;
			item.useTime = 90;
			item.useTurn = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.useAnimation = 90;
			item.height = dims.Height;
			item.UseSound = SoundID.Item6;
		}

		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override void UseStyle(Player player)
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.1f);
			}
			if (player.itemTime == 0)
			{
				player.itemTime = item.useTime;
			}
			else if (player.itemTime == item.useTime / 2)
			{
				for (int num345 = 0; num345 < 70; num345++)
				{
					Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.5f);
				}
				player.grappling[0] = -1;
				player.grapCount = 0;
				for (int num346 = 0; num346 < 1000; num346++)
				{
					if (Main.projectile[num346].active && Main.projectile[num346].owner == player.whoAmI && Main.projectile[num346].aiStyle == 7)
					{
						Main.projectile[num346].Kill();
					}
				}
				player.Spawn();
				for (int num347 = 0; num347 < 70; num347++)
				{
					Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.5f);
				}
			}
		}
	}
}
