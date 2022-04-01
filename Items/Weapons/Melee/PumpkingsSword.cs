using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class PumpkingsSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pumpking's Sword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 105;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.scale = 1.15f;
            Item.rare = ItemRarityID.Red;
            Item.width = dims.Width;
            Item.useTime = 36;
            Item.useAnimation = 16;
            Item.knockBack = 8f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.PumpkingsBeam>();
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 40, 0, 0);
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.TheHorsemansBlade).AddIngredient(ItemID.SpookyWood, 900).AddIngredient(ItemID.LivingFireBlock, 200).AddIngredient(ItemID.Pumpkin, 30).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 20).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            pumpkinSword(target.whoAmI, (int)(damage * 2), knockBack, 0, player);
        }
        private void pumpkinSword(int i, int dmg, float kb, int Type, Player p)
        {
            //if (Main.rand.Next(2) == 1)
            {
                int logicCheckScreenHeight = Main.LogicCheckScreenHeight;
                int logicCheckScreenWidth = Main.LogicCheckScreenWidth;
                int num = Main.rand.Next(100, 300);
                int num2 = Main.rand.Next(100, 300);
                num = ((Main.rand.Next(2) != 0) ? (num + (logicCheckScreenWidth / 2 - num)) : (num - (logicCheckScreenWidth / 2 + num)));
                num2 = ((Main.rand.Next(2) != 0) ? (num2 + (logicCheckScreenHeight / 2 - num2)) : (num2 - (logicCheckScreenHeight / 2 + num2)));
                num += (int)p.position.X;
                num2 += (int)p.position.Y;
                Vector2 vector = new Vector2(num, num2);
                float num3 = Main.npc[i].position.X - vector.X;
                float num4 = Main.npc[i].position.Y - vector.Y;
                float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
                num5 = 8f / num5;
                num3 *= num5;
                num4 *= num5;
                Projectile.NewProjectile((float)num, (float)num2, num4, num5, ModContent.ProjectileType<Projectiles.Melee.PumpkinHead>(), dmg, kb, p.whoAmI, (float)i, 0f);
            }
        }

    }
}
