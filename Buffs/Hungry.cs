using ExxoAvalonOrigins.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class Hungry : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hungry");
        Description.SetDefault("The hungry will fight for you");
        Main.buffNoTimeDisplay[Type] = true;
        Main.buffNoSave[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<HungrySummon>()] > 0)
        {
            player.Avalon().hungryMinion = true;
        }

        if (!player.Avalon().hungryMinion)
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
