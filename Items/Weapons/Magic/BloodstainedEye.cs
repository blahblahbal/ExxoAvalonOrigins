using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class BloodstainedEye : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bloodstained Eye");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 22;
        Item.scale = 1.1f;
        Item.DamageType = DamageClass.Magic;
        Item.autoReuse = true;
        Item.noMelee = true;
        Item.useTurn = false;
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 2f;
        Item.mana = 3;
        Item.shoot = ModContent.ProjectileType<Projectiles.BloodyTear>();
        Item.shootSpeed = 14f;
        Item.UseSound = SoundID.NPCHit1;
        Item.value = Item.sellPrice(0, 1, 0, 0);
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
        int numberProjectiles = 1 + Main.rand.Next(2);
        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
            float scale = 1f - (Main.rand.NextFloat() * .3f);
            perturbedSpeed = perturbedSpeed * scale;
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
        }
        return false;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<GlassEye>()).AddIngredient(ModContent.ItemType<BloodshotLens>()).AddIngredient(ModContent.ItemType<BottledLava>()).AddTile(TileID.Anvils).Register();
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(5, 0);
    }
}