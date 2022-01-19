using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class AstrallineArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astralline Artifact");
            Tooltip.SetDefault("Allows you to astral project\nRun into enemies to mark them while astral projecting\nEnemies marked will take triple damage until they die");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Accessories/AstrallineArtifact");
            item.rare = -12;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.height = dims.Height;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().astralProject = true;
        }
    }
}
