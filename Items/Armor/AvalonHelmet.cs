using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class AvalonHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Avalon Helmet");
            Tooltip.SetDefault("32% increased damage"
                + "\n20% decreased mana usage"
                + "\nIncreases maximum mana by 280"
                + "\nOccasionally summons a leaf storm when damaged");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/AvalonHelmet");
            item.defense = 40;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 41, 0, 0);
            item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AvalonBodyarmor>() && legs.type == ModContent.ItemType<AvalonCuisses>();
        }

        public override void UpdateArmorSet(Player player)
        {
            ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();
            player.setBonus = "Restoration"
                + "\nDealing a critical hit temporarily gives the 'Blessing of Avalon' buff"
                + "\nThis buff removes almost all debuffs and greatly increases your stats"
                + "\n\nRetribution"
                + "\nEnemies who strike you are marked for their destruction"
                + "\nThey will take quadruple damage from your next attack";

            modPlayer.avalonRestoration = true;
            modPlayer.avalonRetribution = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.32f;
            player.manaCost -= 0.20f;
            player.statManaMax2 += 280;
            player.Avalon().leafStorm = true;
        }
    }
}
