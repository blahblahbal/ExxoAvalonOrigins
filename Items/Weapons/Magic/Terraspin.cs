using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
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
            item.UseSound = SoundID.Item84;
            item.magic = true;
            item.damage = 185;
            item.autoReuse = true;
            item.channel = true;
            item.useTurn = false;
            item.shootSpeed = 9f;
            item.crit += 9;
            item.mana = 26;
            item.noMelee = true;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.knockBack = 7f;
            item.useTime = 30;
            item.shoot = ModContent.ProjectileType<Projectiles.TerraTyphoon>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.useAnimation = 30;
            item.height = dims.Height;
            if (!Main.dedServ)
            {
                item.GetGlobalItem<ItemUseGlow>().glowTexture = ModContent.GetTexture(Texture + "_Glow");
            }
            item.GetGlobalItem<ItemUseGlow>().glowOffsetX = 2;
            item.GetGlobalItem<ItemUseGlow>().glowOffsetY = 0;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, 0);
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.GetTexture(Texture + "_Glow");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DevilsScythe>());
            recipe.AddIngredient(ModContent.ItemType<TheGoldenFlames>());
            recipe.AddIngredient(ItemID.RazorbladeTyphoon);
            recipe.AddIngredient(ModContent.ItemType<Material.BrokenVigilanteTome>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
