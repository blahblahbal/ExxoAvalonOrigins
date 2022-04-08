using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools;

class SonicScrewdriverMkIII : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sonic Screwdriver Mk III");
        Tooltip.SetDefault("Reveals treasures, ores, mobs, and dangers\nTells time, shows position, and can open all locks");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.useTime = 70;
        Item.value = Item.sellPrice(0, 10, 0, 0);
        Item.useStyle = ItemUseStyleID.Thrust;
        Item.useAnimation = 70;
        Item.height = dims.Height;
        Item.UseSound = SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/SonicScrewdriver");
    }
}
