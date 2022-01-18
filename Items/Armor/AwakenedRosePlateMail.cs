using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class AwakenedRosePlateMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Awakened Rose Plate Mail");
            Tooltip.SetDefault("Press V to teleport to the cursor"
                + "\nOn hitting tiles with a magic attack, there is a chance a small vine of thorns shoots out of the ground");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 21;
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();
            modPlayer.teleportV = true;
            modPlayer.thornMagic = true;
        }
    }
}
