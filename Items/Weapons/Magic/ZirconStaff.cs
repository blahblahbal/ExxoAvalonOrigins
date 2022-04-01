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
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SapphireStaff);
            Item.staff[Item.type] = true;
            Rectangle dims = this.GetDims();
            Item.width = dims.Width;
            Item.height = dims.Height;
            Item.damage = 32;
            Item.autoReuse = true;
            Item.shootSpeed = 7.75f;
            Item.mana = 9;
            Item.rare = ItemRarityID.Green;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.knockBack = 4.75f;
            Item.shoot = ModContent.ProjectileType<Projectiles.ZirconBolt>();
            Item.value = Item.buyPrice(0, 3, 60, 0);
            Item.UseSound = SoundID.Item43;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.Zircon>(), 15).AddIngredient(ModContent.ItemType<Placeable.Bar.BacciliteBar>(), 8).AddIngredient(ModContent.ItemType<Material.Booger>(), 5).AddTile(TileID.Anvils).Register();
        }
    }
}
