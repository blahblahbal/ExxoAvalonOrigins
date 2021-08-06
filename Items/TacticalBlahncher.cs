using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Items{	class TacticalBlahncher : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Tactical Blahncher");			Tooltip.SetDefault("Launches homing blahckets\n75% chance to not consume ammo");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TacticalBlahncher");			item.damage = 160;			item.autoReuse = true;			item.useTurn = false;			item.useAmmo = AmmoID.Rocket;			item.shootSpeed = 11f;			item.crit += 1;			item.ranged = true;			item.rare = 12;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
            item.noMelee = true;			item.width = dims.Width;			item.knockBack = 5f;			item.useTime = 9;			item.shoot = ModContent.ProjectileType<Projectiles.Blahcket>();			item.value = Item.sellPrice(1, 0, 0, 0);			item.useStyle = 5;			item.useAnimation = 9;			item.height = dims.Height;            item.UseSound = SoundID.Item11;        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 45);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 45);
            recipe.AddIngredient(ModContent.ItemType<TacticalExpulsor>());
            recipe.AddIngredient(ItemID.RocketLauncher);
            recipe.AddIngredient(ItemID.GrenadeLauncher);
            recipe.AddIngredient(ItemID.Stynger);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,			ref float knockBack)		{            float num78 = speedX + (float)Main.rand.Next(-50, 51) * 0.05f;
            float num79 = speedY + (float)Main.rand.Next(-50, 51) * 0.05f;
            if (Main.rand.Next(3) == 0)
            {
                num78 *= 1f + (float)Main.rand.Next(-40, 41) * 0.02f;
                num79 *= 1f + (float)Main.rand.Next(-40, 41) * 0.02f;
            }
            Projectile.NewProjectile(position.X, position.Y, num78, num79, ModContent.ProjectileType<Projectiles.Blahcket>(), damage, knockBack, player.whoAmI, 0f, 0f);			return false;		}        public override void HoldItem(Player player)
        {
            Vector2 vector = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
            float num70 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
            float num71 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
            if (player.gravDir == -1f)
            {
                num71 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
            }
            float num72 = (float)Math.Sqrt((double)(num70 * num70 + num71 * num71));
            float num73 = num72;
            num72 = player.inventory[player.selectedItem].shootSpeed / num72;
            if (player.inventory[player.selectedItem].type == item.type)
            {
                num70 += (float)Main.rand.Next(-50, 51) * 0.03f / num72;
                num71 += (float)Main.rand.Next(-50, 51) * 0.03f / num72;
            }
            num70 *= num72;
            num71 *= num72;
            player.itemRotation = (float)Math.Atan2((double)(num71 * (float)player.direction), (double)(num70 * (float)player.direction));
        }        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(4) < 2) return false;
            return base.ConsumeAmmo(player);
        }
    }}