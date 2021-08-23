using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class IridiumPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Pickaxe");
            Tooltip.SetDefault("Can mine Hellstone");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/IridiumPickaxe");
            item.UseSound = SoundID.Item1;
            item.damage = 15;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1f;
            item.rare = ItemRarityID.LightRed;
            item.pick = 85;
            item.width = dims.Width;
            item.useTime = 15;
            item.knockBack = 2.6f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == mod.ItemType("IridiumPickaxe"))
            {
                player.pickSpeed -= 0.5f;
            }
        }
    }}