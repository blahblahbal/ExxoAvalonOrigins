using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Consumables;

class TheBeak : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("The Beak");
        Tooltip.SetDefault("Summons Desert Beak");
    }

    public override void SetDefaults()
    {
        //Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.width = 32;
        Item.useTime = 40;
        Item.maxStack = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useAnimation = 40;
        Item.height = 28;
    }

    public override bool CanUseItem(Player player)
    {
        return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.DesertBeak>());
    }

    public override bool? UseItem(Player player)
    {
        NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.DesertBeak>());
        Main.PlaySound(SoundID.Roar, player.position, 0);
        return true;
    }
}