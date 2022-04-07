using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Consumables;

class InfestedCarcass : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Infested Carcass");
        Tooltip.SetDefault("Summons Bacterium Prime");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.width = dims.Width;
        Item.useTime = 45;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.value = 0;
        Item.maxStack = 20;
        Item.useAnimation = 45;
        Item.height = dims.Height;
    }

    public override bool CanUseItem(Player player)
    {
        return !NPC.AnyNPCs(ModContent.NPCType<NPCs.BacteriumPrime>()) && player.Avalon().ZoneContagion;
    }

    public override bool? UseItem(Player player)
    {
        NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.BacteriumPrime>());
        SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
        return true;
    }
}
