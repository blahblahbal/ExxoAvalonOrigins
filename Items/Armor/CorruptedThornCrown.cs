using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class CorruptedThornCrown : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Corrupted Thorn Crown");
        Tooltip.SetDefault("15% increased melee and ranged damage" +
                           "\n35% increased magic damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Items/Armor/CorruptedThornCrown");
        Item.defense = 7;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 2, 10, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Spike, 20).AddIngredient(ModContent.ItemType<Material.CorruptShard>(), 20).AddIngredient(ItemID.SoulofNight, 10).AddTile(TileID.MythrilAnvil).Register();
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<CorruptedThornBodyarmor>() && legs.type == ModContent.ItemType<CorruptedThornGreaves>();
    }

    public override void UpdateArmorSet(Player player)
    {
        ExxoAvalonOriginsModPlayer modPlayer = player.Avalon();
        player.setBonus = "Blood Casting, Necrotic Aura, 75% increased mana usage";
        modPlayer.bloodCast = true;
        modPlayer.necroticAura = true;
        player.manaCost += 0.75f;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Ranged) += 0.15f;
        player.GetDamage(DamageClass.Melee) += 0.15f;
        player.GetDamage(DamageClass.Magic) += 0.35f;
    }
}