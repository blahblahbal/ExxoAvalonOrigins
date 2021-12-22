using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class CaesiumScimitar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Scimitar");
			Tooltip.SetDefault("Explodes foes on hit");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item1;
			item.damage = 66;
			item.useTurn = true;
			item.scale = 1.3f;
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
			item.useTime = 18;
			item.knockBack = 8f;
			item.melee = true;
			item.autoReuse = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.useAnimation = 18;
			item.height = dims.Height;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			Main.PlaySound(SoundID.Item14, target.position);
			for (int i = 0; i < 5; i++)
            {
				Projectile.NewProjectile(target.Center.X, target.Center.Y, Main.rand.Next(-2, 3), Main.rand.Next(-2, 3), ModContent.ProjectileType<Projectiles.CaesiumExplosion>(), damage, knockBack, player.whoAmI, 0f, 0f);
			}
		}
	}
}
