using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class BronzeBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Broadsword");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.TinBroadsword);
        }
    }
}
