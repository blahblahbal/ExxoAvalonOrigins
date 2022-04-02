using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class Gastropod : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gastropod");
        Description.SetDefault("The gastropod will fight for you");
        Main.buffNoTimeDisplay[Type] = true;
        Main.buffNoSave[Type] = true;
    }

    public override void Update(Player player, ref int k)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summon.GastrominiSummon>()] > 0)
        {
            player.Avalon().gastroMinion = true;
        }
        if (!player.Avalon().gastroMinion)
        {
            player.DelBuff(k);
            k--;
        }
        else
        {
            player.buffTime[k] = 18000;
        }
    }
}