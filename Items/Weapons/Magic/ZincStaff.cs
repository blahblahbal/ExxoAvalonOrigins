using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class ZincStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Staff");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SapphireStaff);
            Item.staff[Item.type] = true;
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.width = dims.Width;
            Item.height = dims.Height;
            Item.damage = 21;
            Item.shootSpeed = 7.5f;
            Item.mana = 8;
            Item.rare = ItemRarityID.Blue;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.knockBack = 4f;
            Item.shoot = ProjectileID.EmeraldBolt;
            Item.value = 20000;
            Item.UseSound = SoundID.Item43;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 10).AddIngredient(ItemID.Sapphire, 8).AddTile(TileID.Anvils).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.ZincBar>(), 10).AddIngredient(ItemID.Emerald, 8).AddTile(TileID.Anvils).Register();
        }
    }
}
