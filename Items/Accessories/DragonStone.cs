using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class DragonStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Stone");
            Tooltip.SetDefault("Provides immunity to flying creatures");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.accessory = true;
            item.height = dims.Height;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.npcTypeNoAggro[NPCID.DemonEye] = true;
            player.npcTypeNoAggro[NPCID.EaterofSouls] = true;
            player.npcTypeNoAggro[NPCID.Harpy] = true;
            player.npcTypeNoAggro[NPCID.CaveBat] = true;
            player.npcTypeNoAggro[NPCID.JungleBat] = true;
            player.npcTypeNoAggro[NPCID.Pixie] = true;
            player.npcTypeNoAggro[NPCID.GiantBat] = true;
            player.npcTypeNoAggro[NPCID.Crimera] = true;
            player.npcTypeNoAggro[NPCID.CataractEye] = true;
            player.npcTypeNoAggro[NPCID.SleepyEye] = true;
            player.npcTypeNoAggro[NPCID.DialatedEye] = true;
            player.npcTypeNoAggro[NPCID.GreenEye] = true;
            player.npcTypeNoAggro[NPCID.PurpleEye] = true;
            player.npcTypeNoAggro[NPCID.Moth] = true;
            player.npcTypeNoAggro[NPCID.FlyingFish] = true;
            player.npcTypeNoAggro[NPCID.FlyingSnake] = true;
            player.npcTypeNoAggro[NPCID.AngryNimbus] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.VampireHarpy>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.Dragonfly>()] = true;
        }
    }
}
