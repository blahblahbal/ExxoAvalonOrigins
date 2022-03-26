using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class GuardianHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Hammer");
            Tooltip.SetDefault("'Lightning strikes with each hit'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 120;
            item.noUseGraphic = true;
            item.shootSpeed = 14f;
            item.rare = ItemRarityID.Red;
            item.autoReuse = true;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 13;
            item.knockBack = 12f;
            item.shoot = ModContent.ProjectileType<Projectiles.Melee.GuardianHammer>();
            item.melee = true;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 13;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override bool CanUseItem(Player player)
        {
            return (!(player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Melee.GuardianHammer>()] > 0));
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PaladinsHammer);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
