using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class OblivirodBobber : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Oblivirod Bobber");
    }

    public override void SetDefaults()
    {
        Projectile.width = 14;
        Projectile.height = 14;
        Projectile.aiStyle = 61;
        Projectile.bobber = true;
        Projectile.penetrate = -1;
    }
    public override bool PreDrawExtras()
    {
        return Projectile.DrawFishingLine(ModContent.ItemType<Items.Tools.Oblivirod>(), new Color(234, 113, 201, 100));
    }
}
