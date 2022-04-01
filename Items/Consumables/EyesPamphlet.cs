using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class EyesPamphlet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eyes' Pamphlet");
            Tooltip.SetDefault("Summons three Eyes of Cthulhu");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.width = dims.Width;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = 0;
            Item.maxStack = 30;
            Item.useAnimation = 45;
            Item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.EyeofCthulhu) && !Main.dayTime;
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.Lens, 20).AddTile(TileID.DemonAltar).Register();
        }
    }
}
