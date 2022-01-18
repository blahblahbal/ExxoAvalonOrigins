using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class ZirconStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zircon Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SapphireStaff);
            Item.staff[item.type] = true;
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.height = dims.Height;
            item.damage = 32;
            item.autoReuse = true;
            item.shootSpeed = 7.75f;
            item.mana = 9;
            item.rare = ItemRarityID.Green;
            item.useTime = 23;
            item.useAnimation = 23;
            item.knockBack = 4.75f;
            item.shoot = ModContent.ProjectileType<Projectiles.ZirconBolt>();
            item.value = Item.buyPrice(0, 3, 60, 0);
            item.UseSound = SoundID.Item43;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Material.Zircon>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 8);
            recipe.AddIngredient(ModContent.ItemType<Material.Booger>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
