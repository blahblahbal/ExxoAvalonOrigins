using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class WorldgenHelper : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("WorldGen Helper");			Tooltip.SetDefault("Use this item to generate a pre-set structure at your location\nDO NOT USE IN NORMAL GAMEPLAY - IT WILL OVERWRITE BLOCKS");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/WorldgenHelper");
            item.rare = 11;			item.width = dims.Width;			item.maxStack = 1;
            item.useAnimation = item.useTime = 30;
            item.useStyle = 1;
            item.value = 0;			item.height = dims.Height;		}        public override bool UseItem(Player player)
        {
            //World.Structures.Nest.CreateWaspNest((int)player.position.X / 16, (int)player.position.Y / 16);
            return true;
        }
    }}