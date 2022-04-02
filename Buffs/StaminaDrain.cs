using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs;

public class StaminaDrain : ModBuff
{
    int stacks = 1;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Stamina Sickness");
        Description.SetDefault("Stamina usage is increased by ");
        Main.debuff[Type] = true;
        canBeCleared = false;
    }
    public override void ModifyBuffTip(ref string tip, ref int rare)
    {
        if (stacks == 1) tip += "20%";
        else if (stacks == 2) tip += "40%";
        else if (stacks == 3) tip += "60%";
        else if (stacks == 4) tip += "80%";
        else if (stacks == 5) tip += "100%";
    }
    public override void Update(Player player, ref int k)
    {
        player.Avalon().staminaDrain = true;
        stacks = player.Avalon().staminaDrainStacks;
        if (player.buffTime[k] == 0)
        {
            player.Avalon().staminaDrainStacks = 1;
        }
    }
}