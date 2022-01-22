using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    public class TropicalBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropic Blade");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.height = dims.Height;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = item.useAnimation = 24;
            item.damage = 21;
            item.knockBack = 2;
            item.scale = 1f;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Orange;
            item.melee = true;
            item.value = Item.sellPrice(0, 0, 54, 0);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(
            new Vector2(hitbox.X, hitbox.Y),
            hitbox.Width,
            hitbox.Height,
            ModContent.DustType<Dusts.TropicalDust>(),
            (player.velocity.X * 0.2f) + (player.direction * 3),
            player.velocity.Y * 0.2f,
            0,
            new Color(),
            1f
            );
            Main.dust[dust].noGravity = true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(ModContent.BuffType<Buffs.Malaria>(), 660);
            }
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(ModContent.BuffType<Buffs.Malaria>(), 660);
            }
        }
    }
}
