using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class Reflector : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Reflector");
        Description.SetDefault("The minions will reflect projectiles for you");
        Main.buffNoTimeDisplay[Type] = true;
        Main.buffNoSave[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Reflector>()] > 0)
        {
            player.Avalon().reflectorMinion = true;
        }

        if (!player.Avalon().reflectorMinion)
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
