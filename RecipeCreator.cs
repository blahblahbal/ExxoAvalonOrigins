using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace ExxoAvalonOrigins
{
    public static class RecipeCreator
    {
        public static void CreateRecipes(Mod mod)
        {
            ModRecipe recipe;

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 33);
            recipe.AddIngredient(ModContent.ItemType<Items.Pathogen>());
            recipe.SetResult(ModContent.ItemType<Items.PathogenTorch>(), 33);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.FleshyTendril>(), 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.GuideVoodooDoll);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.HallowedOre>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.HallowedBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 2);
            recipe.AddIngredient(ItemID.BeeWax, 2);
            recipe.SetResult(ModContent.ItemType<Items.JungleTorch>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddIngredient(ModContent.ItemType<Items.Tourmaline>());
            recipe.SetResult(ModContent.ItemType<Items.CyanTorch>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddIngredient(ModContent.ItemType<Items.Peridot>());
            recipe.SetResult(ModContent.ItemType<Items.LimeTorch>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddIngredient(ModContent.ItemType<Items.Zircon>());
            recipe.SetResult(ModContent.ItemType<Items.BrownTorch>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Obsidian);
            recipe.SetResult(ModContent.ItemType<Items.BottledLava>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.MagicPowerPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.MagicPowerPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddIngredient(ItemID.Vertebrae);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.BattlePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddIngredient(ModContent.ItemType<Items.YuckyBit>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.BattlePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddIngredient(ItemID.Cactus);
            recipe.AddIngredient(ItemID.WormTooth);
            recipe.AddIngredient(ItemID.Stinger);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.ThornsPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ItemID.Feather);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.GravitationPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
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
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.CratePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Amber);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.CratePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Bone);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddIngredient(ItemID.Shiverthorn);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.TitanPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Bone);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddIngredient(ItemID.Shiverthorn);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.TitanPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Hemopiranha);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.RagePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Hemopiranha);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.RagePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Ebonkoi);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.WrathPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Ebonkoi);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.WrathPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.SpecularFish);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.RecallPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.SpecularFish);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.RecallPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledHoney, 2);
            recipe.AddIngredient(ItemID.SoulofFlight);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.BeeRepellent>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>(), 2);
            recipe.AddIngredient(ItemID.Hellstone);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.ForceFieldPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Stinkfish);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.StinkPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Stinkfish);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.StinkPotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.BottledHoney, 5);
            recipe.AddIngredient(ItemID.Feather, 8);
            recipe.AddIngredient(ItemID.FastClock);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.TimeShiftPotion>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.ChaosDust>(), 9);
            recipe.AddIngredient(ItemID.Waterleaf, 3);
            recipe.AddIngredient(ItemID.Fireblossom, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.ShadowPotion>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumOre>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.TitanskinPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumOre>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.TitanskinPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>());
            recipe.AddIngredient(ItemID.IronOre);
            recipe.AddIngredient(ModContent.ItemType<Items.RottenEye>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GPSPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>());
            recipe.AddIngredient(ItemID.LeadOre);
            recipe.AddIngredient(ModContent.ItemType<Items.RottenEye>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GPSPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>());
            recipe.AddIngredient(ItemID.IronOre);
            recipe.AddIngredient(ModContent.ItemType<Items.Patella>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GPSPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>());
            recipe.AddIngredient(ItemID.LeadOre);
            recipe.AddIngredient(ModContent.ItemType<Items.Patella>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GPSPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ItemID.TitaniumBar);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.StrengthPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ItemID.Ectoplasm);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.BloodCastPotion>(), 6);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.CrimsonPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.CrimsonPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.CrimsonPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ItemID.Meteorite);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.ShockwavePotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>());
            recipe.AddIngredient(ItemID.GreaterHealingPotion, 2);
            recipe.AddIngredient(ItemID.LifeFruit);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.ElixirofLife>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FakeFourLeafClover>());
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.LuckPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FourLeafClover>());
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>(), 20);
            recipe.AddIngredient(ItemID.Fireblossom, 20);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.LuckPotion>(), 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ItemID.SpecularFish);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.RoguePotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ItemID.Waterleaf);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.WisdomPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.IronOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GauntletPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddIngredient(ItemID.IronOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GauntletPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.LeadOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GauntletPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddIngredient(ItemID.LeadOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GauntletPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddIngredient(ItemID.IronOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GauntletPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sweetstem>());
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddIngredient(ItemID.LeadOre, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GauntletPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BottledLava>());
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddIngredient(ItemID.Lens);
            recipe.AddIngredient(ItemID.Meteorite);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.StarbrightPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Pathogen>(), 5);
            recipe.AddTile(TileID.ImbuingStation);
            recipe.SetResult(ModContent.ItemType<Items.FlaskofInfection>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TempleKey);
            recipe.AddIngredient(ModContent.ItemType<Items.UnderworldKeyMold>());
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.UnderworldKey>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TempleKey);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertKeyMold>());
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.DesertKey>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TempleKey);
            recipe.AddIngredient(ModContent.ItemType<Items.ContagionKeyMold>());
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.ContagionKey>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 35);
            recipe.AddIngredient(ModContent.ItemType<Items.Pathogen>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.PathogenArrow>(), 35);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.TungstenBullet>(), 35);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FrostShard>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Icicle>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Seed, 50);
            recipe.AddIngredient(ItemID.CrystalShard);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CrystalSeed>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Seed, 50);
            recipe.AddIngredient(ItemID.CursedFlame);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CursedTooth>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 25);
            recipe.AddIngredient(ModContent.ItemType<Items.RottenEye>(), 5);
            recipe.AddIngredient(ItemID.CursedFlame);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.RottenBullet>(), 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 25);
            recipe.AddIngredient(ModContent.ItemType<Items.Patella>(), 5);
            recipe.AddIngredient(ItemID.Ichor);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.PatellaBullet>(), 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 60);
            recipe.AddIngredient(ModContent.ItemType<Items.Pathogen>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.PathogenBullet>(), 60);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>());
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodPlatform>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Opal>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.OpalGemsparkBlock>(), 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenCandyCaneBlock);
            recipe.AddIngredient(ModContent.ItemType<Items.ChocolateCandyCaneBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.MintChocolateCandyCaneBlock>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CandyCaneBlock);
            recipe.AddIngredient(ModContent.ItemType<Items.ChocolateCandyCaneBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.RedVelvetCandyCaneBlock>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CandyCaneBlock);
            recipe.AddIngredient(ItemID.GreenCandyCaneBlock);
            recipe.AddIngredient(ModContent.ItemType<Items.ChocolateCandyCaneBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.RainbowCandyCaneBlock>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.MintChocolateCandyCaneBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.MintChocolateCandyCaneWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RedVelvetCandyCaneBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.RedVelvetCandyCaneWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RainbowCandyCaneBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.RainbowCandyCaneWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ImperviousBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ImperviousBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.PyroscoricBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.PyroscoricBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumOre>());
            recipe.AddIngredient(ItemID.IceBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LeadBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.LeadBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IronBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.IronBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadOre);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.LeadBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronOre);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.IronBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.RhodiumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.RhodiumBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.OsmiumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.OsmiumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.OsmiumBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.VertebraeWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteOre);
            recipe.AddIngredient(ItemID.MudBlock);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<Items.ChlorophyteBrick>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ChlorophyteBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ChlorophyteBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BlueLihzahrdBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.BlueLihzahrdBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Obsidian);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ObsidianLavaTubeWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.HeartstoneBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OrangeBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.OrangeBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OrangeBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.OrangeSlabWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OrangeBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.OrangeTiledWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OrangeBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.OrangeBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OrangeSlabWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.OrangeBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OrangeTiledWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.OrangeBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ChocolateCandyCaneBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ChocolateCandyCaneWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddIngredient(ItemID.JungleSpores);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.SporeBlock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterWood>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkMatterWoodWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodTable>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 10);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlimeBlock, 5);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeBlock>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 33);
            recipe.AddIngredient(ItemID.SlimeBlock);
            recipe.SetResult(ModContent.ItemType<Items.SlimeTorch>(), 33);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeBathtub>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeBed>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeCandelabra>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeChandelier>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 10);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeClock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeDresser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimePiano>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeSofa>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>());
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimePlatform>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 10);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.DarkSlimeSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneBathtub>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneBed>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneCandelabra>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneChandelier>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 10);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneClock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneDresser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstonePiano>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneSofa>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneTable>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>());
            recipe.SetResult(ModContent.ItemType<Items.HeartstonePlatform>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.HeartstonePlatform>());
            recipe.SetResult(ModContent.ItemType<Items.Heartstone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 10);
            recipe.SetResult(ModContent.ItemType<Items.HeartstoneWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.HeartstoneSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ectoplasm);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Echoplasm>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmBathtub>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmBed>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmCandelabra>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmChandelier>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 10);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmClock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmDresser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmPiano>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmSofa>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmTable>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>());
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmPlatform>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.EctoplasmPlatform>());
            recipe.SetResult(ModContent.ItemType<Items.Echoplasm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 10);
            recipe.SetResult(ModContent.ItemType<Items.EctoplasmWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Echoplasm>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.EctoplasmSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.VertebraeBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.VertebraeCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.VertebraeChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.VertebraeChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.VertebraeDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.VertebraeLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae);
            recipe.SetResult(ModContent.ItemType<Items.VertebraePlatform>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.VertebraePlatform>());
            recipe.SetResult(ItemID.Vertebrae);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 10);
            recipe.SetResult(ModContent.ItemType<Items.VertebraeWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 10);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodBathtub>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodChandelier>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodBed>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.ImperviousBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 10);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodClock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 16);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodDresser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodPiano>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodSofa>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodCandelabra>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 6);
            recipe.AddIngredient(ItemID.Torch, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ResistantWoodTable>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ResistantWood>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.ResistantWoodSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OrangeBrick>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.OrangeDungeonSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.SapphireWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.RubyWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.EmeraldWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.TopazWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.AmethystWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DiamondWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ebonwood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.EbonwoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shadewood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.ShadewoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.PearlwoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.RichMahoganyBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BorealWood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.BorealWoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalmWood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.PalmWoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>());
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandstoneBrick);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.SandstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlstoneBlock);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.PearlstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimstoneBlock);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.CrimstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EbonstoneBlock);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.EbonstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ChunkstoneBlock>());
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<Items.ChunkstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodBreastplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 9);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CoughwoodBow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>());
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeBlock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkSlimeBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.DarkSlimeBlockWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 6);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.GemWand>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueBrick, 50);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ModContent.ItemType<Items.BlueDungeonWand>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenBrick, 50);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ModContent.ItemType<Items.GreenDungeonWand>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PinkBrick, 50);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ModContent.ItemType<Items.PinkDungeonWand>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OrangeBrick>(), 50);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ModContent.ItemType<Items.OrangeDungeonWand>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueBrick);
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ItemID.BlueBrickWall, 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenBrick);
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ItemID.GreenBrickWall, 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PinkBrick);
            recipe.AddTile(TileID.BoneWelder);
            recipe.SetResult(ItemID.PinkBrickWall, 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Robe);
            recipe.AddIngredient(ModContent.ItemType<Items.Tourmaline>(), 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ModContent.ItemType<Items.TourmalineRobe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Robe);
            recipe.AddIngredient(ModContent.ItemType<Items.Peridot>(), 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ModContent.ItemType<Items.PeridotRobe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Robe);
            recipe.AddIngredient(ModContent.ItemType<Items.Zircon>(), 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ModContent.ItemType<Items.ZirconRobe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BlueLihzahrdBrick>(), 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.BlueLihzahrdStatue>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 5);
            recipe.AddIngredient(ItemID.Blowpipe);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ReinforcedBlowpipe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 5);
            recipe.AddIngredient(ItemID.Blowpipe);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ReinforcedBlowpipe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBroadsword);
            recipe.AddIngredient(ItemID.BugNet);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.SwordNet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBroadsword);
            recipe.AddIngredient(ItemID.BugNet);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.SwordNet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SwordNet>());
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ExcaliburNet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ExcaliburNet>());
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Oblivionet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.OsmiumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.OsmiumHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.OsmiumJerkin>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.OsmiumTreads>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.OsmiumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumBar>(), 14);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.OsmiumGreatsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.RhodiumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.RhodiumHeadgear>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.RhodiumPlateMail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.RhodiumGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.RhodiumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumBar>(), 14);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.RhodiumGreatsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.RhodiumHamaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FleshyTendril>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.FleshCap>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FleshyTendril>(), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.FleshWrappings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FleshyTendril>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.FleshPants>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FleshyTendril>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.HungryStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ModContent.ItemType<Items.LivingLightningBlock>(), 50);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.PlasmaLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cloud);
            recipe.AddIngredient(ModContent.ItemType<Items.LivingLightningBlock>());
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.VoltBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cloud);
            recipe.SetResult(ItemID.RainCloud);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LivingLightningBlock>(), 80);
            recipe.AddIngredient(ItemID.Cloud, 50);
            recipe.AddIngredient(ItemID.RainCloud, 80);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.NimbusRod);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 14);
            recipe.AddIngredient(ItemID.Gel, 100);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.GastropodStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMirror);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.BloodshotLens>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.EideticMirror>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMirror);
            recipe.AddIngredient(ItemID.PlatinumBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.BloodshotLens>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.EideticMirror>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumOre);
            recipe.AddIngredient(ItemID.Cloud);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.MoonplateBlock>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.BacciliteBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ViruthornHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ViruthornScalemail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ViruthornGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.TheCell>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Snotsabre>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.GoldminePickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.AxeofSickness>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 11);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.MucusHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Wheezebow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Zircon>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 8);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZirconStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NastySpike>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tourmaline>(), 15);
            recipe.AddIngredient(ItemID.DemoniteBar, 20);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.TourmalineStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddIngredient(ItemID.ShadowScale);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DemonSpikeScale>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Peridot>(), 15);
            recipe.AddIngredient(ItemID.CrimtaneBar, 20);
            recipe.AddIngredient(ItemID.TissueSample, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.PeridotStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike);
            recipe.AddIngredient(ItemID.TissueSample);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BloodiedSpike>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AntlionMandible);
            recipe.AddIngredient(ItemID.SandBlock, 60);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 5);
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertLongSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 75);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 2);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ItemID.GoldHelmet);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 5);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ItemID.GoldChainmail);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 3);
            recipe.AddIngredient(ItemID.AntlionMandible);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.GoldGreaves);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 75);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 2);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 10);
            recipe.AddIngredient(ItemID.PlatinumHelmet);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 5);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddIngredient(ItemID.PlatinumChainmail);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 3);
            recipe.AddIngredient(ItemID.AntlionMandible);
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddIngredient(ItemID.PlatinumGreaves);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 75);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 2);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthHelmet>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 5);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthChainmail>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 3);
            recipe.AddIngredient(ItemID.AntlionMandible);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthGreaves>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DesertGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tourmaline>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.TourmalineHook>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Peridot>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.PeridotHook>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Zircon>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZirconHook>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.InfernoFork);
            recipe.AddIngredient(ItemID.SpectreStaff);
            recipe.AddIngredient(ItemID.ShadowbeamStaff);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.SpiritbeamFork>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.OnyxHook>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tourmaline>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.LargeTourmaline>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Peridot>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.LargePeridot>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedSword);
            recipe.AddIngredient(ItemID.LivingFireBlock, 100);
            recipe.AddIngredient(ItemID.SoulofMight, 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Infernasword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LaserRifle);
            recipe.AddIngredient(ModContent.ItemType<Items.LensApparatus>());
            recipe.AddIngredient(ItemID.SoulofFright, 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.EnergyRevolver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronOre, 30);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.CarbonSteel>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadOre, 30);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.CarbonSteel>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.Sandstone>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Seed, 25);
            recipe.AddIngredient(ItemID.HellstoneBar);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.HellstoneSeed>(), 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianShield);
            recipe.AddIngredient(ItemID.IronskinPotion, 10);
            recipe.AddIngredient(ItemID.BattlePotion, 15);
            recipe.AddIngredient(ItemID.ThornsPotion, 15);
            recipe.AddIngredient(ItemID.WaterWalkingPotion, 10);
            recipe.AddIngredient(ItemID.Bone, 99);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.AlchemicalSkull>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 15);
            recipe.AddIngredient(ItemID.CursedFlame, 5);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.CorruptShard>(), 5);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.BagofShadows>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Fireblossom, 15);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.AshBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.FireShard>(), 5);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.BagofFire>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.PixieDust, 10);
            recipe.AddIngredient(ItemID.UnicornHorn, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.SacredShard>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.BagofHallows>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 15);
            recipe.AddIngredient(ItemID.Ichor, 10);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.CorruptShard>(), 5);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.BagofBlood>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.YuckyBit>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.Pathogen>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.ChunkstoneBlock>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.CorruptShard>(), 5);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Items.BagofIck>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TheHorsemansBlade);
            recipe.AddIngredient(ItemID.SpookyWood, 900);
            recipe.AddIngredient(ItemID.LivingFireBlock, 200);
            recipe.AddIngredient(ItemID.Pumpkin, 30);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 70);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.PumpkingsSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SiltBlock, 20);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Gravel>(), 15);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlushBlock, 20);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Gravel>(), 15);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 60);
            recipe.anyWood = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.FineLumber>(), 15);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertLongSword>());
            recipe.AddIngredient(ModContent.ItemType<Items.RhodiumGreatsword>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.AeonsEternity>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertLongSword>());
            recipe.AddIngredient(ModContent.ItemType<Items.OsmiumGreatsword>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.AeonsEternity>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertLongSword>());
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumGreatsword>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.AeonsEternity>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LightsBane);
            recipe.AddIngredient(ItemID.Muramasa);
            recipe.AddIngredient(ModContent.ItemType<Items.FieryBladeofGrass>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.NightsEdge);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BloodButcherer);
            recipe.AddIngredient(ItemID.Muramasa);
            recipe.AddIngredient(ModContent.ItemType<Items.FieryBladeofGrass>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.NightsEdge);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Snotsabre>());
            recipe.AddIngredient(ItemID.Muramasa);
            recipe.AddIngredient(ItemID.BladeofGrass);
            recipe.AddIngredient(ItemID.FieryGreatsword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.NightsEdge);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Snotsabre>());
            recipe.AddIngredient(ItemID.Muramasa);
            recipe.AddIngredient(ModContent.ItemType<Items.FieryBladeofGrass>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.NightsEdge);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueMoon);
            recipe.AddIngredient(ItemID.Sunfury);
            recipe.AddIngredient(ItemID.BallOHurt);
            recipe.AddIngredient(ModContent.ItemType<Items.Sporalash>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.Moonfury>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueMoon);
            recipe.AddIngredient(ItemID.Sunfury);
            recipe.AddIngredient(ItemID.TheMeatball);
            recipe.AddIngredient(ModContent.ItemType<Items.Sporalash>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.Moonfury>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueMoon);
            recipe.AddIngredient(ItemID.Sunfury);
            recipe.AddIngredient(ModContent.ItemType<Items.TheCell>());
            recipe.AddIngredient(ModContent.ItemType<Items.Sporalash>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.Moonfury>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NightsEdge);
            recipe.AddIngredient(ItemID.Excalibur);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient(ItemID.DarkShard);
            recipe.AddIngredient(ItemID.LightShard);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<Items.VertexofExcalibur>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolarFragment>(), 3);
            recipe.AddIngredient(ItemID.SilverBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.SunCharm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolarFragment>(), 3);
            recipe.AddIngredient(ItemID.TungstenBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.SunCharm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkLance);
            recipe.AddIngredient(ItemID.Gungnir);
            recipe.AddIngredient(ItemID.SoulofFright, 30);
            recipe.AddIngredient(ItemID.DarkShard);
            recipe.AddIngredient(ItemID.LightShard);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<Items.DarklightLance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.AeonsEternity>());
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TrueAeonsEternity>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TrueAeonsEternity>());
            recipe.AddIngredient(ItemID.TrueExcalibur);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.TerraBlade);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumHeadgear>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 24);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumDrill>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumChainsaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumWaraxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumGlaive>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumRepeater>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.OrichythrilBlowpipe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.MythrilSplitknife>(), 65);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.OrichythrilBlowpipe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.OrichalcumSplitblade>(), 65);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahHeadguard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahHood>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahMask>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahBreastplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahShinguards>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahDrill>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahChainsaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahGreataxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahRepeater>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahTrident>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NaquadahAnvil>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumOre>(), 30);
            recipe.AddIngredient(ItemID.Hellforge);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumForge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumOre>(), 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumStar>(), 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.EmptyXeradonBucket>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumHat>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumDrill>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumChainsaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumWaraxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumSpear>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumRepeater>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.HallowedCrown>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.HeavensTear>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.LightShard, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.HallowedThorn>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pwnhammer);
            recipe.AddIngredient(ItemID.HallowedBar, 35);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TheBanhammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 35);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.HallowedGreatsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.HallowedBlowpipe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.HallowedKunai>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.SunlightKunai>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteForge);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumOre>(), 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CaesiumForge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumForge);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumOre>(), 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CaesiumForge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumForge>());
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumOre>(), 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CaesiumForge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumBar>(), 30);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.CaesiumHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumBar>(), 40);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.CaesiumPlateMail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumBar>(), 28);
            recipe.AddIngredient(ItemID.HellstoneBar, 9);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.CaesiumGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumStar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.XeradonAnvil>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FireShard>(), 2);
            recipe.AddIngredient(ItemID.LivingFireBlock, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.BlastShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FrostShard>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofIce>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.FrigidShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ToxinShard>(), 2);
            recipe.AddIngredient(ItemID.Stinger);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.VenomShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.EarthShard>(), 2);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CoreShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BreezeShard>(), 2);
            recipe.AddIngredient(ItemID.SoulofFlight);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TornadoShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.UndeadShard>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.RottenFlesh>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.DemonicShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.WaterShard>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.WaterXeradonBucket>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TorrentShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CorruptShard>(), 2);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.WickedShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ArcaneShard>(), 2);
            recipe.AddIngredient(ItemID.SoulofLight, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.SacredShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BlastShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.TornadoShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.VenomShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.WickedShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.SacredShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.CoreShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.TorrentShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.DemonicShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidShard>(), 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.ElementShard>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumStar>(), 5);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.LihzahrdPowerCell);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteHeadgear);
            recipe.AddIngredient(ItemID.TikiMask);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteMask);
            recipe.AddIngredient(ItemID.TikiMask);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteHelmet);
            recipe.AddIngredient(ItemID.TikiMask);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteHeadgear);
            recipe.AddIngredient(ItemID.SpookyHelmet);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteMask);
            recipe.AddIngredient(ItemID.SpookyHelmet);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteHelmet);
            recipe.AddIngredient(ItemID.SpookyHelmet);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleScaleMail);
            recipe.AddIngredient(ItemID.SpectreRobe);
            recipe.AddIngredient(ItemID.ShroomiteBreastplate);
            recipe.AddIngredient(ItemID.TikiShirt);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientBodyplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleScaleMail);
            recipe.AddIngredient(ItemID.SpectreRobe);
            recipe.AddIngredient(ItemID.ShroomiteBreastplate);
            recipe.AddIngredient(ItemID.SpookyBreastplate);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientBodyplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleLeggings);
            recipe.AddIngredient(ItemID.SpectrePants);
            recipe.AddIngredient(ItemID.ShroomiteLeggings);
            recipe.AddIngredient(ItemID.TikiPants);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientLeggings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleLeggings);
            recipe.AddIngredient(ItemID.SpectrePants);
            recipe.AddIngredient(ItemID.ShroomiteLeggings);
            recipe.AddIngredient(ItemID.SpookyLeggings);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.AncientLeggings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumOre>(), 6);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>(), 24);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumBreastplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>(), 18);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>());
            recipe.AddIngredient(ItemID.WoodenArrow, 70);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumArrow>(), 70);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>());
            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumBullet>(), 70);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>(), 18);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumIceSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.FeroziumWaraxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ectoplasm, 12);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.SpectreHeadgear>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ShroomiteOre>(), 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ItemID.ShroomiteBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.ShadowRing>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TacticalShotgun, 2);
            recipe.AddIngredient(ItemID.Ectoplasm, 50);
            recipe.AddIngredient(ItemID.ShroomiteBar, 30);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.TacticalExpulsor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BrokenVigilanteTome>());
            recipe.AddIngredient(ItemID.FallenStar, 200);
            recipe.AddIngredient(ItemID.MeteoriteBar, 150);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 35);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Starfall>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PossessedHatchet);
            recipe.AddIngredient(ItemID.AdamantiteChainsaw);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.CursedFlame, 50);
            recipe.AddIngredient(ItemID.LivingFireBlock, 160);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.PossessedFlamesaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PossessedHatchet);
            recipe.AddIngredient(ItemID.TitaniumChainsaw);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.CursedFlame, 50);
            recipe.AddIngredient(ItemID.LivingFireBlock, 160);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.PossessedFlamesaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.EarthStone>());
            recipe.AddIngredient(ItemID.LihzahrdPowerCell);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumShrine>());
            recipe.SetResult(ModContent.ItemType<Items.SolariumRod>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumOre>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.SolariumStar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumStar>(), 33);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.SolarFlaresword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumStar>(), 21);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.SolarFlareBow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumStar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>(), 7);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.SolariumStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VampireKnives);
            recipe.AddIngredient(ItemID.ScourgeoftheCorruptor);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.IllegalWeaponInstructions>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.KnivesoftheCorruptor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DevilsScythe>());
            recipe.AddIngredient(ModContent.ItemType<Items.TheGoldenFlames>());
            recipe.AddIngredient(ItemID.RazorbladeTyphoon);
            recipe.AddIngredient(ModContent.ItemType<Items.BrokenVigilanteTome>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Terraspin>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 35);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddIngredient(ItemID.Fireblossom, 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.TheGoldenFlames>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VenusMagnum);
            recipe.AddIngredient(ItemID.Uzi);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.PlanterasFury>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FreezeBolt>());
            recipe.AddIngredient(ItemID.LavaBucket, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 50);
            recipe.AddIngredient(ItemID.Fireblossom, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.MagmafrostBolt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
            recipe.AddIngredient(ItemID.Shotgun);
            recipe.AddIngredient(ItemID.TurtleShell, 2);
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ModContent.ItemType<Items.LensApparatus>());
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.QuadroCannon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMissile);
            recipe.AddIngredient(ItemID.Bomb, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Boomlash>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicDagger);
            recipe.AddIngredient(ItemID.Grenade, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.MagicGrenade>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 5);
            recipe.AddIngredient(ItemID.IceBlock, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.IceGel>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.CobaltShieldMarkII>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.PalladiumShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CobaltShieldMarkII>());
            recipe.AddIngredient(ModContent.ItemType<Items.PalladiumShield>());
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumShield>());
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.CobaltOmegaShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CobaltShieldMarkII>());
            recipe.AddIngredient(ModContent.ItemType<Items.PalladiumShield>());
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumShield>());
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.PalladiumOmegaShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CobaltShieldMarkII>());
            recipe.AddIngredient(ModContent.ItemType<Items.PalladiumShield>());
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumShield>());
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.DurataniumOmegaShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 50);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddIngredient(ItemID.SoulofFright, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.PrimeStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 2);
            recipe.AddIngredient(ItemID.SandBlock, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.SandBomb>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.Cannonball);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenSolution, 15);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.PurityBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PurpleSolution, 15);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.CorruptionBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LimeGreenSolution>(), 15);
            recipe.AddIngredient(ItemID.MudBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.JungleBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedSolution, 15);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.CrimsonBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.YellowSolution>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.ChunkstoneBlock>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.ContagionBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkBlueSolution, 15);
            recipe.AddIngredient(ItemID.MudBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.MushroomBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueSolution, 15);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.HallowBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RoyalGel);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.BandofSlime>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.StickyCharm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.EtherealHeart>());
            recipe.AddIngredient(ModContent.ItemType<Items.HeartoftheGolem>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.SouloftheGolem>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CloudinaBottle);
            recipe.AddIngredient(ItemID.BlizzardinaBottle);
            recipe.AddIngredient(ItemID.SandstorminaBottle);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.SandyStormcloudinaBottle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SandyStormcloudinaBottle>());
            recipe.AddIngredient(ItemID.ShinyRedBalloon, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.BundleofBalloons);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shotgun);
            recipe.AddIngredient(ItemID.Spike, 100);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.SpikeCannon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StarCloak);
            recipe.AddIngredient(ItemID.PanicNecklace);
            recipe.AddIngredient(ItemID.HoneyComb);
            recipe.AddIngredient(ModContent.ItemType<Items.LightninginaBottle>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.CloakofAssists>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StarCloak);
            recipe.AddIngredient(ItemID.SweetheartNecklace);
            recipe.AddIngredient(ModContent.ItemType<Items.LightninginaBottle>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.CloakofAssists>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeeCloak);
            recipe.AddIngredient(ItemID.PanicNecklace);
            recipe.AddIngredient(ModContent.ItemType<Items.LightninginaBottle>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.CloakofAssists>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianHorseshoe);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.Spike, 50);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.GuardianBoots>());
            recipe.AddRecipe();

            // vanilla items

            // end vanilla items

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NaturesGift, 4);
            recipe.AddIngredient(ItemID.JungleRose);
            recipe.AddIngredient(ModContent.ItemType<Items.ArcaneShard>(), 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.NaturesEndowment>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaFlower);
            recipe.AddIngredient(ItemID.BandofStarpower, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.NaturesEndowment>());
            recipe.AddIngredient(ItemID.SorcererEmblem);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.GiftofStarpower>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ForsakenRelic>());
            recipe.AddIngredient(ItemID.CrossNecklace);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.ForsakenCross>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NullEmblem>(), 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.AvengerEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NullEmblem>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.RangerEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NullEmblem>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.SorcererEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NullEmblem>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.WarriorEmblem);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ChaosCharm>());
            recipe.AddIngredient(ItemID.EyeoftheGolem);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.ChaosEye>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianSkull);
            recipe.AddIngredient(ItemID.ObsidianRose);
            recipe.AddIngredient(ItemID.MagmaStone);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.FlareStone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.AegisofAges>());
            recipe.AddIngredient(ItemID.PaladinsShield);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.TitanShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CellPhone);
            recipe.AddIngredient(ModContent.ItemType<Items.MagicConch>());
            recipe.AddIngredient(ModContent.ItemType<Items.DemonConch>());
            recipe.AddIngredient(ItemID.FallenStar, 40);
            recipe.AddIngredient(ItemID.Diamond, 20);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 7);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.ShadowMirror>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DestroyerEmblem);
            recipe.AddIngredient(ItemID.MagicQuiver);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.ApollosQuiver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 50);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.CrystalEdge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ChaosCrystal>());
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.ChaosEmblem>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.SoulofSight, 8);
            recipe.AddIngredient(ItemID.LightShard, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.ReflexCharm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ReflexCharm>());
            recipe.AddIngredient(ItemID.AnkhShield);
            recipe.AddIngredient(ModContent.ItemType<Items.GoldenShield>());
            recipe.AddIngredient(ModContent.ItemType<Items.OxygenTank>());
            recipe.AddIngredient(ModContent.ItemType<Items.Vortex>());
            recipe.AddIngredient(ModContent.ItemType<Items.NuclearExtinguisher>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.ReflexShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.GreekExtinguisher>());
            recipe.AddIngredient(ModContent.ItemType<Items.SixHundredWattLightbulb>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.NuclearExtinguisher>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shackle, 6);
            recipe.AddIngredient(ItemID.BandofRegeneration);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.DullingTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.AngerTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.TungstenOre, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.AngerTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.AngerTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.TungstenOre, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.AngerTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Toolbelt);
            recipe.AddIngredient(ItemID.GPS);
            recipe.AddIngredient(ItemID.GoldCoin);
            recipe.AddIngredient(ItemID.TinkerersWorkshop);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.GoblinToolbelt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.GoblinToolbelt>());
            recipe.AddIngredient(ItemID.JellyfishNecklace);
            recipe.AddIngredient(ItemID.DestroyerEmblem);
            recipe.AddIngredient(ItemID.CrossNecklace);
            recipe.AddIngredient(ItemID.BundleofBalloons);
            recipe.AddIngredient(ModContent.ItemType<Items.Magnet>());
            recipe.AddIngredient(ItemID.SpelunkerPotion, 5);
            recipe.AddIngredient(ItemID.HunterPotion, 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<Items.GoblinArmyKnife>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.GoblinToolbelt>());
            recipe.AddIngredient(ItemID.PortableCementMixer);
            recipe.AddIngredient(ItemID.BrickLayer);
            recipe.AddIngredient(ItemID.ExtendoGrip);
            recipe.AddIngredient(ItemID.FlyingCarpet);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.BuildersToolbelt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TitanShield>());
            recipe.AddIngredient(ModContent.ItemType<Items.FrostGauntlet>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.TitanGauntlets>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ItemID.SandstoneBrick, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.SandCastle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.GuideSummonDoll>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.TungstenOre, 5);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.GuideSummonDoll>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.GuideSummonDoll>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.TungstenOre, 5);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.GuideSummonDoll>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FireGauntlet);
            recipe.AddIngredient(ItemID.FrozenTurtleShell);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.FrostGauntlet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FireGauntlet);
            recipe.AddIngredient(ItemID.Ichor, 20);
            recipe.AddIngredient(ItemID.CursedFlame, 20);
            recipe.AddIngredient(ItemID.SpiderFang, 20);
            recipe.AddIngredient(ItemID.Stinger, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.FrostShard>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Pathogen>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.TerraClaws>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddIngredient(ItemID.Hellstone, 20);
            recipe.AddIngredient(ItemID.LavaBucket);
            recipe.AddIngredient(ItemID.SoulofFright, 6);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.HadesCross>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CelestialShell);
            recipe.AddIngredient(ModContent.ItemType<Items.HadesCross>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.TransformationTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemonWings);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.BlackBelt);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:Wings");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.InertiaBoots>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby, 10);
            recipe.AddIngredient(ItemID.MeteoriteBar, 5);
            recipe.AddIngredient(ItemID.Wire, 30);
            recipe.AddIngredient(ItemID.HunterPotion, 3);
            recipe.AddIngredient(ItemID.SpelunkerPotion, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.SonicScrewdriverMkI>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SonicScrewdriverMkI>());
            recipe.AddIngredient(ItemID.Sapphire, 7);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.AddIngredient(ItemID.GPS);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.SonicScrewdriverMkII>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SonicScrewdriverMkII>());
            recipe.AddIngredient(ItemID.Emerald, 10);
            recipe.AddIngredient(ItemID.Wire, 20);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.SonicScrewdriverMkIII>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DualHook);
            recipe.AddIngredient(ItemID.IvyWhip);
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddIngredient(ItemID.Hook, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.QuadWhip>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
            recipe.AddIngredient(ItemID.GillsPotion, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.OxygenTank>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flamelash);
            recipe.AddIngredient(ItemID.CursedFlame, 99);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CursedFlamelash>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(ModContent.ItemType<Items.Pathogen>(), 30);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Items.PathogenMist>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Items.MysteriousPage>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.BloodshotLens>(), 10);
            recipe.AddIngredient(ItemID.BlackLens);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Items.LensApparatus>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemonScythe);
            recipe.AddIngredient(ItemID.Fireblossom, 20);
            recipe.AddIngredient(ItemID.LivingFireBlock, 100);
            recipe.AddIngredient(ItemID.SoulofFright, 7);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Items.DevilsScythe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Tourmaline>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.LensApparatus>());
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Items.FocusBeam>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BrokenVigilanteTome>());
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 20);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Items.GigaHorn>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofIce>(), 20);
            recipe.AddIngredient(ItemID.WaterBolt);
            recipe.AddIngredient(ModContent.ItemType<Items.IceGel>(), 50);
            recipe.AddIngredient(ItemID.FrostCore, 2);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Items.FreezeBolt>());
            recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(ItemID.SpellTome);
            //recipe.AddIngredient(ItemID.Emerald, 15);
            //recipe.AddIngredient(ItemID.SoulofSight, 7);
            //recipe.AddIngredient(ItemID.Lens, 3);
            //recipe.AddTile(TileID.Bookcases);
            //recipe.SetResult(ModContent.ItemType<Items.Venoshock>());
            //recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusicBoxTitle);
            recipe.AddIngredient(ItemID.MusicBoxSnow);
            recipe.AddIngredient(ItemID.MusicBoxDesert);
            recipe.AddIngredient(ItemID.MusicBoxSpace);
            recipe.AddIngredient(ItemID.MusicBoxCrimson);
            recipe.AddIngredient(ItemID.MusicBoxDungeon);
            recipe.AddIngredient(ItemID.MusicBoxPlantera);
            recipe.AddIngredient(ItemID.MusicBoxTemple);
            recipe.AddIngredient(ItemID.MusicBoxEclipse);
            recipe.AddIngredient(ItemID.MusicBoxPumpkinMoon);
            recipe.AddIngredient(ItemID.MusicBoxFrostMoon);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Items.MusicBoxEssence>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusicBox, 2);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.MusicBoxEssence>());
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Items.Jukebox>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.Heartstone>(), 45);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Heartstone>(), 45);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ItemID.LifeCrystal);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.StaminaCrystal>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.Staminastone>(), 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Staminastone>(), 25);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.StaminaCrystal>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Staminastone>(), 5);
            recipe.AddIngredient(ItemID.Silk);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.LesserStaminaPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LesserStaminaPotion>(), 2);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.StaminaPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.StaminaPotion>());
            recipe.AddIngredient(ItemID.SharkFin, 3);
            recipe.AddIngredient(ItemID.Mushroom, 5);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.GreaterStaminaPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.GreaterStaminaPotion>(), 2);
            recipe.AddIngredient(ItemID.SharkFin, 6);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddIngredient(ItemID.Silk);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<Items.SuperStaminaPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeFruit);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<Items.Lifestone>(), 30);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Lifestone>(), 30);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ItemID.LifeFruit);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedBoomerang);
            recipe.AddIngredient(ItemID.Shuriken, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Shurikerang>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.EnchantedBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.EnchantedBoomerang);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.EnchantedBar>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.EnchantedShuriken>(), 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.EnchantedBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.BrokenHiltPiece>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.EnchantedSword);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 50);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.anyWood = true;
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.TorchLauncher>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SiltBlock, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CompressedExtractBlock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlushBlock, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.CompressedExtractBlock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.YuckyBit>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.VirulentPowder>(), 30);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.BacterialTotem>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Beak>(), 6);
            recipe.AddIngredient(ItemID.SandBlock, 30);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.TheBeak>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Rock>());
            recipe.AddIngredient(ModContent.ItemType<Items.PointingLaser>());
            recipe.AddIngredient(ModContent.ItemType<Items.AlienDevice>());
            recipe.AddIngredient(ModContent.ItemType<Items.IllegalWeaponInstructions>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.EyeofOblivionAncient>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ToxinShard>(), 30);
            recipe.AddIngredient(ItemID.Stinger, 15);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.HornetFood>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 20);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.EyesPamphlet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 100);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.EarthStone>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.DarkMatterChunk>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 100);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.EarthStone>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.DarkMatterChunk>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ChunkstoneBlock>(), 100);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.EarthStone>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.DarkMatterChunk>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.YuckyBit>(), 6);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.MechanicalWorm);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 5);
            recipe.AddIngredient(ItemID.Stinger, 15);
            recipe.AddIngredient(ItemID.JungleSpores, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.OddFertilizer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.Coral, 15);
            recipe.AddIngredient(ItemID.SharkFin);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.PirateMap);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTime>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>());
            recipe.AddIngredient(ModContent.ItemType<Items.Timechanger>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.TimechangerMkII>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.GoldBar, 20);
            recipe.AddIngredient(ItemID.BlackLens);
            recipe.AddIngredient(ModContent.ItemType<Items.BloodshotLens>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Moonphaser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.PlatinumBar, 20);
            recipe.AddIngredient(ItemID.BlackLens);
            recipe.AddIngredient(ModContent.ItemType<Items.BloodshotLens>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Moonphaser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionOre>());
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.OblivionBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 2);
            recipe.AddIngredient(ItemID.LifeFruit, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.CrystalFruit>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.BlueBrick, 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.ImperviousBrick>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.PinkBrick, 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.ImperviousBrick>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.GreenBrick, 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.ImperviousBrick>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ModContent.ItemType<Items.OrangeBrick>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.ImperviousBrick>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.PyroscoricOre>());
            recipe.AddIngredient(ItemID.StoneBlock, 3);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.PyroscoricBrick>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.PyroscoricOre>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.PyroscoricBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.PyroscoricBar>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.PyroscoricLongsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.PyroscoricBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.PyroscoricPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.PyroscoricBar>());
            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.PyroscoricBullet>(), 70);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TritanoriumOre>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.TritanoriumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TritanoriumBar>(), 35);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.TritanoriumBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TritanoriumBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.TritanoriumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TritanoriumBar>());
            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.TritonBullet>(), 70);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.UnvolanditeOre>(), 6);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.UnvolanditeBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.UnvolanditeBar>(), 24);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.UnvolanditeGreatsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.UnvolanditeBar>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.UnvolanditePicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumStaff>());
            recipe.AddIngredient(ModContent.ItemType<Items.UnvolanditeBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 9);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.UnvolanditeKunziteWaveStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PulseBow);
            recipe.AddIngredient(ModContent.ItemType<Items.UnvolanditeBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.UnvolanditeFusebow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.UnvolanditeBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.SpikedBlastShell>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.UnvolanditeHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.UnvolanditeBar>(), 46);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.SpikedBlastShell>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.UnvolanditeBodyplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.UnvolanditeBar>(), 32);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 8);
            recipe.AddIngredient(ModContent.ItemType<Items.SpikedBlastShell>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.UnvolanditeLeggings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.VorazylcumOre>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.VorazylcumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.VorazylcumBar>(), 22);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.VoraylzumKatana>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.VorazylcumBar>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.VorazylcumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumStaff>());
            recipe.AddIngredient(ModContent.ItemType<Items.VorazylcumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 9);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.VorazylcumKunziteBoltStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PulseBow);
            recipe.AddIngredient(ModContent.ItemType<Items.VorazylcumBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.VorazylcumFusebow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.VorazylcumBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.SpikedBlastShell>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.VorazylcumHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.VorazylcumBar>(), 46);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.SpikedBlastShell>(), 4);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.VorazylcumBodyplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.VorazylcumBar>(), 32);
            recipe.AddIngredient(ModContent.ItemType<Items.Kunzite>(), 8);
            recipe.AddIngredient(ModContent.ItemType<Items.SpikedBlastShell>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.VorazylcumLeggings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Phantoplasm>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Elektriwave>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumBar>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumBar>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.SuperhardmodeBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 200);
            recipe.AddIngredient(ModContent.ItemType<Items.Phantoplasm>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Electrobullet>(), 200);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Phantoplasm>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.BlahsHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Phantoplasm>(), 35);
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 35);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.BlahsBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Phantoplasm>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 17);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.BlahsCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Phantoplasm>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.InstantaniumPicksaw>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.BlahsPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Phantoplasm>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.TheBanhammer>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.BlahsWarhammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteShotbow);
            recipe.AddIngredient(ItemID.HallowedRepeater);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 22);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.GleamingTwilight>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StaffoftheFrostHydra);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofIce>(), 75);
            recipe.AddIngredient(ItemID.FrostCore, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 40);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.StaffoftheTempestFrigid>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 60);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 75);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.ElementShard>(), 7);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.BerserkerNightmare>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
            recipe.AddIngredient(ItemID.TitaniumBar, 30);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.InstantaniumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.InstantaniumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
            recipe.AddIngredient(ItemID.AdamantiteBar, 30);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.InstantaniumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TerraBlade);
            recipe.AddIngredient(ModContent.ItemType<Items.VertexofExcalibur>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofDelight>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.ElementShard>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.ElementalExcalibur>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TerraBlade);
            recipe.AddIngredient(ItemID.SpectreStaff);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 5);
            recipe.AddIngredient(ItemID.Ectoplasm, 60);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.SoulEdge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.OblivionGlaive>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Oblivirod>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Opal>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.OpalStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.OnyxStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PaladinsHammer);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.GuardianHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 75);
            recipe.AddIngredient(ModContent.ItemType<Items.ElementShard>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.ElementalArrow>(), 75);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteArrow, 75);
            recipe.AddIngredient(ItemID.HolyArrow, 75);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.BerserkerArrow>(), 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBullet, 75);
            recipe.AddIngredient(ItemID.CrystalBullet, 75);
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.BerserkerBullet>(), 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumOre>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.CaesiumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CaesiumRepeater>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CaesiumScimitar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CaesiumBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.ElementShard>(), 20);
            recipe.AddIngredient(ItemID.Flamelash);
            recipe.AddIngredient(ItemID.MagicMissile);
            recipe.AddIngredient(ItemID.DirtRod);
            recipe.AddIngredient(ItemID.RainbowRod);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.ElementalRod>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionOre>(), 7);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.OblivionBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 60);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.BerserkerHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 23);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 65);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientBodyplate>());
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.BerserkerBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 70);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientLeggings>());
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.BerserkerCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SouloftheJungle>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 60);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.AwakenedRoseCrown>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SouloftheJungle>(), 23);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 65);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientBodyplate>());
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.AwakenedRosePlateMail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SouloftheJungle>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 70);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientLeggings>());
            recipe.AddIngredient(ModContent.ItemType<Items.LifeDew>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.AwakenedRoseSubligar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.SpectrumHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 23);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientBodyplate>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.SpectrumBreastplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientLeggings>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.SpectrumGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythOre>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.SolariumOre>());
            recipe.AddIngredient(ModContent.ItemType<Items.FeroziumOre>());
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.HydrolythBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 60);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientHeadpiece>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.MiloticCrown>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 23);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 4);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 75);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientBodyplate>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.MiloticSkinplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 70);
            recipe.AddIngredient(ModContent.ItemType<Items.AncientLeggings>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.MiloticJodpurs>());
            recipe.AddRecipe();

            #region Avalon Armor

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.BerserkerHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.BerserkerBodyarmor>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.BerserkerCuisses>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.AwakenedRoseCrown>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.AwakenedRosePlateMail>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.AwakenedRoseSubligar>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.SpectrumHelmet>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.SpectrumBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.SpectrumGreaves>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.MiloticCrown>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.MiloticSkinplate>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<Items.MiloticJodpurs>());
            recipe.AddIngredient(ModContent.ItemType<Items.SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonCuisses>());
            recipe.AddRecipe();

            #endregion Avalon Armor

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedPhasesaber);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.RedPhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.YellowPhasesaber);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.YellowPhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenPhasesaber);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.GreenPhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BluePhasesaber);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.BluePhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PurplePhasesaber);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.PurplePhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WhitePhasesaber);
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.WhitePhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BladeofGrass);
            recipe.AddIngredient(ItemID.FieryGreatsword);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.FieryBladeofGrass>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.LightShard, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.SacredShard>(), 2);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.HallowedAltar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
            recipe.AddIngredient(ItemID.RottenChunk, 10);
            recipe.AddIngredient(ItemID.Deathweed, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(ItemID.ShadowScale, 20);
            recipe.AddIngredient(ItemID.DemoniteBar, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.DemonAltar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
            recipe.AddIngredient(ItemID.Vertebrae, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>(), 5);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(ItemID.TissueSample, 20);
            recipe.AddIngredient(ItemID.CrimtaneBar, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.CrimsonAltar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ChunkstoneBlock>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.YuckyBit>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>(), 5);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.IckyAltar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Bloodberry>());
            recipe.AddIngredient(ItemID.RottenChunk);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.BattlePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Items.Barfbush>());
            recipe.AddIngredient(ModContent.ItemType<Items.YuckyBit>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ItemID.BattlePotion);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 15);
            recipe.AddIngredient(ItemID.Stinger, 10);
            recipe.AddIngredient(ItemID.Vine, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.ToxinShard>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Sporalash>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteMask);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.TurtleHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophytePlateMail);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.TurtleScaleMail);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteGreaves);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.TurtleLeggings);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 3);
            recipe.AddTile(TileID.Autohammer);
            recipe.SetResult(ModContent.ItemType<Items.BeetleBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 8);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.SunsShadow>());
            recipe.AddRecipe();

            // phm ore alts

            // bronze
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.BronzeBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.BronzeBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.BronzeBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.BronzeBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 12);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzePickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 9);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzeAxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 10);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzeHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzeBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzeShortsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzeBow>());
            recipe.AddRecipe();

            // staff

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzeHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzeChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzeGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BronzeBar>(), 10);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BronzeWatch>());
            recipe.AddRecipe();
            // end bronze stuff

            // Nickel
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.NickelBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.NickelBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.NickelBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.NickelFence>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.NickelDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.NickelAnvil>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelFence>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.NickelBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.NickelBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 12);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NickelPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 9);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NickelAxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 10);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NickelHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NickelBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NickelShortsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NickelBow>());
            recipe.AddRecipe();

            // staff

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NickelHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NickelChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NickelBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.NickelGreaves>());
            recipe.AddRecipe();
            // end Nickel stuff

            // Zinc
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.ZincBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ZincBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.ZincBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.ZincBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 12);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 9);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincAxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 10);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincShortsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincBow>());
            recipe.AddRecipe();

            // staff

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ZincBar>(), 10);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.ZincWatch>());
            recipe.AddRecipe();
            // end Zinc stuff

            // Bismuth
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.BismuthBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.BismuthBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.BismuthBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.BismuthBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 12);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 9);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthAxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 10);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthShortsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthBow>());
            recipe.AddRecipe();

            // staff

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 35);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BismuthBar>(), 10);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.BismuthWatch>());
            recipe.AddRecipe();
            // end Bismuth stuff

            // Iridium
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.IridiumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.IridiumBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.IridiumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Items.IridiumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.IridiumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.IridiumHamaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumBar>(), 14);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.IridiumGreatsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.IridiumLongbow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.IridiumHat>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.IridiumPlateMail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.IridiumBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<Items.DesertFeather>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.IridiumPants>());
            recipe.AddRecipe();
            // end Iridium stuff

            #region catalyzer

            // catalyzer stuff
            // catalyzer recipe
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 30);
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.AddIngredient(ItemID.WorkBench);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:WorkBenches");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Catalyzer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.EbonstoneBlock, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CrimstoneBlock, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.ChunkstoneBlock>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ChunkstoneBlock>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PearlstoneBlock, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterWood>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Wood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Ebonwood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ebonwood, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Shadewood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shadewood, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.Coughwood>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Coughwood>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Pearlwood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.BorealWood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BorealWood, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PalmWood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalmWood, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.DarkMatterWood>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteOre>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.DemoniteOre, 40);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteOre, 40);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CrimtaneOre, 40);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneOre, 40);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.BacciliteOre>(), 40);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumOre>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CobaltOre, 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltOre, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PalladiumOre, 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumOre, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.DurataniumOre>(), 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahOre>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.MythrilOre, 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilOre, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.OrichalcumOre, 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumOre, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.NaquadahOre>(), 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumOre>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.AdamantiteOre, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteOre, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.TitaniumOre, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumOre, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumOre>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BacciliteBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.DemoniteBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CrimtaneBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.BacciliteBar>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DurataniumBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CobaltBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PalladiumBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.DurataniumBar>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.NaquadahBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.MythrilBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.OrichalcumBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.NaquadahBar>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TroxiniumBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.AdamantiteBar, 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.TitaniumBar, 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.TroxiniumBar>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Booger>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.ShadowScale, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShadowScale, 3);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.TissueSample, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TissueSample, 3);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.Booger>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Pathogen>(), 33);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CursedFlame, 33);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CursedFlame, 33);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Ichor, 33);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ichor, 33);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.Pathogen>(), 33);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.YuckyBit>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.RottenChunk, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RottenChunk, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Vertebrae, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.YuckyBit>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LimeGreenSolution>(), 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.GreenSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PurpleSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PurpleSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.RedSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.YellowSolution>(), 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.YellowSolution>(), 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.BlueSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.DarkBlueSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkBlueSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Items.LimeGreenSolution>(), 100);
            recipe.AddRecipe();

            #endregion catalyzer

            #region Corrupted Thorn Armor

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.CorruptShard>(), 20);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Armor.CorruptedThornCrown>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike, 25);
            recipe.AddIngredient(ModContent.ItemType<Items.CorruptShard>(), 25);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Armor.CorruptedThornBodyarmor>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.CorruptShard>(), 20);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Armor.CorruptedThornGreaves>());

            #endregion Corrupted Thorn Armor

            #region Divine Light Armor

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Armor.DivineLightHuntingHorns>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PixieDust, 25);
            recipe.AddIngredient(ItemID.HallowedBar, 25);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Armor.DivineLightJerkin>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.SoulofLight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Armor.DivineLightTreads>());

            #endregion Divine Light Armor

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TropicalShroomCap>(), 12);
            recipe.AddIngredient(ModContent.ItemType<Items.MosquitoProboscis>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.TropicalBlade>());
            recipe.AddRecipe();
        }
    }
}