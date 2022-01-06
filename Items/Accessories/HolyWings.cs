using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	class HolyWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holy Wings");
			Tooltip.SetDefault("Allows flight and slow fall\nOther bonuses apply when in the Hallow");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
			item.value = 600000;
			item.accessory = true;
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.AngelWings);
            r.AddIngredient(ItemID.CrystalShard, 100);
            r.AddIngredient(ItemID.PixieDust, 75);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 160;
            if (player.ZoneHoly)
            {
                player.statLifeMax2 += 60;
                player.statDefense += 4;
                player.buffImmune[142] = true;
                player.buffImmune[BuffID.Slow] = true;
                player.buffImmune[BuffID.Silenced] = true;
            }
        }
	}
}
