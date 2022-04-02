using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged;

class QuadroCannon : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Quadro Cannon");
        Tooltip.SetDefault("Four round burst\nOnly the first shot consumes ammo and fires a spread of bullets");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 15;
        Item.autoReuse = true;
        Item.shootSpeed = 14f;
        Item.useAmmo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = ItemRarityID.Yellow;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 4;
        Item.knockBack = 5f;
        Item.shoot = ProjectileID.Bullet;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 780000;
        Item.reuseDelay = 14;
        Item.useAnimation = 16;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item11;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.ClockworkAssaultRifle).AddIngredient(ItemID.Shotgun).AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 10).AddIngredient(ItemID.SoulofFright).AddIngredient(ItemID.SoulofSight).AddIngredient(ItemID.SoulofMight).AddIngredient(ModContent.ItemType<Material.LensApparatus>()).AddIngredient(ModContent.ItemType<Placeable.Tile.Onyx>(), 25).AddTile(TileID.MythrilAnvil).Register();
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-10, 0);
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
        //sound is weird sometimes?? idk why tho
        for (int num209 = 0; num209 < 4; num209++)
        {
            float num210 = speedX;
            float num211 = speedY;
            num210 += (float)Main.rand.Next(-24, 25) * 0.05f;
            num211 += (float)Main.rand.Next(-24, 25) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, num210, num211, type, damage, knockBack, player.whoAmI, 0f, 0f);
            SoundEngine.PlaySound(SoundID.Item, -1, -1, 11);
        }
        return false;
    }
    public override bool ConsumeAmmo(Player player)
    {
        return player.itemAnimation >= Item.useAnimation - 4;
    }
}