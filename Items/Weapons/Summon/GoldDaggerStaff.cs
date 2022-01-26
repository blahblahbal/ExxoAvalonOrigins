using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Summon
{
    public class GoldDaggerStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Dagger Staff");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.summon = true;
            item.damage = 10;
            item.shootSpeed = 14f;
            item.mana = 8;
            item.noMelee = true;
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.useTime = 30;
            item.knockBack = 5.5f;
            item.shoot = ModContent.ProjectileType<Projectiles.GoldDagger>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 20);
            item.useAnimation = 30;
            item.height = dims.Height;
            item.UseSound = SoundID.Item44;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 13);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
