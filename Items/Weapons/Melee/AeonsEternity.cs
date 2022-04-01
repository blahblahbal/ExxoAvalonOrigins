using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    public class AeonsEternity : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aeon's Eternity");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 36;
            Item.scale = 1.1f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.height = dims.Height;
            Item.useTime = 30;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.AeonBeam2>();
            Item.shootSpeed = 9f;
            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.IceBlade).AddIngredient(ItemID.Starfury).AddIngredient(ModContent.ItemType<DesertLongSword>()).AddIngredient(ModContent.ItemType<RhodiumGreatsword>()).AddIngredient(ModContent.ItemType<MinersSword>()).AddTile(TileID.DemonAltar).Register();
            CreateRecipe(1).AddIngredient(ItemID.IceBlade).AddIngredient(ItemID.Starfury).AddIngredient(ModContent.ItemType<DesertLongSword>()).AddIngredient(ModContent.ItemType<OsmiumGreatsword>()).AddIngredient(ModContent.ItemType<MinersSword>()).AddTile(TileID.DemonAltar).Register();
            CreateRecipe(1).AddIngredient(ItemID.IceBlade).AddIngredient(ItemID.Starfury).AddIngredient(ModContent.ItemType<DesertLongSword>()).AddIngredient(ModContent.ItemType<IridiumGreatsword>()).AddIngredient(ModContent.ItemType<MinersSword>()).AddTile(TileID.DemonAltar).Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 0)
            {
                int num208 = Main.rand.Next(3);
                if (num208 == 0)
                {
                    num208 = 15;
                }
                else if (num208 == 1)
                {
                    num208 = 57;
                }
                else if (num208 == 2)
                {
                    num208 = 58;
                }
                int num209 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, num208);
                Dust dust = Main.dust[num209];
                dust.velocity *= 0.2f;
                dust.scale = 1.3f;
            }
        }
    }
}
