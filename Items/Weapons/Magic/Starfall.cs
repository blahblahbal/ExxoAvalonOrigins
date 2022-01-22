using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    public class Starfall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starfall");
            Tooltip.SetDefault("'The power of the stars consumes your mana'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.magic = true;
            item.damage = 1000;
            item.mana = 400;
            item.noMelee = true;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.knockBack = 16f;
            item.useTime = 35;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.useAnimation = 35;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.BrokenVigilanteTome>());
            recipe.AddIngredient(ItemID.FallenStar, 200);
            recipe.AddIngredient(ItemID.MeteoriteBar, 150);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.OblivionBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 35);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool UseItem(Player player)
        {
            float x = (float)(Main.mouseX + Main.screenPosition.X);
            float y = (float)(Main.mouseY + Main.screenPosition.Y) - Main.rand.Next(500, 800);
            float speedX = 0;
            float speedY = 14.9f;
            int type = ProjectileID.FallingStar;
            int damage = (int)(player.inventory[player.selectedItem].damage * player.magicDamage);
            float knockback = 16f;
            int owner = player.whoAmI;
            int projID = Projectile.NewProjectile(x, y, speedX, speedY, type, damage, knockback, owner);
            return true;
        }
    }
}
