using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class DivineLightHuntingHorns : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Light Hunting Horns");
            Tooltip.SetDefault("15% increased melee and magic damage"
                + "\n25% increased ranged damage");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Armor/DivineLightHuntingHorns");
            item.defense = 10;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 2, 10, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<DivineLightJerkin>() && legs.type == ModContent.ItemType<DivineLightTreads>();
        }

        public override void UpdateArmorSet(Player player)
        {
            ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();
            player.setBonus = "Reckoning: your reckoning level increases as you attack enemies, up to a maximum of ten"
                + "\nThe greater your reckoning level, the greater your ranged critical strike chance"
                + "\nYour reckoning level decreases gradually over time"
                + "\nReckoning Level: " + modPlayer.reckoningLevel;
            modPlayer.reckoning = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.25f;
            player.meleeDamage += 0.15f;
            player.magicDamage += 0.15f;
        }
    }
}
