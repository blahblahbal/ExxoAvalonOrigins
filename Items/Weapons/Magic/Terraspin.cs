using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

public class Terraspin : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Terraspin");
        Tooltip.SetDefault("Fires a spread of typhoons");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item84;
        Item.DamageType = DamageClass.Magic;
        Item.damage = 185;
        Item.autoReuse = true;
        Item.channel = true;
        Item.useTurn = false;
        Item.shootSpeed = 9f;
        Item.crit += 9;
        Item.mana = 26;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.knockBack = 7f;
        Item.useTime = 30;
        Item.shoot = ModContent.ProjectileType<Projectiles.TerraTyphoon>();
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = Item.sellPrice(0, 50, 0, 0);
        Item.useAnimation = 30;
        Item.height = dims.Height;
        if (!Main.dedServ)
        {
            Item.GetGlobalItem<ItemUseGlow>().glowTexture = ModContent.Request<Texture2D>(Texture + "_Glow");
        }
        Item.GetGlobalItem<ItemUseGlow>().glowOffsetX = 2;
        Item.GetGlobalItem<ItemUseGlow>().glowOffsetY = 0;
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(2, 0);
    }
    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
    {
        Texture2D texture = ModContent.Request<Texture2D>(Texture + "_Glow");
        spriteBatch.Draw
        (
            texture,
            new Vector2
            (
                Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
            ),
            new Rectangle(0, 0, texture.Width, texture.Height),
            Color.White,
            rotation,
            texture.Size() * 0.5f,
            scale,
            SpriteEffects.None,
            0f
        );
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        for (int num212 = 0; num212 < 2; num212++)
        {
            float num213 = speedX;
            float num214 = speedY;
            num213 += Main.rand.Next(-30, 31) * 0.05f;
            num214 += Main.rand.Next(-30, 31) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, num213, num214, type, damage, knockBack, player.whoAmI, 0f, 0f);
        }
        return false;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<DevilsScythe>()).AddIngredient(ModContent.ItemType<TheGoldenFlames>()).AddIngredient(ItemID.RazorbladeTyphoon).AddIngredient(ModContent.ItemType<Material.BrokenVigilanteTome>()).AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 5).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
    }
}