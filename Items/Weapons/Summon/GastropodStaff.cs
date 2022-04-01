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
            Item.DamageType = DamageClass.Summon;
            Item.damage = 40;
            Item.shootSpeed = 14f;
            Item.mana = 13;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.useTime = 30;
            Item.knockBack = 4.5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Summon.GastrominiSummon>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.useAnimation = 30;
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item44;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.HallowedBar, 14).AddIngredient(ItemID.Gel, 100).AddIngredient(ItemID.SoulofLight, 20).AddIngredient(ItemID.SoulofNight, 5).AddTile(TileID.MythrilAnvil).Register();
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
