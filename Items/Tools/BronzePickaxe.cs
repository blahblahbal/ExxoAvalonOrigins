using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

public class BronzePickaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bronze Pickaxe");
    }
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.TinPickaxe);
    }
}