using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class PeridotStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Peridot Staff");
            Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SapphireStaff);
			Item.staff[item.type] = true;
			Rectangle dims = this.GetDims();
			item.width = dims.Width;
			item.height = dims.Height;
			item.damage = 30;
			item.autoReuse = true;
			item.shootSpeed = 7.75f;
			item.mana = 10;
			item.rare = ItemRarityID.Blue;
			item.useTime = 26;
			item.useAnimation = 26;
			item.knockBack = 4.75f;
			item.shoot = ModContent.ProjectileType<Projectiles.PeridotBolt>();
			item.value = Item.buyPrice(0, 3, 60, 0);
			
            item.UseSound = SoundID.Item43;
        }
	}
}
