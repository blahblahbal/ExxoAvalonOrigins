using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class BlahsEnergyBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blah's Energy Blade");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BlahsEnergyBlade");
			item.damage = 250;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.2f;
			item.shootSpeed = 13f;
			item.rare = 12;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
            item.width = dims.Width;
			item.useTime = 14;
			item.knockBack = 20f;
			item.shoot = ModContent.ProjectileType<Projectiles.BlahBeam>();
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.useStyle = 1;
			item.value = Item.sellPrice(3, 0, 0, 0);
			item.useAnimation = 14;
			item.height = dims.Height;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 255);
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 45);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 45);
            recipe.AddIngredient(ModContent.ItemType<ElementalExcalibur>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerBlade>());
            recipe.AddIngredient(ModContent.ItemType<PumpkingsSword>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            for (int num194 = 0; num194 < 3; num194++)
            {
                float num195 = speedX;
                float num196 = speedY;
                num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
                num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num195, num196, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
    }
}