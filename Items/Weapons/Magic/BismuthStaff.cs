using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class BismuthStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SapphireStaff);
            Item.staff[item.type] = true;
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.width = dims.Width;
            item.height = dims.Height;
            item.damage = 27;
            item.shootSpeed = 7.5f;
            item.mana = 10;
            item.rare = ItemRarityID.Orange;
            item.useTime = 24;
            item.useAnimation = 24;
            item.knockBack = 4f;
            item.shoot = ProjectileID.DiamondBolt;
            item.value = 20000;
            item.UseSound = SoundID.Item43;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 10);
            recipe.AddIngredient(ItemID.Ruby, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BismuthBar>(), 10);
            recipe.AddIngredient(ItemID.Diamond, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
