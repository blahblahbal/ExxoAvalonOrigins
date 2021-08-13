using Terraria;using Terraria.ModLoader;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvBloodCast : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Blood Casting");
            Description.SetDefault("Maximum life is added to maximum mana");
        }

        public override void Update(Player player, ref int k)
        {
            player.statManaMax2 += player.statLifeMax2;
        }
    }}