using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

class BacchusBoots : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bacchus Boots");
        Tooltip.SetDefault("Increases your max number of minions by 2\nIncreases your max number of sentries by 1\n" +
                           "8% increased minion damage\nIncreases armor penetration by 5\nProvides immunity to traps, knockback, fire blocks, and fall damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightPurple;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 2);
        Item.height = dims.Height;
        Item.defense = 3;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.maxMinions += 2;
        player.GetDamage(DamageClass.Summon) += 0.08f;
        player.armorPenetration += 5;
        player.maxTurrets++;
        player.noKnockback = true;
        player.noFallDmg = true;
        player.fireWalk = true;
        player.Avalon().trapImmune = true;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ModContent.ItemType<DionysusAmulet>()).AddIngredient(ModContent.ItemType<GuardianBoots>()).AddTile(TileID.TinkerersWorkbench).Register();
    }
}