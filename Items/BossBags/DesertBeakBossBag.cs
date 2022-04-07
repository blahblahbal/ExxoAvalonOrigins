using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.BossBags;

public class DesertBeakBossBag : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Treasure Bag");
        Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.consumable = true;
        Item.width = 36;
        Item.height = 34;
        Item.rare = ItemRarityID.Purple;
        Item.expert = true;
    }

    public override bool CanRightClick()
    {
        return true;
    }

    public override void OpenBossBag(Player player)
    {
        player.QuickSpawnItem(player.GetItemSource_OpenItem(Item.type), ItemID.SandBlock, Main.rand.Next(22, 55));
        player.QuickSpawnItem(player.GetItemSource_OpenItem(Item.type), ModContent.ItemType<DesertFeather>(), Main.rand.Next(6, 11));
        if (ExxoAvalonOriginsWorld.rhodiumOre == ExxoAvalonOriginsWorld.RhodiumVariant.rhodium)
        {
            player.QuickSpawnItem(player.GetItemSource_OpenItem(Item.type), ModContent.ItemType<Placeable.Tile.RhodiumOre>(), Main.rand.Next(20, 31));
        }
        else if (ExxoAvalonOriginsWorld.rhodiumOre == ExxoAvalonOriginsWorld.RhodiumVariant.osmium)
        {
            player.QuickSpawnItem(player.GetItemSource_OpenItem(Item.type), ModContent.ItemType<Placeable.Tile.OsmiumOre>(), Main.rand.Next(20, 31));
        }
        else if (ExxoAvalonOriginsWorld.rhodiumOre == ExxoAvalonOriginsWorld.RhodiumVariant.iridium)
        {
            player.QuickSpawnItem(player.GetItemSource_OpenItem(Item.type), ModContent.ItemType<Placeable.Tile.IridiumOre>(), Main.rand.Next(20, 31));
        }
        if (Main.rand.Next(3) == 0)
        {
            player.QuickSpawnItem(player.GetItemSource_OpenItem(Item.type), ModContent.ItemType<TomeoftheDistantPast>(), 1);
        }
        if (Main.rand.Next(4) == 0)
        {
            player.QuickSpawnItem(player.GetItemSource_OpenItem(Item.type), ModContent.ItemType<Consumables.StaminaCrystal>());
        }
    }

    public override int BossBagNPC => ModContent.NPCType<NPCs.Bosses.DesertBeak>();
}
