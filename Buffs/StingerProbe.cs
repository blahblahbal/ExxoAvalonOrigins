using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class StingerProbe : ModBuff
    {
        public bool stingerProbeMinion = false;
        public int spawnProbeTimer;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stinger Probe");
            Description.SetDefault("'Don't get too close!'");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            Projectiles.StingerProbeMinion.rotTimer += 0.5f;
            if (Projectiles.StingerProbeMinion.rotTimer >= 360)
                Projectiles.StingerProbeMinion.rotTimer = 0;

            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.StingerProbeMinion>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }

            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.StingerProbeMinion>()] < 4)
                spawnProbeTimer++;
            else
                spawnProbeTimer = 0;

            if (spawnProbeTimer >= 300)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.StingerProbeMinion>(), (player.HeldItem.damage / 4) * 3, 0f, player.whoAmI);
                spawnProbeTimer = 0;
            }
}
    }
}
