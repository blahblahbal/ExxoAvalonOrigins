using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class MysteryTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystery Tome");
            Tooltip.SetDefault("Casts all spells used to make it in random order\nSpells cast may not match the original");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.magic = true;
            item.damage = 110;
            item.reuseDelay = 14;
            item.autoReuse = true;
            item.scale = 0.9f;
            item.shootSpeed = 9f;
            item.mana = 25;
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.useTime = 11;
            item.knockBack = 4f;
            item.shoot = ModContent.ProjectileType<Projectiles.InfectedMist>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 505000;
            item.useAnimation = 11;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DevilsScythe>());
            recipe.AddIngredient(ModContent.ItemType<TheGoldenFlames>());
            recipe.AddIngredient(ModContent.ItemType<Terraspin>());
            recipe.AddIngredient(ModContent.ItemType<FocusBeam>());
            recipe.AddIngredient(ModContent.ItemType<Ancient>());
            recipe.AddIngredient(ModContent.ItemType<TomeoftheDistantPast>());
            recipe.AddIngredient(ModContent.ItemType<FreezeBolt>());
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int x = Main.rand.Next(7);

            Vector2 vel = new Vector2(speedX, speedY);
            if (x == 0) // Ancient
            {
                Main.PlaySound(2, new Vector2(-1, -1), 34);
                Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.AncientSandstorm>(), item.damage, 4);
                return false;
            }
            if (x == 1) // Devil's Scythe
            {
                Main.PlaySound(2, new Vector2(-1, -1), 8);
                Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.DevilScythe>(), item.damage, 5);
                return false;
            }
            if (x == 2) // Tome of the Distant Past
            {
                Main.PlaySound(2, new Vector2(-1, -1), 8);
                Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.Bones>(), item.damage, 4);
                return false;
            }
            if (x == 3) // The Golden Flames
            {
                Main.PlaySound(2, new Vector2(-1, -1), 20);
                Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.GoldenFire>(), item.damage, 6);
                return false;
            }
            if (x == 4) // Focus Beam
            {
                Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Beam"));
                Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.FocusBeam>(), item.damage, 5);
                return false;
            }
            if (x == 5) // Freeze Bolt
            {
                Main.PlaySound(2, new Vector2(-1, -1), 21);
                Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.FreezeBolt>(), item.damage, 5);
                return false;
            }
            if (x == 6) // Terraspin
            {
                Main.PlaySound(2, -1, -1, 84);
                Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.TerraTyphoon>(), item.damage, 5);
                return false;
            }

            return true;
        }
    }
}
