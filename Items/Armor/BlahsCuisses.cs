using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class BlahsCuisses : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah's Cuisses");
            Tooltip.SetDefault("Melee weapons have a chance to instantly kill mobs | Teleportation to the\nRanged projectiles have a chance to split in two | cursor is enabled");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 50;
            Item.rare = ItemRarityID.Red;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.height = dims.Height;
        }

        public override void UpdateEquip(Player player)
        {
            player.Avalon().oblivionKill = true;
            player.Avalon().splitProj = true;
            player.Avalon().teleportV = true;
        }
    }
}
