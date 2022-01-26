using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class UltrablivionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ultrablivion");
            Description.SetDefault("The mini Ultrablivion will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.UltraHMinion>()] > 0 && player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.UltraLMinion>()] > 0 && player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.UltraRMinion>()] > 0)
            {
                modPlayer.UltraHMinion = true;
                modPlayer.UltraLMinion = true;
                modPlayer.UltraRMinion = true;
            }
            if (!modPlayer.UltraHMinion && !modPlayer.UltraLMinion && !modPlayer.UltraRMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}
