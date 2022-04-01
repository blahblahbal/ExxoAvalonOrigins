using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class DivineLightJerkin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Light Jerkin");
            Tooltip.SetDefault("10% increased critical strike chance" +
                "\n25% increased critical damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Armor/DivineLightJerkin");
            Item.defense = 18;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 1, 90, 0);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.PixieDust, 25).AddIngredient(ItemID.HallowedBar, 25).AddIngredient(ItemID.SoulofLight, 20).AddTile(TileID.MythrilAnvil).Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Magic) += 10;
            player.GetCritChance(DamageClass.Melee) += 10;
            player.GetCritChance(DamageClass.Ranged) += 10;
            player.GetCritChance(DamageClass.Throwing) += 10;
            player.Avalon().critDamageMult += 0.25f;
        }
    }
}
