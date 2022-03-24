using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class Infernasword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infernasword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 44;
            item.autoReuse = true;
            item.shootSpeed = 4f;
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.knockBack = 4f;
            item.useTime = 20;
            item.shoot = ModContent.ProjectileType<Projectiles.Melee.InfernoScythe>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.useAnimation = 20;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedSword);
            recipe.AddIngredient(ItemID.LivingFireBlock, 100);
            recipe.AddIngredient(ItemID.SoulofMight, 16);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 7);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
