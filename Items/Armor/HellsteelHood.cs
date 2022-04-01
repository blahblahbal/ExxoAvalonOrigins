using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class HellsteelHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellsteel Hood");
            Tooltip.SetDefault("16% increased minion damage\nIncreases your max number of minions by 1");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.defense = 26;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 15).AddIngredient(ModContent.ItemType<FleshCap>()).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<HellsteelVest>() && legs.type == ModContent.ItemType<HellsteelPants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases your max number of minions by 10"; // make mecha hungry summon weapon
            player.maxMinions += 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.16f;
            player.maxMinions++;
        }
    }
}
