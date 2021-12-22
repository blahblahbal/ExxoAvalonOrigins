using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class CrystalEdge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Edge");
			Tooltip.SetDefault("Increases damage by 25%");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.height = dims.Height;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.25f;
            player.meleeDamage += 0.25f;
            player.minionDamage += 0.25f;
            player.thrownDamage += 0.25f;
            player.rangedDamage += 0.25f;
        }
    }
}
