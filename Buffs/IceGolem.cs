using ExxoAvalonOrigins.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class IceGolem : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ice Golem");
        Description.SetDefault("The ice golem will fight for you");
        Main.buffNoTimeDisplay[Type] = true;
        Main.buffNoSave[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<IceGolemSummon>()] > 0)
        {
            player.Avalon().iceGolem = true;
        }

        if (!player.Avalon().iceGolem)
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
