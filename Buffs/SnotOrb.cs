using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class SnotOrb : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Snot Orb");
        Description.SetDefault("The snot orb provides light");
        Main.buffNoTimeDisplay[Type] = true;
        Main.lightPet[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.buffTime[buffIndex] = 18000;
        player.Avalon().snotOrb = true;
        if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SnotOrb>()] <= 0 &&
            player.whoAmI == Main.myPlayer)
        {
            Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                player.position.Y + (player.height / 2),
                0f, 0f, ModContent.ProjectileType<Projectiles.SnotOrb>(), 0, 0f, player.whoAmI);
        }
    }

    /*public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SnotOrb>()] > 0)
        {
            player.Avalon().snotOrb = true;
        }
        if (!player.Avalon().snotOrb)
        {
            player.DelBuff(k);
            k--;
        }
        else
        {
            player.buffTime[k] = 18000;
        }
    }*/
}
