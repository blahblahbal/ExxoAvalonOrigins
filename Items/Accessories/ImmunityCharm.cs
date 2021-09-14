using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class ImmunityCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Immunity Charm");
			Tooltip.SetDefault("Provides immunity to slimes and flying creatures\nProvides 20 defense against undead monsters\nReduces damage taken by 10% and negates fall damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Accessories/ImmunityCharm");
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.value = Item.sellPrice(0, 7, 25, 0);
			item.accessory = true;
			item.height = dims.Height;
		}

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<StickyCharm>());
            r.AddIngredient(ModContent.ItemType<UndeadTalisman>());
            r.AddIngredient(ModContent.ItemType<DragonStone>());
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().undeadTalisman = true;
            player.endurance += 0.1f;
            player.noFallDmg = true;
            player.npcTypeNoAggro[1] = true;
            player.npcTypeNoAggro[16] = true;
            player.npcTypeNoAggro[59] = true;
            player.npcTypeNoAggro[71] = true;
            player.npcTypeNoAggro[81] = true;
            player.npcTypeNoAggro[138] = true;
            player.npcTypeNoAggro[121] = true;
            player.npcTypeNoAggro[122] = true;
            player.npcTypeNoAggro[141] = true;
            player.npcTypeNoAggro[147] = true;
            player.npcTypeNoAggro[183] = true;
            player.npcTypeNoAggro[184] = true;
            player.npcTypeNoAggro[204] = true;
            player.npcTypeNoAggro[225] = true;
            player.npcTypeNoAggro[244] = true;
            player.npcTypeNoAggro[302] = true;
            player.npcTypeNoAggro[333] = true;
            player.npcTypeNoAggro[335] = true;
            player.npcTypeNoAggro[334] = true;
            player.npcTypeNoAggro[336] = true;
            player.npcTypeNoAggro[537] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.CopperSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.TinSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.BronzeSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.IronSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.LeadSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.NickelSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.SilverSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.TungstenSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.ZincSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.GoldSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.PlatinumSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.BismuthSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.RhodiumSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.OsmiumSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.IridiumSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.CobaltSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.PalladiumSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.DurantiumSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.MythrilSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.OrichalcumSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.NaquadahSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.AdamantiteSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.TitaniumSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.TroxiniumSlime>()] = true;
            player.npcTypeNoAggro[ModContent.NPCType<NPCs.DarkMatterSlime>()] = true;
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