using ExxoAvalonOrigins.Items.Accessories;
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
            recipe.AddIngredient(ModContent.ItemType<Items.Vanity.BismuthCrown>());
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.SlimeCrown);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NullEmblem>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.RangerEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NullEmblem>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.SorcererEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NullEmblem>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.WarriorEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NullEmblem>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.SummonerEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Bar.FeroziumBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.FrostHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Bar.FeroziumBar>(), 24);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.FrostBreastplate);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Bar.FeroziumBar>(), 18);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.FrostLeggings);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:CopperBar", 6);
            recipe.AddIngredient(ItemID.Wood);
            recipe.anyWood = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Aglet);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddIngredient(ModContent.ItemType<NickelOre>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.IronskinPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ModContent.ItemType<BismuthOre>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SpelunkerPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Bar.BismuthBar>(), 2);
            recipe.AddIngredient(ItemID.PinkTorch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PeaceCandle);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Snotsabre>());
            recipe.AddIngredient(ItemID.Muramasa);
            recipe.AddIngredient(ItemID.BladeofGrass);
            recipe.AddIngredient(ItemID.FieryGreatsword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.NightsEdge);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LightsBane);
            recipe.AddIngredient(ItemID.Muramasa);
            recipe.AddIngredient(ModContent.ItemType<FieryBladeofGrass>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.NightsEdge);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BloodButcherer);
            recipe.AddIngredient(ItemID.Muramasa);
            recipe.AddIngredient(ModContent.ItemType<FieryBladeofGrass>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.NightsEdge);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Snotsabre>());
            recipe.AddIngredient(ItemID.Muramasa);
            recipe.AddIngredient(ModContent.ItemType<FieryBladeofGrass>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.NightsEdge);
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
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(ModContent.ItemType<FleshyTendril>(), 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.GuideVoodooDoll);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.MagicPowerPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.MagicPowerPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddIngredient(ItemID.Vertebrae);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.BattlePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddIngredient(ModContent.ItemType<YuckyBit>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.BattlePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddIngredient(ItemID.Cactus);
            recipe.AddIngredient(ItemID.WormTooth);
            recipe.AddIngredient(ItemID.Stinger);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.ThornsPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ItemID.Feather);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.GravitationPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ItemID.Feather);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.GravitationPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Amber);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.CratePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Amber);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.CratePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Bone);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddIngredient(ItemID.Shiverthorn);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.TitanPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Bone);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddIngredient(ItemID.Shiverthorn);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.TitanPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Hemopiranha);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.RagePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Hemopiranha);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.RagePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Ebonkoi);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.WrathPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Ebonkoi);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.WrathPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.SpecularFish);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.RecallPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.SpecularFish);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.RecallPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledHoney, 2);
            recipe.AddIngredient(ItemID.SoulofFlight);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.Potions.BeeRepellent>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BottledLava>());
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddIngredient(ModContent.ItemType<Sweetstem>(), 2);
            recipe.AddIngredient(ItemID.Hellstone);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.Potions.ForceFieldPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Stinkfish);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.StinkPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Stinkfish);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.StinkPotion);
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
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Spike, 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(ItemID.BeetleHusk, 2);
            recipe.anyWood = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.WoodenSpike, 40);
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
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Timer1Second);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.Extractinator);
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
            recipe.AddIngredient(ItemID.LeadOre);
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
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ItemID.Picksaw);
            recipe.AddRecipe();

            // seed fabricator stuff
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddIngredient(ItemID.Torch, 2);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.BlinkrootSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Mushroom, 4);
            recipe.AddIngredient(ItemID.DirtBlock, 6);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.DaybloomSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteOre, 5);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 5);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.DeathweedSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AshBlock, 8);
            recipe.AddIngredient(ItemID.Hellstone, 2);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.FireblossomSeeds, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MudBlock, 6);
            recipe.AddIngredient(ItemID.GlowingMushroom);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.MoonglowSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 6);
            recipe.AddIngredient(ItemID.SharkFin);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.WaterleafSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 2);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.GrassSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GrassSeeds, 2);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 5);
            recipe.AddIngredient(ItemID.DemoniteOre, 3);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.CorruptSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GrassSeeds, 2);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 5);
            recipe.AddIngredient(ItemID.CrimtaneOre, 3);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.CrimsonSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GrassSeeds, 2);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 5);
            recipe.AddIngredient(ModContent.ItemType<HallowedOre>(), 3);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.HallowedSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GrassSeeds, 2);
            recipe.AddIngredient(ItemID.MudBlock, 5);
            recipe.AddIngredient(ItemID.GlowingMushroom, 6);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.MushroomGrassSeeds, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GrassSeeds, 2);
            recipe.AddIngredient(ItemID.MudBlock, 5);
            recipe.AddIngredient(ItemID.JungleSpores, 6);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(ItemID.JungleGrassSeeds, 2);
            recipe.AddRecipe();
            // end seed fabricator stuff
        }
    }
}
