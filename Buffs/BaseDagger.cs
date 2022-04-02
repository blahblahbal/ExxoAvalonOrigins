using ExxoAvalonOrigins.Players;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public abstract class BaseDagger<T> : ModBuff where T : ModProjectile
{
    public override void SetStaticDefaults()
    {
        Main.buffNoTimeDisplay[Type] = true;
        Main.buffNoSave[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<T>()] > 0)
        {
            player.buffTime[buffIndex] = 18000;
        }
        else
        {
            player.DelBuff(buffIndex);
            buffIndex--;
        }

        player.GetModPlayer<ExxoBuffPlayer>().UpdateDaggerStaff();
    }
}
