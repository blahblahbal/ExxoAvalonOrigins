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
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Armor/DivineLightHuntingHorns");
            Item.defense = 10;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.value = Item.sellPrice(0, 2, 10, 0);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.PixieDust, 20).AddIngredient(ItemID.HallowedBar, 20).AddIngredient(ItemID.SoulofLight, 10).AddTile(TileID.MythrilAnvil).Register();
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
            player.GetDamage(DamageClass.Ranged) += 0.25f;
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetDamage(DamageClass.Magic) += 0.15f;
        }
    }
}
