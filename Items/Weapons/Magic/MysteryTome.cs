using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

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
        Item.DamageType = DamageClass.Magic;
        Item.damage = 110;
        Item.reuseDelay = 14;
        Item.autoReuse = true;
        Item.scale = 0.9f;
        Item.shootSpeed = 9f;
        Item.mana = 25;
        Item.rare = ItemRarityID.Purple;
        Item.width = dims.Width;
        Item.useTime = 11;
        Item.knockBack = 4f;
        Item.shoot = ModContent.ProjectileType<Projectiles.InfectedMist>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 505000;
        Item.useAnimation = 11;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<DevilsScythe>()).AddIngredient(ModContent.ItemType<TheGoldenFlames>()).AddIngredient(ModContent.ItemType<Terraspin>()).AddIngredient(ModContent.ItemType<FocusBeam>()).AddIngredient(ModContent.ItemType<Ancient>()).AddIngredient(ModContent.ItemType<TomeoftheDistantPast>()).AddIngredient(ModContent.ItemType<FreezeBolt>()).AddTile(TileID.Bookcases).Register();
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
        int x = Main.rand.Next(7);

        Vector2 vel = new Vector2(speedX, speedY);
        if (x == 0) // Ancient
        {
            SoundEngine.PlaySound(2, new Vector2(-1, -1), 34);
            Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.AncientSandstorm>(), Item.damage, 4);
            return false;
        }
        if (x == 1) // Devil's Scythe
        {
            SoundEngine.PlaySound(2, new Vector2(-1, -1), 8);
            Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.DevilScythe>(), Item.damage, 5);
            return false;
        }
        if (x == 2) // Tome of the Distant Past
        {
            SoundEngine.PlaySound(2, new Vector2(-1, -1), 8);
            Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.Bones>(), Item.damage, 4);
            return false;
        }
        if (x == 3) // The Golden Flames
        {
            SoundEngine.PlaySound(2, new Vector2(-1, -1), 20);
            Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.GoldenFire>(), Item.damage, 6);
            return false;
        }
        if (x == 4) // Focus Beam
        {
            SoundEngine.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Beam"));
            Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.FocusBeam>(), Item.damage, 5);
            return false;
        }
        if (x == 5) // Freeze Bolt
        {
            SoundEngine.PlaySound(2, new Vector2(-1, -1), 21);
            Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.FreezeBolt>(), Item.damage, 5);
            return false;
        }
        if (x == 6) // Terraspin
        {
            SoundEngine.PlaySound(2, -1, -1, 84);
            Projectile.NewProjectile(position, vel, ModContent.ProjectileType<Projectiles.TerraTyphoon>(), Item.damage, 5);
            return false;
        }

        return true;
    }
}