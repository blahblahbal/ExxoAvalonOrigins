using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class StickyCharm : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Sticky Charm");			Tooltip.SetDefault("Reduces damage taken by 10% and negates fall damage\nProvides immunity to slimes");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/StickyCharm");			item.rare = ItemRarityID.Orange;			item.width = dims.Width;			item.accessory = true;			item.value = 200000;			item.height = dims.Height;		}		public override void UpdateAccessory(Player player, bool hideVisual)		{			player.endurance += 0.1f;			player.noFallDmg = true;            player.npcTypeNoAggro[1] = true;
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
        }	}}