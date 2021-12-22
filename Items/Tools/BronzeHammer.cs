using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class BronzeHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Hammer");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.TinHammer);
        }
    }
}
