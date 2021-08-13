using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	[AutoloadEquip(EquipType.Legs)]	class BlahsCuisses2 : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Blah's Cuisses");			Tooltip.SetDefault("Melee weapons have a chance to instantly kill your non-boss enemies\nRanged projectiles have a chance to split in two\nTeleportation to the cursor is enabled");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BlahsCuisses2");			item.defense = 100;			item.rare = 11;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
            item.width = dims.Width;			item.value = Item.sellPrice(2, 0, 0, 0);			item.height = dims.Height;		}        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "ItemName")
                {
                    line.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                }
            }
        }
        public override void UpdateEquip(Player player)		{			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().oblivionKill = true;			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().splitProj = true;			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().teleportV = true;		}	}}