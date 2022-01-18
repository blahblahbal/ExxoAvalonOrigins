using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
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
            item.consumable = true;
            item.width = 32;
            item.useTime = 40;
            item.maxStack = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 40;
            item.height = 28;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.DesertBeak>());
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.DesertBeak>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }
}
