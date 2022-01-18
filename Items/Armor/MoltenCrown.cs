using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class MoltenCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Crown");
            Tooltip.SetDefault("Magic helmet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 3;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.value = 30000;
            item.height = dims.Height;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MoltenBreastplate && legs.type == ItemID.MoltenGreaves;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.HellstoneBar, 10);
            r.AddIngredient(ModContent.ItemType<Items.Material.FireShard>());
            r.AddTile(TileID.Anvils);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "17% increased magic damage and 17% decreased mana usage";
            player.magicDamage += 0.17f;
            player.manaCost -= 0.17f;
        }
    }
}
