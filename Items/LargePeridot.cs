using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class LargePeridot : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Large Peridot");			Tooltip.SetDefault("For Capture the Gem");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/LargePeridot");			item.rare = 1;			item.width = dims.Width;			item.height = dims.Height;		}	}}