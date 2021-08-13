using Terraria;using Terraria.ModLoader;namespace ExxoAvalonOrigins.Buffs.AdvancedBuffs{
    public class AdvBuilder : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Advanced Builder");
            Description.SetDefault("Increased placement speed and range");
        }

        public override void Update(Player player, ref int k)
        {
            player.tileSpeed += 0.5f;
            player.wallSpeed += 0.5f;
            player.blockRange += 2;
        }
    }}