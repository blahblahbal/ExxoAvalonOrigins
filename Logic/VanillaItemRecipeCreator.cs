﻿using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Weapons.Melee;
using ExxoAvalonOrigins.Items.Weapons.Throw;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Logic
{
    public static class VanillaItemRecipeCreator
    {
        public static void CreateRecipes(Mod mod)
        {
            ModRecipe recipe;

            recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(ItemID.CopperBar, 6);
            recipe.AddIngredient(ItemID.Wood);
            recipe.anyWood = true;
            recipe.AddRecipeGroup("ExxoAvalonOrigins:CopperBar");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Aglet);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RecallPotion, 3);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddIngredient(ItemID.Glass, 20);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ItemID.MagicMirror);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 6);
            recipe.AddIngredient(ItemID.IronBar, 4);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.IceSkates);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Leather, 7);
            recipe.AddIngredient(ItemID.WaterWalkingPotion, 10);
            recipe.AddIngredient(ModContent.ItemType<WaterShard>(), 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.WaterWalkingBoots);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianSkull);
            recipe.AddIngredient(ItemID.ObsidianSkinPotion, 10);
            recipe.AddIngredient(ModContent.ItemType<BlastShard>(), 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.LavaCharm);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBroadsword);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemID.FallenStar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Starfury);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBroadsword);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemID.FallenStar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Starfury);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBroadsword);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemID.FallenStar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Starfury);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBroadsword>());
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemID.FallenStar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Starfury);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cloud, 25);
            recipe.AddIngredient(ModContent.ItemType<BreezeShard>(), 3);
            recipe.AddIngredient(ItemID.JungleSpores, 20);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.AnkletoftheWind);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cloud, 25);
            recipe.AddIngredient(ModContent.ItemType<BreezeShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<TropicalShroomCap>(), 20);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.AnkletoftheWind);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Cloud, 30);
            recipe.AddIngredient(ItemID.Feather, 2);
            recipe.AddIngredient(ModContent.ItemType<BreezeShard>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.CloudinaBottle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ModContent.ItemType<BlastShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<SacredShard>(), 2);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<LightninginaBottle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<EarthShard>(), 5);
            recipe.AddIngredient(ModContent.ItemType<BreezeShard>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.SandstorminaBottle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.IceBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 5);
            recipe.AddIngredient(ModContent.ItemType<BreezeShard>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.BlizzardinaBottle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.Cloud, 25);
            recipe.AddIngredient(ItemID.SoulofFlight, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.FlyingCarpet);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaCrystal, 3);
            recipe.AddIngredient(ItemID.Shackle, 2);
            recipe.AddIngredient(ModContent.ItemType<CorruptShard>(), 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.BandofStarpower);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 3);
            recipe.AddIngredient(ItemID.Shackle, 2);
            recipe.AddIngredient(ItemID.HealingPotion, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.BandofRegeneration);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldOre);
            recipe.AddIngredient(ItemID.Cloud);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ItemID.SunplateBlock, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBroadsword);
            recipe.AddIngredient(ModContent.ItemType<Icicle>(), 50);
            recipe.AddIngredient(ItemID.FallenStar, 8);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 4);
            recipe.AddTile(TileID.IceMachine);
            recipe.SetResult(ItemID.IceBlade);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBroadsword);
            recipe.AddIngredient(ModContent.ItemType<Icicle>(), 50);
            recipe.AddIngredient(ItemID.FallenStar, 8);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 4);
            recipe.AddTile(TileID.IceMachine);
            recipe.SetResult(ItemID.IceBlade);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBroadsword>());
            recipe.AddIngredient(ModContent.ItemType<Icicle>(), 50);
            recipe.AddIngredient(ItemID.FallenStar, 8);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 4);
            recipe.AddTile(TileID.IceMachine);
            recipe.SetResult(ItemID.IceBlade);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 30);
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddIngredient(ItemID.Wire, 20);
            recipe.AddIngredient(ItemID.Timer1Second);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.Extractinator);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthWatch>());
            recipe.AddIngredient(ItemID.DepthMeter);
            recipe.AddIngredient(ItemID.Compass);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.GPS);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OldShoe);
            recipe.AddIngredient(ItemID.SwiftnessPotion, 2);
            recipe.AddIngredient(ItemID.Cloud, 60);
            recipe.AddIngredient(ModContent.ItemType<BreezeShard>(), 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.HermesBoots);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChaosDust>(), 45);
            recipe.AddIngredient(ItemID.SoulofLight, 25);
            recipe.AddIngredient(ItemID.Diamond, 10);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.RodofDiscord);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStar>(), 5);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.LihzahrdPowerCell);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<RottenFlesh>());
            recipe.AddIngredient(ItemID.IronOre);
            recipe.needWater = true;
            recipe.SetResult(ItemID.ClayBlock, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<RottenFlesh>());
            recipe.AddIngredient(ItemID.IronOre);
            recipe.needWater = true;
            recipe.SetResult(ItemID.ClayBlock, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<RottenFlesh>());
            recipe.AddIngredient(ModContent.ItemType<NickelOre>());
            recipe.needWater = true;
            recipe.SetResult(ItemID.ClayBlock, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cloud);
            recipe.needWater = true;
            recipe.SetResult(ItemID.RainCloud, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RottenFlesh>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Leather);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<YuckyBit>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Leather);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStar>(), 50);
            recipe.AddIngredient(ModContent.ItemType<EarthStone>(), 3);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ItemID.Picksaw);
            recipe.AddRecipe();
        }
    }
}