using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class EctoplasmicBeacon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ectoplasmic Beacon");
            Tooltip.SetDefault("Summons Phantasm\nMust be used in the Hellcastle");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/EctoplasmicBeacon");
            item.consumable = true;
            item.width = dims.Width;
            item.useTime = 45;
            item.useStyle = 4;
            item.value = 0;
            item.maxStack = 20;
            item.useAnimation = 45;
            item.height = dims.Height;            item.rare = 8;        }        public override bool CanUseItem(Player player)        {            return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Phantasm>()) && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle;        }        public override bool UseItem(Player player)        {            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Phantasm>());            Main.PlaySound(SoundID.Roar, player.position, 0);            return true;        }        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(ModContent.ItemType<SolariumStar>(), 8);
            recipe.AddTile(ModContent.TileType<Tiles.LibraryAltar>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }    }}