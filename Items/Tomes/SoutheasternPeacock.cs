using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tomes;

class SoutheasternPeacock : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Southeastern Peacock");
        Tooltip.SetDefault("Tome\n+3% critical strike chance, -5% mana cost\n8% increased minion damage, 5% increased minion knockback");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightPurple;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 40);
        Item.height = dims.Height;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetCritChance(DamageClass.Melee) += 3;
        player.GetCritChance(DamageClass.Ranged) += 3;
        player.GetCritChance(DamageClass.Throwing) += 3;
        player.GetCritChance(DamageClass.Magic) += 3;
        player.minionKB += 0.05f;
        player.GetDamage(DamageClass.Summon) += 0.08f;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<TomorrowsPhoenix>()).AddIngredient(ModContent.ItemType<ChristmasTome>()).AddIngredient(ModContent.ItemType<MysticalTomePage>(), 2).AddTile(ModContent.TileType<Tiles.TomeForge>()).Register();
    }
}