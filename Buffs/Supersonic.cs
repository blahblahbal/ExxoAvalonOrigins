using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace ExxoAvalonOrigins.Buffs
{
	public class Supersonic : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Supersonic");
			Description.SetDefault("You are speedy");
		}

		public override void Update(Player player, ref int k)
		{
            player.accRunSpeed = 14.29f;
            if (player.controlLeft)
            {
                if (player.velocity.X > -5f)
                {
                    player.velocity.X = player.velocity.X - 0.41f;
                }
                if (player.velocity.X < -5f && player.velocity.X > -14f)
                {
                    player.velocity.X = player.velocity.X - 0.39f;
                }
            }
            if (player.controlRight)
            {
                if (player.velocity.X < 5f)
                {
                    player.velocity.X = player.velocity.X + 0.41f;
                }
                if (player.velocity.X > 5f && player.velocity.X < 14f)
                {
                    player.velocity.X = player.velocity.X + 0.39f;
                }
            }
            if (player.velocity.X > 6f || player.velocity.X < -6f)
            {
                var newColor = default(Color);
                var num = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Cloud, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 100, newColor, 2f);
                Main.dust[num].noGravity = true;
            }
        }
	}
}
