using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TheHeavenlyScent : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("The Heavenly Scent");			Tooltip.SetDefault("+2 life regen");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TheHeavenlyScent");			item.rare = 7;			item.width = dims.Width;			item.value = 150000;			item.height = dims.Height;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;        }        public override void UpdateAccessory(Player player, bool hideVisual)        {            player.lifeRegen += 2;        }    }}