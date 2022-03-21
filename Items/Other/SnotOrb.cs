using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Other
{
    class SnotOrb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snot Orb");
            Tooltip.SetDefault("Creates a snot orb that provides light");
        }
        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600);
            }
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(1183);
            item.shoot = ModContent.ProjectileType<Projectiles.SnotOrb>();
            item.buffType = ModContent.BuffType<Buffs.SnotOrb>();
            item.value = Item.sellPrice(0, 0, 54);
            item.rare = ItemRarityID.Blue;
        }
    }
}
