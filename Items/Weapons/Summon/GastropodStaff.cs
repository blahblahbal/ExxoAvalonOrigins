using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Summon
{
    class GastropodStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gastropod Staff");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.summon = true;
            item.damage = 40;
            item.shootSpeed = 14f;
            item.mana = 13;
            item.noMelee = true;
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.useTime = 30;
            item.knockBack = 4.5f;
            item.shoot = ModContent.ProjectileType<Projectiles.Summon.GastrominiSummon>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.useAnimation = 30;
            item.height = dims.Height;
            item.UseSound = SoundID.Item44;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 14);
            recipe.AddIngredient(ItemID.Gel, 100);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            float posX = (float)Main.mouseX + Main.screenPosition.X;
            float posY = (float)Main.mouseY + Main.screenPosition.Y;
            Projectile.NewProjectile(posX, posY, 0f, 0f, type, damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}
