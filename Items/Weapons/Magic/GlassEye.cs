using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class GlassEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass Eye");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 14;
            Item.scale = 1.1f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.useTurn = false;
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.height = dims.Height;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.mana = 3;
            Item.shoot = ModContent.ProjectileType<Projectiles.Tear>();
            Item.shootSpeed = 12f;
            Item.UseSound = SoundID.NPCHit1;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Lens, 1).AddIngredient(ItemID.Glass, 5).AddIngredient(ItemID.FallenStar, 3).AddIngredient(ItemID.BottledWater, 1).AddTile(TileID.WorkBenches).Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }
    }
}
