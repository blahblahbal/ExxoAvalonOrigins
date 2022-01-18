using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Buffs
{
    public class Berserk : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Berserk!");
            Description.SetDefault("True melee weapons deal 150% increased critical damage");
        }

        public override void Update(Player player, ref int k)
        {
            if (player.HeldItem.shoot == ProjectileID.None)
                player.GetModPlayer<ExxoAvalonOriginsModPlayer>().critDamageMult += 1.5f;
        }
    }
}