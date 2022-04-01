using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class BronzeShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Shortsword");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TinShortsword);
        }
    }
}
