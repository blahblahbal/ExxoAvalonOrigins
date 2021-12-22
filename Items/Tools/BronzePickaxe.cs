using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    internal class BronzePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Pickaxe");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.TinPickaxe);
        }
    }
}
