﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class WorldgenHelper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("WorldGen Helper");
            Tooltip.SetDefault("Use this item to generate a pre-set structure at your location\nDO NOT USE IN NORMAL GAMEPLAY - IT WILL OVERWRITE BLOCKS");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Purple;
            item.width = dims.Width;
            item.maxStack = 1;
            item.useAnimation = item.useTime = 30;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 0;
            item.height = dims.Height;
            //item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Scroll");
        }

        public override bool UseItem(Player player)
        {
            //ExxoAvalonOriginsWorld.GenerateSulphur();
            //ModContent.GetInstance<ExxoAvalonOriginsWorld>().GenerateCrystalMines();
            //World.Structures.SkyFortress.Generate((int)player.position.X / 16, (int)player.position.Y / 16);
            //World.Structures.CaesiumSpike.CreateSpikeUp((int)player.position.X / 16, (int)player.position.Y / 16, (ushort)ModContent.TileType<Tiles.CaesiumOre>());
            return true;
        }
    }
}

