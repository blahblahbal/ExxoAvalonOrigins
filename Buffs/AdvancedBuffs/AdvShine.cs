using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs;

public class AdvShine : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Shine");
        Description.SetDefault("Emitting a lot of light");
    }

    public override void Update(Player player, ref int k)
    {
        Lighting.AddLight((int)(player.position.X + (player.width / 2)) / 16, (int)(player.position.Y + (player.height / 2)) / 16, 2f, 2f, 2f);
    }
}