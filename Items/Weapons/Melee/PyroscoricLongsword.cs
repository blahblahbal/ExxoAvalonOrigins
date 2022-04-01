using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class PyroscoricLongsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pyroscoric Flamesword");
            Tooltip.SetDefault("Shoots a wave of fire\n'It burns, I tell you!'");
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 200);
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 131;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.3f;
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.useTime = 25;
            Item.useAnimation = 20;
            Item.knockBack = 7f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.FireWave>();
            Item.shootSpeed = 25f;
            Item.value = Item.sellPrice(0, 7, 63, 0);
            Item.height = dims.Height;
            Item.UseSound = SoundID.Item1;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            SoundEngine.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 20, 0.8f, 0.25f);
            return true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 0)
            {
                int num162 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 0, default(Color), 2f);
                Main.dust[num162].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 180);
        }
    }
}
