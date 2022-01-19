using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class HornetFood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hornet Food");
            Tooltip.SetDefault("Summons King Sting");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.width = dims.Width;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.value = 0;
            item.maxStack = 20;
            item.useAnimation = 45;
            item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.KingSting>()) && player.Avalon().ZoneTropics;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.KingSting>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }
}
