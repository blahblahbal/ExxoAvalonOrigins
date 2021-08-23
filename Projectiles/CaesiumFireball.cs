using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Projectiles{	public class CaesiumFireball : ModProjectile	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Caesium Fireball");		}		public override void SetDefaults()		{
            projectile.width = 16;
            projectile.height = 16;			projectile.aiStyle = 27;			projectile.melee = true;			projectile.alpha = 255;			projectile.friendly = true;		}
		//public override Color? GetAlpha(Color lightColor)
		//{
		//	if (this.projectile.localAI[1] >= 15f)
		//	{
		//		return new Color(255, 255, 255, this.projectile.alpha);
		//	}
		//	if (this.projectile.localAI[1] < 5f)
		//	{
		//		return Color.Transparent;
		//	}
		//	int num7 = (int)((this.projectile.localAI[1] - 5f) / 10f * 255f);
		//	return new Color(num7, num7, num7, num7);
		//}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Fireball"));
            projectile.damage <<= 1;
            projectile.penetrate = 10;
            projectile.width <<= 3;
            projectile.height <<= 3;
            projectile.Damage();
        //for (int num949 = 4; num949 < 31; num949++)
        //{
        //	float num950 = projectile.oldVelocity.X * (30f / (float)num949);
        //	float num951 = projectile.oldVelocity.Y * (30f / (float)num949);
        //	int num952 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num950, projectile.oldPosition.Y - num951), 8, 8, DustID.PinkFairy, projectile.oldVelocity.X, projectile.oldVelocity.Y, 255, default(Color), 1.8f);
        //	Main.dust[num952].noGravity = true;
        //	Dust dust = Main.dust[num952];
        //	dust.velocity *= 0.5f;
        //	num952 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num950, projectile.oldPosition.Y - num951), 8, 8, DustID.PinkFairy, projectile.oldVelocity.X, projectile.oldVelocity.Y, 255, default(Color), 1.4f);
        //	dust = Main.dust[num952];
        //	dust.velocity *= 0.05f;
        //	Main.dust[num952].noGravity = true;
        //}
    }
	}}