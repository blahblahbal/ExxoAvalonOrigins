using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class MinersPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Miner's Pickaxe");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 10;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1f;
			item.pick = 60;
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 18;
			item.knockBack = 3.5f;
			item.melee = true;
			item.tileBoost += 1;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 16000;
			item.useAnimation = 19;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
	}
}
