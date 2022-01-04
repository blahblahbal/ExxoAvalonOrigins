using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Ammo;
using ExxoAvalonOrigins.Items.Armor;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Placeable.Beam;
using ExxoAvalonOrigins.Items.Placeable.Crafting;
using ExxoAvalonOrigins.Items.Placeable.Furniture;
using ExxoAvalonOrigins.Items.Placeable.Light;
using ExxoAvalonOrigins.Items.Placeable.Seed;
using ExxoAvalonOrigins.Items.Placeable.Statue;
using ExxoAvalonOrigins.Items.Placeable.Storage;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Placeable.Wall;
using ExxoAvalonOrigins.Items.Potions;
using ExxoAvalonOrigins.Items.Tools;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Melee;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using ExxoAvalonOrigins.Items.Weapons.Throw;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Logic
{
    public static class RecipeCreator
    {
        public static void CreateRecipes(Mod mod)
        {
            ModRecipe recipe;

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TempleKey);
            recipe.AddIngredient(ModContent.ItemType<UnderworldKeyMold>());
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<UnderworldKey>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TempleKey);
            recipe.AddIngredient(ModContent.ItemType<DesertKeyMold>());
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<DesertKey>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TempleKey);
            recipe.AddIngredient(ModContent.ItemType<ContagionKeyMold>());
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<ContagionKey>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteOre);
            recipe.AddIngredient(ItemID.MudBlock);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<ChlorophyteBrick>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChlorophyteBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ChlorophyteBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HeartstoneBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OrangeBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<OrangeBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OrangeBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<OrangeSlabWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OrangeBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<OrangeTiledWall>(), 4);
            recipe.AddRecipe();

            

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChocolateCandyCaneBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ChocolateCandyCaneWall>(), 4);
            recipe.AddRecipe();

            

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterWood>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkMatterWoodWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodTable>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 10);
            recipe.SetResult(ModContent.ItemType<CoughwoodWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlimeBlock, 5);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ModContent.ItemType<DarkSlimeBlock>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 33);
            recipe.AddIngredient(ItemID.SlimeBlock);
            recipe.SetResult(ModContent.ItemType<SlimeTorch>(), 33);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeBathtub>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeBed>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeCandelabra>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeChandelier>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 10);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeClock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeDresser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimePiano>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeSofa>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>());
            recipe.SetResult(ModContent.ItemType<DarkSlimePlatform>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 10);
            recipe.SetResult(ModContent.ItemType<DarkSlimeWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.Furniture.DarkSlimeSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneBathtub>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneBed>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneCandelabra>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneChandelier>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 10);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneClock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneDresser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstonePiano>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneSofa>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<HeartstoneTable>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>());
            recipe.SetResult(ModContent.ItemType<HeartstonePlatform>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HeartstonePlatform>());
            recipe.SetResult(ModContent.ItemType<Heartstone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 10);
            recipe.SetResult(ModContent.ItemType<HeartstoneWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.Furniture.HeartstoneSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ectoplasm);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Echoplasm>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 14);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmBathtub>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmBed>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmCandelabra>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmChandelier>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 10);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmClock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmDresser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmPiano>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmSofa>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EctoplasmTable>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>());
            recipe.SetResult(ModContent.ItemType<EctoplasmPlatform>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EctoplasmPlatform>());
            recipe.SetResult(ModContent.ItemType<Echoplasm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 10);
            recipe.SetResult(ModContent.ItemType<EctoplasmWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Echoplasm>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.Furniture.EctoplasmSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<VertebraeBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<VertebraeCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<VertebraeChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<VertebraeChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<VertebraeDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<VertebraeLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae);
            recipe.SetResult(ModContent.ItemType<VertebraePlatform>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VertebraePlatform>());
            recipe.SetResult(ItemID.Vertebrae);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 10);
            recipe.SetResult(ModContent.ItemType<VertebraeWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 10);
            recipe.SetResult(ModContent.ItemType<ResistantWoodWorkBench>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ResistantWoodBathtub>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ResistantWoodChandelier>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<ResistantWoodBed>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<ImperviousBookcase>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 10);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<ResistantWoodClock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 16);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<ResistantWoodDresser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<ResistantWoodPiano>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<ResistantWoodSofa>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ResistantWoodCandelabra>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ResistantWoodCandle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ResistantWoodChair>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 8);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ResistantWoodChest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ResistantWoodLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 6);
            recipe.AddIngredient(ItemID.Torch, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ResistantWoodLantern>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ResistantWoodTable>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ResistantWood>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.Furniture.ResistantWoodSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OrangeBrick>(), 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Items.Placeable.Furniture.OrangeDungeonSink>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<SapphireWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<RubyWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EmeraldWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<TopazWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<AmethystWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DiamondWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ebonwood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<EbonwoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shadewood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<ShadewoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<PearlwoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<RichMahoganyBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BorealWood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<BorealWoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalmWood);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<PalmWoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>());
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<CoughwoodBeam>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandstoneBrick);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<SandstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlstoneBlock);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<PearlstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimstoneBlock);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<CrimstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EbonstoneBlock);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<EbonstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChunkstoneBlock>());
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(ModContent.ItemType<ChunkstoneColumn>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodBreastplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 9);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CoughwoodBow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>());
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ModContent.ItemType<DarkSlimeBlock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkSlimeBlock>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DarkSlimeBlockWall>(), 4);
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
            recipe.AddIngredient(ModContent.ItemType<BlueLihzahrdBrick>(), 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<BlueLihzahrdStatue>());
            recipe.AddRecipe();

            

            

            

            

            

            

            

            

            

            

            

            


            

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ModContent.ItemType<LivingLightningBlock>(), 50);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<PlasmaLamp>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cloud);
            recipe.AddIngredient(ModContent.ItemType<LivingLightningBlock>());
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<VoltBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LivingLightningBlock>(), 80);
            recipe.AddIngredient(ItemID.Cloud, 50);
            recipe.AddIngredient(ItemID.RainCloud, 80);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.NimbusRod);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumOre);
            recipe.AddIngredient(ItemID.Cloud);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<MoonplateBlock>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AntlionMandible);
            recipe.AddIngredient(ItemID.SandBlock, 60);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 5);
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertLongSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 75);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 2);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ItemID.GoldHelmet);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 100);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 5);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ItemID.GoldChainmail);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 3);
            recipe.AddIngredient(ItemID.AntlionMandible);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.GoldGreaves);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 75);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 2);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 10);
            recipe.AddIngredient(ItemID.PlatinumHelmet);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 100);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 5);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddIngredient(ItemID.PlatinumChainmail);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 3);
            recipe.AddIngredient(ItemID.AntlionMandible);
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddIngredient(ItemID.PlatinumGreaves);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 75);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 2);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ModContent.ItemType<BismuthHelmet>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 100);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 5);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ModContent.ItemType<BismuthChainmail>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 3);
            recipe.AddIngredient(ItemID.AntlionMandible);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ModContent.ItemType<BismuthGreaves>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DesertGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Tourmaline>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<TourmalineHook>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Peridot>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<PeridotHook>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Zircon>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZirconHook>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.InfernoFork);
            recipe.AddIngredient(ItemID.SpectreStaff);
            recipe.AddIngredient(ItemID.ShadowbeamStaff);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 30);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<SpiritbeamFork>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 20);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<OnyxHook>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LaserRifle);
            recipe.AddIngredient(ModContent.ItemType<LensApparatus>());
            recipe.AddIngredient(ItemID.SoulofFright, 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<EnergyRevolver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronOre, 30);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<CarbonSteel>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadOre, 30);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<CarbonSteel>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<Sandstone>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Seed, 25);
            recipe.AddIngredient(ItemID.HellstoneBar);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<HellstoneSeed>(), 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianShield);
            recipe.AddIngredient(ItemID.IronskinPotion, 10);
            recipe.AddIngredient(ItemID.BattlePotion, 15);
            recipe.AddIngredient(ItemID.ThornsPotion, 15);
            recipe.AddIngredient(ItemID.WaterWalkingPotion, 10);
            recipe.AddIngredient(ItemID.Bone, 99);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<AlchemicalSkull>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 15);
            recipe.AddIngredient(ItemID.CursedFlame, 5);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<CorruptShard>(), 5);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<BagofShadows>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Fireblossom, 15);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.AshBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<FireShard>(), 5);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<BagofFire>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.PixieDust, 10);
            recipe.AddIngredient(ItemID.UnicornHorn, 2);
            recipe.AddIngredient(ModContent.ItemType<SacredShard>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<BagofHallows>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 15);
            recipe.AddIngredient(ItemID.Ichor, 10);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<CorruptShard>(), 5);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<BagofBlood>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<YuckyBit>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Pathogen>(), 10);
            recipe.AddIngredient(ModContent.ItemType<ChunkstoneBlock>(), 50);
            recipe.AddIngredient(ModContent.ItemType<CorruptShard>(), 5);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<BagofIck>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TheHorsemansBlade);
            recipe.AddIngredient(ItemID.SpookyWood, 900);
            recipe.AddIngredient(ItemID.LivingFireBlock, 200);
            recipe.AddIngredient(ItemID.Pumpkin, 30);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 70);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<PumpkingsSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SiltBlock, 20);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Gravel>(), 15);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlushBlock, 20);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Gravel>(), 15);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 60);
            recipe.anyWood = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<FineLumber>(), 15);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<DesertLongSword>());
            recipe.AddIngredient(ModContent.ItemType<RhodiumGreatsword>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.AeonsEternity>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<DesertLongSword>());
            recipe.AddIngredient(ModContent.ItemType<OsmiumGreatsword>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.AeonsEternity>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddIngredient(ModContent.ItemType<DesertLongSword>());
            recipe.AddIngredient(ModContent.ItemType<IridiumGreatsword>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.AeonsEternity>());
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
            recipe.AddIngredient(ItemID.BladeofGrass);
            recipe.AddIngredient(ItemID.FieryGreatsword);
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
            recipe.AddIngredient(ItemID.BlueMoon);
            recipe.AddIngredient(ItemID.Sunfury);
            recipe.AddIngredient(ItemID.BallOHurt);
            recipe.AddIngredient(ModContent.ItemType<Sporalash>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Moonfury>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueMoon);
            recipe.AddIngredient(ItemID.Sunfury);
            recipe.AddIngredient(ItemID.TheMeatball);
            recipe.AddIngredient(ModContent.ItemType<Sporalash>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Moonfury>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueMoon);
            recipe.AddIngredient(ItemID.Sunfury);
            recipe.AddIngredient(ModContent.ItemType<TheCell>());
            recipe.AddIngredient(ModContent.ItemType<Sporalash>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<Moonfury>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NightsEdge);
            recipe.AddIngredient(ItemID.Excalibur);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient(ItemID.DarkShard);
            recipe.AddIngredient(ItemID.LightShard);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<VertexofExcalibur>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolarFragment>(), 3);
            recipe.AddIngredient(ItemID.SilverBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<SunCharm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolarFragment>(), 3);
            recipe.AddIngredient(ItemID.TungstenBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<SunCharm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkLance);
            recipe.AddIngredient(ItemID.Gungnir);
            recipe.AddIngredient(ItemID.SoulofFright, 30);
            recipe.AddIngredient(ItemID.DarkShard);
            recipe.AddIngredient(ItemID.LightShard);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<DarklightLance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Melee.AeonsEternity>());
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TrueAeonsEternity>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TrueAeonsEternity>());
            recipe.AddIngredient(ItemID.TrueExcalibur);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.TerraBlade);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<DurataniumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumHeadgear>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 24);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumDrill>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumChainsaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumWaraxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumGlaive>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumRepeater>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<OrichythrilBlowpipe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<MythrilSplitknife>(), 65);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<OrichythrilBlowpipe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<OrichalcumSplitblade>(), 65);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<NaquadahBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahHeadguard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahHood>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahMask>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahBreastplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahShinguards>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahDrill>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahChainsaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahGreataxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahRepeater>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<NaquadahTrident>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NaquadahAnvil>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumOre>(), 30);
            recipe.AddIngredient(ItemID.Hellforge);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumForge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumOre>(), 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<TroxiniumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStar>(), 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<EmptyXeradonBucket>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumHat>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumDrill>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumChainsaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumWaraxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumSpear>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TroxiniumRepeater>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<HallowedCrown>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<HeavensTear>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.LightShard, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<HallowedThorn>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pwnhammer);
            recipe.AddIngredient(ItemID.HallowedBar, 35);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TheBanhammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 35);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<HallowedGreatsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<HallowedBlowpipe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<HallowedKunai>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<SunlightKunai>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteForge);
            recipe.AddIngredient(ModContent.ItemType<CaesiumOre>(), 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<CaesiumForge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumForge);
            recipe.AddIngredient(ModContent.ItemType<CaesiumOre>(), 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<CaesiumForge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumForge>());
            recipe.AddIngredient(ModContent.ItemType<CaesiumOre>(), 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<CaesiumForge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CaesiumBar>(), 30);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<CaesiumHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CaesiumBar>(), 40);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<CaesiumPlateMail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CaesiumBar>(), 28);
            recipe.AddIngredient(ItemID.HellstoneBar, 9);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<CaesiumGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<XeradonAnvil>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FireShard>(), 2);
            recipe.AddIngredient(ItemID.LivingFireBlock, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<BlastShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 2);
            recipe.AddIngredient(ModContent.ItemType<SoulofIce>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<FrigidShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ToxinShard>(), 2);
            recipe.AddIngredient(ItemID.Stinger);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<VenomShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EarthShard>(), 2);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<CoreShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BreezeShard>(), 2);
            recipe.AddIngredient(ItemID.SoulofFlight);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TornadoShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UndeadShard>(), 2);
            recipe.AddIngredient(ModContent.ItemType<RottenFlesh>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<DemonicShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WaterShard>(), 2);
            recipe.AddIngredient(ModContent.ItemType<WaterXeradonBucket>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TorrentShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CorruptShard>(), 2);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<WickedShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 2);
            recipe.AddIngredient(ItemID.SoulofLight, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<SacredShard>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BlastShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<TornadoShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<VenomShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<WickedShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<SacredShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<CoreShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<TorrentShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<DemonicShard>(), 3);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>(), 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<ElementShard>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStar>(), 5);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.LihzahrdPowerCell);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteHeadgear);
            recipe.AddIngredient(ItemID.TikiMask);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteMask);
            recipe.AddIngredient(ItemID.TikiMask);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteHelmet);
            recipe.AddIngredient(ItemID.TikiMask);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteHeadgear);
            recipe.AddIngredient(ItemID.SpookyHelmet);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteMask);
            recipe.AddIngredient(ItemID.SpookyHelmet);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.SpectreHood);
            recipe.AddIngredient(ItemID.ShroomiteHelmet);
            recipe.AddIngredient(ItemID.SpookyHelmet);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleScaleMail);
            recipe.AddIngredient(ItemID.SpectreRobe);
            recipe.AddIngredient(ItemID.ShroomiteBreastplate);
            recipe.AddIngredient(ItemID.TikiShirt);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientBodyplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleScaleMail);
            recipe.AddIngredient(ItemID.SpectreRobe);
            recipe.AddIngredient(ItemID.ShroomiteBreastplate);
            recipe.AddIngredient(ItemID.SpookyBreastplate);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientBodyplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleLeggings);
            recipe.AddIngredient(ItemID.SpectrePants);
            recipe.AddIngredient(ItemID.ShroomiteLeggings);
            recipe.AddIngredient(ItemID.TikiPants);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientLeggings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleLeggings);
            recipe.AddIngredient(ItemID.SpectrePants);
            recipe.AddIngredient(ItemID.ShroomiteLeggings);
            recipe.AddIngredient(ItemID.SpookyLeggings);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AncientLeggings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FeroziumOre>(), 6);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<FeroziumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<FeroziumHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 24);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<FeroziumBreastplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 18);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<FeroziumGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>());
            recipe.AddIngredient(ItemID.WoodenArrow, 70);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<FeroziumArrow>(), 70);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>());
            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<FeroziumBullet>(), 70);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<FeroziumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 18);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<FeroziumIceSword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<FeroziumWaraxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ectoplasm, 12);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<SpectreHeadgear>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShroomiteOre>(), 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ItemID.ShroomiteBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 5);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<ShadowRing>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TacticalShotgun, 2);
            recipe.AddIngredient(ItemID.Ectoplasm, 50);
            recipe.AddIngredient(ItemID.ShroomiteBar, 30);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<TacticalExpulsor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BrokenVigilanteTome>());
            recipe.AddIngredient(ItemID.FallenStar, 200);
            recipe.AddIngredient(ItemID.MeteoriteBar, 150);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 35);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Starfall>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PossessedHatchet);
            recipe.AddIngredient(ItemID.AdamantiteChainsaw);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.CursedFlame, 50);
            recipe.AddIngredient(ItemID.LivingFireBlock, 160);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<PossessedFlamesaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PossessedHatchet);
            recipe.AddIngredient(ItemID.TitaniumChainsaw);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.CursedFlame, 50);
            recipe.AddIngredient(ItemID.LivingFireBlock, 160);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<PossessedFlamesaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EarthStone>());
            recipe.AddIngredient(ItemID.LihzahrdPowerCell);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumShrine>());
            recipe.SetResult(ModContent.ItemType<SolariumRod>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumOre>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<SolariumStar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStar>(), 33);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<SolarFlaresword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStar>(), 21);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<SolarFlareBow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 7);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<SolariumStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VampireKnives);
            recipe.AddIngredient(ItemID.ScourgeoftheCorruptor);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 30);
            recipe.AddIngredient(ModContent.ItemType<IllegalWeaponInstructions>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<KnivesoftheCorruptor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 35);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddIngredient(ItemID.Fireblossom, 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<TheGoldenFlames>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VenusMagnum);
            recipe.AddIngredient(ItemID.Uzi);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 50);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<PlanterasFury>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMissile);
            recipe.AddIngredient(ItemID.Bomb, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Boomlash>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicDagger);
            recipe.AddIngredient(ItemID.Grenade, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<MagicGrenade>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 5);
            recipe.AddIngredient(ItemID.IceBlock, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<IceGel>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<CobaltShieldMarkII>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<PalladiumShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DurataniumShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CobaltShieldMarkII>());
            recipe.AddIngredient(ModContent.ItemType<PalladiumShield>());
            recipe.AddIngredient(ModContent.ItemType<DurataniumShield>());
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<CobaltOmegaShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CobaltShieldMarkII>());
            recipe.AddIngredient(ModContent.ItemType<PalladiumShield>());
            recipe.AddIngredient(ModContent.ItemType<DurataniumShield>());
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<PalladiumOmegaShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CobaltShieldMarkII>());
            recipe.AddIngredient(ModContent.ItemType<PalladiumShield>());
            recipe.AddIngredient(ModContent.ItemType<DurataniumShield>());
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<DurataniumOmegaShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 50);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddIngredient(ItemID.SoulofFright, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Summon.PrimeStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 2);
            recipe.AddIngredient(ItemID.SandBlock, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<SandBomb>(), 2);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 2);
            recipe.AddIngredient(ItemID.EbonsandBlock, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<EbonsandBomb>(), 2);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 2);
            recipe.AddIngredient(ItemID.CrimsandBlock, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<CrimsandBomb>(), 2);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 2);
            recipe.AddIngredient(ItemID.PearlsandBlock, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<PearlsandBomb>(), 2);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 2);
            recipe.AddIngredient(ModContent.ItemType<SnotsandBlock>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<SandBomb>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.Cannonball);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenSolution, 15);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<PurityBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PurpleSolution, 15);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<CorruptionBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LimeGreenSolution>(), 15);
            recipe.AddIngredient(ItemID.MudBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<JungleBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedSolution, 15);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<CrimsonBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<YellowSolution>(), 15);
            recipe.AddIngredient(ModContent.ItemType<ChunkstoneBlock>(), 50);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<ContagionBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkBlueSolution, 15);
            recipe.AddIngredient(ItemID.MudBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<MushroomBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueSolution, 15);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 5);
            recipe.AddIngredient(ItemID.Explosives);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<HallowBomb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RoyalGel);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.BandofSlime>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<StickyCharm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EtherealHeart>());
            recipe.AddIngredient(ModContent.ItemType<HeartoftheGolem>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<SouloftheGolem>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CloudinaBottle);
            recipe.AddIngredient(ItemID.BlizzardinaBottle);
            recipe.AddIngredient(ItemID.SandstorminaBottle);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<SandyStormcloudinaBottle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SandyStormcloudinaBottle>());
            recipe.AddIngredient(ItemID.ShinyRedBalloon, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.BundleofBalloons);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shotgun);
            recipe.AddIngredient(ItemID.Spike, 100);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<SpikeCannon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StarCloak);
            recipe.AddIngredient(ItemID.PanicNecklace);
            recipe.AddIngredient(ItemID.HoneyComb);
            recipe.AddIngredient(ModContent.ItemType<LightninginaBottle>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<CloakofAssists>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StarCloak);
            recipe.AddIngredient(ItemID.SweetheartNecklace);
            recipe.AddIngredient(ModContent.ItemType<LightninginaBottle>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<CloakofAssists>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeeCloak);
            recipe.AddIngredient(ItemID.PanicNecklace);
            recipe.AddIngredient(ModContent.ItemType<LightninginaBottle>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<CloakofAssists>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianHorseshoe);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.Spike, 50);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<GuardianBoots>());
            recipe.AddRecipe();

            // vanilla items

            // end vanilla items

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NaturesGift, 4);
            recipe.AddIngredient(ItemID.JungleRose);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<NaturesEndowment>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaFlower);
            recipe.AddIngredient(ItemID.BandofStarpower, 2);
            recipe.AddIngredient(ModContent.ItemType<NaturesEndowment>());
            recipe.AddIngredient(ItemID.SorcererEmblem);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<GiftofStarpower>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ForsakenRelic>());
            recipe.AddIngredient(ItemID.CrossNecklace);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<ForsakenCross>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NullEmblem>(), 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.AvengerEmblem);
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
            recipe.AddIngredient(ModContent.ItemType<ChaosCharm>());
            recipe.AddIngredient(ItemID.EyeoftheGolem);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<ChaosEye>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianSkull);
            recipe.AddIngredient(ItemID.ObsidianRose);
            recipe.AddIngredient(ItemID.MagmaStone);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<FlareStone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.AegisofAges>());
            recipe.AddIngredient(ItemID.PaladinsShield);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<TitanShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CellPhone);
            recipe.AddIngredient(ModContent.ItemType<MagicConch>());
            recipe.AddIngredient(ModContent.ItemType<DemonConch>());
            recipe.AddIngredient(ItemID.FallenStar, 40);
            recipe.AddIngredient(ItemID.Diamond, 20);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 7);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<ShadowMirror>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DestroyerEmblem);
            recipe.AddIngredient(ItemID.MagicQuiver);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<ApollosQuiver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 50);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<CrystalEdge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChaosCrystal>());
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<ChaosEmblem>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.SoulofSight, 8);
            recipe.AddIngredient(ItemID.LightShard, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<ReflexCharm>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ReflexCharm>());
            recipe.AddIngredient(ItemID.AnkhShield);
            recipe.AddIngredient(ModContent.ItemType<GoldenShield>());
            recipe.AddIngredient(ModContent.ItemType<OxygenTank>());
            recipe.AddIngredient(ModContent.ItemType<Vortex>());
            recipe.AddIngredient(ModContent.ItemType<NuclearExtinguisher>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<ReflexShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GreekExtinguisher>());
            recipe.AddIngredient(ModContent.ItemType<SixHundredWattLightbulb>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<NuclearExtinguisher>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shackle, 6);
            recipe.AddIngredient(ItemID.BandofRegeneration);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DullingTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<AngerTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.TungstenOre, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<AngerTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<AngerTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.TungstenOre, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<AngerTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Toolbelt);
            recipe.AddIngredient(ItemID.GPS);
            recipe.AddIngredient(ItemID.GoldCoin);
            recipe.AddIngredient(ItemID.TinkerersWorkshop);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<GoblinToolbelt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GoblinToolbelt>());
            recipe.AddIngredient(ItemID.JellyfishNecklace);
            recipe.AddIngredient(ItemID.DestroyerEmblem);
            recipe.AddIngredient(ItemID.CrossNecklace);
            recipe.AddIngredient(ItemID.BundleofBalloons);
            recipe.AddIngredient(ModContent.ItemType<Magnet>());
            recipe.AddIngredient(ItemID.SpelunkerPotion, 5);
            recipe.AddIngredient(ItemID.HunterPotion, 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<GoblinArmyKnife>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GoblinToolbelt>());
            recipe.AddIngredient(ItemID.PortableCementMixer);
            recipe.AddIngredient(ItemID.BrickLayer);
            recipe.AddIngredient(ItemID.ExtendoGrip);
            recipe.AddIngredient(ItemID.FlyingCarpet);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<BuildersToolbelt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TitanShield>());
            recipe.AddIngredient(ModContent.ItemType<FrostGauntlet>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<TitanGauntlets>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ItemID.SandstoneBrick, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<SandCastle>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<GuideSummonDoll>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.TungstenOre, 5);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<GuideSummonDoll>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.SilverOre, 5);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<GuideSummonDoll>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll);
            recipe.AddIngredient(ItemID.Cobweb, 50);
            recipe.AddIngredient(ItemID.TungstenOre, 5);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<GuideSummonDoll>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FireGauntlet);
            recipe.AddIngredient(ItemID.FrozenTurtleShell);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<FrostGauntlet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FireGauntlet);
            recipe.AddIngredient(ItemID.Ichor, 20);
            recipe.AddIngredient(ItemID.CursedFlame, 20);
            recipe.AddIngredient(ItemID.SpiderFang, 20);
            recipe.AddIngredient(ItemID.Stinger, 20);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Pathogen>(), 20);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<TerraClaws>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddIngredient(ItemID.Hellstone, 20);
            recipe.AddIngredient(ItemID.LavaBucket);
            recipe.AddIngredient(ItemID.SoulofFright, 6);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<HadesCross>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CelestialShell);
            recipe.AddIngredient(ModContent.ItemType<HadesCross>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<TransformationTalisman>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby, 10);
            recipe.AddIngredient(ItemID.MeteoriteBar, 5);
            recipe.AddIngredient(ItemID.Wire, 30);
            recipe.AddIngredient(ItemID.HunterPotion, 3);
            recipe.AddIngredient(ItemID.SpelunkerPotion, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<SonicScrewdriverMkI>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SonicScrewdriverMkI>());
            recipe.AddIngredient(ItemID.Sapphire, 7);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.AddIngredient(ItemID.GPS);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<SonicScrewdriverMkII>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SonicScrewdriverMkII>());
            recipe.AddIngredient(ItemID.Emerald, 10);
            recipe.AddIngredient(ItemID.Wire, 20);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<SonicScrewdriverMkIII>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DualHook);
            recipe.AddIngredient(ItemID.IvyWhip);
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddIngredient(ItemID.Hook, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<QuadWhip>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
            recipe.AddIngredient(ItemID.GillsPotion, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<OxygenTank>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flamelash);
            recipe.AddIngredient(ItemID.CursedFlame, 99);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<CursedFlamelash>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(ModContent.ItemType<Pathogen>(), 30);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<PathogenMist>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<MysteriousPage>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 20);
            recipe.AddIngredient(ModContent.ItemType<BloodshotLens>(), 10);
            recipe.AddIngredient(ItemID.BlackLens);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<LensApparatus>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemonScythe);
            recipe.AddIngredient(ItemID.Fireblossom, 20);
            recipe.AddIngredient(ItemID.LivingFireBlock, 100);
            recipe.AddIngredient(ItemID.SoulofFright, 7);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<DevilsScythe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddIngredient(ModContent.ItemType<Tourmaline>(), 15);
            recipe.AddIngredient(ModContent.ItemType<LensApparatus>());
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<FocusBeam>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BrokenVigilanteTome>());
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 20);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<GigaHorn>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofIce>(), 20);
            recipe.AddIngredient(ItemID.WaterBolt);
            recipe.AddIngredient(ModContent.ItemType<IceGel>(), 50);
            recipe.AddIngredient(ItemID.FrostCore, 2);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<FreezeBolt>());
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
            recipe.SetResult(ModContent.ItemType<MusicBoxEssence>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusicBox, 2);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddIngredient(ModContent.ItemType<MusicBoxEssence>());
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ModContent.ItemType<Jukebox>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Heartstone>(), 45);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Heartstone>(), 45);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ItemID.LifeCrystal);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<StaminaCrystal>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<Staminastone>(), 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Staminastone>(), 25);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<StaminaCrystal>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Staminastone>(), 5);
            recipe.AddIngredient(ItemID.Silk);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<LesserStaminaPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LesserStaminaPotion>(), 2);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<StaminaPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<StaminaPotion>());
            recipe.AddIngredient(ItemID.SharkFin, 3);
            recipe.AddIngredient(ItemID.Mushroom, 5);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<GreaterStaminaPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GreaterStaminaPotion>(), 2);
            recipe.AddIngredient(ItemID.SharkFin, 6);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddIngredient(ItemID.Silk);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(ModContent.ItemType<SuperStaminaPotion>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeFruit);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ModContent.ItemType<Lifestone>(), 30);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Lifestone>(), 30);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(ItemID.LifeFruit);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedBoomerang);
            recipe.AddIngredient(ItemID.Shuriken, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Shurikerang>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnchantedBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.EnchantedBoomerang);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnchantedBar>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<EnchantedShuriken>(), 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnchantedBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<BrokenHiltPiece>(), 5);
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
            recipe.SetResult(ModContent.ItemType<TorchLauncher>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SiltBlock, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CompressedExtractBlock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlushBlock, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CompressedExtractBlock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<YuckyBit>(), 15);
            recipe.AddIngredient(ModContent.ItemType<VirulentPowder>(), 30);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<BacterialTotem>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Beak>(), 6);
            recipe.AddIngredient(ItemID.SandBlock, 30);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<TheBeak>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Rock>());
            recipe.AddIngredient(ModContent.ItemType<PointingLaser>());
            recipe.AddIngredient(ModContent.ItemType<AlienDevice>());
            recipe.AddIngredient(ModContent.ItemType<IllegalWeaponInstructions>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<EyeofOblivionAncient>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ToxinShard>(), 30);
            recipe.AddIngredient(ItemID.Stinger, 15);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<HornetFood>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 20);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<EyesPamphlet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 100);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddIngredient(ModContent.ItemType<EarthStone>());
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<DarkMatterChunk>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 100);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddIngredient(ModContent.ItemType<EarthStone>());
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<DarkMatterChunk>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChunkstoneBlock>(), 100);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddIngredient(ModContent.ItemType<EarthStone>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<DarkMatterChunk>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<YuckyBit>(), 6);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.MechanicalWorm);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 5);
            recipe.AddIngredient(ItemID.Stinger, 15);
            recipe.AddIngredient(ItemID.JungleSpores, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<OddFertilizer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.Coral, 15);
            recipe.AddIngredient(ItemID.SharkFin);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.PirateMap);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTime>(), 40);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>());
            recipe.AddIngredient(ModContent.ItemType<Timechanger>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TimechangerMkII>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.GoldBar, 20);
            recipe.AddIngredient(ItemID.BlackLens);
            recipe.AddIngredient(ModContent.ItemType<BloodshotLens>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Moonphaser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.PlatinumBar, 20);
            recipe.AddIngredient(ItemID.BlackLens);
            recipe.AddIngredient(ModContent.ItemType<BloodshotLens>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<Moonphaser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddIngredient(ModContent.ItemType<OblivionOre>());
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<OblivionBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 2);
            recipe.AddIngredient(ItemID.LifeFruit, 2);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<CrystalFruit>(), 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.BlueBrick, 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<ImperviousBrick>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.PinkBrick, 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<ImperviousBrick>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.GreenBrick, 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<ImperviousBrick>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ModContent.ItemType<OrangeBrick>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<ImperviousBrick>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PyroscoricOre>());
            recipe.AddIngredient(ItemID.StoneBlock, 3);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<PyroscoricBrick>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PyroscoricOre>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<PyroscoricBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PyroscoricBar>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<PyroscoricLongsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PyroscoricBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<PyroscoricPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PyroscoricBar>());
            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<PyroscoricBullet>(), 70);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TritanoriumOre>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<TritanoriumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TritanoriumBar>(), 35);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<TritanoriumBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TritanoriumBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<TritanoriumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TritanoriumBar>());
            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<TritonBullet>(), 70);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeOre>(), 6);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<UnvolanditeBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 24);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<UnvolanditeGreatsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<UnvolanditePicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStaff>());
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 9);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<UnvolanditeKunziteWaveStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PulseBow);
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<UnvolanditeFusebow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 17);
            recipe.AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<UnvolanditeHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 46);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 10);
            recipe.AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<UnvolanditeBodyplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 32);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 8);
            recipe.AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<UnvolanditeLeggings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VorazylcumOre>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<VorazylcumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VorazylcumBar>(), 22);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<VoraylzumKatana>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VorazylcumBar>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<VorazylcumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SolariumStaff>());
            recipe.AddIngredient(ModContent.ItemType<VorazylcumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 9);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<VorazylcumKunziteBoltStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PulseBow);
            recipe.AddIngredient(ModContent.ItemType<VorazylcumBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<VorazylcumFusebow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VorazylcumBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 17);
            recipe.AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<VorazylcumHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VorazylcumBar>(), 46);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 10);
            recipe.AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 4);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<VorazylcumBodyplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VorazylcumBar>(), 32);
            recipe.AddIngredient(ModContent.ItemType<Kunzite>(), 8);
            recipe.AddIngredient(ModContent.ItemType<SpikedBlastShell>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<VorazylcumLeggings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 30);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Elektriwave>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 3);
            recipe.AddIngredient(ModContent.ItemType<CaesiumBar>(), 3);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 3);
            recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<SuperhardmodeBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 200);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Electrobullet>(), 200);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 30);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<BlahsHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 35);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 35);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<BlahsBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 30);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 17);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<BlahsCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 50);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 25);
            recipe.AddIngredient(ModContent.ItemType<InstantaniumPicksaw>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<BlahsPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Phantoplasm>(), 25);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 25);
            recipe.AddIngredient(ModContent.ItemType<TheBanhammer>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<BlahsWarhammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteShotbow);
            recipe.AddIngredient(ItemID.HallowedRepeater);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 22);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<GleamingTwilight>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 60);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 75);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 40);
            recipe.AddIngredient(ModContent.ItemType<ElementShard>(), 7);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<BerserkerNightmare>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
            recipe.AddIngredient(ItemID.TitaniumBar, 30);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<InstantaniumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<InstantaniumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
            recipe.AddIngredient(ItemID.AdamantiteBar, 30);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<InstantaniumPicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TerraBlade);
            recipe.AddIngredient(ItemID.SpectreStaff);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 40);
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 5);
            recipe.AddIngredient(ItemID.Ectoplasm, 60);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<SoulEdge>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<OblivionGlaive>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Oblivirod>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Opal>(), 40);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<OpalStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 25);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<OnyxStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PaladinsHammer);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<GuardianHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 75);
            recipe.AddIngredient(ModContent.ItemType<ElementShard>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<ElementalArrow>(), 75);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteArrow, 75);
            recipe.AddIngredient(ItemID.HolyArrow, 75);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<BerserkerArrow>(), 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBullet, 75);
            recipe.AddIngredient(ItemID.CrystalBullet, 75);
            recipe.AddIngredient(ModContent.ItemType<LifeDew>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<BerserkerBullet>(), 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CaesiumOre>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<CaesiumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CaesiumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<CaesiumRepeater>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CaesiumBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<CaesiumScimitar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CaesiumBar>(), 30);
            recipe.AddIngredient(ModContent.ItemType<ElementShard>(), 20);
            recipe.AddIngredient(ItemID.Flamelash);
            recipe.AddIngredient(ItemID.MagicMissile);
            recipe.AddIngredient(ItemID.DirtRod);
            recipe.AddIngredient(ItemID.RainbowRod);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<ElementalRod>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionOre>(), 7);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<OblivionBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 60);
            recipe.AddIngredient(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<BerserkerHeadpiece>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 23);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 65);
            recipe.AddIngredient(ModContent.ItemType<AncientBodyplate>());
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<BerserkerBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 70);
            recipe.AddIngredient(ModContent.ItemType<AncientLeggings>());
            recipe.AddIngredient(ModContent.ItemType<Onyx>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<BerserkerCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SouloftheJungle>(), 20);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 60);
            recipe.AddIngredient(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<AwakenedRoseCrown>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SouloftheJungle>(), 23);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 65);
            recipe.AddIngredient(ModContent.ItemType<AncientBodyplate>());
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<AwakenedRosePlateMail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SouloftheJungle>(), 17);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 70);
            recipe.AddIngredient(ModContent.ItemType<AncientLeggings>());
            recipe.AddIngredient(ModContent.ItemType<LifeDew>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<AwakenedRoseSubligar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<SpectrumHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 23);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<AncientBodyplate>());
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<SpectrumBreastplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OblivionBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 40);
            recipe.AddIngredient(ModContent.ItemType<AncientLeggings>());
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Opal>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<SpectrumGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HydrolythOre>(), 5);
            recipe.AddIngredient(ModContent.ItemType<SolariumOre>());
            recipe.AddIngredient(ModContent.ItemType<FeroziumOre>());
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<HydrolythBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 3);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 60);
            recipe.AddIngredient(ModContent.ItemType<AncientHeadpiece>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<MiloticCrown>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 23);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 4);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 75);
            recipe.AddIngredient(ModContent.ItemType<AncientBodyplate>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<MiloticSkinplate>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>(), 3);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterGel>(), 70);
            recipe.AddIngredient(ModContent.ItemType<AncientLeggings>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<MiloticJodpurs>());
            recipe.AddRecipe();

            #region Avalon Armor

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerHeadpiece>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerBodyarmor>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerCuisses>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<AwakenedRoseCrown>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<AwakenedRosePlateMail>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<AwakenedRoseSubligar>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<SpectrumHelmet>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<SpectrumBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<SpectrumGreaves>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonCuisses>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<MiloticCrown>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<MiloticSkinplate>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonBodyarmor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SoulofTorture>(), 50);
            recipe.AddIngredient(ModContent.ItemType<VictoryPiece>());
            recipe.AddIngredient(ModContent.ItemType<MiloticJodpurs>());
            recipe.AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Armor.AvalonCuisses>());
            recipe.AddRecipe();

            #endregion Avalon Armor

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedPhasesaber);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<RedPhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.YellowPhasesaber);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<YellowPhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenPhasesaber);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<GreenPhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BluePhasesaber);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<BluePhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PurplePhasesaber);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<PurplePhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WhitePhasesaber);
            recipe.AddIngredient(ModContent.ItemType<HydrolythBar>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<WhitePhasecleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BladeofGrass);
            recipe.AddIngredient(ItemID.FieryGreatsword);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<FieryBladeofGrass>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.LightShard, 2);
            recipe.AddIngredient(ModContent.ItemType<SacredShard>(), 2);
            recipe.AddIngredient(ItemID.PixieDust, 20);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 20);
            recipe.AddIngredient(ModContent.ItemType<SoulofBlight>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<HallowedAltar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
            recipe.AddIngredient(ItemID.RottenChunk, 10);
            recipe.AddIngredient(ItemID.Deathweed, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(ItemID.ShadowScale, 20);
            recipe.AddIngredient(ItemID.DemoniteBar, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<DemonAltar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
            recipe.AddIngredient(ItemID.Vertebrae, 10);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>(), 5);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(ItemID.TissueSample, 20);
            recipe.AddIngredient(ItemID.CrimtaneBar, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<CrimsonAltar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChunkstoneBlock>(), 50);
            recipe.AddIngredient(ModContent.ItemType<YuckyBit>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Barfbush>(), 5);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(ModContent.ItemType<Booger>(), 20);
            recipe.AddIngredient(ModContent.ItemType<BacciliteBar>(), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<IckyAltar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<Bloodberry>());
            recipe.AddIngredient(ItemID.RottenChunk);
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
            recipe.AddIngredient(ItemID.JungleSpores, 15);
            recipe.AddIngredient(ItemID.Stinger, 10);
            recipe.AddIngredient(ItemID.Vine, 2);
            recipe.AddIngredient(ModContent.ItemType<ToxinShard>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Sporalash>());
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
            recipe.SetResult(ModContent.ItemType<BeetleBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 8);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<SunsShadow>());
            recipe.AddRecipe();

            // phm ore alts

            // bronze
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<BronzeBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<BronzeBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<BronzeBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<BronzeBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 12);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Tools.BronzePickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 9);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BronzeAxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 10);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BronzeHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BronzeBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BronzeShortsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BronzeBow>());
            recipe.AddRecipe();

            // staff

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BronzeHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BronzeChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BronzeGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 10);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BronzeWatch>());
            recipe.AddRecipe();
            // end bronze stuff

            // Nickel
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<NickelBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<NickelBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<NickelBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<NickelFence>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<NickelDoor>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<NickelAnvil>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelFence>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<NickelBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<NickelBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 12);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NickelPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 9);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NickelAxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 10);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NickelHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NickelBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NickelShortsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NickelBow>());
            recipe.AddRecipe();

            // staff

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NickelHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NickelChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NickelBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<NickelGreaves>());
            recipe.AddRecipe();
            // end Nickel stuff

            // Zinc
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<ZincBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ZincBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ZincBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<ZincBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 12);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 9);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincAxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 10);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincShortsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincBow>());
            recipe.AddRecipe();

            // staff

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ZincBar>(), 10);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ZincWatch>());
            recipe.AddRecipe();
            // end Zinc stuff

            // Bismuth
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<BismuthBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<BismuthBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<BismuthBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<BismuthBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 12);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 9);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthAxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 10);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthHammer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthBroadsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthShortsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthBow>());
            recipe.AddRecipe();

            // staff

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthHelmet>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 35);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthChainmail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthGreaves>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 10);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthWatch>());
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthBar>(), 5);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BismuthCrown>());
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BismuthCrown>(), 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.SlimeCrown);
            // end Bismuth stuff

            // Iridium
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumOre>());
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<IridiumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumBrick>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<IridiumBrickWall>(), 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumBrickWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<IridiumBrick>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(ModContent.ItemType<IridiumBar>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<DesertFeather>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<IridiumPickaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<DesertFeather>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<IridiumHamaxe>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumBar>(), 14);
            recipe.AddIngredient(ModContent.ItemType<DesertFeather>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<IridiumGreatsword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumBar>(), 13);
            recipe.AddIngredient(ModContent.ItemType<DesertFeather>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<IridiumLongbow>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<DesertFeather>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<IridiumHat>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<DesertFeather>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<IridiumPlateMail>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IridiumBar>(), 17);
            recipe.AddIngredient(ModContent.ItemType<DesertFeather>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<IridiumPants>());
            recipe.AddRecipe();
            // end Iridium stuff

            #region catalyzer

            // catalyzer stuff
            // catalyzer recipe
            recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 20);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 30);
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.AddRecipeGroup("ExxoAvalonOrigins:WorkBenches");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Catalyzer>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.EbonstoneBlock, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CrimstoneBlock, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<ChunkstoneBlock>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChunkstoneBlock>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PearlstoneBlock, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkMatterWood>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Wood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Ebonwood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ebonwood, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Shadewood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shadewood, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Coughwood>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Coughwood>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Pearlwood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.BorealWood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BorealWood, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PalmWood, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalmWood, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<DarkMatterWood>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BacciliteOre>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.DemoniteOre, 40);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteOre, 40);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CrimtaneOre, 40);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneOre, 40);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<BacciliteOre>(), 40);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumOre>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CobaltOre, 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltOre, 20);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PalladiumOre, 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumOre, 20);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<DurataniumOre>(), 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahOre>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.MythrilOre, 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilOre, 20);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.OrichalcumOre, 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumOre, 20);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<NaquadahOre>(), 20);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumOre>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.AdamantiteOre, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteOre, 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.TitaniumOre, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumOre, 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<TroxiniumOre>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BacciliteBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.DemoniteBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CrimtaneBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<BacciliteBar>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DurataniumBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CobaltBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PalladiumBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<DurataniumBar>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NaquadahBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.MythrilBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.OrichalcumBar, 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<NaquadahBar>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TroxiniumBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.AdamantiteBar, 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 5);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.TitaniumBar, 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 5);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<TroxiniumBar>(), 5);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Booger>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.ShadowScale, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShadowScale, 3);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.TissueSample, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TissueSample, 3);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Booger>(), 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Pathogen>(), 33);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.CursedFlame, 33);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CursedFlame, 33);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Ichor, 33);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ichor, 33);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<Pathogen>(), 33);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<YuckyBit>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.RottenChunk, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RottenChunk, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.Vertebrae, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae, 50);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>());
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<YuckyBit>(), 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LimeGreenSolution>(), 100);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.GreenSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.PurpleSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PurpleSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.RedSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<YellowSolution>(), 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<YellowSolution>(), 100);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.BlueSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ItemID.DarkBlueSolution, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkBlueSolution, 100);
            recipe.AddIngredient(ModContent.ItemType<Sulphur>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.Catalyzer>());
            recipe.SetResult(ModContent.ItemType<LimeGreenSolution>(), 100);
            recipe.AddRecipe();

            #endregion catalyzer

            #region Corrupted Thorn Armor

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike, 20);
            recipe.AddIngredient(ModContent.ItemType<CorruptShard>(), 20);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Armor.CorruptedThornCrown>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike, 25);
            recipe.AddIngredient(ModContent.ItemType<CorruptShard>(), 25);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Armor.CorruptedThornBodyarmor>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spike, 20);
            recipe.AddIngredient(ModContent.ItemType<CorruptShard>(), 20);
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
            recipe.AddIngredient(ModContent.ItemType<TropicalShroomCap>(), 12);
            recipe.AddIngredient(ModContent.ItemType<MosquitoProboscis>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.TropicalBlade>());
            recipe.AddRecipe();
        }
    }
}
