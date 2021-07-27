using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class ChantoftheWaterDragon : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Chant of the Water Dragon");			Tooltip.SetDefault("+20% magic damage");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ChantoftheWaterDragon");			item.rare = 8;			item.width = dims.Width;			item.value = 150000;			item.height = dims.Height;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;        }        public override void UpdateAccessory(Player player, bool hideVisual)        {            player.magicDamage += 0.2f;        }    }}