using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Ammo;
using ExxoAvalonOrigins.Items.Armor;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Other;
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
using ExxoAvalonOrigins.Items.Tools;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Melee;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using ExxoAvalonOrigins.Items.Weapons.Summon;
using ExxoAvalonOrigins.Items.Weapons.Throw;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Logic;

public static class RecipeCreator
{
    public static void CreateRecipes(Mod mod)
    {
        mod.CreateRecipe(ModContent.ItemType<BrokenVigilanteTome>())
            .AddIngredient(ItemID.BrokenHeroSword)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.BrokenHeroSword)
            .AddIngredient(ModContent.ItemType<BrokenVigilanteTome>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<UnderworldKey>())
            .AddIngredient(ItemID.TempleKey)
            .AddIngredient(ModContent.ItemType<UnderworldKeyMold>())
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddIngredient(ItemID.SoulofMight, 5)
            .AddIngredient(ItemID.SoulofSight, 5)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertKey>())
            .AddIngredient(ItemID.TempleKey)
            .AddIngredient(ModContent.ItemType<DesertKeyMold>())
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddIngredient(ItemID.SoulofMight, 5)
            .AddIngredient(ItemID.SoulofSight, 5)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<ContagionKey>())
            .AddIngredient(ItemID.TempleKey)
            .AddIngredient(ModContent.ItemType<ContagionKeyMold>())
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddIngredient(ItemID.SoulofMight, 5)
            .AddIngredient(ItemID.SoulofSight, 5)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodDoor>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 6)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodChair>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 4)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodChest>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 8)
            .AddRecipeGroup("IronBar", 2)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodTable>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 8)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodWorkBench>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 10).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeBlock>(), 5)
            .AddIngredient(ItemID.SlimeBlock, 5)
            .AddIngredient(ItemID.SoulofNight)
            .AddTile(TileID.Solidifier).Register();

        mod.CreateRecipe(ModContent.ItemType<SlimeTorch>(), 33)
            .AddIngredient(ItemID.Torch, 33)
            .AddIngredient(ItemID.SlimeBlock).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeBathtub>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 14)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeBed>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeBookcase>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeCandelabra>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeCandle>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeChair>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 4)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeChandelier>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeChest>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 8)
            .AddRecipeGroup("IronBar", 2)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeClock>())
            .AddRecipeGroup("IronBar", 3)
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 10)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeDoor>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 6)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeDresser>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 16)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeLamp>())
            .AddIngredient(ItemID.Torch)
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeLantern>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimePiano>())
            .AddIngredient(ItemID.Bone, 4)
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 15)
            .AddIngredient(ItemID.Book)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeSofa>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeWorkBench>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 10).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeSink>())
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>(), 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneBathtub>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 14)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneBed>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneBookcase>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneCandelabra>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneCandle>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneChair>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 4)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneChandelier>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneChest>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 8)
            .AddRecipeGroup("IronBar", 2)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneClock>())
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ModContent.ItemType<Heartstone>(), 10)
            .AddRecipeGroup("IronBar", 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneDoor>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 6)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneDresser>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 16)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneLamp>())
            .AddIngredient(ItemID.Torch)
            .AddIngredient(ModContent.ItemType<Heartstone>(), 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneLantern>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstonePiano>())
            .AddIngredient(ItemID.Bone, 4)
            .AddIngredient(ModContent.ItemType<Heartstone>(), 15)
            .AddIngredient(ItemID.Book)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneSofa>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneTable>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 8)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneWorkBench>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 10).Register();

        mod.CreateRecipe(ModContent.ItemType<HeartstoneSink>())
            .AddIngredient(ModContent.ItemType<Heartstone>(), 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<Echoplasm>(), 10)
            .AddIngredient(ItemID.Ectoplasm)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmBathtub>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 14)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmBed>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmBookcase>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmCandelabra>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmCandle>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmChair>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 4)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmChandelier>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmClock>())
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 10)
            .AddRecipeGroup("IronBar", 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmDresser>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 16)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmLamp>())
            .AddIngredient(ItemID.Torch)
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmLantern>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmPiano>())
            .AddIngredient(ItemID.Bone, 4)
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 15)
            .AddIngredient(ItemID.Book)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmSofa>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmTable>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 8)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmWorkBench>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 10).Register();

        mod.CreateRecipe(ModContent.ItemType<EctoplasmSink>())
            .AddIngredient(ModContent.ItemType<Echoplasm>(), 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<VertebraeBookcase>())
            .AddIngredient(ItemID.Vertebrae, 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<VertebraeCandle>())
            .AddIngredient(ItemID.Vertebrae, 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<VertebraeChair>())
            .AddIngredient(ItemID.Vertebrae, 4)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<VertebraeChest>())
            .AddIngredient(ItemID.Vertebrae, 8)
            .AddRecipeGroup("IronBar", 2)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<VertebraeDoor>())
            .AddIngredient(ItemID.Vertebrae, 6)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<VertebraeLantern>())
            .AddIngredient(ItemID.Vertebrae, 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<VertebraeWorkBench>())
            .AddIngredient(ItemID.Vertebrae, 10).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodWorkBench>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 10).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodBathtub>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 14)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodChandelier>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodBed>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<ImperviousBookcase>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodClock>())
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 10)
            .AddRecipeGroup("IronBar", 3)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodDresser>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 16)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodPiano>())
            .AddIngredient(ItemID.Bone, 4)
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 15)
            .AddIngredient(ItemID.Book)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodSofa>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodCandelabra>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodCandle>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodChair>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 4)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodChest>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 8)
            .AddRecipeGroup("IronBar", 2)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodLamp>())
            .AddIngredient(ItemID.Torch)
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodLantern>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodTable>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 8)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<ResistantWoodSink>())
            .AddIngredient(ModContent.ItemType<ResistantWood>(), 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<OrangeDungeonSink>())
            .AddIngredient(ModContent.ItemType<OrangeBrick>(), 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzeChandelier>())
            .AddIngredient(ModContent.ItemType<BronzeBar>(), 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincChandelier>())
            .AddIngredient(ModContent.ItemType<ZincBar>(), 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<BismuthChandelier>())
            .AddIngredient(ModContent.ItemType<BismuthBar>(), 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<BismuthCandle>())
            .AddIngredient(ModContent.ItemType<BismuthBar>())
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<BismuthCandelabra>())
            .AddIngredient(ModContent.ItemType<BismuthBar>(), 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<EbonwoodBeam>(), 2)
            .AddIngredient(ItemID.Ebonwood)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<ShadewoodBeam>(), 2)
            .AddIngredient(ItemID.Shadewood)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<PearlwoodBeam>(), 2)
            .AddIngredient(ItemID.Pearlwood)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<RichMahoganyBeam>(), 2)
            .AddIngredient(ItemID.RichMahogany)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<BorealWoodBeam>(), 2)
            .AddIngredient(ItemID.BorealWood)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<PalmWoodBeam>(), 2)
            .AddIngredient(ItemID.PalmWood)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodBeam>(), 2)
            .AddIngredient(ModContent.ItemType<Coughwood>())
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<SandstoneColumn>(), 2)
            .AddIngredient(ItemID.SandstoneBrick)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<PearlstoneColumn>(), 2)
            .AddIngredient(ItemID.PearlstoneBlock)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<CrimstoneColumn>(), 2)
            .AddIngredient(ItemID.CrimstoneBlock)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<EbonstoneColumn>(), 2)
            .AddIngredient(ItemID.EbonstoneBlock)
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<ChunkstoneColumn>(), 2)
            .AddIngredient(ModContent.ItemType<ChunkstoneBlock>())
            .AddTile(TileID.Sawmill).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodHelmet>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 25)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodBreastplate>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 30)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodGreaves>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 20)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodSword>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 9)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodHammer>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 8)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CoughwoodBow>())
            .AddIngredient(ModContent.ItemType<Coughwood>(), 8)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeBlock>())
            .AddIngredient(ModContent.ItemType<DarkMatterGel>())
            .AddTile(TileID.Solidifier).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkSlimeBlockWall>(), 4)
            .AddIngredient(ModContent.ItemType<DarkSlimeBlock>())
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ItemID.BlueBrickWall, 4)
            .AddIngredient(ItemID.BlueBrick)
            .AddTile(TileID.BoneWelder).Register();

        mod.CreateRecipe(ItemID.GreenBrickWall, 4)
            .AddIngredient(ItemID.GreenBrick)
            .AddTile(TileID.BoneWelder).Register();

        mod.CreateRecipe(ItemID.PinkBrickWall, 4)
            .AddIngredient(ItemID.PinkBrick)
            .AddTile(TileID.BoneWelder).Register();

        mod.CreateRecipe(ModContent.ItemType<BlueLihzahrdStatue>())
            .AddIngredient(ModContent.ItemType<BlueLihzahrdBrick>(), 25)
            .AddTile(TileID.WorkBenches).Register();


        mod.CreateRecipe(ModContent.ItemType<PlasmaLamp>())
            .AddIngredient(ItemID.CrystalBall)
            .AddIngredient(ModContent.ItemType<LivingLightningBlock>(), 50)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<VoltBrick>())
            .AddIngredient(ItemID.Cloud)
            .AddIngredient(ModContent.ItemType<LivingLightningBlock>())
            .AddTile(TileID.Hellforge).Register();

        mod.CreateRecipe(ItemID.NimbusRod)
            .AddIngredient(ModContent.ItemType<LivingLightningBlock>(), 80)
            .AddIngredient(ItemID.Cloud, 50)
            .AddIngredient(ItemID.RainCloud, 80)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<MoonplateBlock>(), 2)
            .AddIngredient(ItemID.PlatinumOre)
            .AddIngredient(ItemID.Cloud)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertLongSword>())
            .AddIngredient(ItemID.AntlionMandible)
            .AddIngredient(ItemID.SandBlock, 60)
            .AddIngredient(ModContent.ItemType<Beak>(), 5)
            .AddIngredient(ItemID.Topaz, 5)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertHelmet>())
            .AddIngredient(ItemID.SandBlock, 75)
            .AddIngredient(ModContent.ItemType<Beak>(), 2)
            .AddIngredient(ItemID.AntlionMandible, 2)
            .AddIngredient(ItemID.Topaz, 2)
            .AddIngredient(ItemID.GoldHelmet)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertChainmail>())
            .AddIngredient(ItemID.SandBlock, 100)
            .AddIngredient(ModContent.ItemType<Beak>(), 5)
            .AddIngredient(ItemID.AntlionMandible, 2)
            .AddIngredient(ItemID.Topaz, 2)
            .AddIngredient(ItemID.GoldChainmail)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertGreaves>())
            .AddIngredient(ItemID.SandBlock, 50)
            .AddIngredient(ModContent.ItemType<Beak>(), 3)
            .AddIngredient(ItemID.AntlionMandible)
            .AddIngredient(ItemID.Topaz)
            .AddIngredient(ItemID.GoldGreaves)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertHelmet>())
            .AddIngredient(ItemID.SandBlock, 75)
            .AddIngredient(ModContent.ItemType<Beak>(), 2)
            .AddIngredient(ItemID.AntlionMandible, 2)
            .AddIngredient(ItemID.Topaz, 10)
            .AddIngredient(ItemID.PlatinumHelmet)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertChainmail>())
            .AddIngredient(ItemID.SandBlock, 100)
            .AddIngredient(ModContent.ItemType<Beak>(), 5)
            .AddIngredient(ItemID.AntlionMandible, 2)
            .AddIngredient(ItemID.Topaz, 5)
            .AddIngredient(ItemID.PlatinumChainmail)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertGreaves>())
            .AddIngredient(ItemID.SandBlock, 50)
            .AddIngredient(ModContent.ItemType<Beak>(), 3)
            .AddIngredient(ItemID.AntlionMandible)
            .AddIngredient(ItemID.Topaz, 5)
            .AddIngredient(ItemID.PlatinumGreaves)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertHelmet>())
            .AddIngredient(ItemID.SandBlock, 75)
            .AddIngredient(ModContent.ItemType<Beak>(), 2)
            .AddIngredient(ItemID.AntlionMandible, 2)
            .AddIngredient(ItemID.Topaz, 2)
            .AddIngredient(ModContent.ItemType<BismuthHelmet>())
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertChainmail>())
            .AddIngredient(ItemID.SandBlock, 100)
            .AddIngredient(ModContent.ItemType<Beak>(), 5)
            .AddIngredient(ItemID.AntlionMandible, 2)
            .AddIngredient(ItemID.Topaz, 2)
            .AddIngredient(ModContent.ItemType<BismuthChainmail>())
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DesertGreaves>())
            .AddIngredient(ItemID.SandBlock, 50)
            .AddIngredient(ModContent.ItemType<Beak>(), 3)
            .AddIngredient(ItemID.AntlionMandible)
            .AddIngredient(ItemID.Topaz)
            .AddIngredient(ModContent.ItemType<BismuthGreaves>())
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<TourmalineHook>())
            .AddIngredient(ModContent.ItemType<Tourmaline>(), 15)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<PeridotHook>())
            .AddIngredient(ModContent.ItemType<Peridot>(), 15)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<ZirconHook>())
            .AddIngredient(ModContent.ItemType<Zircon>(), 15)
            .AddTile(TileID.Anvils).Register();


        mod.CreateRecipe(ModContent.ItemType<OnyxHook>())
            .AddIngredient(ModContent.ItemType<Onyx>(), 20)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 5)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<EnergyRevolver>())
            .AddIngredient(ItemID.LaserRifle)
            .AddIngredient(ModContent.ItemType<LensApparatus>())
            .AddIngredient(ItemID.SoulofFright, 16)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<Sandstone>(), 5)
            .AddIngredient(ItemID.SandBlock, 10)
            .AddIngredient(ItemID.StoneBlock, 10)
            .AddTile(TileID.Hellforge).Register();

        mod.CreateRecipe(ModContent.ItemType<HellstoneSeed>(), 25)
            .AddIngredient(ItemID.Seed, 25)
            .AddIngredient(ItemID.HellstoneBar)
            .AddTile(TileID.Hellforge).Register();

        mod.CreateRecipe(ModContent.ItemType<AlchemicalSkull>())
            .AddIngredient(ItemID.ObsidianShield)
            .AddIngredient(ItemID.IronskinPotion, 10)
            .AddIngredient(ItemID.BattlePotion, 15)
            .AddIngredient(ItemID.ThornsPotion, 15)
            .AddIngredient(ItemID.WaterWalkingPotion, 10)
            .AddIngredient(ItemID.Bone, 99)
            .AddTile(TileID.Hellforge).Register();

        mod.CreateRecipe(ModContent.ItemType<BagofShadows>())
            .AddIngredient(ItemID.DemoniteBar, 15)
            .AddIngredient(ItemID.CursedFlame, 5)
            .AddIngredient(ItemID.EbonstoneBlock, 50)
            .AddIngredient(ModContent.ItemType<CorruptShard>(), 5)
            .AddTile(TileID.Hellforge).Register();

        mod.CreateRecipe(ModContent.ItemType<BagofFire>())
            .AddIngredient(ItemID.Fireblossom, 15)
            .AddIngredient(ItemID.HellstoneBar, 10)
            .AddIngredient(ItemID.AshBlock, 50)
            .AddIngredient(ModContent.ItemType<FireShard>(), 5)
            .AddTile(TileID.Hellforge).Register();

        mod.CreateRecipe(ModContent.ItemType<BagofHallows>())
            .AddIngredient(ItemID.HallowedBar, 15)
            .AddIngredient(ItemID.PixieDust, 10)
            .AddIngredient(ItemID.UnicornHorn, 2)
            .AddIngredient(ModContent.ItemType<SacredShard>(), 2)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<BagofBlood>())
            .AddIngredient(ItemID.Vertebrae, 15)
            .AddIngredient(ItemID.Ichor, 10)
            .AddIngredient(ItemID.CrimstoneBlock, 50)
            .AddIngredient(ModContent.ItemType<CorruptShard>(), 5)
            .AddTile(TileID.Hellforge).Register();

        mod.CreateRecipe(ModContent.ItemType<BagofIck>())
            .AddIngredient(ModContent.ItemType<YuckyBit>(), 15)
            .AddIngredient(ModContent.ItemType<Pathogen>(), 10)
            .AddIngredient(ModContent.ItemType<ChunkstoneBlock>(), 50)
            .AddIngredient(ModContent.ItemType<CorruptShard>(), 5)
            .AddTile(TileID.Hellforge).Register();


        mod.CreateRecipe(ModContent.ItemType<Gravel>(), 15)
            .AddIngredient(ItemID.SiltBlock, 20)
            .AddIngredient(ItemID.StoneBlock, 5)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<Gravel>(), 15)
            .AddIngredient(ItemID.SlushBlock, 20)
            .AddIngredient(ItemID.StoneBlock, 5)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<FineLumber>(), 15)
            .AddRecipeGroup("Wood", 60)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<Moonfury>())
            .AddIngredient(ItemID.BlueMoon)
            .AddIngredient(ItemID.Sunfury)
            .AddIngredient(ItemID.BallOHurt)
            .AddIngredient(ModContent.ItemType<Sporalash>())
            .AddTile(TileID.DemonAltar).Register();

        mod.CreateRecipe(ModContent.ItemType<Moonfury>())
            .AddIngredient(ItemID.BlueMoon)
            .AddIngredient(ItemID.Sunfury)
            .AddIngredient(ItemID.TheMeatball)
            .AddIngredient(ModContent.ItemType<Sporalash>())
            .AddTile(TileID.DemonAltar).Register();

        mod.CreateRecipe(ModContent.ItemType<Moonfury>())
            .AddIngredient(ItemID.BlueMoon)
            .AddIngredient(ItemID.Sunfury)
            .AddIngredient(ModContent.ItemType<TheCell>())
            .AddIngredient(ModContent.ItemType<Sporalash>())
            .AddTile(TileID.DemonAltar).Register();

        mod.CreateRecipe(ModContent.ItemType<VertexofExcalibur>())
            .AddIngredient(ItemID.NightsEdge)
            .AddIngredient(ItemID.Excalibur)
            .AddIngredient(ItemID.BrokenHeroSword)
            .AddIngredient(ItemID.DarkShard)
            .AddIngredient(ItemID.LightShard)
            .AddTile(TileID.AdamantiteForge).Register();

        mod.CreateRecipe(ModContent.ItemType<DarklightLance>())
            .AddIngredient(ItemID.DarkLance)
            .AddIngredient(ItemID.Gungnir)
            .AddIngredient(ItemID.SoulofFright, 30)
            .AddIngredient(ItemID.DarkShard)
            .AddIngredient(ItemID.LightShard)
            .AddTile(TileID.AdamantiteForge).Register();

        mod.CreateRecipe(ModContent.ItemType<TrueAeonsEternity>())
            .AddIngredient(ModContent.ItemType<AeonsEternity>())
            .AddIngredient(ItemID.BrokenHeroSword)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ItemID.TerraBlade)
            .AddIngredient(ModContent.ItemType<TrueAeonsEternity>())
            .AddIngredient(ItemID.TrueExcalibur)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumBar>())
            .AddIngredient(ModContent.ItemType<DurataniumOre>(), 3)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumHelmet>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 12)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumHeadgear>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 12)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumHeadpiece>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 12)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumChainmail>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 24)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumGreaves>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 18)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumDrill>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 18)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumPickaxe>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 18)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumSword>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 12)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumChainsaw>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 12)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumWaraxe>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 12)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumGlaive>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 12)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumRepeater>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 12)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<OrichythrilBlowpipe>())
            .AddIngredient(ItemID.MythrilBar, 8)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<MythrilSplitknife>(), 65)
            .AddIngredient(ItemID.MythrilBar)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<OrichythrilBlowpipe>())
            .AddIngredient(ItemID.OrichalcumBar, 8)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<OrichalcumSplitblade>(), 65)
            .AddIngredient(ItemID.OrichalcumBar)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahBar>())
            .AddIngredient(ModContent.ItemType<NaquadahOre>(), 4)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahHeadguard>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahHood>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahMask>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahBreastplate>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 24)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahShinguards>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 18)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahDrill>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 18)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahPickaxe>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 18)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahChainsaw>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahGreataxe>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahRepeater>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahSword>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahTrident>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahAnvil>())
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 10)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumForge>())
            .AddIngredient(ModContent.ItemType<TroxiniumOre>(), 30)
            .AddIngredient(ItemID.Hellforge)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumBar>())
            .AddIngredient(ModContent.ItemType<TroxiniumOre>(), 5)
            .AddTile(TileID.AdamantiteForge).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumHeadpiece>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumHelmet>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumHat>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumBodyarmor>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 24)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumCuisses>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 18)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumDrill>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 18)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumPickaxe>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 18)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumChainsaw>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumWaraxe>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumSpear>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumSword>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumRepeater>())
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<HallowedCrown>())
            .AddIngredient(ItemID.HallowedBar, 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<HeavensTear>())
            .AddIngredient(ItemID.HallowedBar, 13)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<HallowedThorn>())
            .AddIngredient(ItemID.HallowedBar, 8)
            .AddIngredient(ItemID.SoulofFright, 15)
            .AddIngredient(ItemID.LightShard, 3)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TheBanhammer>())
            .AddIngredient(ItemID.Pwnhammer)
            .AddIngredient(ItemID.HallowedBar, 35)
            .AddIngredient(ItemID.SoulofMight, 10)
            .AddIngredient(ModContent.ItemType<SoulofBlight>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<HallowedGreatsword>())
            .AddIngredient(ItemID.HallowedBar, 35)
            .AddIngredient(ItemID.SoulofMight, 20)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<HallowedBlowpipe>())
            .AddIngredient(ItemID.HallowedBar, 13)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<HallowedKunai>(), 50)
            .AddIngredient(ItemID.HallowedBar)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<SunlightKunai>(), 50)
            .AddIngredient(ItemID.BeetleHusk, 5)
            .AddIngredient(ModContent.ItemType<LifeDew>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<CaesiumForge>())
            .AddIngredient(ItemID.AdamantiteForge)
            .AddIngredient(ModContent.ItemType<CaesiumOre>(), 40)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<CaesiumForge>())
            .AddIngredient(ItemID.TitaniumForge)
            .AddIngredient(ModContent.ItemType<CaesiumOre>(), 40)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<CaesiumForge>())
            .AddIngredient(ModContent.ItemType<TroxiniumForge>())
            .AddIngredient(ModContent.ItemType<CaesiumOre>(), 40)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<CaesiumHeadpiece>())
            .AddIngredient(ModContent.ItemType<CaesiumBar>(), 30)
            .AddIngredient(ItemID.HellstoneBar, 10)
            .AddIngredient(ItemID.SoulofSight, 5)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<CaesiumPlateMail>())
            .AddIngredient(ModContent.ItemType<CaesiumBar>(), 40)
            .AddIngredient(ItemID.HellstoneBar, 12)
            .AddIngredient(ItemID.SoulofMight, 5)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<CaesiumGreaves>())
            .AddIngredient(ModContent.ItemType<CaesiumBar>(), 28)
            .AddIngredient(ItemID.HellstoneBar, 9)
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<SolariumAnvil>())
            .AddIngredient(ModContent.ItemType<SolariumStar>(), 16)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 2)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<BlastShard>())
            .AddIngredient(ModContent.ItemType<FireShard>(), 2)
            .AddIngredient(ItemID.LivingFireBlock, 10)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<FrigidShard>())
            .AddIngredient(ModContent.ItemType<FrostShard>(), 2)
            .AddIngredient(ModContent.ItemType<SoulofIce>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<VenomShard>())
            .AddIngredient(ModContent.ItemType<ToxinShard>(), 2)
            .AddIngredient(ItemID.Stinger)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<CoreShard>())
            .AddIngredient(ModContent.ItemType<EarthShard>(), 2)
            .AddIngredient(ItemID.DirtBlock, 10)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TornadoShard>())
            .AddIngredient(ModContent.ItemType<BreezeShard>(), 2)
            .AddIngredient(ItemID.SoulofFlight)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<DemonicShard>())
            .AddIngredient(ModContent.ItemType<UndeadShard>(), 2)
            .AddIngredient(ModContent.ItemType<RottenFlesh>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<WickedShard>())
            .AddIngredient(ModContent.ItemType<CorruptShard>(), 2)
            .AddIngredient(ItemID.SoulofNight, 2)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<SacredShard>())
            .AddIngredient(ModContent.ItemType<ArcaneShard>(), 2)
            .AddIngredient(ItemID.SoulofLight, 2)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<ElementShard>(), 10)
            .AddIngredient(ModContent.ItemType<BlastShard>(), 3)
            .AddIngredient(ModContent.ItemType<TornadoShard>(), 3)
            .AddIngredient(ModContent.ItemType<VenomShard>(), 3)
            .AddIngredient(ModContent.ItemType<WickedShard>(), 3)
            .AddIngredient(ModContent.ItemType<SacredShard>(), 3)
            .AddIngredient(ModContent.ItemType<CoreShard>(), 3)
            .AddIngredient(ModContent.ItemType<TorrentShard>(), 3)
            .AddIngredient(ModContent.ItemType<DemonicShard>(), 3)
            .AddIngredient(ModContent.ItemType<FrigidShard>(), 3)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ItemID.LihzahrdPowerCell)
            .AddIngredient(ModContent.ItemType<SolariumStar>(), 5)
            .AddIngredient(ItemID.LihzahrdBrick, 10)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<FeroziumBar>())
            .AddIngredient(ModContent.ItemType<FeroziumOre>(), 6)
            .AddTile(TileID.AdamantiteForge).Register();

        mod.CreateRecipe(ModContent.ItemType<FeroziumArrow>(), 70)
            .AddIngredient(ModContent.ItemType<FeroziumBar>())
            .AddIngredient(ItemID.WoodenArrow, 70)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<FeroziumBullet>(), 70)
            .AddIngredient(ModContent.ItemType<FeroziumBar>())
            .AddIngredient(ItemID.MusketBall, 70)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<FeroziumPickaxe>())
            .AddIngredient(ModContent.ItemType<FeroziumBar>(), 16)
            .AddIngredient(ModContent.ItemType<FrigidShard>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<FeroziumIceSword>())
            .AddIngredient(ModContent.ItemType<FeroziumBar>(), 18)
            .AddIngredient(ModContent.ItemType<FrigidShard>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<FeroziumWaraxe>())
            .AddIngredient(ModContent.ItemType<FeroziumBar>(), 17)
            .AddIngredient(ModContent.ItemType<FrigidShard>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<SpectreHeadgear>())
            .AddIngredient(ItemID.Ectoplasm, 12)
            .AddIngredient(ItemID.ChlorophyteBar, 12)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ItemID.ShroomiteBar)
            .AddIngredient(ModContent.ItemType<ShroomiteOre>(), 5)
            .AddTile(TileID.AdamantiteForge).Register();

        mod.CreateRecipe(ModContent.ItemType<ShadowRing>())
            .AddIngredient(ItemID.ShroomiteBar, 5)
            .AddIngredient(ModContent.ItemType<Onyx>(), 2)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TacticalExpulsor>())
            .AddIngredient(ItemID.TacticalShotgun, 2)
            .AddIngredient(ItemID.Ectoplasm, 50)
            .AddIngredient(ItemID.ShroomiteBar, 30)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<SolariumStar>())
            .AddIngredient(ModContent.ItemType<SolariumOre>(), 2)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<SolarFlaresword>())
            .AddIngredient(ModContent.ItemType<SolariumStar>(), 33)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<SolarFlareBow>())
            .AddIngredient(ModContent.ItemType<SolariumStar>(), 21)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<SolariumStaff>())
            .AddIngredient(ModContent.ItemType<SolariumStar>(), 40)
            .AddIngredient(ModContent.ItemType<FeroziumBar>(), 7)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<KnivesoftheCorruptor>())
            .AddIngredient(ItemID.VampireKnives)
            .AddIngredient(ItemID.ScourgeoftheCorruptor)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 30)
            .AddIngredient(ModContent.ItemType<IllegalWeaponInstructions>())
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<TheGoldenFlames>())
            .AddIngredient(ItemID.HallowedBar, 35)
            .AddIngredient(ItemID.SpellTome)
            .AddIngredient(ItemID.SoulofLight, 20)
            .AddIngredient(ItemID.Fireblossom, 5)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<PlanterasFury>())
            .AddIngredient(ItemID.VenusMagnum)
            .AddIngredient(ItemID.Uzi)
            .AddIngredient(ItemID.IllegalGunParts)
            .AddIngredient(ModContent.ItemType<LifeDew>(), 50)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 10)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<Boomlash>())
            .AddIngredient(ItemID.MagicMissile)
            .AddIngredient(ItemID.Bomb, 10)
            .AddIngredient(ItemID.SoulofMight, 20)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<MagicGrenade>())
            .AddIngredient(ItemID.MagicDagger)
            .AddIngredient(ItemID.Grenade, 10)
            .AddIngredient(ItemID.SoulofFright, 20)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<IceGel>(), 2)
            .AddIngredient(ItemID.Gel, 5)
            .AddIngredient(ItemID.IceBlock, 2)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CobaltShieldMarkII>())
            .AddIngredient(ItemID.CobaltBar, 15)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<PalladiumShield>())
            .AddIngredient(ItemID.PalladiumBar, 15)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumShield>())
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 15)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<CobaltOmegaShield>())
            .AddIngredient(ModContent.ItemType<CobaltShieldMarkII>())
            .AddIngredient(ModContent.ItemType<PalladiumShield>())
            .AddIngredient(ModContent.ItemType<DurataniumShield>())
            .AddIngredient(ItemID.SoulofMight, 5)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<PalladiumOmegaShield>())
            .AddIngredient(ModContent.ItemType<CobaltShieldMarkII>())
            .AddIngredient(ModContent.ItemType<PalladiumShield>())
            .AddIngredient(ModContent.ItemType<DurataniumShield>())
            .AddIngredient(ItemID.SoulofSight, 5)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumOmegaShield>())
            .AddIngredient(ModContent.ItemType<CobaltShieldMarkII>())
            .AddIngredient(ModContent.ItemType<PalladiumShield>())
            .AddIngredient(ModContent.ItemType<DurataniumShield>())
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<PrimeStaff>())
            .AddIngredient(ItemID.Bone, 50)
            .AddIngredient(ItemID.HallowedBar, 12)
            .AddIngredient(ItemID.SoulofFright, 20)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<SandBomb>(), 2)
            .AddIngredient(ItemID.Bomb, 2)
            .AddIngredient(ItemID.SandBlock, 30)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<EbonsandBomb>(), 2)
            .AddIngredient(ItemID.Bomb, 2)
            .AddIngredient(ItemID.EbonsandBlock, 30)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<CrimsandBomb>(), 2)
            .AddIngredient(ItemID.Bomb, 2)
            .AddIngredient(ItemID.CrimsandBlock, 30)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<PearlsandBomb>(), 2)
            .AddIngredient(ItemID.Bomb, 2)
            .AddIngredient(ItemID.PearlsandBlock, 30)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<SnotsandBomb>(), 2)
            .AddIngredient(ItemID.Bomb, 2)
            .AddIngredient(ModContent.ItemType<SnotsandBlock>(), 30)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ItemID.Cannonball)
            .AddIngredient(ItemID.Bomb, 5)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<PurityBomb>())
            .AddIngredient(ItemID.GreenSolution, 15)
            .AddIngredient(ItemID.StoneBlock, 50)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 2)
            .AddIngredient(ItemID.Explosives)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<CorruptionBomb>())
            .AddIngredient(ItemID.PurpleSolution, 15)
            .AddIngredient(ItemID.EbonstoneBlock, 50)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 2)
            .AddIngredient(ItemID.Explosives)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<JungleBomb>())
            .AddIngredient(ModContent.ItemType<LimeGreenSolution>(), 15)
            .AddIngredient(ItemID.MudBlock, 50)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 2)
            .AddIngredient(ItemID.Explosives)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<CrimsonBomb>())
            .AddIngredient(ItemID.RedSolution, 15)
            .AddIngredient(ItemID.CrimstoneBlock, 50)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 2)
            .AddIngredient(ItemID.Explosives)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<ContagionBomb>())
            .AddIngredient(ModContent.ItemType<YellowSolution>(), 15)
            .AddIngredient(ModContent.ItemType<ChunkstoneBlock>(), 50)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 2)
            .AddIngredient(ItemID.Explosives)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<MushroomBomb>())
            .AddIngredient(ItemID.DarkBlueSolution, 15)
            .AddIngredient(ItemID.MudBlock, 50)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 2)
            .AddIngredient(ItemID.Explosives)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<HallowBomb>())
            .AddIngredient(ItemID.BlueSolution, 15)
            .AddIngredient(ItemID.PearlstoneBlock, 50)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 2)
            .AddIngredient(ItemID.Explosives)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<StickyCharm>())
            .AddIngredient(ItemID.RoyalGel)
            .AddIngredient(ModContent.ItemType<BandofSlime>())
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<SouloftheGolem>())
            .AddIngredient(ModContent.ItemType<EtherealHeart>())
            .AddIngredient(ModContent.ItemType<HeartoftheGolem>())
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<SandyStormcloudinaBottle>())
            .AddIngredient(ItemID.CloudinaBottle)
            .AddIngredient(ItemID.BlizzardinaBottle)
            .AddIngredient(ItemID.SandstorminaBottle)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ItemID.BundleofBalloons)
            .AddIngredient(ModContent.ItemType<SandyStormcloudinaBottle>())
            .AddIngredient(ItemID.ShinyRedBalloon, 3)
            .AddTile(TileID.TinkerersWorkbench).Register();


        mod.CreateRecipe(ModContent.ItemType<CloakofAssists>())
            .AddIngredient(ItemID.StarCloak)
            .AddIngredient(ItemID.PanicNecklace)
            .AddIngredient(ItemID.HoneyComb)
            .AddIngredient(ModContent.ItemType<LightninginaBottle>())
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<CloakofAssists>())
            .AddIngredient(ItemID.StarCloak)
            .AddIngredient(ItemID.SweetheartNecklace)
            .AddIngredient(ModContent.ItemType<LightninginaBottle>())
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<CloakofAssists>())
            .AddIngredient(ItemID.BeeCloak)
            .AddIngredient(ItemID.PanicNecklace)
            .AddIngredient(ModContent.ItemType<LightninginaBottle>())
            .AddTile(TileID.TinkerersWorkbench).Register();

        // vanilla items

        // end vanilla items

        mod.CreateRecipe(ModContent.ItemType<NaturesEndowment>())
            .AddIngredient(ItemID.NaturesGift, 4)
            .AddIngredient(ItemID.JungleRose)
            .AddIngredient(ModContent.ItemType<ArcaneShard>(), 2)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<GiftofStarpower>())
            .AddIngredient(ItemID.ManaFlower)
            .AddIngredient(ItemID.BandofStarpower, 2)
            .AddIngredient(ModContent.ItemType<NaturesEndowment>())
            .AddIngredient(ItemID.SorcererEmblem)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<ForsakenCross>())
            .AddIngredient(ModContent.ItemType<ForsakenRelic>())
            .AddIngredient(ItemID.CrossNecklace)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<ChaosEye>())
            .AddIngredient(ModContent.ItemType<ChaosCharm>())
            .AddIngredient(ItemID.EyeoftheGolem)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<FlareStone>())
            .AddIngredient(ItemID.ObsidianSkull)
            .AddIngredient(ItemID.ObsidianRose)
            .AddIngredient(ItemID.MagmaStone)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<TitanShield>())
            .AddIngredient(ModContent.ItemType<AegisofAges>())
            .AddIngredient(ItemID.PaladinsShield)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<ShadowMirror>())
            .AddIngredient(ItemID.CellPhone)
            .AddIngredient(ItemID.MagicConch)
            .AddIngredient(ItemID.DemonConch)
            .AddIngredient(ItemID.FallenStar, 40)
            .AddIngredient(ItemID.Diamond, 20)
            .AddIngredient(ItemID.ChlorophyteBar, 7)
            .AddIngredient(ItemID.Ectoplasm, 10)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<ApollosQuiver>())
            .AddIngredient(ItemID.DestroyerEmblem)
            .AddIngredient(ItemID.MagicQuiver)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<CrystalEdge>())
            .AddIngredient(ItemID.CrystalShard, 50)
            .AddIngredient(ItemID.SoulofMight, 10)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<ChaosEmblem>())
            .AddIngredient(ModContent.ItemType<ChaosCrystal>())
            .AddIngredient(ItemID.AvengerEmblem)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<ReflexCharm>())
            .AddIngredient(ItemID.CobaltShield)
            .AddIngredient(ItemID.SoulofSight, 8)
            .AddIngredient(ItemID.LightShard, 3)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<NuclearExtinguisher>())
            .AddIngredient(ModContent.ItemType<GreekExtinguisher>())
            .AddIngredient(ModContent.ItemType<SixHundredWattLightbulb>())
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<DullingTalisman>())
            .AddIngredient(ItemID.Shackle, 6)
            .AddIngredient(ItemID.BandofRegeneration)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<AngerTalisman>())
            .AddIngredient(ItemID.AvengerEmblem)
            .AddIngredient(ItemID.Cobweb, 30)
            .AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5)
            .AddIngredient(ItemID.SilverOre, 5)
            .AddIngredient(ItemID.SoulofFright, 15)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<AngerTalisman>())
            .AddIngredient(ItemID.AvengerEmblem)
            .AddIngredient(ItemID.Cobweb, 30)
            .AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5)
            .AddIngredient(ItemID.TungstenOre, 5)
            .AddIngredient(ItemID.SoulofFright, 15)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<AngerTalisman>())
            .AddIngredient(ItemID.AvengerEmblem)
            .AddIngredient(ItemID.Cobweb, 30)
            .AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 5)
            .AddIngredient(ModContent.ItemType<ZincOre>(), 5)
            .AddIngredient(ItemID.SoulofFright, 15)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<GoblinToolbelt>())
            .AddIngredient(ItemID.Toolbelt)
            .AddIngredient(ItemID.GPS)
            .AddIngredient(ItemID.GoldCoin)
            .AddIngredient(ItemID.TinkerersWorkshop)
            .AddTile(TileID.MythrilAnvil).Register();

        

        mod.CreateRecipe(ModContent.ItemType<BuildersToolbelt>())
            .AddIngredient(ModContent.ItemType<GoblinToolbelt>())
            .AddIngredient(ItemID.PortableCementMixer)
            .AddIngredient(ItemID.BrickLayer)
            .AddIngredient(ItemID.ExtendoGrip)
            .AddIngredient(ItemID.FlyingCarpet)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<TitanGauntlets>())
            .AddIngredient(ModContent.ItemType<TitanShield>())
            .AddIngredient(ModContent.ItemType<FrostGauntlet>())
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<SandCastle>())
            .AddIngredient(ItemID.SandBlock, 50)
            .AddIngredient(ItemID.SandstoneBrick, 5)
            .AddTile(TileID.Anvils).Register();


        mod.CreateRecipe(ModContent.ItemType<FrostGauntlet>())
            .AddIngredient(ItemID.FireGauntlet)
            .AddIngredient(ItemID.FrozenTurtleShell)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<TerraClaws>())
            .AddIngredient(ItemID.FireGauntlet)
            .AddIngredient(ItemID.Ichor, 20)
            .AddIngredient(ItemID.CursedFlame, 20)
            .AddIngredient(ItemID.SpiderFang, 20)
            .AddIngredient(ItemID.Stinger, 20)
            .AddIngredient(ModContent.ItemType<FrostShard>(), 20)
            .AddIngredient(ModContent.ItemType<Pathogen>(), 20)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 5)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<HadesCross>())
            .AddIngredient(ItemID.LavaWaders)
            .AddIngredient(ItemID.Hellstone, 20)
            .AddIngredient(ItemID.LavaBucket)
            .AddIngredient(ItemID.SoulofFright, 6)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<BestialBand>())
            .AddIngredient(ItemID.CelestialShell)
            .AddIngredient(ModContent.ItemType<HadesCross>())
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<SonicScrewdriverMkI>())
            .AddIngredient(ItemID.Ruby, 10)
            .AddIngredient(ItemID.MeteoriteBar, 5)
            .AddIngredient(ItemID.Wire, 30)
            .AddIngredient(ItemID.HunterPotion, 3)
            .AddIngredient(ItemID.SpelunkerPotion, 3)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<SonicScrewdriverMkII>())
            .AddIngredient(ModContent.ItemType<SonicScrewdriverMkI>())
            .AddIngredient(ItemID.Sapphire, 7)
            .AddIngredient(ItemID.Wire, 10)
            .AddIngredient(ItemID.GPS)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<SonicScrewdriverMkIII>())
            .AddIngredient(ModContent.ItemType<SonicScrewdriverMkII>())
            .AddIngredient(ItemID.Emerald, 10)
            .AddIngredient(ItemID.Wire, 20)
            .AddIngredient(ItemID.SoulofMight, 5)
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddIngredient(ItemID.SoulofSight, 5)
            .AddIngredient(ModContent.ItemType<Onyx>(), 10)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<QuadWhip>())
            .AddIngredient(ItemID.DualHook)
            .AddIngredient(ItemID.IvyWhip)
            .AddIngredient(ItemID.Chain, 2)
            .AddIngredient(ItemID.Hook, 2)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<OxygenTank>())
            .AddIngredient(ModContent.ItemType<LifeDew>(), 5)
            .AddIngredient(ItemID.ChlorophyteBar, 20)
            .AddIngredient(ItemID.GillsPotion, 2)
            .AddTile(TileID.TinkerersWorkbench).Register();

        mod.CreateRecipe(ModContent.ItemType<CursedFlamelash>())
            .AddIngredient(ItemID.Flamelash)
            .AddIngredient(ItemID.CursedFlame, 99)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<PathogenMist>())
            .AddIngredient(ItemID.SpellTome)
            .AddIngredient(ModContent.ItemType<Pathogen>(), 30)
            .AddIngredient(ItemID.SoulofNight, 15)
            .AddTile(TileID.Bookcases).Register();

        mod.CreateRecipe(ModContent.ItemType<LensApparatus>())
            .AddIngredient(ItemID.Lens, 20)
            .AddIngredient(ModContent.ItemType<BloodshotLens>(), 10)
            .AddIngredient(ItemID.BlackLens)
            .AddTile(TileID.Bookcases).Register();

        mod.CreateRecipe(ModContent.ItemType<DevilsScythe>())
            .AddIngredient(ItemID.DemonScythe)
            .AddIngredient(ItemID.Fireblossom, 20)
            .AddIngredient(ItemID.LivingFireBlock, 100)
            .AddIngredient(ItemID.SoulofFright, 7)
            .AddTile(TileID.Bookcases).Register();

        mod.CreateRecipe(ModContent.ItemType<FocusBeam>())
            .AddIngredient(ItemID.SpellTome)
            .AddIngredient(ItemID.SoulofMight, 20)
            .AddIngredient(ModContent.ItemType<Tourmaline>(), 15)
            .AddIngredient(ModContent.ItemType<LensApparatus>())
            .AddTile(TileID.Bookcases).Register();

        mod.CreateRecipe(ModContent.ItemType<GigaHorn>())
            .AddIngredient(ModContent.ItemType<BrokenVigilanteTome>())
            .AddIngredient(ItemID.SoulofMight, 15)
            .AddIngredient(ModContent.ItemType<Onyx>(), 20)
            .AddTile(TileID.Bookcases).Register();

        mod.CreateRecipe(ModContent.ItemType<FreezeBolt>())
            .AddIngredient(ModContent.ItemType<SoulofIce>(), 20)
            .AddIngredient(ItemID.WaterBolt)
            .AddIngredient(ModContent.ItemType<IceGel>(), 50)
            .AddIngredient(ItemID.FrostCore, 2)
            .AddTile(TileID.Bookcases).Register();

        //replaceme11111
        //.AddIngredient(ItemID.SpellTome)
        //.AddIngredient(ItemID.Emerald, 15)
        //.AddIngredient(ItemID.SoulofSight, 7)
        //.AddIngredient(ItemID.Lens, 3)
        //.AddTile(TileID.Bookcases)
        //.SetResult(ModContent.ItemType<Items.Venoshock>())
        //.AddRecipe()

        mod.CreateRecipe(ModContent.ItemType<MusicBoxEssence>())
            .AddIngredient(ItemID.MusicBoxTitle)
            .AddIngredient(ItemID.MusicBoxSnow)
            .AddIngredient(ItemID.MusicBoxDesert)
            .AddIngredient(ItemID.MusicBoxSpace)
            .AddIngredient(ItemID.MusicBoxCrimson)
            .AddIngredient(ItemID.MusicBoxDungeon)
            .AddIngredient(ItemID.MusicBoxPlantera)
            .AddIngredient(ItemID.MusicBoxTemple)
            .AddIngredient(ItemID.MusicBoxEclipse)
            .AddIngredient(ItemID.MusicBoxPumpkinMoon)
            .AddIngredient(ItemID.MusicBoxFrostMoon)
            .AddTile(TileID.Bookcases).Register();

        mod.CreateRecipe(ModContent.ItemType<Jukebox>())
            .AddIngredient(ItemID.MusicBox, 2)
            .AddIngredient(ItemID.PixieDust, 20)
            .AddIngredient(ItemID.SoulofFlight, 10)
            .AddIngredient(ModContent.ItemType<MusicBoxEssence>())
            .AddTile(TileID.Bookcases).Register();

        mod.CreateRecipe(ModContent.ItemType<Heartstone>(), 45)
            .AddIngredient(ItemID.LifeCrystal)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ItemID.LifeCrystal)
            .AddIngredient(ModContent.ItemType<Heartstone>(), 45)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<Lifestone>(), 30)
            .AddIngredient(ItemID.LifeFruit)
            .AddTile(TileID.AdamantiteForge).Register();

        mod.CreateRecipe(ItemID.LifeFruit)
            .AddIngredient(ModContent.ItemType<Lifestone>(), 30)
            .AddTile(TileID.AdamantiteForge).Register();

        mod.CreateRecipe(ModContent.ItemType<Shurikerang>())
            .AddIngredient(ItemID.EnchantedBoomerang)
            .AddIngredient(ItemID.Shuriken, 50)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ItemID.EnchantedBoomerang)
            .AddIngredient(ModContent.ItemType<EnchantedBar>(), 12)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<EnchantedShuriken>(), 25)
            .AddIngredient(ModContent.ItemType<EnchantedBar>())
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ItemID.EnchantedSword)
            .AddIngredient(ModContent.ItemType<EnchantedBar>(), 20)
            .AddIngredient(ModContent.ItemType<BrokenHiltPiece>(), 5)
            .AddTile(TileID.Anvils).Register();


        mod.CreateRecipe(ModContent.ItemType<CompressedExtractBlock>())
            .AddIngredient(ItemID.SiltBlock, 100)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<CompressedExtractBlock>())
            .AddIngredient(ItemID.SlushBlock, 100)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<BacterialTotem>())
            .AddIngredient(ModContent.ItemType<YuckyBit>(), 15)
            .AddIngredient(ModContent.ItemType<VirulentPowder>(), 30)
            .AddTile(TileID.DemonAltar).Register();

        mod.CreateRecipe(ModContent.ItemType<TheBeak>())
            .AddIngredient(ModContent.ItemType<Beak>(), 6)
            .AddIngredient(ItemID.SandBlock, 30)
            .AddTile(TileID.DemonAltar).Register();

        mod.CreateRecipe(ModContent.ItemType<HornetFood>())
            .AddIngredient(ModContent.ItemType<ToxinShard>(), 30)
            .AddIngredient(ItemID.Stinger, 15)
            .AddTile(TileID.DemonAltar).Register();

        mod.CreateRecipe(ItemID.MechanicalWorm)
            .AddIngredient(ModContent.ItemType<YuckyBit>(), 6)
            .AddRecipeGroup("IronBar", 5)
            .AddIngredient(ItemID.SoulofNight, 6)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<OddFertilizer>())
            .AddIngredient(ModContent.ItemType<LifeDew>(), 5)
            .AddIngredient(ItemID.Stinger, 15)
            .AddIngredient(ItemID.JungleSpores, 15)
            .AddIngredient(ItemID.SoulofMight, 5)
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ItemID.PirateMap)
            .AddIngredient(ItemID.SoulofFright, 5)
            .AddIngredient(ItemID.Coral, 15)
            .AddIngredient(ItemID.SharkFin)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<TimechangerMkII>())
            .AddIngredient(ModContent.ItemType<SoulofTime>(), 40)
            .AddIngredient(ModContent.ItemType<SoulofBlight>())
            .AddIngredient(ModContent.ItemType<Timechanger>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<Moonphaser>())
            .AddIngredient(ItemID.Lens, 5)
            .AddIngredient(ItemID.SoulofLight, 10)
            .AddIngredient(ItemID.SoulofNight, 10)
            .AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 20)
            .AddIngredient(ItemID.BlackLens)
            .AddIngredient(ModContent.ItemType<BloodshotLens>(), 4)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<OblivionBrick>())
            .AddIngredient(ItemID.StoneBlock)
            .AddIngredient(ModContent.ItemType<OblivionOre>())
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<ImperviousBrick>(), 5)
            .AddIngredient(ItemID.SoulofMight)
            .AddIngredient(ItemID.BlueBrick, 5)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<ImperviousBrick>(), 5)
            .AddIngredient(ItemID.SoulofMight)
            .AddIngredient(ItemID.PinkBrick, 5)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<ImperviousBrick>(), 5)
            .AddIngredient(ItemID.SoulofMight)
            .AddIngredient(ItemID.GreenBrick, 5)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<ImperviousBrick>(), 5)
            .AddIngredient(ItemID.SoulofMight)
            .AddIngredient(ModContent.ItemType<OrangeBrick>(), 5)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<PyroscoricBrick>(), 3)
            .AddIngredient(ModContent.ItemType<PyroscoricOre>())
            .AddIngredient(ItemID.StoneBlock, 3)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<PyroscoricBar>())
            .AddIngredient(ModContent.ItemType<PyroscoricOre>(), 5)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<PyroscoricLongsword>())
            .AddIngredient(ModContent.ItemType<PyroscoricBar>(), 20)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<PyroscoricPickaxe>())
            .AddIngredient(ModContent.ItemType<PyroscoricBar>(), 25)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<PyroscoricBullet>(), 70)
            .AddIngredient(ModContent.ItemType<PyroscoricBar>())
            .AddIngredient(ItemID.MusketBall, 70)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<TritanoriumBar>())
            .AddIngredient(ModContent.ItemType<TritanoriumOre>(), 5)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<TritanoriumBroadsword>())
            .AddIngredient(ModContent.ItemType<TritanoriumBar>(), 35)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<TritanoriumPickaxe>())
            .AddIngredient(ModContent.ItemType<TritanoriumBar>(), 25)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<TritonBullet>(), 70)
            .AddIngredient(ModContent.ItemType<TritanoriumBar>())
            .AddIngredient(ItemID.MusketBall, 70)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<UnvolanditeBar>())
            .AddIngredient(ModContent.ItemType<UnvolanditeOre>(), 6)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<UnvolanditeGreatsword>())
            .AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 24)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<UnvolanditeKunziteWaveStaff>())
            .AddIngredient(ModContent.ItemType<SolariumStaff>())
            .AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 15)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 9)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<UnvolanditeFusebow>())
            .AddIngredient(ItemID.PulseBow)
            .AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 13)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 5)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<UnvolanditeHeadpiece>())
            .AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 40)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 17)
            .AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<UnvolanditeBodyplate>())
            .AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 46)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 10)
            .AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 3)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<UnvolanditeLeggings>())
            .AddIngredient(ModContent.ItemType<UnvolanditeBar>(), 32)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 8)
            .AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<VorazylcumBar>())
            .AddIngredient(ModContent.ItemType<VorazylcumOre>(), 5)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<VoraylzumKatana>())
            .AddIngredient(ModContent.ItemType<VorazylcumBar>(), 22)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<VorazylcumKunziteBoltStaff>())
            .AddIngredient(ModContent.ItemType<SolariumStaff>())
            .AddIngredient(ModContent.ItemType<VorazylcumBar>(), 15)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 9)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<VorazylcumFusebow>())
            .AddIngredient(ItemID.PulseBow)
            .AddIngredient(ModContent.ItemType<VorazylcumBar>(), 13)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 5)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<VorazylcumHeadpiece>())
            .AddIngredient(ModContent.ItemType<VorazylcumBar>(), 40)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 17)
            .AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 3)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<VorazylcumBodyplate>())
            .AddIngredient(ModContent.ItemType<VorazylcumBar>(), 46)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 10)
            .AddIngredient(ModContent.ItemType<SpikedBlastShell>(), 4)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<VorazylcumLeggings>())
            .AddIngredient(ModContent.ItemType<VorazylcumBar>(), 32)
            .AddIngredient(ModContent.ItemType<Kunzite>(), 8)
            .AddIngredient(ModContent.ItemType<SpikedBlastShell>())
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<Elektriwave>())
            .AddIngredient(ModContent.ItemType<Phantoplasm>(), 30)
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 30)
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 20)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();


        mod.CreateRecipe(ModContent.ItemType<Electrobullet>(), 200)
            .AddIngredient(ItemID.MusketBall, 200)
            .AddIngredient(ModContent.ItemType<Phantoplasm>())
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BlahsHelmet>())
            .AddIngredient(ModContent.ItemType<Phantoplasm>(), 30)
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 30)
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 15)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BlahsBodyarmor>())
            .AddIngredient(ModContent.ItemType<Phantoplasm>(), 35)
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 35)
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 20)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BlahsCuisses>())
            .AddIngredient(ModContent.ItemType<Phantoplasm>(), 30)
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 25)
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 17)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BlahsPicksaw>())
            .AddIngredient(ModContent.ItemType<Phantoplasm>(), 50)
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 25)
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 25)
            .AddIngredient(ModContent.ItemType<InstantaniumPicksaw>())
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BlahsWarhammer>())
            .AddIngredient(ModContent.ItemType<Phantoplasm>(), 25)
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 25)
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 25)
            .AddIngredient(ModContent.ItemType<TheBanhammer>())
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();


        mod.CreateRecipe(ModContent.ItemType<SoulEdge>())
            .AddIngredient(ItemID.TerraBlade)
            .AddIngredient(ItemID.SpectreStaff)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 40)
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 5)
            .AddIngredient(ItemID.Ectoplasm, 60)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<OblivionGlaive>())
            .AddIngredient(ModContent.ItemType<OblivionBar>(), 30)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 10)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<Oblivirod>())
            .AddIngredient(ModContent.ItemType<OblivionBar>(), 10)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<OpalStaff>())
            .AddIngredient(ModContent.ItemType<Opal>(), 40)
            .AddIngredient(ModContent.ItemType<OblivionBar>(), 10)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<OnyxStaff>())
            .AddIngredient(ModContent.ItemType<Onyx>(), 25)
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 10)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BerserkerArrow>(), 100)
            .AddIngredient(ItemID.ChlorophyteArrow, 75)
            .AddIngredient(ItemID.HolyArrow, 75)
            .AddIngredient(ModContent.ItemType<LifeDew>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<BerserkerBullet>(), 100)
            .AddIngredient(ItemID.ChlorophyteBullet, 75)
            .AddIngredient(ItemID.CrystalBullet, 75)
            .AddIngredient(ModContent.ItemType<LifeDew>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<CaesiumBar>())
            .AddIngredient(ModContent.ItemType<CaesiumOre>(), 5)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<CaesiumRepeater>())
            .AddIngredient(ModContent.ItemType<CaesiumBar>(), 18)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<CaesiumScimitar>())
            .AddIngredient(ModContent.ItemType<CaesiumBar>(), 18)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<ElementalRod>())
            .AddIngredient(ModContent.ItemType<CaesiumBar>(), 30)
            .AddIngredient(ModContent.ItemType<ElementShard>(), 20)
            .AddIngredient(ItemID.Flamelash)
            .AddIngredient(ItemID.MagicMissile)
            .AddIngredient(ItemID.DirtRod)
            .AddIngredient(ItemID.RainbowRod)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<OblivionBar>())
            .AddIngredient(ModContent.ItemType<OblivionOre>(), 7)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();


        mod.CreateRecipe(ModContent.ItemType<AwakenedRoseCrown>())
            .AddIngredient(ModContent.ItemType<SoulofHumidity>(), 20)
            .AddIngredient(ModContent.ItemType<DarkMatterGel>(), 60)
            .AddIngredient(ModContent.ItemType<AncientHeadpiece>())
            .AddIngredient(ModContent.ItemType<LifeDew>(), 15)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AwakenedRosePlateMail>())
            .AddIngredient(ModContent.ItemType<SoulofHumidity>(), 23)
            .AddIngredient(ModContent.ItemType<DarkMatterGel>(), 65)
            .AddIngredient(ModContent.ItemType<AncientBodyplate>())
            .AddIngredient(ModContent.ItemType<LifeDew>(), 15)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AwakenedRoseSubligar>())
            .AddIngredient(ModContent.ItemType<SoulofHumidity>(), 17)
            .AddIngredient(ModContent.ItemType<DarkMatterGel>(), 70)
            .AddIngredient(ModContent.ItemType<AncientLeggings>())
            .AddIngredient(ModContent.ItemType<LifeDew>(), 15)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();


        mod.CreateRecipe(ModContent.ItemType<HydrolythBar>())
            .AddIngredient(ModContent.ItemType<HydrolythOre>(), 5)
            .AddIngredient(ModContent.ItemType<SolariumOre>())
            .AddIngredient(ModContent.ItemType<FeroziumOre>())
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<MiloticCrown>())
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 20)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 3)
            .AddIngredient(ModContent.ItemType<DarkMatterGel>(), 60)
            .AddIngredient(ModContent.ItemType<AncientHeadpiece>())
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<MiloticSkinplate>())
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 23)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 4)
            .AddIngredient(ModContent.ItemType<DarkMatterGel>(), 75)
            .AddIngredient(ModContent.ItemType<AncientBodyplate>())
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<MiloticJodpurs>())
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 17)
            .AddIngredient(ModContent.ItemType<SoulofBlight>(), 3)
            .AddIngredient(ModContent.ItemType<DarkMatterGel>(), 70)
            .AddIngredient(ModContent.ItemType<AncientLeggings>())
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        #region Avalon Armor

        mod.CreateRecipe(ModContent.ItemType<AvalonHelmet>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<BerserkerHeadpiece>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonBodyarmor>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<BerserkerBodyarmor>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonCuisses>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<BerserkerCuisses>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonHelmet>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<AwakenedRoseCrown>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonBodyarmor>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<AwakenedRosePlateMail>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonCuisses>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<AwakenedRoseSubligar>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonHelmet>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<SpectrumHelmet>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonBodyarmor>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<SpectrumBreastplate>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonCuisses>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<SpectrumGreaves>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonHelmet>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<MiloticCrown>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonBodyarmor>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<MiloticSkinplate>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        mod.CreateRecipe(ModContent.ItemType<AvalonCuisses>())
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 50)
            .AddIngredient(ModContent.ItemType<VictoryPiece>())
            .AddIngredient(ModContent.ItemType<MiloticJodpurs>())
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 2)
            .AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();

        #endregion Avalon Armor

        mod.CreateRecipe(ModContent.ItemType<RedPhasecleaver>())
            .AddIngredient(ItemID.RedPhasesaber)
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 25)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<YellowPhasecleaver>())
            .AddIngredient(ItemID.YellowPhasesaber)
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 25)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<GreenPhasecleaver>())
            .AddIngredient(ItemID.GreenPhasesaber)
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 25)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BluePhasecleaver>())
            .AddIngredient(ItemID.BluePhasesaber)
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 25)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<PurplePhasecleaver>())
            .AddIngredient(ItemID.PurplePhasesaber)
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 25)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<WhitePhasecleaver>())
            .AddIngredient(ItemID.WhitePhasesaber)
            .AddIngredient(ModContent.ItemType<HydrolythBar>(), 25)
            .AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();

        mod.CreateRecipe(ModContent.ItemType<FieryBladeofGrass>())
            .AddIngredient(ItemID.BladeofGrass)
            .AddIngredient(ItemID.FieryGreatsword)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<HallowedAltar>())
            .AddIngredient(ItemID.HallowedBar, 10)
            .AddIngredient(ItemID.LightShard, 2)
            .AddIngredient(ModContent.ItemType<SacredShard>(), 2)
            .AddIngredient(ItemID.PixieDust, 20)
            .AddIngredient(ItemID.PearlstoneBlock, 20)
            .AddIngredient(ModContent.ItemType<SoulofBlight>())
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<DemonAltar>())
            .AddIngredient(ItemID.EbonstoneBlock, 50)
            .AddIngredient(ItemID.RottenChunk, 10)
            .AddIngredient(ItemID.Deathweed, 5)
            .AddIngredient(ItemID.SoulofNight, 20)
            .AddIngredient(ItemID.ShadowScale, 20)
            .AddIngredient(ItemID.DemoniteBar, 25)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<CrimsonAltar>())
            .AddIngredient(ItemID.CrimstoneBlock, 50)
            .AddIngredient(ItemID.Vertebrae, 10)
            .AddIngredient(ModContent.ItemType<Bloodberry>(), 5)
            .AddIngredient(ItemID.SoulofNight, 20)
            .AddIngredient(ItemID.TissueSample, 20)
            .AddIngredient(ItemID.CrimtaneBar, 25)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<IckyAltar>())
            .AddIngredient(ModContent.ItemType<ChunkstoneBlock>(), 50)
            .AddIngredient(ModContent.ItemType<YuckyBit>(), 10)
            .AddIngredient(ModContent.ItemType<Barfbush>(), 5)
            .AddIngredient(ItemID.SoulofNight, 20)
            .AddIngredient(ModContent.ItemType<Booger>(), 20)
            .AddIngredient(ModContent.ItemType<BacciliteBar>(), 25)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ItemID.BattlePotion)
            .AddIngredient(ItemID.BottledWater)
            .AddIngredient(ModContent.ItemType<Bloodberry>())
            .AddIngredient(ItemID.RottenChunk)
            .AddTile(TileID.Bottles).Register();

        mod.CreateRecipe(ItemID.BattlePotion)
            .AddIngredient(ItemID.BottledWater)
            .AddIngredient(ModContent.ItemType<Barfbush>())
            .AddIngredient(ModContent.ItemType<YuckyBit>())
            .AddTile(TileID.Bottles).Register();

        mod.CreateRecipe(ModContent.ItemType<Sporalash>())
            .AddIngredient(ItemID.JungleSpores, 15)
            .AddIngredient(ItemID.Stinger, 10)
            .AddIngredient(ItemID.Vine, 2)
            .AddIngredient(ModContent.ItemType<ToxinShard>(), 2)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ItemID.TurtleHelmet)
            .AddIngredient(ItemID.ChlorophyteMask)
            .AddIngredient(ItemID.TurtleShell)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ItemID.TurtleScaleMail)
            .AddIngredient(ItemID.ChlorophytePlateMail)
            .AddIngredient(ItemID.TurtleShell)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ItemID.TurtleLeggings)
            .AddIngredient(ItemID.ChlorophyteGreaves)
            .AddIngredient(ItemID.TurtleShell)
            .AddTile(TileID.MythrilAnvil).Register();

        mod.CreateRecipe(ModContent.ItemType<BeetleBar>())
            .AddIngredient(ItemID.BeetleHusk)
            .AddIngredient(ItemID.ChlorophyteBar, 3)
            .AddTile(TileID.Autohammer).Register();

        mod.CreateRecipe(ModContent.ItemType<SunsShadow>())
            .AddIngredient(ItemID.BeetleHusk, 8)
            .AddIngredient(ItemID.TurtleShell)
            .AddIngredient(ItemID.ChlorophyteBar, 3)
            .AddTile(TileID.MythrilAnvil).Register();

        // phm ore alts

        // bronze
        mod.CreateRecipe(ModContent.ItemType<BronzeBrick>())
            .AddIngredient(ModContent.ItemType<BronzeOre>())
            .AddIngredient(ItemID.StoneBlock)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzeBar>())
            .AddIngredient(ModContent.ItemType<BronzeOre>(), 3)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzePickaxe>())
            .AddIngredient(ModContent.ItemType<BronzeBar>(), 12)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzeAxe>())
            .AddIngredient(ModContent.ItemType<BronzeBar>(), 9)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzeHammer>())
            .AddIngredient(ModContent.ItemType<BronzeBar>(), 10)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzeBroadsword>())
            .AddIngredient(ModContent.ItemType<BronzeBar>(), 8)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzeShortsword>())
            .AddIngredient(ModContent.ItemType<BronzeBar>(), 7)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzeBow>())
            .AddIngredient(ModContent.ItemType<BronzeBar>(), 7)
            .AddTile(TileID.Anvils).Register();

        // staff
        // end bronze stuff

        // Nickel
        mod.CreateRecipe(ModContent.ItemType<NickelBrick>())
            .AddIngredient(ModContent.ItemType<NickelOre>())
            .AddIngredient(ItemID.StoneBlock)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelDoor>())
            .AddIngredient(ModContent.ItemType<NickelBar>(), 6)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelAnvil>())
            .AddIngredient(ModContent.ItemType<NickelBar>(), 5)
            .AddTile(TileID.WorkBenches).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelBar>())
            .AddIngredient(ModContent.ItemType<NickelOre>(), 3)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelPickaxe>())
            .AddIngredient(ModContent.ItemType<NickelBar>(), 12)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelAxe>())
            .AddIngredient(ModContent.ItemType<NickelBar>(), 9)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelHammer>())
            .AddIngredient(ModContent.ItemType<NickelBar>(), 10)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelBroadsword>())
            .AddIngredient(ModContent.ItemType<NickelBar>(), 8)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelShortsword>())
            .AddIngredient(ModContent.ItemType<NickelBar>(), 7)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelBow>())
            .AddIngredient(ModContent.ItemType<NickelBar>(), 7)
            .AddTile(TileID.Anvils).Register();

        // staff
        // end Nickel stuff

        // Zinc
        mod.CreateRecipe(ModContent.ItemType<ZincBrick>())
            .AddIngredient(ModContent.ItemType<ZincOre>())
            .AddIngredient(ItemID.StoneBlock)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincBar>())
            .AddIngredient(ModContent.ItemType<ZincOre>(), 4)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincPickaxe>())
            .AddIngredient(ModContent.ItemType<ZincBar>(), 12)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincAxe>())
            .AddIngredient(ModContent.ItemType<ZincBar>(), 9)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincHammer>())
            .AddIngredient(ModContent.ItemType<ZincBar>(), 10)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincBroadsword>())
            .AddIngredient(ModContent.ItemType<ZincBar>(), 8)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincShortsword>())
            .AddIngredient(ModContent.ItemType<ZincBar>(), 6)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincBow>())
            .AddIngredient(ModContent.ItemType<ZincBar>(), 7)
            .AddTile(TileID.Anvils).Register();

        // staff
        // end Zinc stuff

        // Bismuth
        mod.CreateRecipe(ModContent.ItemType<BismuthBrick>())
            .AddIngredient(ModContent.ItemType<BismuthOre>())
            .AddIngredient(ItemID.StoneBlock)
            .AddTile(TileID.Furnaces).Register();

        // staff


        // end Bismuth stuff

        // Iridium
        mod.CreateRecipe(ModContent.ItemType<IridiumBrick>())
            .AddIngredient(ModContent.ItemType<IridiumOre>())
            .AddIngredient(ItemID.StoneBlock)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<IridiumBar>())
            .AddIngredient(ModContent.ItemType<IridiumOre>(), 4)
            .AddTile(TileID.Furnaces).Register();

        mod.CreateRecipe(ModContent.ItemType<IridiumPickaxe>())
            .AddIngredient(ModContent.ItemType<IridiumBar>(), 13)
            .AddIngredient(ModContent.ItemType<DesertFeather>(), 2)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<IridiumHamaxe>())
            .AddIngredient(ModContent.ItemType<IridiumBar>(), 12)
            .AddIngredient(ModContent.ItemType<DesertFeather>())
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<IridiumGreatsword>())
            .AddIngredient(ModContent.ItemType<IridiumBar>(), 14)
            .AddIngredient(ModContent.ItemType<DesertFeather>(), 3)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<IridiumLongbow>())
            .AddIngredient(ModContent.ItemType<IridiumBar>(), 13)
            .AddIngredient(ModContent.ItemType<DesertFeather>(), 2)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<IridiumHat>())
            .AddIngredient(ModContent.ItemType<IridiumBar>(), 15)
            .AddIngredient(ModContent.ItemType<DesertFeather>(), 4)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<IridiumPlateMail>())
            .AddIngredient(ModContent.ItemType<IridiumBar>(), 20)
            .AddIngredient(ModContent.ItemType<DesertFeather>(), 6)
            .AddTile(TileID.Anvils).Register();

        mod.CreateRecipe(ModContent.ItemType<IridiumPants>())
            .AddIngredient(ModContent.ItemType<IridiumBar>(), 17)
            .AddIngredient(ModContent.ItemType<DesertFeather>(), 5)
            .AddTile(TileID.Anvils).Register();
        // end Iridium stuff

        #region catalyzer

        // catalyzer stuff
        // catalyzer 
        mod.CreateRecipe(ModContent.ItemType<Catalyzer>())
            .AddRecipeGroup(RecipeGroupID.Wood, 20)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 30)
            .AddRecipeGroup("IronBar", 15)
            .AddRecipeGroup("ExxoAvalonOrigins:WorkBenches")
            .AddTile(TileID.Anvils).Register();

        //start stone types
        mod.CreateRecipe(ItemID.EbonstoneBlock, 50)
            .AddIngredient(ItemID.PearlstoneBlock, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.CrimstoneBlock, 50)
            .AddIngredient(ItemID.EbonstoneBlock, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<ChunkstoneBlock>(), 50)
            .AddIngredient(ItemID.CrimstoneBlock, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.PearlstoneBlock, 50)
            .AddIngredient(ModContent.ItemType<ChunkstoneBlock>(), 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();
        //end stone types
        //start wood
        mod.CreateRecipe(ItemID.Wood, 50)
            .AddIngredient(ModContent.ItemType<DarkMatterWood>(), 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.Ebonwood, 50)
            .AddRecipeGroup("Wood", 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.Shadewood, 50)
            .AddIngredient(ItemID.Ebonwood, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<Coughwood>(), 50)
            .AddIngredient(ItemID.Shadewood, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.Pearlwood, 50)
            .AddIngredient(ModContent.ItemType<Coughwood>(), 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.BorealWood, 50)
            .AddIngredient(ItemID.Pearlwood, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.PalmWood, 50)
            .AddIngredient(ItemID.BorealWood, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.RichMahogany, 50)
            .AddIngredient(ItemID.PalmWood, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<TropicalWood>(), 50)
            .AddIngredient(ItemID.RichMahogany, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<DarkMatterWood>(), 50)
            .AddIngredient(ModContent.ItemType<TropicalWood>(), 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();
        //end wood
        //evil ores
        mod.CreateRecipe(ItemID.DemoniteOre, 40)
            .AddIngredient(ModContent.ItemType<BacciliteOre>(), 40)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.CrimtaneOre, 40)
            .AddIngredient(ItemID.DemoniteOre, 40)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BacciliteOre>(), 40)
            .AddIngredient(ItemID.CrimtaneOre, 40)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();
        //end evil ores
        //hardmode ores
        mod.CreateRecipe(ItemID.CobaltOre, 20)
            .AddIngredient(ModContent.ItemType<DurataniumOre>(), 20)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.PalladiumOre, 20)
            .AddIngredient(ItemID.CobaltOre, 20)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumOre>(), 20)
            .AddIngredient(ItemID.PalladiumOre, 20)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.MythrilOre, 20)
            .AddIngredient(ModContent.ItemType<NaquadahOre>(), 20)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.OrichalcumOre, 20)
            .AddIngredient(ItemID.MythrilOre, 20)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahOre>(), 20)
            .AddIngredient(ItemID.OrichalcumOre, 20)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.AdamantiteOre, 10)
            .AddIngredient(ModContent.ItemType<TroxiniumOre>(), 10)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.TitaniumOre, 10)
            .AddIngredient(ItemID.AdamantiteOre, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumOre>(), 10)
            .AddIngredient(ItemID.TitaniumOre, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();
        //end hardmode ores
        //evil bars
        mod.CreateRecipe(ItemID.DemoniteBar, 10)
            .AddIngredient(ModContent.ItemType<BacciliteBar>(), 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.CrimtaneBar, 10)
            .AddIngredient(ItemID.DemoniteBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BacciliteBar>(), 10)
            .AddIngredient(ItemID.CrimtaneBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();
        //end evil bars

        //phm ores
        mod.CreateRecipe(ItemID.CopperOre, 30)
            .AddIngredient(ModContent.ItemType<BronzeOre>(), 30)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.TinOre, 30)
            .AddIngredient(ItemID.CopperOre, 30)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzeOre>(), 30)
            .AddIngredient(ItemID.TinOre, 30)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.IronOre, 30)
            .AddIngredient(ModContent.ItemType<NickelOre>(), 30)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.LeadOre, 30)
            .AddIngredient(ItemID.IronOre, 30)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelOre>(), 30)
            .AddIngredient(ItemID.LeadOre, 30)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.SilverOre, 40)
            .AddIngredient(ModContent.ItemType<ZincOre>(), 40)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.TungstenOre, 40)
            .AddIngredient(ItemID.SilverOre, 40)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincOre>(), 40)
            .AddIngredient(ItemID.TungstenOre, 40)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.GoldOre, 40)
            .AddIngredient(ModContent.ItemType<BismuthOre>(), 40)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.PlatinumOre, 40)
            .AddIngredient(ItemID.GoldOre, 40)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BismuthOre>(), 40)
            .AddIngredient(ItemID.PlatinumOre, 40)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();
        //end phm ores

        //phm bars
        mod.CreateRecipe(ItemID.CopperBar, 10)
            .AddIngredient(ModContent.ItemType<BronzeBar>(), 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.TinBar, 10)
            .AddIngredient(ItemID.CopperBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BronzeBar>(), 10)
            .AddIngredient(ItemID.TinBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.IronBar, 10)
            .AddIngredient(ModContent.ItemType<NickelBar>(), 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.LeadBar, 10)
            .AddRecipeGroup("IronBar", 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<NickelBar>(), 10)
            .AddIngredient(ItemID.LeadBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.SilverBar, 10)
            .AddIngredient(ModContent.ItemType<ZincBar>(), 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.TungstenBar, 10)
            .AddIngredient(ItemID.SilverBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<ZincBar>(), 10)
            .AddIngredient(ItemID.TungstenBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.GoldBar, 10)
            .AddIngredient(ModContent.ItemType<BismuthBar>(), 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.PlatinumBar, 10)
            .AddIngredient(ItemID.GoldBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<BismuthBar>(), 10)
            .AddIngredient(ItemID.PlatinumBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();
        //end phm bars

        //hardmode ore bars
        mod.CreateRecipe(ItemID.CobaltBar, 10)
            .AddIngredient(ModContent.ItemType<DurataniumBar>(), 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.PalladiumBar, 10)
            .AddIngredient(ItemID.CobaltBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<DurataniumBar>(), 10)
            .AddIngredient(ItemID.PalladiumBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.MythrilBar, 10)
            .AddIngredient(ModContent.ItemType<NaquadahBar>(), 10)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.OrichalcumBar, 10)
            .AddIngredient(ItemID.MythrilBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<NaquadahBar>(), 10)
            .AddIngredient(ItemID.OrichalcumBar, 10)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.AdamantiteBar, 5)
            .AddIngredient(ModContent.ItemType<TroxiniumBar>(), 5)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.TitaniumBar, 5)
            .AddIngredient(ItemID.AdamantiteBar, 5)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<TroxiniumBar>(), 5)
            .AddIngredient(ItemID.TitaniumBar, 5)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 2)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();
        //end hardmode ore bars
        //evil boss materials
        mod.CreateRecipe(ItemID.ShadowScale, 3)
            .AddIngredient(ModContent.ItemType<Booger>(), 3)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.TissueSample, 3)
            .AddIngredient(ItemID.ShadowScale, 3)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<Booger>(), 3)
            .AddIngredient(ItemID.TissueSample, 3)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();
        //end evil boss materials

        mod.CreateRecipe(ItemID.CursedFlame, 33)
            .AddIngredient(ModContent.ItemType<Pathogen>(), 33)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.Ichor, 33)
            .AddIngredient(ItemID.CursedFlame, 33)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<Pathogen>(), 33)
            .AddIngredient(ItemID.Ichor, 33)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.RottenChunk, 50)
            .AddIngredient(ModContent.ItemType<YuckyBit>(), 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.Vertebrae, 50)
            .AddIngredient(ItemID.RottenChunk, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<YuckyBit>(), 50)
            .AddIngredient(ItemID.Vertebrae, 50)
            .AddIngredient(ModContent.ItemType<Sulphur>())
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.GreenSolution, 100)
            .AddIngredient(ModContent.ItemType<LimeGreenSolution>(), 100)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 10)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.PurpleSolution, 100)
            .AddIngredient(ItemID.GreenSolution, 100)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 10)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.RedSolution, 100)
            .AddIngredient(ItemID.PurpleSolution, 100)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 10)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<YellowSolution>(), 100)
            .AddIngredient(ItemID.RedSolution, 100)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 10)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.BlueSolution, 100)
            .AddIngredient(ModContent.ItemType<YellowSolution>(), 100)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 10)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ItemID.DarkBlueSolution, 100)
            .AddIngredient(ItemID.BlueSolution, 100)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 10)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        mod.CreateRecipe(ModContent.ItemType<LimeGreenSolution>(), 100)
            .AddIngredient(ItemID.DarkBlueSolution, 100)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 10)
            .AddTile(ModContent.TileType<Tiles.Catalyzer>()).Register();

        #endregion catalyzer

        mod.CreateRecipe(ModContent.ItemType<TropicalBlade>())
            .AddIngredient(ModContent.ItemType<TropicalShroomCap>(), 12)
            .AddIngredient(ModContent.ItemType<MosquitoProboscis>(), 12)
            .AddTile(TileID.Anvils).Register();
    }
}
