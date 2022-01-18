using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
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
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.useTime = 70;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useAnimation = 70;
            item.height = dims.Height;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SonicScrewdriver");
        }
    }
}
