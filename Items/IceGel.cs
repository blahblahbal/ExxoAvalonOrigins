using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class IceGel : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Ice Gel");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/IceGel");			item.rare = 0;			item.width = dims.Width;			item.value = 700;			item.maxStack = 999;			item.height = dims.Height;		}	}}