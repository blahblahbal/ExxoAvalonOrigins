using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class AncientElementalExcalibur : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Elemental Excalibur");
            Tooltip.SetDefault("'The unification of the Elements'\n'A relic of the past'");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 190;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.2f;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.knockBack = 7f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 50, 0, 0);
            Item.useAnimation = 10;
            Item.height = dims.Height;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                int num313 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Enchanted_Pink);
                Main.dust[num313].noGravity = true;
                Main.dust[num313].fadeIn = 1.25f;
                Main.dust[num313].velocity *= 0.25f;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            int randomNum = Main.rand.Next(8);
            if (randomNum == 0) target.AddBuff(BuffID.Poisoned, 300);
            else if (randomNum == 1) target.AddBuff(BuffID.OnFire, 200);
            else if (randomNum == 2) target.AddBuff(BuffID.Confused, 120);
            else if (randomNum == 3) target.AddBuff(BuffID.CursedInferno, 300);
            else if (randomNum == 4) target.AddBuff(BuffID.Frostburn, 300);
            else if (randomNum == 5) target.AddBuff(BuffID.Venom, 240);
            else if (randomNum == 6) target.AddBuff(BuffID.Ichor, 300);
            else if (randomNum == 7)
            {
                if (Logic.CanBeFrozen.CanFreeze(target))
                    target.AddBuff(ModContent.BuffType<Buffs.Frozen>(), 60);
                else
                    randomNum = Main.rand.Next(7);
            }
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
            int randomNum = Main.rand.Next(8);
            if (randomNum == 0) target.AddBuff(BuffID.Poisoned, 300);
            else if (randomNum == 1) target.AddBuff(BuffID.OnFire, 200);
            else if (randomNum == 2) target.AddBuff(BuffID.Confused, 120);
            else if (randomNum == 3) target.AddBuff(BuffID.CursedInferno, 300);
            else if (randomNum == 4) target.AddBuff(BuffID.Frostburn, 300);
            else if (randomNum == 5) target.AddBuff(BuffID.Venom, 240);
            else if (randomNum == 6) target.AddBuff(BuffID.Ichor, 300);
            else if (randomNum == 7) target.AddBuff(BuffID.Frozen, 60);
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<VertexofExcalibur>()).AddIngredient(ModContent.ItemType<PyroscoricLongsword>()).AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 20).AddIngredient(ModContent.ItemType<Material.ElementShard>(), 15).AddTile(ModContent.TileType<Tiles.Ancient.AncientWorkbench>()).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<VertexofExcalibur>()).AddIngredient(ModContent.ItemType<TritanoriumBroadsword>()).AddIngredient(ModContent.ItemType<Material.SoulofDelight>(), 20).AddIngredient(ModContent.ItemType<Material.ElementShard>(), 15).AddTile(ModContent.TileType<Tiles.Ancient.AncientWorkbench>()).Register();
        }
    }
}
