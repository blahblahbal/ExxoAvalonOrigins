using ExxoAvalonOrigins.Projectiles.Summon;
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

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<GastrominiSummon>()] > 0)
        {
            player.Avalon().gastroMinion = true;
        }

        if (!player.Avalon().gastroMinion)
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
