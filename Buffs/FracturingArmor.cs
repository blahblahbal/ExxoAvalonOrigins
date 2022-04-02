using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class FracturingArmor : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Fracturing Armor");
        Description.SetDefault("Defense is decreased by ");
        Main.debuff[Type] = true;
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
    }

    public override void ModifyBuffTip(ref string tip, ref int rare)
    {
        tip += Main.LocalPlayer.Avalon().fAlevel;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense -= player.Avalon().fAlevel;
        if (player.Avalon().fAlastRecord <=
            player.buffTime[player.FindBuffIndex(ModContent.BuffType<FracturingArmor>())])
        {
            player.Avalon().fAlastRecord =
                player.buffTime[player.FindBuffIndex(ModContent.BuffType<FracturingArmor>())];
            if (player.Avalon().fAlevel < 30)
            {
                player.Avalon().fAlevel += 3;
            }
        }
        //Main.buffTip[149] = "Decreased defense by " + player.GetModPlayer<ExxoAvalonOriginsGlobalPlayer>(mod).fAlevel;
    }
}
