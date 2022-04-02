using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.BossBags;

public class KingStingBossBag : ModItem
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
        //player.TryGettingDevArmor();

        player.QuickSpawnItem(ItemID.BeeWax, Main.rand.Next(16, 27));
        player.QuickSpawnItem(ItemID.BottledHoney, Main.rand.Next(5, 16));
        if (Main.rand.Next(4) == 0) player.QuickSpawnItem(ItemID.JestersArrow, Main.rand.Next(20, 31));
        if (Main.rand.Next(7) == 0) player.QuickSpawnItem(ModContent.ItemType<Vanity.KingStingMask>());
        if (Main.rand.Next(4) == 0)
        {
            player.QuickSpawnItem(ModContent.ItemType<Consumables.StaminaCrystal>());
        }
    }

    public override int BossBagNPC => ModContent.NPCType<NPCs.Bosses.KingSting>();
}